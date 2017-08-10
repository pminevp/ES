using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EStates.Migrations
{
    public partial class Construct_Basic_Tables_V1 : Migration
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
                name: "BuildingEntrance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentBuildingId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingEntrance", x => x.id);
                    table.ForeignKey(
                        name: "FK_BuildingEntrance_AppBuilding_CurrentBuildingId",
                        column: x => x.CurrentBuildingId,
                        principalTable: "AppBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppBuildingFloor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    buildingEntranceid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBuildingFloor", x => x.id);
                    table.ForeignKey(
                        name: "FK_AppBuildingFloor_BuildingEntrance_buildingEntranceid",
                        column: x => x.buildingEntranceid,
                        principalTable: "BuildingEntrance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppApartament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingEntranceid = table.Column<int>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentFloorid = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppApartament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppApartament_BuildingEntrance_BuildingEntranceid",
                        column: x => x.BuildingEntranceid,
                        principalTable: "BuildingEntrance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppApartament_AppBuilding_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "AppBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppApartament_AppBuildingFloor_ParentFloorid",
                        column: x => x.ParentFloorid,
                        principalTable: "AppBuildingFloor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApartamentId",
                table: "AspNetUsers",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppApartament_BuildingEntranceid",
                table: "AppApartament",
                column: "BuildingEntranceid");

            migrationBuilder.CreateIndex(
                name: "IX_AppApartament_BuildingId",
                table: "AppApartament",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AppApartament_ParentFloorid",
                table: "AppApartament",
                column: "ParentFloorid");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingEntrance_CurrentBuildingId",
                table: "BuildingEntrance",
                column: "CurrentBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBuildingFloor_buildingEntranceid",
                table: "AppBuildingFloor",
                column: "buildingEntranceid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AppApartament_ApartamentId",
                table: "AspNetUsers",
                column: "ApartamentId",
                principalTable: "AppApartament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppApartament_ApartamentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppApartament");

            migrationBuilder.DropTable(
                name: "AppBuildingFloor");

            migrationBuilder.DropTable(
                name: "BuildingEntrance");

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
