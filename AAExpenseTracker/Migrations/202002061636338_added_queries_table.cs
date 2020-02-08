namespace AAExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_queries_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Statement = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Queries");
        }
    }
}
