using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class ApplicaitonUSerAdd_Managed_EntrancesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_ApplicationUserId",
                table: "BuildingEntrance");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "BuildingEntrance",
                newName: "managerId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingEntrance_ApplicationUserId",
                table: "BuildingEntrance",
                newName: "IX_BuildingEntrance_managerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_managerId",
                table: "BuildingEntrance",
                column: "managerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_managerId",
                table: "BuildingEntrance");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "BuildingEntrance",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingEntrance_managerId",
                table: "BuildingEntrance",
                newName: "IX_BuildingEntrance_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingEntrance_AspNetUsers_ApplicationUserId",
                table: "BuildingEntrance",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
