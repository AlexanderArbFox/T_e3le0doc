using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teledocer.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id_type = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_of_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id_type);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id_clients = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Inn_kl = table.Column<long>(nullable: false),
                    Name_corp = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Data_add = table.Column<DateTime>(nullable: false),
                    Data_reload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id_clients);
                    table.ForeignKey(
                        name: "FK_Clients_Types_Type",
                        column: x => x.Type,
                        principalTable: "Types",
                        principalColumn: "Id_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "founder",
                columns: table => new
                {
                    Id_founder = table.Column<int>(nullable: false),
                    Inn_uch = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fio = table.Column<string>(nullable: false),
                    Date_add = table.Column<DateTime>(nullable: false),
                    Date_reload = table.Column<DateTime>(nullable: false),
                    fff = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_founder", x => x.Inn_uch);
                    table.ForeignKey(
                        name: "FK_founder_Clients_Id_founder",
                        column: x => x.Id_founder,
                        principalTable: "Clients",
                        principalColumn: "Id_clients",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Type",
                table: "Clients",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_founder_Id_founder",
                table: "founder",
                column: "Id_founder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "founder");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
