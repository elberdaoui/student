using Microsoft.EntityFrameworkCore.Migrations;

namespace studentOneMethod.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @" Create procedure AddStudent
                                @CIN nvarchar(max),
                                @FName nvarchar(max),
                                @LName nvarchar(max),
                                @Address nvarchar(max)
                                as
                                Begin
                                     Insert into Students values (@CIN, @FName, @LName, @Address)   
                                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @" Drop procedure InsertEmployee";
            migrationBuilder.Sql(procedure);
        }
    }
}
