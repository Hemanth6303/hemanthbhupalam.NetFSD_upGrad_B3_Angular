using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEZ.API.Migrations
{
    /// <inheritdoc />
    public partial class seedadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "PasswordHash", "Role" },
                values: new object[] { 1, "admin@gmail.com", "Admin", "$2a$11$7.PSaQxw4V8qxxUniB2Q6u2JKVzvgoujznRMWa6Y1CEAxQG4wDa36", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
