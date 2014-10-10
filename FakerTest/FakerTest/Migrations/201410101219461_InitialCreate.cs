namespace FakerTest.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        HomePhone = c.String(),
                        WorkPhone = c.String(),
                        MobilePhone = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Locations", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Phones", new[] { "Person_PersonId" });
            DropIndex("dbo.Locations", new[] { "Person_PersonId" });
            DropTable("dbo.Phones");
            DropTable("dbo.People");
            DropTable("dbo.Locations");
        }
    }
}
