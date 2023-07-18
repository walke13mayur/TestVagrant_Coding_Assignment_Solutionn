using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace TestVagant_Coding_Assignment
{
    class RecentlyPlayedStore
    {
        private int capacity;
        private int currentSize;
        private SongNode head;
        private SongNode tail;
        private Dictionary<string, SongNode> songMap;

        public RecentlyPlayedStore(int initialCapacity)
        {
            capacity = initialCapacity;
            currentSize = 0;
            head = null;
            tail = null;
            songMap = new Dictionary<string, SongNode>();
        }

        public void AddSong(string song, string user)
        {
            if (currentSize == capacity)
            {
                RemoveLeastRecentlyPlayed();
            }

            SongNode newNode = new SongNode(song, user);
            songMap[song] = newNode;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            currentSize++;
        }

        private void RemoveLeastRecentlyPlayed()
        {
            if (tail != null)
            {
                songMap.Remove(tail.Song);
                tail = tail.Prev;
                if (tail != null)
                {
                    tail.Next = null;
                }
                currentSize--;
            }
        }

        public LinkedList<string> GetRecentlyPlayedSongs(string user)
        {
            LinkedList<string> result = new LinkedList<string>();
            SongNode current = head;
            while (current != null)
            {
                if (current.User == user)
                {
                    result.AddLast(current.Song);
                }
                current = current.Next;
            }
            return result;
        }
    }
}
