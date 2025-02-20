using System;
using System.ComponentModel.DataAnnotations;

namespace LoLMatchHistory.Infrastructure.Models
{
    public class ApiRequestLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string Endpoint { get; set; } = string.Empty;

        [Required]
        public long DurationMilliseconds { get; set; }
    }
}
