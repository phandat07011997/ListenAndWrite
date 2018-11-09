namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTrack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "TimeStart", c => c.Single(nullable: false));
            AlterColumn("dbo.Tracks", "Duration", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "TimeStart", c => c.Int(nullable: false));
        }
    }
}
