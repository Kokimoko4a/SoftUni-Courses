using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Team 
    {
        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(280)]
        public string LogoUrl { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Initials { get; set; } = null!;

        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; } = null!;


        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public Town Town { get; set; } = null!;

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; } = null!;

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; } = null!;

        public ICollection<Player> Players { get; set; }
    }
}