using LibraryEFVideotheque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryEFVideotheque
{
    public class GestionFilms
    {
        private videothequeContext model = new videothequeContext();

        public List<Film> ChargerFilms()
        {
            return model.Films.Include(a => a.IdRealisateurNavigation).ToList();
        }

        public Film AjouterFilm(Film film)
        {
            // Ajoute le produit à l'ORM EF
            model.Films.Add(film);
            // Valide les changement dans la base de données
            if (model.SaveChanges() > 0)
                return film;
            return null;
        }

        public Film RechercherFilm(int id)
        {
            return model.Films.Find(id);
        }

        public List<Film> RechercherFilmTitre(string titre)
        {
            var liste = model.Films.Where(p => p.Titre.StartsWith(titre));
            return liste.ToList();
        }

        public bool ModifierFilm(Film film)
        {
            // Mettre le statut de l'entité à "Modifiée" dans l'ORM
            model.Entry(film).State = EntityState.Modified;
            // Valide les changements dans la base de données
            return (model.SaveChanges() > 0);
        }

        public bool SupprimerFilm(int id)
        {
            Film p = RechercherFilm(id);
            if (p == null)
                return false;
            return SupprimerFilm(p);
        }
        public bool SupprimerFilm(Film produit)
        {
            if (produit != null)
            {
                // Supprime le produit dans l'ORM
                model.Films.Remove(produit);
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }
            return false;
        }
    }
}
