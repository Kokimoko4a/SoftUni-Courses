namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            /* StringBuilder sb = new StringBuilder();
             XmlRootAttribute root = new XmlRootAttribute("Despatchers");
             XmlSerializer xmlSerializer = new XmlSerializer(typeof(DespatchersImportDto[]), root);
             XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
             ns.Add(string.Empty, string.Empty);
             StringReader stringReader = new StringReader(xmlString);

             DespatchersImportDto[] despatchersDto = (DespatchersImportDto[])xmlSerializer.Deserialize(stringReader);

             foreach (var despatcherDto in despatchersDto)
             {
                 if (!IsValid(despatcherDto))
                 {
                     sb.AppendLine(ErrorMessage);
                     continue;
                 }

                 Despatcher validDespatcher = new Despatcher()
                 {
                     Name = despatcherDto.Name,
                     Position = despatcherDto.Position,
                 };

                 foreach (var truckDto in despatcherDto.Trucks)
                 {
                     if (!IsValid(truckDto))
                     {
                         sb.AppendLine(ErrorMessage);
                         continue;
                     }

                     Truck validTruck = new Truck()
                     {
                         RegistrationNumber = truckDto.RegistrationNumber,
                         VinNumber = truckDto.VinNumber,
                         TankCapacity = truckDto.TankCapacity,
                         CargoCapacity = truckDto.CargoCapacity,
                         CategoryType = (CategoryType)truckDto.CategoryType,
                         MakeType = (MakeType)truckDto.MakeType
                     };

                     context.Trucks.Add(validTruck);
                     validDespatcher.Trucks.Add(validTruck);
                 }

                 sb.AppendLine($"Successfully imported despatcher - {validDespatcher.Name} with {validDespatcher.Trucks.Count} trucks.");
                 context.Despatchers.Add(validDespatcher);
             }

             context.SaveChanges();

             return sb.ToString().TrimEnd();*/
            return null;
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            /*StringBuilder sb = new StringBuilder();

            ClientImportDto[] clientsDto = JsonConvert.DeserializeObject<ClientImportDto[]>(jsonString);

            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientDto) || clientDto.Nationality == "usual" || clientDto.Type == "usual" || clientDto.Name == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    if (context.Trucks.All(t => t.Id != truckId) || !IsValid(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validClient.ClientsTrucks.Add(new ClientTruck() { TruckId = truckId, ClientId = validClient.Id });
                }

                sb.AppendLine($"Successfully imported client - {validClient.Name} with {validClient.ClientsTrucks.Count} trucks.");
                context.Clients.Add(validClient);
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();*/
            return null;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}