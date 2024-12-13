using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDRadzenBlazor.Migrations
{
    /// <inheritdoc />
    public partial class seedColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Colors",
            columns: new[] { "ColorName" },
            values: new object[,]
            {
         {"Red"},
         {"Blue" },
         {"Brown"},
         {"Gray"},
         {"Black"},
         {"White"}
            });

    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "Colors",
             keyColumn: "ColorId",
             keyValues: new object[]
             {
               1,2,3,4,5,6
             });
        }
    }
}
