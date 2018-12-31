﻿namespace NetPhlixDB.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.Watchlist = new List<Movie>();
            this.Reviews = new List<Review>();
            this.Articles = new List<Article>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public DateTime? BirthDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<Movie> Watchlist { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}