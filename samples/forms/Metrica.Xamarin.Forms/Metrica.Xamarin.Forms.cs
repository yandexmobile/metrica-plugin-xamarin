using System;
using System.Collections.Generic;
using YandexMetricaPCL;
using Xamarin.Forms;

namespace Metrica.Xamarin.Forms
{
    public class App : Application
    {
        static int clicksCount = 0;
        static int errorsCount = 0;

        public static string ApiKey()
        {
            // Return your API key here.
            throw new NotImplementedException();
        }

        public App()
        {
            var clickButton = new Button {
                Text = "Log click",
            };
            clickButton.Clicked += (sender, e) => {
                ++clicksCount;

                var dict = new Dictionary<string, string>{
                    { "click", clicksCount.ToString() },
                };
                YandexMetrica.Implementation.ReportEvent("Click from Forms", dict);

                clickButton.Text = string.Format("{0} clicks logged", clicksCount);
            };

            var errorButton = new Button {
                Text = "Log error",
            };
            errorButton.Clicked += (sender, e) => {
                ++errorsCount;

                try {
                    throw new Exception(string.Format("I'm exception #{0}", errorsCount));
                } catch (Exception ex) {
                    YandexMetrica.Implementation.ReportError("Error from Forms", ex);
                }

                errorButton.Text = string.Format("{0} errors logged", errorsCount);
            };

            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Hello! I'm AppMetrica Xamarin Forms sample."
                        },
                        clickButton,
                        errorButton
                    }
                }
            };
        }
    }
}

