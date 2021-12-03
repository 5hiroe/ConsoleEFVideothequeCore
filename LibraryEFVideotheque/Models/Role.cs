using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public int IdActeur { get; set; }
        public string Role1 { get; set; }

        public virtual Artiste IdActeurNavigation { get; set; }
        public virtual Film IdFilmNavigation { get; set; }
    }
}
