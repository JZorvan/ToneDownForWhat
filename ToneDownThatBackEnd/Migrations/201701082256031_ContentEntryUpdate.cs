namespace ToneDownThatBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentEntryUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Entries", name: "UserId_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Entries", name: "IX_UserId_Id", newName: "IX_User_Id");
            AddColumn("dbo.Entries", "Content", c => c.String());
            AlterColumn("dbo.Entries", "Anger", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Disgust", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Fear", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Joy", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Sadness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Openness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Conscientiousness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Extraversion", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Agreeableness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "EmotionalRange", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "EmotionalRange", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Agreeableness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Extraversion", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Conscientiousness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Openness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Sadness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Joy", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Fear", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Disgust", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Anger", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "Content");
            RenameIndex(table: "dbo.Entries", name: "IX_User_Id", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Entries", name: "User_Id", newName: "UserId_Id");
        }
    }
}
