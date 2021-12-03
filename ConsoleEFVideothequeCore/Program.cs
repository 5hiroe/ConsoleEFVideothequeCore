using System;
using System.Collections.Generic;
using System.Linq;


using LibraryEFVideotheque;
using LibraryEFVideotheque.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFVideothequeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*GestionFilms gestionFilms = new GestionFilms();
            List<Film> liste = gestionFilms.ChargerFilms();
            AfficherFilm(liste);*/

            videothequeContext context = new videothequeContext();
            Console.WriteLine("\nListe tous les films");
            var liste = context.Films.Include(f => f.IdRealisateurNavigation).AsQueryable();
            AfficherFilm(liste.ToList());
        }

        static void AfficherFilm(List<Film> liste)
        {
            foreach (var film in liste)
            {
                film.Description();
            }
        }
    }
}
