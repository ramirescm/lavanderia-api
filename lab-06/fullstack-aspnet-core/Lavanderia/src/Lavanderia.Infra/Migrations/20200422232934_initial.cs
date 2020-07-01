using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lavanderia.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    documento = table.Column<string>(nullable: true),
                    nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    email = table.Column<string>(type: "varchar(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(15,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "varchar(50)", nullable: false),
                    senha = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ordems_servicos",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cliente_id = table.Column<long>(nullable: false),
                    data_entrada = table.Column<DateTime>(nullable: false),
                    data_saida = table.Column<DateTime>(nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(15,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ordems_servicos", x => x.id);
                    table.ForeignKey(
                        name: "fk_ordems_servicos_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itens_ordem",
                columns: table => new
                {
                    item_id = table.Column<long>(nullable: false),
                    ordem_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_itens_ordem", x => new { x.item_id, x.ordem_id });
                    table.ForeignKey(
                        name: "fk_itens_ordem_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_itens_ordem_ordems_servicos_ordem_id",
                        column: x => x.ordem_id,
                        principalTable: "ordems_servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_itens_ordem_ordem_id",
                table: "itens_ordem",
                column: "ordem_id");

            migrationBuilder.CreateIndex(
                name: "ix_ordems_servicos_cliente_id",
                table: "ordems_servicos",
                column: "cliente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itens_ordem");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "ordems_servicos");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
