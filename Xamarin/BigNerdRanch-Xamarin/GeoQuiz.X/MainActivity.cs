using Android.App;
using Android.Widget;
using Android.OS;

namespace GeoQuiz.X
{
	[Activity(Label = "GeoQuiz.X", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : Activity
	{
		private Button _trueButton;
		private Button _falseButton;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			_trueButton = FindViewById<Button>(Resource.Id.TrueButton);
			_falseButton = FindViewById<Button>(Resource.Id.FalseButton);

			_trueButton.Click += delegate
			{
				Toast.MakeText(this, Resource.String.IncorrectToast, ToastLength.Short).Show();
			};
			_falseButton.Click += delegate
			{
				Toast.MakeText(this, Resource.String.CorrectToast, ToastLength.Short).Show();
			};
		}
	}
}

