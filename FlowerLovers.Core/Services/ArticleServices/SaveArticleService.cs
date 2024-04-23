﻿using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class SaveArticleService : ISaveArticleService
    {
        private readonly FlowerLoversDbContext data;

        public SaveArticleService(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task SaveArticle(int articleId, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var articleToSave = await data
                .Articles
                .FindAsync(articleId);

            if (articleToSave == null)
            {
                throw new ArticleNullException(nameof(articleToSave));
            }

            var user = await data
                .Users
                .FindAsync(userId);

            if (user == null)
            {
                throw new UserNullException(nameof(user));
            }

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(nameof(userAccount));
            }

            var articleParticipant = new ArticleParticipant()
            {
                ArticleId = articleId,
                Article = articleToSave,
                UserAccountId = userAccount.Id,
                UserAccount = userAccount
            };

            if (!await data.ArticlesParticipants.ContainsAsync(articleParticipant))
            {
                await data.ArticlesParticipants.AddAsync(articleParticipant);
                await data.SaveChangesAsync();
            }
        }
    }
}