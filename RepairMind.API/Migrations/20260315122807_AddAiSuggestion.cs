using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMind.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAiSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AiSuggestion",
                table: "RepairRequests",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AiSuggestion",
                table: "RepairRequests");
        }
    }
}
