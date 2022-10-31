using System;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
            int countOfStartingPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStartingPieces; i++)
            {
                string[] tokens = Console.ReadLine().Split("|");
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];
                Piece currPiece = new Piece(composer, key);
                pieces.Add(piece, currPiece);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command.Split("|");
                string action = tokens[0];

                if (action == "Add")
                {
                    string piece = tokens[1];
                    string composer = tokens[2];
                    string key = tokens[3];
                    Piece currPiece = new Piece(composer, key);

                    if (!pieces.ContainsKey(piece))
                    {
                        pieces[piece] = currPiece;
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }

                else if (action == "Remove")
                {
                    string piece = tokens[1];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                else if (action == "ChangeKey")
                {
                    string piece = tokens[1];
                    string newKey = tokens[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].KeyOfPiece = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.KeyOfPiece}");
            }
        }
    }

    class Piece
    {
        public Piece(string composer, string key)
        {
            Composer = composer;
            KeyOfPiece = key;
        }

        public string Composer { get; set; }
        public string KeyOfPiece { get; set; }

    }
}
