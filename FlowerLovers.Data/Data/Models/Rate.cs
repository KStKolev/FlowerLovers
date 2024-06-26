﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerLovers.Data.Data.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Account ID")]
        public int UserAccountId { get; set; }
        [ForeignKey(nameof(UserAccountId))]
        public UserAccount UserAccount { get; set; } = null!;

        [Required]
        [Display(Name = "Article ID")]
        public int ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; } = null!;

        [Required]
        public double Rating { get; set; }
    }
}
