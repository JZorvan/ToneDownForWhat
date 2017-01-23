namespace ToneDownThatBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "Anger", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Disgust", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Fear", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Joy", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Sadness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Openness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Conscientiousness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Extraversion", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "Agreeableness", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "EmotionalRange", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "EmotionalRange", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Agreeableness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Extraversion", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Conscientiousness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Openness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Sadness", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Joy", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Fear", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Disgust", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "Anger", c => c.Double(nullable: false));
        }
    }
}
