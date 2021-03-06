﻿namespace NetPhlixDB.Data.Models
{
    public class MoviePerson
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
