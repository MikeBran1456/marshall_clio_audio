namespace marshall_clio_audio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_id_String : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.AudioFiles DROP CONSTRAINT DF__AudioFile__userI__0EA330E9");
            AlterColumn("dbo.AudioFiles", "userID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AudioFiles", "userID", c => c.Int(nullable: false));
        }
    }
}
