using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels = new HotelRepository();


        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) == null)
            {
                hotels.AddNew(new Hotel(hotelName, category));
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }

            return $"Hotel {hotelName} is already registered in our platform.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (hotels.All().All(x => x.Category != category))
            {
                return $"{category} star hotel is not available in our platform.";
            }

         

            foreach (var hotel in hotels.All().Where(x=>x.Category == category).OrderBy(x => x.FullName))
            {
                foreach (var room in hotel.Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity))
                {
                    if (room.BedCapacity >= adults+children)
                    {
                        int bookingNumber = hotel.Bookings.All().Count + 1;
                        var currHotel = hotels.All().First(x => x.FullName == hotel.FullName);
                        Booking booking = new Booking(room, duration, adults, children, bookingNumber);
                        currHotel.Bookings.AddNew(booking);
                        return $"Booking number {bookingNumber} for {currHotel.FullName} hotel is successful!";
                    }
                }
            };

            return "We cannot offer appropriate room for your request.";
        }

        public string HotelReport(string hotelName)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            /* "Hotel name: {hotelName}
             --{ Category} star hotel
             --Turnover: { hotelTurnover: F2} $
             --Bookings:*/

            var currHotel = hotels.All().First(x => x.FullName == hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{currHotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {currHotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();


            if (currHotel.Bookings.All().Any())
            {
                

                foreach (var booking in currHotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }

                return sb.ToString().TrimEnd();
            }

            sb.AppendLine("none");
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            else if (!(roomTypeName == "DoubleBed" || roomTypeName == "Apartment" || roomTypeName == "Studio"))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            var currHotel = hotels.All().First(x => x.FullName == hotelName);

            if (currHotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName) == null)
            {
                return "Room type is not created yet!";
            }

            var currRoom = currHotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);

             if (currRoom.PricePerNight>0)
            {
                throw new InvalidOperationException("Price is already set!");
            }

            var room = currHotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);
            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            var currHotel = hotels.All().First(x => x.FullName == hotelName);

            if (currHotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName) != null)
            {
                return "Room type is already created!";
            }

            else if (!(roomTypeName == "DoubleBed" || roomTypeName == "Apartment" || roomTypeName == "Studio"))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            Room room = null;

            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }

            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }

            if (roomTypeName == "Studio")
            {
                room = new Studio();
            }

            currHotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
