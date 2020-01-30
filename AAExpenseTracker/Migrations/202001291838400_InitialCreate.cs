namespace AAExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AlarmType = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        Message = c.String(),
                        Active = c.Boolean(nullable: false),
                        User_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.ExpenseTags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Alarm_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alarms", t => t.Alarm_ID)
                .Index(t => t.Alarm_ID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Concept = c.String(),
                        Amount = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        SaltedHash = c.String(maxLength: 128),
                        Salt = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.FixExpens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Concept = c.String(),
                        Amount = c.Single(nullable: false),
                        User_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.FixIncoms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Concept = c.String(),
                        Amount = c.Single(nullable: false),
                        User_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Concept = c.String(),
                        Amount = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.IncomeTags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExpenseExpenseTags",
                c => new
                    {
                        Expense_ID = c.Int(nullable: false),
                        ExpenseTag_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Expense_ID, t.ExpenseTag_ID })
                .ForeignKey("dbo.Expenses", t => t.Expense_ID, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseTags", t => t.ExpenseTag_ID, cascadeDelete: true)
                .Index(t => t.Expense_ID)
                .Index(t => t.ExpenseTag_ID);
            
            CreateTable(
                "dbo.IncomeTagIncomes",
                c => new
                    {
                        IncomeTag_ID = c.String(nullable: false, maxLength: 128),
                        Income_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IncomeTag_ID, t.Income_ID })
                .ForeignKey("dbo.IncomeTags", t => t.IncomeTag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Incomes", t => t.Income_ID, cascadeDelete: true)
                .Index(t => t.IncomeTag_ID)
                .Index(t => t.Income_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.IncomeTagIncomes", "Income_ID", "dbo.Incomes");
            DropForeignKey("dbo.IncomeTagIncomes", "IncomeTag_ID", "dbo.IncomeTags");
            DropForeignKey("dbo.FixIncoms", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.FixExpens", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Expenses", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Alarms", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.ExpenseTags", "Alarm_ID", "dbo.Alarms");
            DropForeignKey("dbo.ExpenseExpenseTags", "ExpenseTag_ID", "dbo.ExpenseTags");
            DropForeignKey("dbo.ExpenseExpenseTags", "Expense_ID", "dbo.Expenses");
            DropIndex("dbo.IncomeTagIncomes", new[] { "Income_ID" });
            DropIndex("dbo.IncomeTagIncomes", new[] { "IncomeTag_ID" });
            DropIndex("dbo.ExpenseExpenseTags", new[] { "ExpenseTag_ID" });
            DropIndex("dbo.ExpenseExpenseTags", new[] { "Expense_ID" });
            DropIndex("dbo.Incomes", new[] { "User_UserID" });
            DropIndex("dbo.FixIncoms", new[] { "User_UserID" });
            DropIndex("dbo.FixExpens", new[] { "User_UserID" });
            DropIndex("dbo.Expenses", new[] { "User_UserID" });
            DropIndex("dbo.ExpenseTags", new[] { "Alarm_ID" });
            DropIndex("dbo.Alarms", new[] { "User_UserID" });
            DropTable("dbo.IncomeTagIncomes");
            DropTable("dbo.ExpenseExpenseTags");
            DropTable("dbo.IncomeTags");
            DropTable("dbo.Incomes");
            DropTable("dbo.FixIncoms");
            DropTable("dbo.FixExpens");
            DropTable("dbo.Users");
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseTags");
            DropTable("dbo.Alarms");
        }
    }
}
