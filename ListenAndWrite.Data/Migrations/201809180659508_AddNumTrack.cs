namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumTrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audios", "NumTrack", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audios", "NumTrack");
        }
    }
}
