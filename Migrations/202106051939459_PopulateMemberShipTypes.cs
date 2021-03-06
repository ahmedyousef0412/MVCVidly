namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MemberShipTypes ON");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonth,DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonth,DiscountRate) VALUES(2,30,1,10)");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonth,DiscountRate) VALUES(3,90,3,15)");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonth,DiscountRate) VALUES(4,300,12,25)");
            Sql("SET IDENTITY_INSERT MemberShipTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
