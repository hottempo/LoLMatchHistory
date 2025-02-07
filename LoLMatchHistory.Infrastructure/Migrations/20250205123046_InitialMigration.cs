using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoLMatchHistory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlueTeamTag = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BlueResult = table.Column<int>(type: "int", nullable: false),
                    RedResult = table.Column<int>(type: "int", nullable: false),
                    RedTeamTag = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GameLength = table.Column<int>(type: "int", nullable: false),
                    BlueTop = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueTopChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueJungle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueJungleChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueMiddle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueMiddleChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueADC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueADCChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueSupport = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlueSupportChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedTop = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedTopChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedJungle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedJungleChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedMiddle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedMiddleChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedADC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedADCChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedSupport = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RedSupportChamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GameHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.UniqueConstraint("AK_Matches_GameHash", x => x.GameHash);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ban1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ban2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ban3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ban4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ban5 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_MatchInfo",
                        column: x => x.GameHash,
                        principalTable: "Matches",
                        principalColumn: "GameHash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameHash = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min1 = table.Column<long>(type: "bigint", nullable: true),
                    Min2 = table.Column<long>(type: "bigint", nullable: true),
                    Min3 = table.Column<long>(type: "bigint", nullable: true),
                    Min4 = table.Column<long>(type: "bigint", nullable: true),
                    Min5 = table.Column<long>(type: "bigint", nullable: true),
                    Min6 = table.Column<long>(type: "bigint", nullable: true),
                    Min7 = table.Column<long>(type: "bigint", nullable: true),
                    Min8 = table.Column<long>(type: "bigint", nullable: true),
                    Min9 = table.Column<long>(type: "bigint", nullable: true),
                    Min10 = table.Column<long>(type: "bigint", nullable: true),
                    Min11 = table.Column<long>(type: "bigint", nullable: true),
                    Min12 = table.Column<long>(type: "bigint", nullable: true),
                    Min13 = table.Column<long>(type: "bigint", nullable: true),
                    Min14 = table.Column<long>(type: "bigint", nullable: true),
                    Min15 = table.Column<long>(type: "bigint", nullable: true),
                    Min16 = table.Column<long>(type: "bigint", nullable: true),
                    Min17 = table.Column<long>(type: "bigint", nullable: true),
                    Min18 = table.Column<long>(type: "bigint", nullable: true),
                    Min19 = table.Column<long>(type: "bigint", nullable: true),
                    Min20 = table.Column<long>(type: "bigint", nullable: true),
                    Min21 = table.Column<long>(type: "bigint", nullable: true),
                    Min22 = table.Column<long>(type: "bigint", nullable: true),
                    Min23 = table.Column<long>(type: "bigint", nullable: true),
                    Min24 = table.Column<long>(type: "bigint", nullable: true),
                    Min25 = table.Column<long>(type: "bigint", nullable: true),
                    Min26 = table.Column<long>(type: "bigint", nullable: true),
                    Min27 = table.Column<long>(type: "bigint", nullable: true),
                    Min28 = table.Column<long>(type: "bigint", nullable: true),
                    Min29 = table.Column<long>(type: "bigint", nullable: true),
                    Min30 = table.Column<long>(type: "bigint", nullable: true),
                    Min31 = table.Column<long>(type: "bigint", nullable: true),
                    Min32 = table.Column<long>(type: "bigint", nullable: true),
                    Min33 = table.Column<long>(type: "bigint", nullable: true),
                    Min34 = table.Column<long>(type: "bigint", nullable: true),
                    Min35 = table.Column<long>(type: "bigint", nullable: true),
                    Min36 = table.Column<long>(type: "bigint", nullable: true),
                    Min37 = table.Column<long>(type: "bigint", nullable: true),
                    Min38 = table.Column<long>(type: "bigint", nullable: true),
                    Min39 = table.Column<long>(type: "bigint", nullable: true),
                    Min40 = table.Column<long>(type: "bigint", nullable: true),
                    Min41 = table.Column<long>(type: "bigint", nullable: true),
                    Min42 = table.Column<long>(type: "bigint", nullable: true),
                    Min43 = table.Column<long>(type: "bigint", nullable: true),
                    Min44 = table.Column<long>(type: "bigint", nullable: true),
                    Min45 = table.Column<long>(type: "bigint", nullable: true),
                    Min46 = table.Column<long>(type: "bigint", nullable: true),
                    Min47 = table.Column<long>(type: "bigint", nullable: true),
                    Min48 = table.Column<long>(type: "bigint", nullable: true),
                    Min49 = table.Column<long>(type: "bigint", nullable: true),
                    Min50 = table.Column<long>(type: "bigint", nullable: true),
                    Min51 = table.Column<long>(type: "bigint", nullable: true),
                    Min52 = table.Column<long>(type: "bigint", nullable: true),
                    Min53 = table.Column<long>(type: "bigint", nullable: true),
                    Min54 = table.Column<long>(type: "bigint", nullable: true),
                    Min55 = table.Column<long>(type: "bigint", nullable: true),
                    Min56 = table.Column<long>(type: "bigint", nullable: true),
                    Min57 = table.Column<long>(type: "bigint", nullable: true),
                    Min58 = table.Column<long>(type: "bigint", nullable: true),
                    Min59 = table.Column<long>(type: "bigint", nullable: true),
                    Min60 = table.Column<long>(type: "bigint", nullable: true),
                    Min61 = table.Column<long>(type: "bigint", nullable: true),
                    Min62 = table.Column<long>(type: "bigint", nullable: true),
                    Min63 = table.Column<long>(type: "bigint", nullable: true),
                    Min64 = table.Column<long>(type: "bigint", nullable: true),
                    Min65 = table.Column<long>(type: "bigint", nullable: true),
                    Min66 = table.Column<long>(type: "bigint", nullable: true),
                    Min67 = table.Column<long>(type: "bigint", nullable: true),
                    Min68 = table.Column<long>(type: "bigint", nullable: true),
                    Min69 = table.Column<long>(type: "bigint", nullable: true),
                    Min70 = table.Column<long>(type: "bigint", nullable: true),
                    Min71 = table.Column<long>(type: "bigint", nullable: true),
                    Min72 = table.Column<long>(type: "bigint", nullable: true),
                    Min73 = table.Column<long>(type: "bigint", nullable: true),
                    Min74 = table.Column<long>(type: "bigint", nullable: true),
                    Min75 = table.Column<long>(type: "bigint", nullable: true),
                    Min76 = table.Column<long>(type: "bigint", nullable: true),
                    Min77 = table.Column<long>(type: "bigint", nullable: true),
                    Min78 = table.Column<long>(type: "bigint", nullable: true),
                    Min79 = table.Column<long>(type: "bigint", nullable: true),
                    Min80 = table.Column<long>(type: "bigint", nullable: true),
                    Min81 = table.Column<long>(type: "bigint", nullable: true),
                    Min82 = table.Column<long>(type: "bigint", nullable: true),
                    Min83 = table.Column<long>(type: "bigint", nullable: true),
                    Min84 = table.Column<long>(type: "bigint", nullable: true),
                    Min85 = table.Column<long>(type: "bigint", nullable: true),
                    Min86 = table.Column<long>(type: "bigint", nullable: true),
                    Min87 = table.Column<long>(type: "bigint", nullable: true),
                    Min88 = table.Column<long>(type: "bigint", nullable: true),
                    Min89 = table.Column<long>(type: "bigint", nullable: true),
                    Min90 = table.Column<long>(type: "bigint", nullable: true),
                    Min91 = table.Column<long>(type: "bigint", nullable: true),
                    Min92 = table.Column<long>(type: "bigint", nullable: true),
                    Min93 = table.Column<long>(type: "bigint", nullable: true),
                    Min94 = table.Column<long>(type: "bigint", nullable: true),
                    Min95 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gold_MatchInfo",
                        column: x => x.GameHash,
                        principalTable: "Matches",
                        principalColumn: "GameHash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: true),
                    Victim = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Killer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Assist_1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Assist_2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Assist_3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Assist_4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Xpos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ypos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kill_MatchInfo",
                        column: x => x.GameHash,
                        principalTable: "Matches",
                        principalColumn: "GameHash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monster_MatchInfo",
                        column: x => x.GameHash,
                        principalTable: "Matches",
                        principalColumn: "GameHash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: true),
                    Lane = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Structure_MatchInfo",
                        column: x => x.GameHash,
                        principalTable: "Matches",
                        principalColumn: "GameHash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bans_GameHash",
                table: "Bans",
                column: "GameHash");

            migrationBuilder.CreateIndex(
                name: "IX_Gold_GameHash",
                table: "Gold",
                column: "GameHash");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_GameHash",
                table: "Kills",
                column: "GameHash");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_GameHash",
                table: "Monsters",
                column: "GameHash");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_GameHash",
                table: "Structures",
                column: "GameHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Gold");

            migrationBuilder.DropTable(
                name: "Kills");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Structures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
