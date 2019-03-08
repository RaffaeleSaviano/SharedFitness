using SharedFitness.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SharedFitness.Network
{
    public class HttpRequestResponse : IRequestResponse
    {
		public String Body { get; set; }
		public WebHeaderCollection Headers { get; set; }

		public bool WasSuccessful { get; set; }
	}
}
