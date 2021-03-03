using Microsoft.EntityFrameworkCore.Migrations;

namespace studentOneMethod.Migrations
{
    public partial class UpdateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @" Create procedure UpdateStudent
                                @id int,
                                @CIN nvarchar(max),
                                @FName nvarchar(max),
                                @LName nvarchar(max),
                                @Address nvarchar(max)
                                as
                                Begin
                                     Update Employees Set CIN = @CIN, FName = @FName, LName = @LName, Address = @Address
                                     where id = @id
                                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @" Drop procedure UpdateStudent";
            migrationBuilder.Sql(procedure);
        }
    }
}
