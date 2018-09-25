namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyNumTrackField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Audios", "NumTrack", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Audios", "NumTrack", c => c.Int(nullable: false));
        }
    }
}
