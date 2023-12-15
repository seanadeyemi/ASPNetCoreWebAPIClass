﻿using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPIClass.Domain.Models.Database
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public virtual List<BannerImage> BannerImages { get; set; }

    }
}
