using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EStates.Migrations
{
    public partial class AddBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartamentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBuilding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartament_AppBuilding_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "AppBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApartamentId",
                table: "AspNetUsers",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_BuildingId",
                table: "Apartament",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apartament_ApartamentId",
                table: "AspNetUsers",
                column: "ApartamentId",
                principalTable: "Apartament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apartament_ApartamentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Apartament");

            migrationBuilder.DropTable(
                name: "AppBuilding");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApartamentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApartamentId",
                table: "AspNetUsers");
        }
    }
}
