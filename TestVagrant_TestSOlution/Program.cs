using System;
using System.Collections.Generic;

namespace TestVagant_Coding_Assignment
{
    /// <summary>
    /// I have implemented POM where this class is having main Logic
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RecentlyPlayedStore store = new RecentlyPlayedStore(3);
            RecentlyPlayedPage page = new RecentlyPlayedPage(store);

            page.AddSong("S1", "user1");
            page.AddSong("S2", "user1");
            page.AddSong("S3", "user1");

            LinkedList<string> songs = page.GetRecentlyPlayedSongs("user1");
            Console.WriteLine(string.Join(", ", songs)); // Output: S3, S2, S1

            page.AddSong("S4", "user1");
            page.AddSong("S2", "user1");
            page.AddSong("S1", "user1");

            songs = page.GetRecentlyPlayedSongs("user1");
            Console.WriteLine(string.Join(", ", songs)); // Output: S1, S2, S4
        }
    }
}
