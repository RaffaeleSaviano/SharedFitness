using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.Network.WebServers
{
    public class Resource
    {
		public static readonly Resource Empty = new Resource("");

		public String TableName { get; private set; }

		protected Resource(String tableName)
		{
			TableName = tableName;
		}
    }
}
