using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class PersonalDataService : PageModel, IPersonalDataService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FlowerLoversDbContext data;

        public PersonalDataService(UserManager<ApplicationUser> userManager,
            FlowerLoversDbContext _data)
        {
            _userManager = userManager;
            data = _data;
        }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount != null)
            {
                var articles = data
                    .Articles
                    .Where(a => a.UserAccountId == userAccount.Id)
                    .ToList();

                if (articles.Count() == 0)
                {
                    articles = null;
                }

                if (articles != null)
                {
                    foreach (var article in articles)
                    {
                        //Take every possible rate of the current article.
                        var rates = data
                        .Rates
                        .Where(r => r.ArticleId == article.Id)
                        .ToList();

                        if (rates.Count() == 0)
                        {
                            rates = null;
                        }

                        if (rates != null)
                        {
                            // Remove every rate from the current article.
                            data
                                .Rates
                                .RemoveRange(rates);

                            // Reseed row's id after the removal of these rates.
                            await ReseedRatesTable();
                        }


                        // Create an articleParticipant to remove later.
                        var articleParticipant = new ArticleParticipant()
                        {
                            ArticleId = article.Id,
                            UserAccountId = userAccount.Id,
                        };

                        if (await data.ArticlesParticipants.ContainsAsync(articleParticipant))
                        {
                            //Remove every articles participants from ArticlesParticipants table.
                            data
                                .ArticlesParticipants
                                .Remove(articleParticipant);
                        }
                    }

                    //Remove every article from Articles table
                    data
                        .Articles
                        .RemoveRange(articles);

                    //Reseed row id after the removal of these articles.
                    await ReseedArticleTable();
                }

                //Reseed row id after the removal of the user account.
                await ReseedUserAccountTable();

                // Remove the user account from UserAccounts table. 
                data
                    .UserAccounts
                    .Remove(userAccount);

                await data.SaveChangesAsync();
            }


            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            return Page();
        }

        private async Task ReseedRatesTable()
        {
            if (await data.Rates.CountAsync() == 0)
            {
                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('Rates', RESEED, 0)");
            }
            else
            {
                var lastRate = await data
                    .Rates
                    .OrderBy(r => r.Id)
                    .LastAsync();

                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('Rates', RESEED, {lastRate.Id})");
            }
        }

        private async Task ReseedArticleTable()
        {
            if (await data.Articles.CountAsync() == 0)
            {
                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('Articles', RESEED, 0)");
            }
            else
            {
                var lastArticle = await data
                    .Articles
                    .OrderBy(a => a.Id)
                    .LastAsync();

                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('Articles', RESEED, {lastArticle.Id})");
            }
        }

        private async Task ReseedUserAccountTable()
        {
            if (await data.UserAccounts.CountAsync() == 1)
            {
                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('UserAccounts', RESEED, 0)");
            }
            else
            {
                var lastUserAccount = await data
                    .UserAccounts
                    .OrderBy(ua => ua.Id)
                    .LastAsync();

                await data
                    .Database
                    .ExecuteSqlRawAsync($"DBCC CHECKIDENT ('UserAccounts', RESEED, {lastUserAccount.Id})");
            }
        }
    }
}
