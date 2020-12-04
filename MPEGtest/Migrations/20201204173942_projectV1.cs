using Microsoft.EntityFrameworkCore.Migrations;

namespace MPEGtest.Migrations
{
    public partial class projectV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mpeg",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    concept = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    time = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    relation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mpeg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AgentMpeg",
                columns: table => new
                {
                    AgentsId = table.Column<int>(type: "int", nullable: false),
                    MpegsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentMpeg", x => new { x.AgentsId, x.MpegsId });
                    table.ForeignKey(
                        name: "FK_AgentMpeg_agent_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "agent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentMpeg_mpeg_MpegsId",
                        column: x => x.MpegsId,
                        principalTable: "mpeg",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentMpeg_MpegsId",
                table: "AgentMpeg",
                column: "MpegsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentMpeg");

            migrationBuilder.DropTable(
                name: "agent");

            migrationBuilder.DropTable(
                name: "mpeg");
        }
    }
}
