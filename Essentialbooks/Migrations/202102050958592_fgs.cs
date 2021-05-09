namespace Essentialbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MediaRatings", "UserId", "dbo.RealUsers");
            DropIndex("dbo.MediaRatings", new[] { "UserId" });
            AlterColumn("dbo.MediaRatings", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MediaRatings", "UserId");
            AddForeignKey("dbo.MediaRatings", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaRatings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.MediaRatings", new[] { "UserId" });
            AlterColumn("dbo.MediaRatings", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.MediaRatings", "UserId");
            AddForeignKey("dbo.MediaRatings", "UserId", "dbo.RealUsers", "Id", cascadeDelete: true);
        }
    }
}
