using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Mvc.RazorPages.OtherLayers;

namespace Fiver.Mvc.RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService service;

        public CreateModel(IMovieService service)
        {
            this.service = service;
        }

        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public void OnGet()
        {
            this.Movie = new MovieInputModel();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var model = ToDomainModel(this.Movie);
            service.AddMovie(model);

            return RedirectToPage("./Index");
        }

        #region " Mappings "
        
        private Movie ToDomainModel(MovieInputModel inputModel)
        {
            return new Movie
            {
                Id = inputModel.Id,
                Title = inputModel.Title,
                ReleaseYear = inputModel.ReleaseYear,
                Summary = inputModel.Summary
            };
        }

        #endregion
    }
}