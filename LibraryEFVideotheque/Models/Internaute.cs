using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class Internaute
    {
        public Internaute()
        {
            Notations = new HashSet<Notation>();
        }

        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Region { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Roles { get; set; }

        public virtual ICollection<Notation> Notations { get; set; }
    }
}
