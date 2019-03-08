using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.Network
{
    public class HttpMethod
    {
		public static readonly HttpMethod Post = new HttpMethod("POST", Method.POST);
		public static readonly HttpMethod Get = new HttpMethod("GET", Method.GET);
		public static readonly HttpMethod Delete = new HttpMethod("DELETE", Method.DELETE);
		public static readonly HttpMethod Put = new HttpMethod("PUT", Method.PUT);

		public String Name { get; private set; }
		public Method Identifier { get; private set; }

		private HttpMethod(String name, Method identifier)
		{
			Name = name;
			Identifier = identifier;
		}
		public enum Method
		{
			POST,
			GET,
			PUT,
			DELETE
		}
	}
}
