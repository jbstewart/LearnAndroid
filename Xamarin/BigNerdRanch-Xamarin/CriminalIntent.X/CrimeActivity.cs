using Android.App;
using Android.OS;
using Android.Support.V4.App;


namespace CriminalIntent.X
{
	[Activity(Label = "CriminalIntent.X", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light.DarkActionBar")]
	public sealed class CrimeActivity : FragmentActivity
	{
		public CrimeActivity()
		{
			
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Crime);
			var fragment = SupportFragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment != null) return;
			fragment = new CrimeFragment();
			SupportFragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
		}
	}
}

