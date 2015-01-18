using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.OS;

namespace GeoQuiz.X
{
	public class TrueFalse
	{
		public string QuestionText { get; private set; }
		public bool Answer { get; private set; }

		public TrueFalse(string text, bool answer)
		{
			QuestionText = text;
			Answer = answer;
		}
	}

	[Activity(Label = "GeoQuiz.X", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]
	public sealed class MainActivity : Activity
	{
		private Button _trueButton;
		private Button _falseButton;
		private ImageButton _nextButton;
		private TextView _questionTextView;
		private int _currentQuestionIndex;
		private readonly List<TrueFalse> _questionBank = new List<TrueFalse>();
		private const string Tag = "MainActivity";
		private const string KeyIndex = "index";


		public MainActivity()
		{
		}


		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			_trueButton = FindViewById<Button>(Resource.Id.TrueButton);
			_falseButton = FindViewById<Button>(Resource.Id.FalseButton);
			_nextButton = FindViewById<ImageButton>(Resource.Id.NextButton);
			_questionTextView = FindViewById<TextView>(Resource.Id.QuestionTextView);

			_trueButton.Click += (sender, args) => ScoreQuestion(true);
			_falseButton.Click += (sender, args) => ScoreQuestion(false);
			_nextButton.Click += (sender, args) => NextQuestion();

			if (bundle != null)
				_currentQuestionIndex = bundle.GetInt(KeyIndex, 0);
			LoadQuestions();
			DisplayQuestion();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			outState.PutInt(KeyIndex, _currentQuestionIndex);
		}

		private void LoadQuestions()
		{
			_questionBank.Add(new TrueFalse(Resources.GetString(Resource.String.Question1), true));
			_questionBank.Add(new TrueFalse(Resources.GetString(Resource.String.Question2), false));
			_questionBank.Add(new TrueFalse(Resources.GetString(Resource.String.Question3), false));
			_questionBank.Add(new TrueFalse(Resources.GetString(Resource.String.Question4), true));
			_questionBank.Add(new TrueFalse(Resources.GetString(Resource.String.Question5), true));
		}

		private void DisplayQuestion()
		{
			_questionTextView.Text = _questionBank[_currentQuestionIndex].QuestionText;
		}

		private void NextQuestion()
		{
			_currentQuestionIndex = (_currentQuestionIndex + 1) % _questionBank.Count;
			DisplayQuestion();
			_nextButton.Enabled = false;
		}

		private void ScoreQuestion(bool answer)
		{
			Toast.MakeText(this, (answer == _questionBank[_currentQuestionIndex].Answer) ? Resource.String.CorrectToast : Resource.String.IncorrectToast, ToastLength.Short).Show();
			_nextButton.Enabled = true;
		}
	}
}

