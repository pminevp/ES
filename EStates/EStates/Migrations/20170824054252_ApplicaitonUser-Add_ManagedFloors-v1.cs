using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class ApplicaitonUserAdd_ManagedFloorsv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AppBuildingFloor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppBuildingFloor_ApplicationUserId",
                table: "AppBuildingFloor",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBuildingFloor_AspNetUsers_ApplicationUserId",
                table: "AppBuildingFloor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBuildingFloor_AspNetUsers_ApplicationUserId",
                table: "AppBuildingFloor");

            migrationBuilder.DropIndex(
                name: "IX_AppBuildingFloor_ApplicationUserId",
                table: "AppBuildingFloor");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AppBuildingFloor");
        }
    }
}
