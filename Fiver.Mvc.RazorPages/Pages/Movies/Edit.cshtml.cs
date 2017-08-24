using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Mvc.RazorPages.OtherLayers;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.RazorPages.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieService service;

        public EditModel(IMovieService service)
        {
            this.service = service;
        }

        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public IActionResult OnGet(int id)
        {
            var model = this.service.GetMovie(id);
            if (model == null)
                return RedirectToPage("./Index");

            this.Movie = ToInputModel(model);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var model = ToDomainModel(this.Movie);
            service.UpdateMovie(model);

            return RedirectToPage("./Index");
        }

        #region " Mappings "
        
        private MovieInputModel ToInputModel(Movie model)
        {
            return new MovieInputModel
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary
            };
        }

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