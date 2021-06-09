using System;
<<<<<<< Updated upstream
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NATS.Client;
=======
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SharedLib;
>>>>>>> Stashed changes

namespace Valuator.Pages
{
    public class IndexModel : PageModel
    {
<<<<<<< Updated upstream
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<IndexModel> _logger;
=======
        private readonly ILogger<IndexModel> _logger;
        private readonly IMessageBroker _messageBroker;
>>>>>>> Stashed changes
        private readonly IStorage _storage;

        public IndexModel(ILogger<IndexModel> logger, IStorage storage, IMessageBroker messageBroker)
        {
<<<<<<< Updated upstream
            _logger = logger;
            _storage = storage;
            _messageBroker = messageBroker;
        }

        public IActionResult OnPost(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return Redirect("/");
            }

            _logger.LogDebug(text);

            string id = Guid.NewGuid().ToString();

            _storage.Store(Constants.SimilarityKeyPrefix + id, GetSimilarity(text).ToString());

            _storage.Store(Constants.TextKeyPrefix + id, text);

            _messageBroker.Publish(Constants.RankKeyPrefix, id);
=======
            _storage = storage;
            _messageBroker = messageBroker;
            _logger = logger;
        }

        public IActionResult OnPost(string text, string country)
        {
            _logger.LogDebug(text);
            if (string.IsNullOrEmpty(text)) Redirect("/");

            var id = Guid.NewGuid().ToString();
            _logger.LogInformation($"{country} : {id} - OnPost");

            var similarity = GetSimilarity(text);
            _storage.StoreShard(id, country);
            _storage.Store(country, Constants.SimilarityKeyPrefix + id, similarity.ToString());
            _storage.Store(country, Constants.TextKeyPrefix + id, text);

            _messageBroker.Publish(Constants.SimilarityKeyCalculated,
                JsonSerializer.Serialize(new SimilarityObject {Id = id, Value = similarity}));
            _messageBroker.Publish(Constants.RankKeyProcessing, id);
>>>>>>> Stashed changes

            return Redirect($"summary?id={id}");
        }

        private int GetSimilarity(string text)
        {
<<<<<<< Updated upstream
            var keys = _storage.GetKeys();

            foreach (string key in keys)
            {
                if (key.Substring(0, 5) == Constants.TextKeyPrefix && _storage.Load(key) == text)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
=======
            return _storage.HasTextDuplicates(text) ? 1 : 0;
        }
    }
}
>>>>>>> Stashed changes
