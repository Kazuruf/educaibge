namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnosDeEstudoPorIdade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnosDeEstudoPorIdades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Unidade = c.String(),
                        FaixaDeIdade = c.String(),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnosDeEstudoPorIdades", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.AnosDeEstudoPorIdades", new[] { "Estado_Id" });
            DropTable("dbo.AnosDeEstudoPorIdades");
        }
    }
}
