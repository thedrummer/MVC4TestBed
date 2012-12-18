namespace MVC4TestBed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 20),
                        IsArchived = c.Boolean(nullable: false),
                        ArchivedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(nullable: false, maxLength: 100),
                        Year = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        ArchivedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.UserProfile");
        }
    }
}
