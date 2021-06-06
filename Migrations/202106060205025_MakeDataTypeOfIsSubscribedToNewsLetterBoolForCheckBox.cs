namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDataTypeOfIsSubscribedToNewsLetterBoolForCheckBox : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customeers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customeers", "IsSubscribedToNewsLetter", c => c.Byte(nullable: false));
        }
    }
}
