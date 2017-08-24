using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Mvc.RazorPages.OtherLayers;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService service;

        public IndexModel(IMovieService service)
        {
            this.service = service;
        }

        public List<MovieOutputModel> Movies { get; set; }

        public void OnGet()
        {
            this.Movies = ToOutputModel(this.service.GetMovies());
        }

        public IActionResult OnGetDelete1(int id)
        {
            if (!service.MovieExists(id))
                return RedirectToPage("./Index");

            service.DeleteMovie(id);

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDelete2(int id)
        {
            if (!service.MovieExists(id))
                return RedirectToPage("./Index");

            service.DeleteMovie(id);

            return RedirectToPage("./Index");
        }

        #region " Mappings "

        private MovieOutputModel ToOutputModel(Movie model)
        {
            return new MovieOutputModel
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary,
                LastReadAt = DateTime.Now
            };
        }

        private List<MovieOutputModel> ToOutputModel(List<Movie> model)
        {
            return model.Select(item => ToOutputModel(item))
                        .ToList();
        }
        
        #endregion
    }
}