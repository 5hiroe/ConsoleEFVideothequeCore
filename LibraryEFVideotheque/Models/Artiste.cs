using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Artiste
    {
        public Artiste()
        {
            Films = new HashSet<Film>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? AnneeNaissance { get; set; }

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
