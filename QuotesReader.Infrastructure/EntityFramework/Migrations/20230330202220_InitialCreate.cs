using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuotesReader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attribution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Text", "Attribution" },
                values: new object[,]
                {
                    { 1, "The Universe is under no obligation to make sense to you.", "Neil deGrasse Tyson" },
                    { 2, "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.", "Albert Einstein" },
                    { 3, "Do not fear to be eccentric in opinion, for every opinion now accepted was once eccentric.", "Bertand Russel" },
                    { 4, "It pays to keep an open mind, but not so open your brains fall out.", "Carl Sagan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
