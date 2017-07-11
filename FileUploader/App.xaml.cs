using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;

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
            MobileCenter.Start("uwp=0cfe44f1-afdf-4b32-97e4-46e0fc73bbca;" +
                      "android={Your Android App secret here}" +
                      "ios={Your iOS App secret here}",
                      typeof(Analytics));

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
