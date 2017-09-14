using Fiver.Mvc.RazorPages.OtherLayers;
using Fiver.Mvc.RazorPages.Pages.Movies;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Fiver.Mvc.RazorPages.Testing
{
    public class MoviesIndexTests
    {
        [Fact(DisplayName = "OnGet_populates_Movies_property")]
        public void OnGet_populates_Movies_property()
        {
            // Arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(service => service.GetMovies()).Returns(new List<Movie>());

            var sut = new IndexModel(mockService.Object);

            // Act
            sut.OnGet();

            // Assert
            Assert.Equal(
                expected: 0,
                actual: sut.Movies.Count);
        }

        [Fact(DisplayName = "OnGetDelete_with_invalid_Id_returns_page_itself")]
        public void OnGetDelete_with_invalid_Id_returns_RedirectToPage()
        {
            // Arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(service => service.MovieExists(It.IsAny<int>())).Returns(false);

            var sut = new IndexModel(mockService.Object);

            // Act
            var result = sut.OnGetDelete1(0);
            
            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact(DisplayName = "OnGetDelete_with_valid_Id_calls_DeleteMovie_and_returns_RedirectToPage")]
        public void OnGetDelete_with_valid_Id_calls_DeleteMovie_and_returns_RedirectToPage()
        {
            // Arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(service => service.MovieExists(It.IsAny<int>())).Returns(true);

            var sut = new IndexModel(mockService.Object);

            // Act
            var result = sut.OnGetDelete1(1);

            // Assert
            mockService.Verify(service =>
                service.DeleteMovie(It.IsAny<int>()), Times.Once);

            var redirectResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(expected: "./Index", actual: redirectResult.PageName);
        }
    }
}
