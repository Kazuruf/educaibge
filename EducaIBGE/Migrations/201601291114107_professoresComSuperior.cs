namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class professoresComSuperior : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UF = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfComSuperiorNoAnoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        UF = c.String(),
                        Valor = c.Double(nullable: false),
                        Unidade = c.String(),
                        Categoria = c.String(),
                        TipoDeEnsino = c.String(),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfComSuperiorNoAnoes", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.ProfComSuperiorNoAnoes", new[] { "Estado_Id" });
            DropTable("dbo.ProfComSuperiorNoAnoes");
            DropTable("dbo.Estadoes");
        }
    }
}
