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
		
		public Crime()
		{
			_id = UUID.RandomUUID();
		}

		public UUID Id { get { return _id; } }
		public string Title { get; set; }
	}
}