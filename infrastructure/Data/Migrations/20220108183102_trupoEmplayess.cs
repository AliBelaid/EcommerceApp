using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class trupoEmplayess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    departmentName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employeeleaves",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employeeName = table.Column<string>(type: "TEXT", nullable: true),
                    designation = table.Column<string>(type: "TEXT", nullable: true),
                    leaveType = table.Column<string>(type: "TEXT", nullable: true),
                    from = table.Column<string>(type: "TEXT", nullable: true),
                    to = table.Column<string>(type: "TEXT", nullable: true),
                    noofDays = table.Column<string>(type: "TEXT", nullable: true),
                    remainleaves = table.Column<string>(type: "TEXT", nullable: true),
                    reason = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeeleaves", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    holidaydate = table.Column<string>(type: "TEXT", nullable: true),
                    day = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    designation = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentsId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    DepartmentsId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designation_Departments_DepartmentsId1",
                        column: x => x.DepartmentsId1,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "TEXT", nullable: true),
                    lastname = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    confirmpassword = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentsId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    DepartmentsId = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    DesignationId = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    mobile = table.Column<string>(type: "TEXT", nullable: true),
                    joindate = table.Column<string>(type: "TEXT", nullable: true),
                    role = table.Column<string>(type: "TEXT", nullable: true),
                    employeeId = table.Column<string>(type: "TEXT", nullable: true),
                    company = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentsId1",
                        column: x => x.DepartmentsId1,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Designation_DesignationId1",
                        column: x => x.DesignationId1,
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designation_DepartmentsId1",
                table: "Designation",
                column: "DepartmentsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentsId1",
                table: "Employees",
                column: "DepartmentsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId1",
                table: "Employees",
                column: "DesignationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeeleaves");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
