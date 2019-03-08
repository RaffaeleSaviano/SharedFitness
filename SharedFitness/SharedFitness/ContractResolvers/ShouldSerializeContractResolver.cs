using SharedFitness.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SharedFitness.ContractResolvers
{
	public class ShouldSerializeContractResolver : DefaultContractResolver
	{
		public new static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);

			if (property.DeclaringType.IsAssignableFrom(typeof(Resource)) && property.PropertyName == "BindingContext")
			{
				property.ShouldSerialize =
					instance =>
					{
						return false;
					};
			}
			/*if (property.DeclaringType.IsAssignableFrom(typeof(Exercice)) && property.PropertyName == "IsTemplate")
			{
				property.ShouldSerialize =
					instance =>
					{
						return false;
					};
			}

			if (property.DeclaringType.IsAssignableFrom(typeof(Exercice)) && property.PropertyName == "FormattedTags")
			{
				property.ShouldSerialize =
					instance =>
					{
						return false;
					};
			}*/
			return property;
		}
	}
}
