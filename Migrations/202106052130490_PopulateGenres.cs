namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (2,'Thriller')");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (3,'Family')");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (4,'Romance')");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (5,'Action')");

            Sql("SET IDENTITY_INSERT Genres ON");


        }
        
        public override void Down()
        {
        }
    }
}
