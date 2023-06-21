using ASP.NET_TaskBoard_App.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_TaskBoard_App.Configuration
{
    public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(GenerateBoards());
        }

        private ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new List<Board>();

            Board board = new Board()
            {
                Id = 1
            };

            boards.Add(board);

            board = new Board()
            {
                Id = 2
            };

            boards.Add(board);

            board = new Board()
            {
                Id = 3
            };

            boards.Add(board);

            return boards;
        }
    }
}

