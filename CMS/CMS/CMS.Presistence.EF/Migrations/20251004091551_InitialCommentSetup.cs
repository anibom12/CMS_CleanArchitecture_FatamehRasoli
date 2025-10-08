using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Presistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommentSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SQ_Hilo_Comment");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApprove = table.Column<bool>(type: "bit", nullable: false),
                    content_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content_Format = table.Column<int>(type: "int", nullable: false),
                    content_IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    content_Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropSequence(
                name: "SQ_Hilo_Comment");
        }
    }
}
