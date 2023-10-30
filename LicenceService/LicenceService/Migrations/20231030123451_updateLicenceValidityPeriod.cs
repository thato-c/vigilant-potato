using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenceService.Migrations
{
    /// <inheritdoc />
    public partial class updateLicenceValidityPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidityMonths",
                table: "Licence",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidityMonths",
                table: "Licence");
        }
    }
}
