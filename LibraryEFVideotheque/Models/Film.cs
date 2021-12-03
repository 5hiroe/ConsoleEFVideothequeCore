using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Film
    {
        public Film()
        {
            Notations = new HashSet<Notation>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public int Annee { get; set; }
        public int? IdRealisateur { get; set; }
        public int IdGenre { get; set; }
        public string Resume { get; set; }
        public string CodePays { get; set; }

        public virtual Genre IdGenreNavigation { get; set; }
        public virtual Artiste IdRealisateurNavigation { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
