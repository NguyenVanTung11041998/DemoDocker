using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnectApp.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SampleAId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleBs_SampleAs_SampleAId",
                        column: x => x.SampleAId,
                        principalTable: "SampleAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SampleBId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SampleCId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleCs_SampleBs_SampleBId",
                        column: x => x.SampleBId,
                        principalTable: "SampleBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleCs_SampleCs_SampleCId",
                        column: x => x.SampleCId,
                        principalTable: "SampleCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SampleDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SampleCId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleDs_SampleCs_SampleCId",
                        column: x => x.SampleCId,
                        principalTable: "SampleCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleBs_SampleAId",
                table: "SampleBs",
                column: "SampleAId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleCs_SampleBId",
                table: "SampleCs",
                column: "SampleBId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleCs_SampleCId",
                table: "SampleCs",
                column: "SampleCId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleDs_SampleCId",
                table: "SampleDs",
                column: "SampleCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleDs");

            migrationBuilder.DropTable(
                name: "SampleCs");

            migrationBuilder.DropTable(
                name: "SampleBs");

            migrationBuilder.DropTable(
                name: "SampleAs");
        }
    }
}
