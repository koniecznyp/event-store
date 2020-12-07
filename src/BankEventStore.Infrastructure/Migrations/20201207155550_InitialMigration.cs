using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankEventStore.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AggregateType = table.Column<string>(nullable: true),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Version = table.Column<long>(nullable: false),
                    Timestamp = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStore", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStore");
        }
    }
}
