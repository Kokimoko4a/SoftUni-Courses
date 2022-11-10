using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;


        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return residenceDuration; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }

                residenceDuration = value;

            }
        }

        public int AdultsCount
        {
            get { return adultsCount; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }

                adultsCount = value;

            }
        }
        public int ChildrenCount
        {
            get { return childrenCount; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }

                childrenCount = value;

            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            return $"Booking number: {BookingNumber}{Environment.NewLine}" +
        $"Room type: {Room.GetType().Name}{Environment.NewLine}" +
        $"Adults: {AdultsCount} Children: {ChildrenCount}{Environment.NewLine}" +
            $"Total amount paid: {(Room.PricePerNight * ResidenceDuration):F2} $";
        }
    }
}
