using System;
<<<<<<< Updated upstream
using System.Globalization;
using System.Linq;
using System.Text;
using NATS.Client;
using Valuator;

namespace RankCalculator
{
    public class RankCalculator
    {
        private readonly IConnection _connection;
        private readonly IAsyncSubscription _subscription;

        public RankCalculator(IStorage storage)
        {
            _connection = new ConnectionFactory().CreateConnection();

            _subscription = _connection.SubscribeAsync(Constants.RankKeyPrefix, (_, args) =>
            {
                var id = Encoding.UTF8.GetString(args.Message.Data);
                var textKey = Constants.TextKeyPrefix + id;
                if (!storage.DoesKeyExist(textKey)) return;
                var text = storage.Load(textKey);
                var rank = GetRank(text);
                storage.Store(Constants.RankKeyPrefix + id, rank.ToString(CultureInfo.InvariantCulture));
            });
        }

        public void Run()
        {
            _subscription.Start();

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

            _connection.Drain();
            _connection.Close();
=======
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using NATS.Client;
using SharedLib;

namespace RankCalculator
{
    public class RankCalculator : IDisposable
    {
        private readonly IConnection _connection;
        private readonly ILogger _logger;
        private readonly IAsyncSubscription _subscription;

        public RankCalculator(ILogger logger, IStorage storage)
        {
            _logger = logger;
            _connection = NatsFactory.GetNatsConnection();
            _subscription = _connection.SubscribeAsync(Constants.RankKeyProcessing, "rank", (_, args) =>
            {
                var id = Encoding.UTF8.GetString(args.Message.Data);
                var shard = storage.LoadShard(id);
                var textKey = Constants.TextKeyPrefix + id;
                if (!storage.IsKeyExist(shard, textKey)) return;
                var text = storage.Load(shard, textKey);
                var rank = GetRank(text);

                _logger.LogInformation($"Shard: [{shard}], id: [{id}], text: \"{text}\", rank: [{rank}]");
                storage.Store(shard, Constants.RankKeyPrefix + id, rank.ToString());

                _connection.Publish(Constants.RankKeyCalculated,
                    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new RankObject {Id = id, Value = rank})));
            });
        }

        public void Dispose()
        {
            _logger.LogInformation("RankCalculator is disposing...");
            _subscription.Dispose();
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            _logger.LogInformation("RankCalculator subscriptions started");
            _subscription.Start();
>>>>>>> Stashed changes
        }

        private static double GetRank(string text)
        {
            if (text.Length == 0) return 0d;
            return 1d * text.Count(x => !char.IsLetter(x)) / text.Length;
        }
    }
}