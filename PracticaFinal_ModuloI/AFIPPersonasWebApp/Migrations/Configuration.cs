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
                        Codigo = 004355
                    },
                    new Models.CodActividad()
                    {
                        ID = 2,
                        Descripcion = "Fabricación",
                        Codigo = 001322
                    },
                    new Models.CodActividad()
                    {
                        ID = 3,
                        Descripcion = "Investigacion",
                        Codigo = 001100
                    }
                    );
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
