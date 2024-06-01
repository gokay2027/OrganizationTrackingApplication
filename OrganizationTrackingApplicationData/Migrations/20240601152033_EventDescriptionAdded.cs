using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganizationTrackingApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class EventDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1bf414fd-9224-4dec-96da-e90e269225a9"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7022), false, "Activity", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7022) },
                    { new Guid("219b4456-6e66-4bd9-b55f-dd4c4a5199cd"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7018), false, "Meeting", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7018) },
                    { new Guid("7923ad09-a6ae-44df-bb85-a0e6140bc02f"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7028), false, "Trip", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7029) },
                    { new Guid("7bc672e2-c0ea-45b7-953a-6b531ff840e0"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(6993), false, "Carnival", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(6993) },
                    { new Guid("83205c21-c8b1-4bae-8214-50ae8a6440a2"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7014), false, "Festival", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(7014) },
                    { new Guid("b885a452-42ad-425b-9aa4-9840d19eb85e"), new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(6953), false, "Concert", new DateTime(2024, 6, 1, 18, 20, 32, 260, DateTimeKind.Local).AddTicks(6963) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}