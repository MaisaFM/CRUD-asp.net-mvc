namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bibliotecastart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CLB.Emprestimo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        LivroId = c.Int(nullable: false),
                        DtEmprestimo = c.DateTime(nullable: false),
                        DtDevolucao = c.DateTime(),
                        DataRegistro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                        Livro_Id = c.Long(),
                        Pessoa_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CLB.Livro", t => t.Livro_Id)
                .ForeignKey("CLB.Pessoa", t => t.Pessoa_Id)
                .Index(t => t.Livro_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "CLB.Livro",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Autor = c.String(nullable: false),
                        Ano = c.Int(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CLB.Pessoa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DtNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CLB.Emprestimo", "Pessoa_Id", "CLB.Pessoa");
            DropForeignKey("CLB.Emprestimo", "Livro_Id", "CLB.Livro");
            DropIndex("CLB.Emprestimo", new[] { "Pessoa_Id" });
            DropIndex("CLB.Emprestimo", new[] { "Livro_Id" });
            DropTable("CLB.Pessoa");
            DropTable("CLB.Livro");
            DropTable("CLB.Emprestimo");
        }
    }
}
