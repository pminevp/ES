using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EStates.Migrations
{
    public partial class Add_DocumentType_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeDataTypeId",
                table: "AppDocumentFile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppDocumentDataType",
                columns: table => new
                {
                    DataTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDocumentDataType", x => x.DataTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDocumentFile_TypeDataTypeId",
                table: "AppDocumentFile",
                column: "TypeDataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDocumentFile_AppDocumentDataType_TypeDataTypeId",
                table: "AppDocumentFile",
                column: "TypeDataTypeId",
                principalTable: "AppDocumentDataType",
                principalColumn: "DataTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDocumentFile_AppDocumentDataType_TypeDataTypeId",
                table: "AppDocumentFile");

            migrationBuilder.DropTable(
                name: "AppDocumentDataType");

            migrationBuilder.DropIndex(
                name: "IX_AppDocumentFile_TypeDataTypeId",
                table: "AppDocumentFile");

            migrationBuilder.DropColumn(
                name: "TypeDataTypeId",
                table: "AppDocumentFile");
        }
    }
}
