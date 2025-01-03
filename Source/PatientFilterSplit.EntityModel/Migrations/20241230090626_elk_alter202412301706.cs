using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientFilterSplit.EntityModel.Migrations
{
    /// <inheritdoc />
    public partial class elk_alter202412301706 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ElkUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ElkUser");
        }
    }
}
