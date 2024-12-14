using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace RateReel.Converters
{
    public class RatingToStarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double rating)
            {
                int fullStars = (int)Math.Floor(rating);
                bool halfStar = (rating - fullStars) >= 0.5;
                int emptyStars = 5 - fullStars - (halfStar ? 1 : 0);

                string stars = new string('★', fullStars);
                if (halfStar)
                    stars += "½";
                stars += new string('☆', emptyStars);

                return stars;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}