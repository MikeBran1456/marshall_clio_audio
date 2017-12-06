namespace marshall_clio_audio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Audio_auth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioFiles", "userID", c => c.Int(nullable: false));
            AddColumn("dbo.AudioFiles", "Verified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AudioFiles", "Verified");
            DropColumn("dbo.AudioFiles", "userID");
        }
    }
}
