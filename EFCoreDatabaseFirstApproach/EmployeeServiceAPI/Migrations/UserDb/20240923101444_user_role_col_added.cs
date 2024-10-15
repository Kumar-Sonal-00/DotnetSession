using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeServiceAPI.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class user_role_col_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "tbl_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "tbl_users");
        }
    }
}
