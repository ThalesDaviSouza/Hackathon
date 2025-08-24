using MongoDB.Driver;

namespace SimuladorCredito.Api.Configuration
{
    public static class MongoDbConfiguration
    {
        public static WebApplicationBuilder AddMongoDbConfiguration(this WebApplicationBuilder builder)
        {
            var mongoConnectionString = builder.Configuration["MongoDb:ConnectionString"];
            var mongoDatabaseName = builder.Configuration["MongoDb:DatabaseName"];

            var mongoClient = new MongoClient(mongoConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);

            builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

            return builder;
        }
    }

    public class MongoDbSettings
    {
        public string ConnectionSintrg { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}