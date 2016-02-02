namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Testes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Testes");
        }
    }
}
