using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_NET7.Migrations
{
    /// <inheritdoc />
    public partial class agregandoDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa", "imageUrl" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa", new DateTime(2024, 2, 24, 14, 30, 14, 75, DateTimeKind.Local).AddTicks(7943), new DateTime(2024, 2, 24, 14, 30, 14, 75, DateTimeKind.Local).AddTicks(7929), 50, "Villa Real", 5, 200.0, "" },
                    { 2, "", "Detalle de la Villa...", new DateTime(2024, 2, 24, 14, 30, 14, 75, DateTimeKind.Local).AddTicks(7954), new DateTime(2024, 2, 24, 14, 30, 14, 75, DateTimeKind.Local).AddTicks(7951), 90, "Preminun Vista al Mar", 3, 1500.0, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
