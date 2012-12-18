using System.Data.Entity;

namespace MVC4TestBed.Models
{
    public class MVC4TestBedContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MVC4TestBed.Models.MVC4TestBedContext>());

        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<Genre> Genres { get; set; }

        public DbSet<MVC4TestBed.Models.Movie> Movies { get; set; }
    }
}