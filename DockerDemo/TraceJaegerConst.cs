namespace DockerDemo
{
    public static class TraceJaegerConst
    {
        public const string TraceJaegerKey = "TraceJaeger";

        public const string OutputTemplate = "{" + TraceJaegerKey + "}{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
    }

    public static class MongoDbConst
    {
        public static string MongoDbConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionName { get; set; }
    }
}
