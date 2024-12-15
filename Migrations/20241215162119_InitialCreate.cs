using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BodyMeasurementsTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Waist = table.Column<float>(type: "real", nullable: true),
                    BodyFat = table.Column<float>(type: "real", nullable: true),
                    Neck = table.Column<float>(type: "real", nullable: true),
                    Shoulder = table.Column<float>(type: "real", nullable: true),
                    Chest = table.Column<float>(type: "real", nullable: true),
                    Biceps = table.Column<float>(type: "real", nullable: true),
                    Forearm = table.Column<float>(type: "real", nullable: true),
                    Abdomen = table.Column<float>(type: "real", nullable: true),
                    Hips = table.Column<float>(type: "real", nullable: true),
                    Thighs = table.Column<float>(type: "real", nullable: true),
                    Calf = table.Column<float>(type: "real", nullable: true),
                    ProgressPicture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurements");
        }
    }
}
