using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingKoi.Migrations
{
    /// <inheritdoc />
    public partial class updatekoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Age",
                table: "KOIs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "KOIs");
        }
    }
}
