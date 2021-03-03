using Microsoft.EntityFrameworkCore.Migrations;

namespace studentOneMethod.Migrations
{
    public partial class GetAllStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure GetAllStudent
                                    @id int,
                                    @CIN nvarchar(max),
                                    @FName nvarchar(max),
                                    @LName nvarchar(max),
                                    @Address nvarchar(max)
                                    as
                                    Begin
                                        Select * from Students
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure GetAllStudent";
            migrationBuilder.Sql(procedure);
        }
    }
}
