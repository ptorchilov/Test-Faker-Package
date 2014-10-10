namespace FakerTest.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "CompanyName");
        }
    }
}
