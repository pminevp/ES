using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class AddApartament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_AppBuilding_BuildingId",
                table: "Apartament");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_AppBuildingFloor_ParentFloorid",
                table: "Apartament");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apartament_ApartamentId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartament",
                table: "Apartament");

            migrationBuilder.RenameTable(
                name: "Apartament",
                newName: "AppApartament");

            migrationBuilder.RenameIndex(
                name: "IX_Apartament_ParentFloorid",
                table: "AppApartament",
                newName: "IX_AppApartament_ParentFloorid");

            migrationBuilder.RenameIndex(
                name: "IX_Apartament_BuildingId",
                table: "AppApartament",
                newName: "IX_AppApartament_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppApartament",
                table: "AppApartament",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppApartament_AppBuilding_BuildingId",
                table: "AppApartament",
                column: "BuildingId",
                principalTable: "AppBuilding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppApartament_AppBuildingFloor_ParentFloorid",
                table: "AppApartament",
                column: "ParentFloorid",
                principalTable: "AppBuildingFloor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AppApartament_AppBuilding_BuildingId",
                table: "AppApartament");

            migrationBuilder.DropForeignKey(
                name: "FK_AppApartament_AppBuildingFloor_ParentFloorid",
                table: "AppApartament");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppApartament_ApartamentId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppApartament",
                table: "AppApartament");

            migrationBuilder.RenameTable(
                name: "AppApartament",
                newName: "Apartament");

            migrationBuilder.RenameIndex(
                name: "IX_AppApartament_ParentFloorid",
                table: "Apartament",
                newName: "IX_Apartament_ParentFloorid");

            migrationBuilder.RenameIndex(
                name: "IX_AppApartament_BuildingId",
                table: "Apartament",
                newName: "IX_Apartament_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartament",
                table: "Apartament",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_AppBuilding_BuildingId",
                table: "Apartament",
                column: "BuildingId",
                principalTable: "AppBuilding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_AppBuildingFloor_ParentFloorid",
                table: "Apartament",
                column: "ParentFloorid",
                principalTable: "AppBuildingFloor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apartament_ApartamentId",
                table: "AspNetUsers",
                column: "ApartamentId",
                principalTable: "Apartament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
