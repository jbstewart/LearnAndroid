using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using CriminalIntent.X.Model;

namespace CriminalIntent.X
{
	public class CrimeFragment : Fragment
	{
		private Crime _crime;
		private EditText _titleTextEdit;
		private Button _dateButton;
		private CheckBox _solvedCheckBox;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			_crime = new Crime();
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var v = inflater.Inflate(Resource.Layout.CrimeFragment, container, false);
			
			_titleTextEdit = v.FindViewById<EditText>(Resource.Id.CrimeTitle);
			_titleTextEdit.TextChanged += (sender, args) =>
			{
				_crime.Title = args.Text.ToString();
			};
			_titleTextEdit.BeforeTextChanged += (sender, args) =>
			{

			};
			_titleTextEdit.AfterTextChanged += (sender, args) =>
			{

			};

			_dateButton = v.FindViewById<Button>(Resource.Id.CrimeDate);
			_dateButton.Text = _crime.Date.ToLongDateString();
			_dateButton.Enabled = false;

			_solvedCheckBox = v.FindViewById<CheckBox>(Resource.Id.CrimeSolved);
			_solvedCheckBox.CheckedChange += (sender, args) =>
			{
				_crime.Solved = _solvedCheckBox.Checked;
			};
			
			return v;
		}
	}
}