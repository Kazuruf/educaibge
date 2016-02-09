namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reprovacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReprovacaoPorSeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Unidade = c.String(),
                        Serie = c.String(),
                        TipoDeEnsino = c.String(),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReprovacaoPorSeries", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.ReprovacaoPorSeries", new[] { "Estado_Id" });
            DropTable("dbo.ReprovacaoPorSeries");
        }
    }
}
