namespace AAExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class single_tag_alarms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseTags", "Alarm_ID", "dbo.Alarms");
            DropIndex("dbo.ExpenseTags", new[] { "Alarm_ID" });
            AddColumn("dbo.Alarms", "Tag_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Alarms", "Tag_ID");
            AddForeignKey("dbo.Alarms", "Tag_ID", "dbo.ExpenseTags", "ID");
            DropColumn("dbo.ExpenseTags", "Alarm_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseTags", "Alarm_ID", c => c.Int());
            DropForeignKey("dbo.Alarms", "Tag_ID", "dbo.ExpenseTags");
            DropIndex("dbo.Alarms", new[] { "Tag_ID" });
            DropColumn("dbo.Alarms", "Tag_ID");
            CreateIndex("dbo.ExpenseTags", "Alarm_ID");
            AddForeignKey("dbo.ExpenseTags", "Alarm_ID", "dbo.Alarms", "ID");
        }
    }
}
