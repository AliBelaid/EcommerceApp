using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class HraddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designation_Departments_DepartmentsId1",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsId1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designation_DesignationId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentsId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Designation_DepartmentsId1",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "DepartmentsId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentsId1",
                table: "Designation");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Designation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentsId",
                table: "Employees",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_DepartmentsId",
                table: "Designation",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_Departments_DepartmentsId",
                table: "Designation",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsId",
                table: "Employees",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designation_DesignationId",
                table: "Employees",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designation_Departments_DepartmentsId",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designation_DesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Designation_DepartmentsId",
                table: "Designation");

            migrationBuilder.AlterColumn<string>(
                name: "DesignationId",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentsId",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId1",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesignationId1",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentsId",
                table: "Designation",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId1",
                table: "Designation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentsId1",
                table: "Employees",
                column: "DepartmentsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId1",
                table: "Employees",
                column: "DesignationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_DepartmentsId1",
                table: "Designation",
                column: "DepartmentsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_Departments_DepartmentsId1",
                table: "Designation",
                column: "DepartmentsId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsId1",
                table: "Employees",
                column: "DepartmentsId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designation_DesignationId1",
                table: "Employees",
                column: "DesignationId1",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
