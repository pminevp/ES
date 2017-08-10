using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class Upgrade_Apartament_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Entrances",
                table: "AppBuilding",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "AppBuilding",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrances",
                table: "AppBuilding");

            migrationBuilder.DropColumn(
                name: "Floors",
                table: "AppBuilding");
        }
    }
}
