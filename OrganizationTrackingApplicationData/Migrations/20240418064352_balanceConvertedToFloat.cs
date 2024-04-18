using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganizationTrackingApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class balanceConvertedToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("13f49a79-07b7-4099-8a51-5a8734b5ef87"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("35af94ac-25ca-4a42-8108-9d07218c9237"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("43b3a288-2069-4613-a039-2ffe8925dccf"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("775a4bfe-9f07-44f1-8483-997dada427db"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("816c7159-9bdd-4377-87d9-64513b1374b4"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("a56a92d9-5d80-4256-98e7-7715ea6ec82f"));

            migrationBuilder.AlterColumn<float>(
                name: "Credit",
                table: "Balances",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Credit",
                table: "Balances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("13f49a79-07b7-4099-8a51-5a8734b5ef87"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9616), false, "Carnival", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9616) },
                    { new Guid("35af94ac-25ca-4a42-8108-9d07218c9237"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9629), false, "Meeting", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9629) },
                    { new Guid("43b3a288-2069-4613-a039-2ffe8925dccf"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9619), false, "Festival", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9619) },
                    { new Guid("775a4bfe-9f07-44f1-8483-997dada427db"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9637), false, "Trip", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9637) },
                    { new Guid("816c7159-9bdd-4377-87d9-64513b1374b4"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9586), false, "Concert", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9597) },
                    { new Guid("a56a92d9-5d80-4256-98e7-7715ea6ec82f"), new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9632), false, "Activity", new DateTime(2024, 4, 18, 9, 20, 40, 93, DateTimeKind.Local).AddTicks(9632) }
                });
        }
    }
}
