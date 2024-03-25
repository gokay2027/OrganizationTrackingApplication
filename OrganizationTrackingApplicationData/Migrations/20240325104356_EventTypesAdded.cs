using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganizationTrackingApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class EventTypesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4f5d2d19-b8a1-4e7a-af4f-e07a92a66bd6"), "Trip" },
                    { new Guid("74213cbf-efe3-43d0-8cc1-68dca8438a23"), "Activity" },
                    { new Guid("903571e4-4496-4216-99df-6f121a133ef5"), "Concert" },
                    { new Guid("c3b33b3f-483a-423e-af09-4c8ce7a6d252"), "Festival" },
                    { new Guid("f6c29eb7-ecdb-49eb-a212-3b63bc9bc00f"), "Meeting" },
                    { new Guid("f862b959-e44f-40f5-9c53-f62b6e31991c"), "Carnival" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f5d2d19-b8a1-4e7a-af4f-e07a92a66bd6"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("74213cbf-efe3-43d0-8cc1-68dca8438a23"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("903571e4-4496-4216-99df-6f121a133ef5"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3b33b3f-483a-423e-af09-4c8ce7a6d252"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("f6c29eb7-ecdb-49eb-a212-3b63bc9bc00f"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("f862b959-e44f-40f5-9c53-f62b6e31991c"));
        }
    }
}
