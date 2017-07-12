using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FileUploader
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new FileUploaderPage();
		}

		protected override void OnStart()
		{
            Push.PushNotificationReceived += (sender, e) => {

                // Add the notification message and title to the message
                var summary = $"Push notification received:" +
                                    $"\n\tNotification title: {e.Title}" +
                                    $"\n\tMessage: {e.Message}";

                // If there is custom data associated with the notification,
                // print the entries
                if (e.CustomData != null)
                {
                    summary += "\n\tCustom data:\n";
                    foreach (var key in e.CustomData.Keys)
                    {
                        summary += $"\t\t{key} : {e.CustomData[key]}\n";
                    }
                }

                // Send the notification summary to debug output
                System.Diagnostics.Debug.WriteLine(summary);
            };

            MobileCenter.SetLogUrl("https://in-staging-south-centralus.staging.avalanch.es");
            MobileCenter.Start("uwp=0cfe44f1-afdf-4b32-97e4-46e0fc73bbca;" +
                      "android={Your Android App secret here}" +
                      "ios={Your iOS App secret here}",
                      typeof(Analytics), typeof(Crashes),typeof(Push));
            Analytics.TrackEvent("Upload clicked");

            // Handle when your app starts
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
