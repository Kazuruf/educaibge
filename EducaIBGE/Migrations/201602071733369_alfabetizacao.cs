namespace EducaIBGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alfabetizacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlfabetizacaoPorIdades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Unidade = c.String(),
                        FaixaDeIdade = c.String(),
                        Alfabetizado = c.String(),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlfabetizacaoPorIdades", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.AlfabetizacaoPorIdades", new[] { "Estado_Id" });
            DropTable("dbo.AlfabetizacaoPorIdades");
        }
    }
}
