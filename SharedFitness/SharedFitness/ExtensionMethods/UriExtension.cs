using Flurl;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.ExtensionMethods
{
	public static class UriExtension
	{
		public static Uri Combine(this Uri uri, String[] s)
		{
			String rightHandUrl = Url.Combine(s);
			return new Uri(Url.Combine(uri.ToString(), rightHandUrl));
		}
	}
}
