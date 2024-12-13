using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDRadzenBlazor.Migrations
{
    /// <inheritdoc />
    public partial class seedYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "Years",
           columns: new[] { "YearName" },
           values: new object[,]
           {
         {"2010-2011"},
{"2011-2012"},
{"2012-2013"},
{"2013-2014"},
{"2014-2015"},
{"2015-2016"},
{"2016-2017"},
{"2017-2018"},
{"2018-2019"},
{"2019-2020"},
{"2020-2021"},
{"2021-2022"},
{"2022-2023"},
{"2023-2024"},
{"2024-2025"},
           });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Years",
            keyColumn: "YearName",
            keyValues: new object[]
            {
               1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
            });

        }
    }
}
