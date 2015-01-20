using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace CriminalIntent.X.Model
{
	public class Crime
	{
		private readonly UUID _id;
		private string _title;
		private DateTime _date;
		private bool _solved;

		public Crime()
		{
			_id = UUID.RandomUUID();
			Date = DateTime.Now;
		}

		public UUID Id { get { return _id; } }

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public bool Solved
		{
			get { return _solved; }
			set { _solved = value; }
		}
	}
}