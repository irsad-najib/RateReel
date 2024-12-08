using Microsoft.Maui.Controls;
using RateReel.Models;
using System;

namespace RateReel.Pages.Homepage
{
    public partial class FilmDetailsPage : ContentPage
    {
        private Film CurrentFilm;

        public FilmDetailsPage(Film film)
        {
            InitializeComponent();
            LoadFilmDetails(film);
            CurrentFilm = film;
        }

        private void LoadFilmDetails(Film film)
        {
            PosterImage.Source = film.PosterUrl;
            TitleLabel.Text = film.Title;
            YearLabel.Text = $"Year: {film.Year}";
            RatingLabel.Text = $"Rating: {film.Rating}";
            DescriptionLabel.Text = film.Description;
        }

        private async void OnSubmitReviewClicked(object sender, EventArgs e)
        {
            var rating = Math.Round(RatingSlider.Value, 1);
            var reviewText = ReviewEditor.Text?.Trim();

            if (string.IsNullOrEmpty(reviewText))
            {
                await DisplayAlert("Error", "Please enter a review.", "OK");
                return;
            }

            var newReview = new Review
            {
                Username = "User", // Replace with actual user logic
                MovieTitle = CurrentFilm.Title,
                Rating = rating,
                ReviewText = reviewText,
                PosterUrl = CurrentFilm.PosterUrl
            };

            // Add the new review to the global Reviews collection
            App.Reviews.Add(newReview);

            await DisplayAlert("Success", "Your review has been submitted.", "OK");

            // Clear input fields
            RatingSlider.Value = 3;
            ReviewEditor.Text = string.Empty;
        }
    }
}