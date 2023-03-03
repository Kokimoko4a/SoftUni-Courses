namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            // Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums.ToArray().Select(x => new
            {
                x.ProducerId,
                AlbumName = x.Name,
                ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = x.Producer.Name,
                TotalPrice = x.Price,
                Songs = x.Songs!.Select(s => new
                {
                    s.Name,
                    Price = s.Price.ToString("f2"),
                    WriterName = s.Writer.Name

                }).OrderByDescending(s => s.Name)
                .ThenBy(a => a.WriterName)
            }).Where(p => p.ProducerId == producerId).OrderByDescending(al => al.TotalPrice).ToArray();



            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int number = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{number++}");

                    sb.AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs.ToArray().Where(s => s.Duration.TotalSeconds > duration).Select(s => new
            {
                Duration = s.Duration.ToString("c"),
                SongName = s.Name,
                Performers = s.SongPerformers.Select(sp => new
                {
                    PerformerName = sp.Performer.FirstName + " " + sp.Performer.LastName,
                }).OrderBy(sp => sp.PerformerName).ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album!.Producer.Name,
            }).OrderBy(x => x.SongName).ThenBy(x => x.WriterName).ToArray();

            int number = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{number++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");


                if (song.Performers.Length != 0)
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer.PerformerName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
