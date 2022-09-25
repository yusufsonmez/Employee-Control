namespace CompanyEmployees.Migrations
{
    using CompanyEmployees.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }

        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
