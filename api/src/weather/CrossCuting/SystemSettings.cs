using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuting
{
    public class SystemSettings
    {
        public MongoDBSettings MongoDBSettings { get; set; }
    }

    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}