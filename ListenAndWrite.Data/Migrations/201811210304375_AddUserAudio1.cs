namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAudio1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAudios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AudioTitle = c.String(nullable: false, maxLength: 256),
                        Path = c.String(nullable: false, maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAudios");
        }
    }
}
