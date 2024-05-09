using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganizationTrackingApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class OrganizatorPropertyAddedForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("00e5313a-b20d-4c2e-9a3f-c08c13c83ebb"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("0bbb3d4b-0a9f-4583-9bcd-659e2a1608a6"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("105b5611-e833-40a3-8916-ff56b5c2ba7c"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("29ab5469-71a7-4605-85ab-82b874d96b73"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("8737ae07-cad9-433a-aee2-07cdbd931175"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("f91a6be4-2da5-4a60-8b93-d6f651e71fb6"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Organizators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("154e605e-afc8-4f0a-9abf-07aaa0b1fef3"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3556), false, "Concert", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3569) },
                    { new Guid("1d3c2a0c-6023-42d1-8b7a-6fdd49f4ca49"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3608), false, "Activity", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3608) },
                    { new Guid("53c4dcb0-da06-4e1b-bc4a-bcf2eeae22c6"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3593), false, "Meeting", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3593) },
                    { new Guid("7b5dc9ee-433e-4dca-8b25-5b2911caf1eb"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3586), false, "Carnival", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3586) },
                    { new Guid("a3bf1923-6699-4c4b-90d8-ef06cecfe33f"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3612), false, "Trip", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3613) },
                    { new Guid("f7010d6e-643a-4c0c-85dc-a10af453699c"), new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3590), false, "Festival", new DateTime(2024, 5, 9, 9, 27, 41, 758, DateTimeKind.Local).AddTicks(3590) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizators_UserId",
                table: "Organizators",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizators_Users_UserId",
                table: "Organizators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizators_Users_UserId",
                table: "Organizators");

            migrationBuilder.DropIndex(
                name: "IX_Organizators_UserId",
                table: "Organizators");

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("154e605e-afc8-4f0a-9abf-07aaa0b1fef3"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("1d3c2a0c-6023-42d1-8b7a-6fdd49f4ca49"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("53c4dcb0-da06-4e1b-bc4a-bcf2eeae22c6"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("7b5dc9ee-433e-4dca-8b25-5b2911caf1eb"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("a3bf1923-6699-4c4b-90d8-ef06cecfe33f"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("f7010d6e-643a-4c0c-85dc-a10af453699c"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Organizators");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00e5313a-b20d-4c2e-9a3f-c08c13c83ebb"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7888), false, "Meeting", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7888) },
                    { new Guid("0bbb3d4b-0a9f-4583-9bcd-659e2a1608a6"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7822), false, "Concert", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7835) },
                    { new Guid("105b5611-e833-40a3-8916-ff56b5c2ba7c"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7891), false, "Activity", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7891) },
                    { new Guid("29ab5469-71a7-4605-85ab-82b874d96b73"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7884), false, "Festival", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7885) },
                    { new Guid("8737ae07-cad9-433a-aee2-07cdbd931175"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7874), false, "Carnival", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7874) },
                    { new Guid("f91a6be4-2da5-4a60-8b93-d6f651e71fb6"), new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7896), false, "Trip", new DateTime(2024, 4, 18, 9, 43, 52, 340, DateTimeKind.Local).AddTicks(7896) }
                });
        }
    }
}
