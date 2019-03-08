using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SharedFitness.ExtensionMethods
{
	public static class ObsvervableCollectionExtension
	{
		public static void AddRange<T>(this ObservableCollection<T> coll, IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				coll.Add(item);
			}
		}
		public static ObservableCollection<K> ItemTo<T, K>(this ObservableCollection<T> coll)
		{
			IEnumerable<K> oe = coll.Cast<K>();
			return new ObservableCollection<K>(oe);
		}
	}
}
