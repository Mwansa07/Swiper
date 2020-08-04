using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Swiper.Utils;

namespace Swiper.Controls
{
    public partial class SwiperControl : ContentView
    {
        public SwiperControl()
        {
            InitializeComponent();
            var picture = new Picture();
            descriptionLabel.Text = picture.Description;
            image.Source = new UriImageSource() { Uri = picture.Uri };
        }
    }
}
