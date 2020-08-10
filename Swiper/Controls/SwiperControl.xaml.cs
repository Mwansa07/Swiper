using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Swiper.Utils;

namespace Swiper.Controls
{
    public partial class SwiperControl : ContentView
    {
        private readonly double _initialRotation;
        private static readonly Random _random = new Random();

        public SwiperControl()
        {
            InitializeComponent();

            var picture = new Picture();
            descriptionLabel.Text = picture.Description;
            image.Source = new UriImageSource() { Uri = picture.Uri };

            loadingLabel.SetBinding(IsVisibleProperty, "IsLoading");
            loadingLabel.BindingContext = image;
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    PanStarted();
                    break;

                case GestureStatus.Running:
                    PanRunning(e);
                    break;

                case GestureStatus.Completed:
                    PanCompleted();
                    break;
            }
        }

        private void PanCompleted()
        {
            photo.TranslateTo(0, 0, 250, Easing.SpringOut);
            photo.RotateTo(_initialRotation, 250, Easing.SpringOut);
            photo.ScaleTo(1, 250);
        }

        private void PanRunning(PanUpdatedEventArgs e)
        {
            photo.TranslationX = e.TotalX;
            photo.TranslationY = e.TotalY;
            photo.Rotation = _initialRotation + (photo.TranslationX / 25);
        }

        private void PanStarted()
        {
            photo.ScaleTo(1.1, 100);
        }
    }
}
