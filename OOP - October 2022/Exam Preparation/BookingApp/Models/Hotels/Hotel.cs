using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{


    public class Hotel : IHotel
    {
        private RoomRepository rooms = new RoomRepository();
        private BookingRepository bookings = new BookingRepository();
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
        }

        public string FullName
        {
            get { return fullName; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }

        public int Category
        {

            get { return category; }

            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                category = value;
            }

        }

        public double Turnover { get { return Math.Round(Bookings.All().Sum(b => b.Room.PricePerNight * b.ResidenceDuration), 2); } }

        public IRepository<IRoom> Rooms { get { return rooms; } }
        public IRepository<IBooking> Bookings { get { return bookings; } }          
       
    }
}