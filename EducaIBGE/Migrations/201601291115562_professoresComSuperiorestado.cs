namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class professoresComSuperiorestado : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProfComSuperiorNoAnoes", "UF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfComSuperiorNoAnoes", "UF", c => c.String());
        }
    }
}
