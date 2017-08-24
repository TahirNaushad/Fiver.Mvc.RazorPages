using System;

namespace Fiver.Mvc.RazorPages.Pages.Movies
{
    public class MovieOutputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }

        public DateTime LastReadAt { get; set; }
    }
}
