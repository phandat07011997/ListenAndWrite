namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyScore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Scores", "AudioScore", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scores", "AudioScore", c => c.Int(nullable: false));
        }
    }
}
