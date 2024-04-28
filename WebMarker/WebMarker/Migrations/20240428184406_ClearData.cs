using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMarker.Migrations
{
    /// <inheritdoc />
    public partial class ClearData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoleClaims;");
            migrationBuilder.Sql("DELETE FROM AspNetRoles;");
            migrationBuilder.Sql("DELETE FROM AspNetUserClaims;");
            migrationBuilder.Sql("DELETE FROM AspNetUserLogins;");
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles;");
            migrationBuilder.Sql("DELETE FROM AspNetUsers;");
            migrationBuilder.Sql("DELETE FROM AspNetUserTokens;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
