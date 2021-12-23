namespace Lab6KPZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drugs", "Price", c => c.Double(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drugs", "Price");
        }
    }
}
