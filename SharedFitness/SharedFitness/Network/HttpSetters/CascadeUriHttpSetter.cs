using SharedFitness.ExtensionMethods;
using Flurl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedFitness.Network.HttpSetters
{
	public class CascadeUriHttpSetter : IHttpSetter
	{
		public IHttp Http { get; set; }

		public CascadeUriHttpSetter()
		{
			Http = new HttpRequest();
		}
		public CascadeUriHttpSetter(IHttp http)
		{
			Http = http;
		}

		public IHttpSetter SetBody(params string[] s)
		{
			Http.Body = s[0];
			return this;
		}

		public IHttpSetter SetMethod(params HttpMethod[] m)
		{
			Http.Method = m[0];
			return this;
		}

		public IHttpSetter SetUri(params string[] s)
		{
			if (Http.Uri != null)
			{
				Http.Uri = Http.Uri.Combine(s);
			}
			else
			{
				Http.Uri = new Uri(Url.Combine(s));
			}
			return this;
		}

		public IHttpSetter SetHeaders(params string[][] s)
		{
			foreach (var pair in s)
			{
				try
				{
					Http.Headers.Add(pair[0], pair[1]);
				}
				catch (Exception e)
				{
				}
			}
			return this;
		}
	}
}
