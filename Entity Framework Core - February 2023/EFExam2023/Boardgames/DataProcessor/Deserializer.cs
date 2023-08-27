namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Metrics;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            //Do not forget about year range         
            XmlRootAttribute root = new XmlRootAttribute("Creators");
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(CreatorsImportDto[]),root);
            StringReader stringReader= new StringReader(xmlString);

            CreatorsImportDto[] creatorsDto = (CreatorsImportDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var creatorDto in creatorsDto)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator validCreator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame validBoardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };

                    validCreator.Boardgames.Add(validBoardgame);
                }

                sb.AppendLine($"Successfully imported creator – {validCreator.FirstName} {validCreator.LastName} with {validCreator.Boardgames.Count} boardgames.");
                context.Creators.Add(validCreator);
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder(); 
            SellerImportDto[] sellersDto = JsonConvert.DeserializeObject<SellerImportDto[]>(jsonString);

            foreach (var sellerDto in sellersDto)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller validSeller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var boardgamesId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(b => b.Id == boardgamesId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validSeller.BoardgamesSellers.Add(new BoardgameSeller() { SellerId = validSeller.Id, BoardgameId = boardgamesId });
                }

                sb.AppendLine($"Successfully imported seller - {validSeller.Name} with {validSeller.BoardgamesSellers.Count} boardgames.");
                context.Sellers.Add(validSeller);
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
