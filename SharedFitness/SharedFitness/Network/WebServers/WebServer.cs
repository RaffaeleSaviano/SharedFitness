using SharedFitness.Interfaces;
using SharedFitness.Network.HttpSetters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedFitness.Network.WebServers
{
	public abstract class WebServer
	{
		public async Task<HttpRequestResponse> Post(Resource resource, IJsonable body,  params String[] urlSegments)
		{
			IHttpSetter hs = Setter(resource, urlSegments);
			hs.SetMethod(HttpMethod.Post)
				.SetBody(FormatJson(body?.ToJson()));
			return await RunRequestFromSetter(hs);
		}
		public async Task<T> Get<T>(Resource resource, params String[] urlSegments)
		{
			IHttpSetter hs = Setter(resource, urlSegments);
			hs.SetMethod(HttpMethod.Get);
			HttpRequestResponse rr = await RunRequestFromSetter(hs);
			T result;
			try
			{
				if (rr.Body == "")
				{
					rr.Body = "[]";
				}
				result = JsonConvert.DeserializeObject<T>(rr.Body);
			}
			catch (Exception e)
			{
				result = default(T);
			}
			return result;
		}
		public async Task<HttpRequestResponse> Delete(Resource resource, IJsonable body, params String[] urlSegments)
		{
			IHttpSetter hs = Setter(resource, urlSegments);
			hs.SetMethod(HttpMethod.Delete)
				.SetBody(FormatJson(body?.ToJson()));
			return await RunRequestFromSetter(hs);
		}
		public async Task<HttpRequestResponse> Delete(Resource resource, params String[] urlSegments)
		{
			return await this.Delete(resource, new SharedFitness.Model.Resource(), urlSegments);
		}
		public async Task<HttpRequestResponse> Put(Resource resource, IJsonable body, params String[] urlSegments)
		{
			return await Post(resource, body, urlSegments);
		}
		private IHttpSetter Setter()
		{
			IHttpSetter hs = NewHttpSetter();
			hs.Http = NewHttpRequest();
			return hs;
		}
		protected IHttpSetter Setter(Resource resource, params String[] urlSegments)
		{
			IHttpSetter hs = Setter();
			SetUri(hs, resource, urlSegments);
			return hs;
		}
		private void SetUri(IHttpSetter httpSetter, Resource resource, String[] uriSegments)
		{
			httpSetter.SetUri(resource.TableName);
			httpSetter.SetUri(uriSegments);
		}
		protected async Task<HttpRequestResponse> RunRequestFromSetter(IHttpSetter hs)
		{
			HttpRequest hr = hs.Http as HttpRequest; //
			HttpRequestResponse rr;
			try
			{
				rr = await hr.Run() as HttpRequestResponse; //
			}
			catch (Exception e)
			{
				rr = new HttpRequestResponse();
				rr.Body = "[]";
			}
			return rr;
		}
		protected abstract HttpRequest NewHttpRequest();
		protected abstract IHttpSetter NewHttpSetter();
		protected abstract String FormatJson(String json);
	}
}
