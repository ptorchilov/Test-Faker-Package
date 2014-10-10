namespace FakerTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDisplayName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "DisplayName", newName: "display-name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "display-name", newName: "DisplayName");
        }
    }
}
