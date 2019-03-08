using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.Network.HttpSetters
{
    public interface IHttpSetter
    {
		IHttp Http { get; set; }
		IHttpSetter SetMethod(params HttpMethod[] m);
		IHttpSetter SetUri(params String[] s);
		IHttpSetter SetBody(params String[] s);
		IHttpSetter SetHeaders(params String[][] s);
	}
}
