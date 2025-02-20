using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoLMatchHistory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchInfoOptimizedView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW [dbo].[MatchInfoOptimizedView] AS
            SELECT 
            m.GameHash,
            m.Year, 
            m.League,
            m.Season, 
            m.Type AS MatchType,
            (SELECT COUNT(*) FROM Kills k WHERE k.GameHash = m.GameHash AND k.Team = 'rKills') AS RedKills,
            (SELECT COUNT(*) FROM Kills k WHERE k.GameHash = m.GameHash AND k.Team = 'bKills') AS BlueKills,
            b.Team, 
            b.Ban1, 
            b.Ban2, 
            b.Ban3, 
            b.Ban4, 
            b.Ban5 
            FROM Matches m 
            JOIN Bans b ON m.GameHash = b.GameHash;
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS MatchInfoOptimizedView;");


        }
    }
}
