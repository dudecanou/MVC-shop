using MVC_miSessionHA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_miSessionHA.DAL
{
    public class initialisationProduits : DropCreateDatabaseAlways<produitModel>
    {
        public override void InitializeDatabase(produitModel context)
        {
           context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",context.Database.Connection.Database));
            //base.InitializeDatabase(context);
        }
        protected override void Seed(produitModel context)
        {

            var Marques = new List<Marque>
                    {
                new Marque {Nom="Almost Skateboards",   Pays="Etats-Unis" },
                new Marque {Nom="Birdhouse",            Pays="Etats-Unis" },
                new Marque {Nom="Cliche Skateboards",   Pays="France" },
                new Marque {Nom="Girl Skateboards",     Pays="Etats-Unis" },
                new Marque {Nom="Element ",             Pays="Etats-Unis" },

                };

            Marques.ForEach(s => context.Marques.Add(s));
            context.SaveChanges();

            var Skateboards = new List<Skateboard>
            {
                new Skateboard {Style="Street-Skateboard",  Image="goo.gl/UXncPl",MarqueID=1},
                new Skateboard {Style="Pipe-Skateboard",    Image="goo.gl/E5TWMt",MarqueID=2},
                new Skateboard {Style="Cruiser",            Image="goo.gl/iEAwBZ",MarqueID=3},
                new Skateboard {Style="Longboard",          Image="goo.gl/ygbLGk",MarqueID=4},
                new Skateboard {Style="Vintage-Skateboard", Image="goo.gl/NdhFoL",MarqueID=5},

                };
            Skateboards.ForEach(s => context.Skateboards.Add(s));
            context.SaveChanges();



            var Accessoires = new List<Accessoire>
            {
                new Accessoire {SkateboardID=1,NomAcc="Venture",        Type="Truck",   Prix=75 },
                new Accessoire {SkateboardID=2,NomAcc="Bones-Brigade",  Type="Wheels",  Prix=60 },
                new Accessoire {SkateboardID=3,NomAcc="Andale",         Type="Bearings",Prix=40 },
                new Accessoire {SkateboardID=4,NomAcc="Shorty's",       Type="Hardware",Prix=5 },
                new Accessoire {SkateboardID=5,NomAcc="Independent",    Type="Bushing", Prix=7 },

            };
            Accessoires.ForEach(s => context.Accessoires.Add(s));
            context.SaveChanges();



        }
    }
}