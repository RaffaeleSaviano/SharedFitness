using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SharedFitness.Network
{
    public interface IHttp
    {
		HttpMethod Method { get; set; }
		Uri Uri { get; set; }
		String Body { get; set; }
		WebHeaderCollection Headers { get; set; }
	}
}
