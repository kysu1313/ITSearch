using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSearch.Data.Migrations
{
    public partial class AddedIOSDevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IOSDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModelNumberModelId = table.Column<int>(type: "int", nullable: true),
                    DeviceConfigurationConfigId = table.Column<int>(type: "int", nullable: true),
                    StringDeviceConfiguration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOSDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOSDevices_Configurations_DeviceConfigurationConfigId",
                        column: x => x.DeviceConfigurationConfigId,
                        principalTable: "Configurations",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IOSDevices_ModelNumbers_DeviceModelNumberModelId",
                        column: x => x.DeviceModelNumberModelId,
                        principalTable: "ModelNumbers",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IOSDevices_DeviceConfigurationConfigId",
                table: "IOSDevices",
                column: "DeviceConfigurationConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_IOSDevices_DeviceModelNumberModelId",
                table: "IOSDevices",
                column: "DeviceModelNumberModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOSDevices");
        }
    }
}
