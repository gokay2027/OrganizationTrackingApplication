using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganizationTrackingApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class CommentColumnAddedForRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("6a35db41-1b97-4980-871a-56490d8dda4b"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("864df255-72f9-43a9-afbe-1b26cd6db182"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("94e99ee7-f305-4930-95b8-4019a81ad519"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("b474bc33-c7ae-4abb-9ae6-7d2dce0f1999"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("d4581336-5d2d-404f-9896-9b25bf2a6080"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("d7a0eff6-f276-47d9-9a27-3b68b95c6c06"));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3c798a1b-942f-4519-9651-fb1f3ab6413c"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7176), false, "Trip", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7176) },
                    { new Guid("5a21c558-901a-4e25-b22a-9533d0d1d771"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7168), false, "Meeting", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7168) },
                    { new Guid("d310eed9-2f56-4459-85ee-d49dad4612e7"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7171), false, "Activity", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7172) },
                    { new Guid("d538a8db-8328-49f5-97c7-182f9f1f17f4"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7135), false, "Concert", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7144) },
                    { new Guid("e7a7f309-6bff-4464-9a66-7a707277f789"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7161), false, "Carnival", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7161) },
                    { new Guid("f06209c0-9699-4153-865a-a7034620329a"), new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7165), false, "Festival", new DateTime(2024, 4, 14, 18, 21, 0, 717, DateTimeKind.Local).AddTicks(7165) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("3c798a1b-942f-4519-9651-fb1f3ab6413c"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("5a21c558-901a-4e25-b22a-9533d0d1d771"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("d310eed9-2f56-4459-85ee-d49dad4612e7"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("d538a8db-8328-49f5-97c7-182f9f1f17f4"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("e7a7f309-6bff-4464-9a66-7a707277f789"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("f06209c0-9699-4153-865a-a7034620329a"));

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Ratings");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6a35db41-1b97-4980-871a-56490d8dda4b"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5626), false, "Trip", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5627) },
                    { new Guid("864df255-72f9-43a9-afbe-1b26cd6db182"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5621), false, "Activity", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5622) },
                    { new Guid("94e99ee7-f305-4930-95b8-4019a81ad519"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5615), false, "Festival", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5615) },
                    { new Guid("b474bc33-c7ae-4abb-9ae6-7d2dce0f1999"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5542), false, "Concert", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5571) },
                    { new Guid("d4581336-5d2d-404f-9896-9b25bf2a6080"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5611), false, "Carnival", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5611) },
                    { new Guid("d7a0eff6-f276-47d9-9a27-3b68b95c6c06"), new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5618), false, "Meeting", new DateTime(2024, 3, 25, 15, 17, 47, 30, DateTimeKind.Local).AddTicks(5619) }
                });
        }
    }
}
