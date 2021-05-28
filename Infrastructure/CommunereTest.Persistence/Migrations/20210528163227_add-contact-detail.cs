using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunereTest.Persistence.Migrations
{
    public partial class addcontactdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Contacts");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "ContactDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactId",
                table: "ContactDetails",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contacts_ContactId",
                table: "ContactDetails",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contacts_ContactId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ContactId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
