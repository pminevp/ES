using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class Add_DocumentFile_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "AppDocumentFile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDocumentFile_creatorId",
                table: "AppDocumentFile",
                column: "creatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDocumentFile_AspNetUsers_creatorId",
                table: "AppDocumentFile",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDocumentFile_AspNetUsers_creatorId",
                table: "AppDocumentFile");

            migrationBuilder.DropIndex(
                name: "IX_AppDocumentFile_creatorId",
                table: "AppDocumentFile");

            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "AppDocumentFile");
        }
    }
}
