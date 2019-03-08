using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedFitness.ExtensionMethods
{
    public static class StringExtension
    {
		public static String CapitalizeFirstOfEachWord(this String inString, String cultureInfoName = "en-US")
		{
			TextInfo cultInfo = new CultureInfo(cultureInfoName, false).TextInfo;
			string output = cultInfo.ToTitleCase(inString);
			return output;
		}
	}
}
