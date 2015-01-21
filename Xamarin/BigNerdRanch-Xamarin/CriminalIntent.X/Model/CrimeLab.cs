using System;
using System.Collections.Generic;
using System.Linq;

namespace CriminalIntent.X.Model
{
	public class CrimeLab
	{
		private static CrimeLab _sCrimeLab;
		private readonly List<Crime> _crimes = new List<Crime>();

		private CrimeLab()
		{
			for (var i = 0; i < 100; ++i)
				_crimes.Add(new Crime() { Title = string.Format("Crime #{0}", i), Solved = (i % 2 == 0)});
		}

		public static CrimeLab Get()
		{
			return _sCrimeLab ?? (_sCrimeLab = new CrimeLab());
		}

		public IEnumerable<Crime> Crimes
		{
			get { return _crimes; }
		}

		public Crime GetCrime(Guid id)
		{
			return _crimes.FirstOrDefault(c => c.Id == id);
		}
	}
}