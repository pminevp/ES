using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStates.Migrations
{
    public partial class Extending_Notification_Deadline_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "AppNotification",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HaveDeadline",
                table: "AppNotification",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "AppNotification");

            migrationBuilder.DropColumn(
                name: "HaveDeadline",
                table: "AppNotification");
        }
    }
}
