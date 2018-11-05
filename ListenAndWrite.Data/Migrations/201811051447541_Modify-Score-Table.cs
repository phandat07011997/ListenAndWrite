namespace ListenAndWrite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyScoreTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "UserId", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "UserId");
        }
    }
}
