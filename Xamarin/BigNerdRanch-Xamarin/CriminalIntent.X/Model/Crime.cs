using System;

namespace CriminalIntent.X.Model
{
	public class Crime
	{
		private readonly Guid _id;
		private string _title;
		private DateTime _date;
		private bool _solved;

		public Crime()
		{
			_id = Guid.NewGuid();
			Date = DateTime.Now;
		}

		public Guid Id { get { return _id; } }

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