using SharedFitness.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharedFitness.Network
{
	public class HttpRequest : IHttp, IRequest
	{
		private static readonly WebClient client = new WebClient();

		public HttpMethod Method { get; set; } = HttpMethod.Get;
		public Uri Uri { get; set; }
		public String Body { get; set; } = "";
		public WebHeaderCollection Headers { get; set; }

		public IRequestResponse RequestResponse { get; set; }
		
		public async Task<IRequestResponse> Run()
		{
			HttpRequestResponse response = new HttpRequestResponse();
			client.Headers = this.Headers;
			try
			{
				switch (Method.Identifier)
				{
					case HttpMethod.Method.POST:
						response.Body = await this.Post();
						break;
					case HttpMethod.Method.GET:
						response.Body = await this.Get();
						break;
					case HttpMethod.Method.PUT:
						response.Body = await this.Post();
						break;
					case HttpMethod.Method.DELETE:
						response.Body = await this.Delete();
						break;
					default:
						break;
				}
			}
			catch (Exception e)
			{
				response.Body = "";
				response.WasSuccessful = false;
			}
			response.Headers = client.ResponseHeaders;
			this.RequestResponse = response;
			return RequestResponse;
		}

		async Task<String> Post()
		{
			var responseString = client.UploadString(Uri, Method.Name, Body);

			return FormatResponse(responseString);
		}
		async Task<String> Get()
		{
			var responseString = client.DownloadString(Uri);
			return FormatResponse(responseString);
		}

		async Task<String> Delete()
		{
			var responseString = client.UploadString(Uri, Method.Name, Body);
			return FormatResponse(responseString);
		}

		String FormatResponse(String response)
		{
			return response.TrimStart('\n', '\r').TrimEnd('\n', '\r');
		}
	}
}
