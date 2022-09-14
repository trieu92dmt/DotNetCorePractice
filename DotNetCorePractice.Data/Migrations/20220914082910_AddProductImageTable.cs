using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCorePractice.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 15, 29, 9, 60, DateTimeKind.Local).AddTicks(6196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 14, 13, 46, 14, 556, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "46263c55-ae6b-4b26-8086-3869fb1b9bc4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("544cdf6e-844a-482a-907d-8808d97b7a5e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8aea6f0-5fb6-41c6-a103-94b9d5f78c19", "AQAAAAEAACcQAAAAEH2io77WeIWM0ssZQankIATcbDHh/bW7us+BF0YHBIcZ7D+gynjl0LBttrbkJ6IPDQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 14, 15, 29, 9, 87, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 13, 46, 14, 556, DateTimeKind.Local).AddTicks(8455),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 14, 15, 29, 9, 60, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "445daa39-ad12-4de0-9a75-4eac49810766");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("544cdf6e-844a-482a-907d-8808d97b7a5e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b834e8a6-79d4-4d56-9f9d-197f6a06dd01", "AQAAAAEAACcQAAAAEFlehxQiXCa/tAaHTIE4Bkk4ecG98VATbdYGFWkN/+DmXtqVEL6TAxNsTOvBRVdmsw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 14, 13, 46, 14, 579, DateTimeKind.Local).AddTicks(5526));
        }
    }
}
