using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalk.Migrations
{
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"), "Easy" },
                    { new Guid("d06e77c7-4733-498d-9122-6260b242d909"), "Medium" },
                    { new Guid("eb24c4a5-c67a-4eee-ae3b-e17bb9a79dd0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"), "AML", "Easy", "" },
                    { new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6c"), "AML", "Easy", "" },
                    { new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6d"), "AML", "Easy", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d06e77c7-4733-498d-9122-6260b242d909"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("eb24c4a5-c67a-4eee-ae3b-e17bb9a79dd0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6d"));
        }
    }
}
