namespace AFIPPersonasWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AFIPPersonasWebApp.Data.AFIPPersonasWebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AFIPPersonasWebApp.Data.AFIPPersonasWebAppContext";
        }

        protected override void Seed(AFIPPersonasWebApp.Data.AFIPPersonasWebAppContext context)
        {
            //  This method will be called after migrating to the latest version.
            try
            {
                context.CodActividads.AddOrUpdate(c => c.ID,
                    new Models.CodActividad()
                    {
                        ID = 1,
                        Descripcion = "Docencia",
                        Codigo = "4355"
                    },
                    new Models.CodActividad()
                    {
                        ID = 2,
                        Descripcion = "Fabricación",
                        Codigo = "1322"
                    },
                    new Models.CodActividad()
                    {
                        ID = 3,
                        Descripcion = "Investigacion",
                        Codigo = "1100"
                    }
                    );
                context.Personas.AddOrUpdate(c => c.ID,
                    new Models.Persona()
                    {
                        ID=1,
                        CodActividadId=1,
                        ClaveTributaria= "20292666557",
                    },
                    new Models.Persona()
                    {
                        ID = 2,
                        CodActividadId = 1,
                        ClaveTributaria = "27302353876",
                    },
                    new Models.Persona()
                    {
                        ID = 3,
                        CodActividadId = 2,
                        ClaveTributaria = "20005344565",
                    },
                    new Models.Persona()
                    {
                        ID = 4,
                        CodActividadId = 2,
                        ClaveTributaria = "20276378751",
                    },
                    new Models.Persona()
                    {
                        ID = 5,
                        CodActividadId = 1,
                        ClaveTributaria = "27303224561",
                    },
                    new Models.Persona()
                    {
                        ID = 6,
                        CodActividadId = 1,
                        ClaveTributaria = "20294366764",
                    },
                    new Models.Persona()
                    {
                        ID = 7,
                        CodActividadId = 3,
                        ClaveTributaria = "20142398258",
                    });
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
