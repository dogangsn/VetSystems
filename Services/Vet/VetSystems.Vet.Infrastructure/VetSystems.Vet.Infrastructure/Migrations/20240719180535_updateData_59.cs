﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetSystems.Vet.Infrastructure.Migrations
{
    public partial class updateData_59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointmentinterval",
                table: "vetparameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "datetimestatus",
                table: "vetparameters",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointmentinterval",
                table: "vetparameters");

            migrationBuilder.DropColumn(
                name: "datetimestatus",
                table: "vetparameters");
        }
    }
}