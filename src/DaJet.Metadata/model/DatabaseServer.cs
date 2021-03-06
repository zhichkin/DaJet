﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace DaJet.Metadata
{
    public sealed class DatabaseServer
    {
        public Guid Identity { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public int ServiceBrokerPortNumber { get; set; } = 4022;
        public string NetworkAddress { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<DatabaseInfo> Databases { get; set; } = new List<DatabaseInfo>();
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Address)
                ? Name
                : string.Format("{0} ({1})", Name, Address);
        }
        public DatabaseServer Copy()
        {
            DatabaseServer server = new DatabaseServer();
            this.CopyTo(server);
            return server;
        }
        public void CopyTo(DatabaseServer server)
        {
            foreach (PropertyInfo property in typeof(DatabaseServer).GetProperties())
            {
                if (property.IsList()) continue;
                if (!property.CanWrite) continue;
                property.SetValue(server, property.GetValue(this));
            }
        }
    }
}