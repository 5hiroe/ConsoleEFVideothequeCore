using LibraryEFVideotheque.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryEFVideotheque
{
    public static class FilmExtension
    {
        public static void Description(this Film film)
        {
            Console.WriteLine("{0} sortit en {1}, réalisé par {2}", film.Titre, film.Annee, film.IdRealisateurNavigation.Nom);
        }
    }
}
