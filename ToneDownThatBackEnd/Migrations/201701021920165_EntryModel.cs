namespace ToneDownThatBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        EntryAuthor = c.String(),
                        EntryName = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Format = c.String(),
                        Context = c.String(),
                        Anger = c.Int(nullable: false),
                        Disgust = c.Int(nullable: false),
                        Fear = c.Int(nullable: false),
                        Joy = c.Int(nullable: false),
                        Sadness = c.Int(nullable: false),
                        Openness = c.Int(nullable: false),
                        Conscientiousness = c.Int(nullable: false),
                        Extraversion = c.Int(nullable: false),
                        Agreeableness = c.Int(nullable: false),
                        EmotionalRange = c.Int(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "UserId_Id" });
            DropTable("dbo.Entries");
        }
    }
}
