using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoLMatchHistory.Infrastructure.Models
{
    public class ApiRequestLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RequestDate { get; init; }

        [Required]
        public string Endpoint { get; set; } = string.Empty;

        [Required]
        public long DurationMilliseconds { get; set; }
    }
}
