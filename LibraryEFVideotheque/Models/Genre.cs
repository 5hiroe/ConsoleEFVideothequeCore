using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
