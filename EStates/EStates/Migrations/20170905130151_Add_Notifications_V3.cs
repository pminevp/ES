using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EStates.Migrations
{
    public partial class Add_Notifications_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    BuildingEntranceId = table.Column<int>(nullable: false),
                    BuildingFloorId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Header = table.Column<string>(nullable: true),
                    IsPinned = table.Column<bool>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNotification_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_CreatorId",
                table: "AppNotification",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppNotification");
        }
    }
}
