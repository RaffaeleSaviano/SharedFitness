using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.Network.WebServers
{
    public class SFResources: Resource
    {
        public static readonly Resource User = new SFResources("UTENTI");
        public static readonly Resource Connect = new SFResources("connect");
        protected SFResources(string tableName) : base(tableName)
        {
        }
    }
}
