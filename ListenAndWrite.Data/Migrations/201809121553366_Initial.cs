namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AudioTitle = c.String(nullable: false, maxLength: 256),
                        Path = c.String(nullable: false, maxLength: 256),
                        Level = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AudioId = c.Int(nullable: false),
                        AudioScore = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audios", t => t.AudioId, cascadeDelete: true)
                .Index(t => t.AudioId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AudioId = c.Int(nullable: false),
                        TrackTitle = c.String(nullable: false, maxLength: 256),
                        Answer = c.String(nullable: false, maxLength: 256),
                        TimeStart = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audios", t => t.AudioId, cascadeDelete: true)
                .Index(t => t.AudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.Scores", "AudioId", "dbo.Audios");
            DropIndex("dbo.Tracks", new[] { "AudioId" });
            DropIndex("dbo.Scores", new[] { "AudioId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Scores");
            DropTable("dbo.Audios");
        }
    }
}
