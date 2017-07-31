using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EStates.Migrations
{
    public partial class AddBuildingFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentFloorid",
                table: "Apartament",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppBuildingFloor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentBuildingId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBuildingFloor", x => x.id);
                    table.ForeignKey(
                        name: "FK_AppBuildingFloor_AppBuilding_CurrentBuildingId",
                        column: x => x.CurrentBuildingId,
                        principalTable: "AppBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_ParentFloorid",
                table: "Apartament",
                column: "ParentFloorid");

            migrationBuilder.CreateIndex(
                name: "IX_AppBuildingFloor_CurrentBuildingId",
                table: "AppBuildingFloor",
                column: "CurrentBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_AppBuildingFloor_ParentFloorid",
                table: "Apartament",
                column: "ParentFloorid",
                principalTable: "AppBuildingFloor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_AppBuildingFloor_ParentFloorid",
                table: "Apartament");

            migrationBuilder.DropTable(
                name: "AppBuildingFloor");

            migrationBuilder.DropIndex(
                name: "IX_Apartament_ParentFloorid",
                table: "Apartament");

            migrationBuilder.DropColumn(
                name: "ParentFloorid",
                table: "Apartament");
        }
    }
}
