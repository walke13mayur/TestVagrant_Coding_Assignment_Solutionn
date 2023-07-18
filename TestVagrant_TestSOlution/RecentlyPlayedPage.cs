using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVagant_Coding_Assignment
{
    /// <summary>
    /// it contains logic for RecentlyPlayedStore
    /// </summary>
    class RecentlyPlayedPage
    {
        private RecentlyPlayedStore store;

        public RecentlyPlayedPage(RecentlyPlayedStore store)
        {
            this.store = store;
        }

        public void AddSong(string song, string user)
        {
            store.AddSong(song, user);
        }

        public LinkedList<string> GetRecentlyPlayedSongs(string user)
        {
            return store.GetRecentlyPlayedSongs(user);
        }
    }

}
