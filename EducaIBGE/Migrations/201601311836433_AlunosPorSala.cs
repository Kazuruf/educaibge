namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunosPorSala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunosPorSalas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
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
            DropForeignKey("dbo.AlunosPorSalas", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.AlunosPorSalas", new[] { "Estado_Id" });
            DropTable("dbo.AlunosPorSalas");
        }
    }
}
