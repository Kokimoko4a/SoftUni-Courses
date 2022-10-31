using System;
using System.Collections.Generic;

namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chatList = new List<string>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Chat")
                {
                    string chatItem = tokens[1];

                    chatList.Add(chatItem);
                }

                else if (action == "Delete")
                {
                    string message = tokens[1];

                    if (chatList .Contains (message ))
                    {
                        chatList.Remove(message);
                    }
                }

                else if (action == "Edit")
                {
                    string message = tokens[1];
                    string newMessage = tokens[2];

                    if (chatList .Contains (message ))
                    {
                        for (int i = 0; i < chatList .Count ; i++)
                        {

                            if (chatList[i] == message )
                            {
                                chatList[i] = newMessage;
                                break;
                            }
                        }
                    }             
                }

                else if (action == "Pin")
                {
                    string message = tokens[1];

                    if (chatList .Contains (message ))
                    {
                        for (int i = 0; i < chatList.Count ; i++)
                        {
                            if (chatList[i] == message )
                            {
                                chatList.Add(message);
                                chatList.Remove(message);
                            }
                        }
                    }                 
                }

                else if (action == "Spam")
                {
                    for (int i = 1; i < tokens .Length; i++)
                    {
                        string message = tokens[i];

                        chatList.Add(message);                  
                    }
                }

                command = Console .ReadLine ();
            }
        
            foreach (var message in chatList )
            {
                Console.WriteLine(message );
            }
        }
    }
}
