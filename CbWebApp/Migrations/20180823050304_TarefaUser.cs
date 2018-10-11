using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CbWebApp.Migrations
{
    public partial class TarefaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_AspNetUsers_UserId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "UserId",
                table: "Tarefas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UserId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tarefas",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_AspNetUsers_UserId",
                table: "Tarefas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
