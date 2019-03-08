using SharedFitness.ContractResolvers;
using SharedFitness.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SharedFitness.Model
{
    public class Resource : BindableObject, IJsonable
    {
		public Int32 Id { get; set; } = 0;

		public string ToJson()
		{
			JsonSerializerSettings jss = new JsonSerializerSettings() { ContractResolver = new ShouldSerializeContractResolver() };
			String s = JsonConvert.SerializeObject(this, jss);
			return s;
		}
	}
}
