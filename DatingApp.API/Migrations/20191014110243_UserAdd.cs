﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class UserAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
  migrationBuilder.CreateTable(
                name:"Users",
                columns: table => new 
                {
                    Id =table.Column<int>(nullable:false).Annotation("Sqlite:AutoIncrement",true),
                    Username=table.Column<string>(nullable:true),
                    PasswordHash=table.Column<byte[]>(nullable:true),
                    PasswordSalt=table.Column<byte[]>(nullable:true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users",x=>x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}