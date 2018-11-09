namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTrack_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "Order", c => c.Int(nullable: false));
            DropColumn("dbo.Tracks", "TrackTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "TrackTitle", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Tracks", "Order");
        }
    }
}
