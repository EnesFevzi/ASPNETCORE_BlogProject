using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCORE_BlogProject.Data.Migrations
{
    public partial class mig_add_indentity_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserID" },
                values: new object[] { new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7284), 1 });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserID" },
                values: new object[] { new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7288), 2 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c673f9f1-a733-4fe1-b2ba-bdd9c6123dff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7094187e-6168-460b-a98c-369e61027ef8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "11d96d55-749d-40b9-8a4d-4ffb7c8c769c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14df5381-25d8-49cb-a35b-e9729ce40b7e", "AQAAAAEAACcQAAAAEFPBuhImpcLLX1g7c79ADbplDlqqVsrOPdoh2a/OASeRemc8aLxDS5j4U3vddHUioA==", "e39dd091-1789-4836-a218-bd3b66c2ce12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c03c6a6-e5c8-4c64-98a6-95942fa177fc", "AQAAAAEAACcQAAAAED9IWRImyn7G7/6QXPtfQxGx+qX/Sx5Mg3Cn2FKt5PK0MHuWt1ewbS5nRkub8JYmUw==", "cddab22b-32ff-4a15-be9b-461eccb7316d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 21, 21, 55, 260, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserID",
                table: "Articles",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1a51d049-4760-4a53-830a-26b6ab6ae026");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "443257c2-9426-463e-858f-834a12c004f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "64236891-ade4-499a-8147-900747479cce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8c28afd-638c-4de1-851a-84eecf0e6623", "AQAAAAEAACcQAAAAEMhqznF0fPt+DvL+A0gp6lE0r6EBOWPeK3+GXgrbuksZZOfwDaqa3JfeITpA/HZeiA==", "7225c4cd-46c1-4dae-9f31-87c4d573d1c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb31dad-08ff-4fb4-a02c-b7086773a6c9", "AQAAAAEAACcQAAAAEDc+fw8c36kGFme2TEHkkkchtzyZWfpuVsD87uEedk0PebJ9h2qzzKC1wp0xtwKKbg==", "11399a51-c973-49e0-b6a7-ffcb75eea060" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 15, 29, 57, 401, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
