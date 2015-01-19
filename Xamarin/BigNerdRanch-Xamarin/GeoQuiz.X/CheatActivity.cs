using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GeoQuiz.X
{
	[Activity(Label = "CheatActivity", Theme = "@android:style/Theme.Holo.Light")]
	public class CheatActivity : Activity
	{
		public const string ExtraAnswerIsTrue = "com.PlayfulPlatypus.BigNerdRanch.GeoQuiz.Extra.AnswerIsTrue";
		public const string ExtraDidTheyCheat = "com.PlayfulPlatypus.BigNerdRanch.GeoQuiz.Extra.DidTheyCheat";
		private const string KeyDidTheyCheat = "DidTheyCheat";
		private Button _showAnswerButton;
		private TextView _answerTextView;
		private bool _answerIsTrue;
		private bool _didTheyCheat;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Cheat);
			if (bundle != null)
			{
				_answerIsTrue = Intent.GetBooleanExtra(ExtraAnswerIsTrue, false);
				_didTheyCheat = bundle.GetBoolean(KeyDidTheyCheat);
			}
			_answerTextView = FindViewById<TextView>(Resource.Id.AnswerTextView);
			_showAnswerButton = FindViewById<Button>(Resource.Id.ShowAnswerButton);
			_showAnswerButton.Click += (sender, args) => ShowAnswer();
			if (_didTheyCheat)
			{
				ShowAnswer();
			}
			SetCheatResult(_didTheyCheat);
		}

		private void ShowAnswer()
		{
			_answerTextView.Text = GetString(_answerIsTrue ? Resource.String.TrueButton : Resource.String.FalseButton);
			SetCheatResult(true);
		}

		private void SetCheatResult(bool didTheyCheat)
		{
			_didTheyCheat = didTheyCheat;
			var i = new Intent();
			i.PutExtra(ExtraDidTheyCheat, _didTheyCheat);
			SetResult(Result.Ok, i);
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			outState.PutBoolean(KeyDidTheyCheat,_didTheyCheat);
		}
	}
}