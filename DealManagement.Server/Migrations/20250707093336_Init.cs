using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DealManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Slug);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealSlug = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Deals_DealSlug",
                        column: x => x.DealSlug,
                        principalTable: "Deals",
                        principalColumn: "Slug",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Slug", "Name", "Video" },
                values: new object[,]
                {
                    { "summer-getaway", "Summer Getaway", "https://example.com/video1" },
                    { "winter-retreat", "Winter Retreat", "https://example.com/video2" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Amenities", "DealSlug", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Pool,WiFi,Breakfast", "summer-getaway", "Palm Beach Resort", 4.5m },
                    { 2, "WiFi,Parking,Gym", "summer-getaway", "Oceanview Inn", 4.2m },
                    { 3, "Sauna,Fireplace,Bar", "winter-retreat", "Snow Lodge", 4.7m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_DealSlug",
                table: "Hotels",
                column: "DealSlug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
