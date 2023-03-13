using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Kassim_Co.Data;
using System;
using System.Linq;
using API_Kassim_Co.Models;

namespace API_BDTN.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new API_Kassim_CoContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<API_Kassim_CoContext>>()))
        {
            context.Database.EnsureCreated();

            // S’il y a déjà des films dans la base
            if (!context.Population.Any())
            {
                context.Population.AddRange(
                new Population
                {
                    Nom = "francais",
                    Pop = 68000000
                }
                );
            }
           //


            if (!context.Continent.Any())
            {
                context.Continent.AddRange(
                new Continent
                {
                    Nom = "Europe",
                    paysList = new List<Pays> {
                    new Pays { Nom = "Allemagne",
                               pop = new Population { Nom = "allemande", Pop = 80000000} } }
                }
                );
            }

            // S’il y a déjà des films dans la base
            if (!context.Pays.Any())
            {
                context.Pays.AddRange(
                new Pays
                {
                    Nom = "France",
                    pop = new Population
                    {
                        Nom = "francais",
                        Pop = 68000000
                    }
                }
                );
            }
            // Sinon on en ajoute un



            context.SaveChanges();
        }
    }
}