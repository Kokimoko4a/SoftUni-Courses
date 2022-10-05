using System;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Player
    {
		public Player(string name,string position,double rating,int games)
		{
			this.Name = name;
			this.Position = position;
			this.Rating = rating;
			this.Games = games;
			this.Retired = false;
		}

		private string name;
		private string position;
		private double rating;
		private int games;
		private bool retired;

		public bool Retired
		{
			get { return retired; }
			set { retired = value; }
		}


		public int Games
		{
			get { return games; }
			set { games = value; }
		}

		public double Rating
		{
			get { return rating; }
			set { rating = value; }
		}

		public string Position
		{
			get { return position; }
			set { position = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public override string ToString() => $"-Player: {name}{Environment.NewLine}" +
            $"--Position: {position}{Environment.NewLine}" +
            $"--Rating: {rating}{Environment.NewLine}" +
            $"--Games played: {games}";

    }
}
