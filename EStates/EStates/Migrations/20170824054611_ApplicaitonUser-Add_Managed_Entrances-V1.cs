using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class ApplicaitonUserAdd_Managed_EntrancesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BuildingEntrance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingEntrance_ApplicationUserId",
                table: "BuildingEntrance",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_ApplicationUserId",
                table: "BuildingEntrance",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_ApplicationUserId",
                table: "BuildingEntrance");

            migrationBuilder.DropIndex(
                name: "IX_BuildingEntrance_ApplicationUserId",
                table: "BuildingEntrance");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BuildingEntrance");
        }
    }
}
