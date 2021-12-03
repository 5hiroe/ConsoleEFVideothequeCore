using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Notation
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public string Email { get; set; }
        public int Note { get; set; }

        public virtual Internaute EmailNavigation { get; set; }
        public virtual Film IdFilmNavigation { get; set; }
    }
}
