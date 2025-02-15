using System.ComponentModel.DataAnnotations.Schema;

namespace LoLMatchHistory.Infrastructure.Models
{
    [Table("MatchInfoOptimizedView")]
    public class MatchInfoOptimizedView
    {
        public string GameHash { get; set; }
        public int Year { get; set; }
        public string League { get; set; }
        public string Season { get; set; }
        public string MatchType { get; set; }
        public int RedKills { get; set; }
        public int BlueKills { get; set; }

        public string Team { get; set; }
        public string? Ban1 { get; set; }
        public string? Ban2 { get; set; }
        public string? Ban3 { get; set; }
        public string? Ban4 { get; set; }
        public string? Ban5 { get; set; }
    }
}
