using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // VIDEO 1: Cooking Tutorial
        Video video1 = new Video("How to Cook Jollof Rice", "ChefKwame", 425);
        video1.AddComment(new Comment("Ama", "This looks so delicious! Trying it tonight."));
        video1.AddComment(new Comment("Kweku", "Best Jollof recipe I've seen!"));
        video1.AddComment(new Comment("Adwoa", "Can you make a video on Fufu next?"));
        video1.AddComment(new Comment("Yaw", "My family loved this recipe. Thanks!"));
        videos.Add(video1);

        // VIDEO 2: Programming Tutorial
        Video video2 = new Video("C# for Beginners", "CodeMaster", 1200);
        video2.AddComment(new Comment("Akosua", "Great explanation of classes!"));
        video2.AddComment(new Comment("Kwadwo", "Finally understand encapsulation!"));
        video2.AddComment(new Comment("Esi", "Please make more C# tutorials."));
        videos.Add(video2);

        // VIDEO 3: Music Video
        Video video3 = new Video("Afrobeats Mix 2024", "DJVibes", 3600);
        video3.AddComment(new Comment("Kwesi", "Fire mix! Playing this at my party."));
        video3.AddComment(new Comment("Akosua", "Where can I find the tracklist?"));
        video3.AddComment(new Comment("Mensah", "Best DJ in Ghana hands down!"));
        video3.AddComment(new Comment("Efua", "Can you drop the full playlist?"));
        videos.Add(video3);

        // VIDEO 4: Fitness Video
        Video video4 = new Video("10-Minute Morning Workout", "FitLife", 600);
        video4.AddComment(new Comment("Kofi", "Perfect for busy mornings!"));
        video4.AddComment(new Comment("Yaa", "I feel energized after doing this."));
        video4.AddComment(new Comment("Kwesi", "Great routine, easy to follow."));
        videos.Add(video4);

        // DISPLAY ALL VIDEOS
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}