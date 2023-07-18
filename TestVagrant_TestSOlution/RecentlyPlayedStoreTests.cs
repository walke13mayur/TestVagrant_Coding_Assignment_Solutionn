using NUnit.Framework;
using TestVagant_Coding_Assignment;

[TestFixture]
public class RecentlyPlayedStoreTests
{
    /// <summary>
    /// this class contains test cases
    /// </summary>
    [Test]
    public void GetRecentlyPlayedSongs_WhenNoSongsPlayed_ReturnsEmptyList()
    {
        RecentlyPlayedStore store = new RecentlyPlayedStore(3);
        LinkedList<string> songs = store.GetRecentlyPlayedSongs("user1");
        Assert.IsEmpty(songs);
    }

    [Test]
    public void GetRecentlyPlayedSongs_WhenSongsPlayed_ReturnsRecentlyPlayedSongs()
    {
        RecentlyPlayedStore store = new RecentlyPlayedStore(3);
        store.AddSong("S1", "user1");
        store.AddSong("S2", "user1");
        store.AddSong("S3", "user1");

        LinkedList<string> songs = store.GetRecentlyPlayedSongs("user1");
        Assert.AreEqual(3, songs.Count);
        Assert.AreEqual("S3", songs.First.Value);
        Assert.AreEqual("S2", songs.First.Next.Value);
        Assert.AreEqual("S1", songs.First.Next.Next.Value);
    }

    [Test]
    public void AddSong_WhenCapacityExceeded_RemovesLeastRecentlyPlayedSong()
    {
        RecentlyPlayedStore store = new RecentlyPlayedStore(2);
        store.AddSong("S1", "user1");
        store.AddSong("S2", "user1");
        store.AddSong("S3", "user1");

        LinkedList<string> songs = store.GetRecentlyPlayedSongs("user1");
        Assert.AreEqual(2, songs.Count);
        Assert.AreEqual("S3", songs.First.Value);
        Assert.AreEqual("S2", songs.First.Next.Value);
    }

    [Test]
    public void GetRecentlyPlayedSongs_WhenDifferentUsers_ReturnsCorrectSongsPerUser()
    {
        RecentlyPlayedStore store = new RecentlyPlayedStore(3);
        store.AddSong("S1", "user1");
        store.AddSong("S2", "user2");
        store.AddSong("S3", "user1");

        LinkedList<string> songsUser1 = store.GetRecentlyPlayedSongs("user1");
        Assert.AreEqual(2, songsUser1.Count);
        Assert.AreEqual("S3", songsUser1.First.Value);
        Assert.AreEqual("S1", songsUser1.First.Next.Value);

        LinkedList<string> songsUser2 = store.GetRecentlyPlayedSongs("user2");
        Assert.AreEqual(1, songsUser2.Count);
        Assert.AreEqual("S2", songsUser2.First.Value);
    }
}
