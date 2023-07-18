namespace TestVagant_Coding_Assignment
{
    class SongNode
    {
        public string Song { get; }
        public string User { get; }
        public SongNode Next { get; set; }
        public SongNode Prev { get; set; }

        public SongNode(string song, string user)
        {
            Song = song;
            User = user;
            Next = null;
            Prev = null;
        }
    }
}
