<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Valuator.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ILogger<SummaryModel> _logger;
        private readonly IStorage _storage;

        public SummaryModel(ILogger<SummaryModel> logger, IStorage storage)
        {
            _logger = logger;
            _storage = storage;
=======
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SharedLib;

namespace Valuator.Pages
{
    public class Summary : PageModel
    {
        private readonly ILogger<Summary> _logger;
        private readonly IStorage _storage;

        public Summary(IStorage storage, ILogger<Summary> logger)
        {
            _storage = storage;
            _logger = logger;
>>>>>>> Stashed changes
        }

        public double Rank { get; set; }
        public double Similarity { get; set; }

<<<<<<< Updated upstream
        private async Task<string> GetRankAsync(string id)
=======
        private async Task<string> GetRankAsync(string id, string shard)
>>>>>>> Stashed changes
        {
            const int tryCount = 1000;
            for (var i = 0; i < tryCount; i++)
            {
<<<<<<< Updated upstream
                var rank = _storage.Load(Constants.RankKeyPrefix + id);
=======
                var rank = _storage.Load(shard, Constants.RankKeyPrefix + id);
>>>>>>> Stashed changes
                if (rank != null)
                    return rank;

                await Task.Delay(10);
            }

            return null;
        }

        public async Task OnGetAsync(string id)
        {
<<<<<<< Updated upstream
            _logger.LogDebug(id);

            string rank;
            if ((rank = await GetRankAsync(id)) != null)
                Rank = double.Parse(rank, CultureInfo.InvariantCulture);
            else
                _logger.LogWarning("Could not get rank value for id: " + id);
            Similarity = double.Parse(_storage.Load(Constants.SimilarityKeyPrefix + id), CultureInfo.InvariantCulture);
        }
    }
}
=======
            var shard = _storage.LoadShard(id);
            _logger.LogInformation($"{shard} : {id} - OnGetAsync");

            string rank;
            if ((rank = await GetRankAsync(id, shard)) != null)
            {
                _logger.LogInformation($"{rank} - Rank");
                Rank = double.Parse(rank);
            }
            else
            {
                _logger.LogWarning($"Could not get rank value on shard [{shard}] for id: {id}");
            }

            Similarity = int.Parse(_storage.Load(shard, Constants.SimilarityKeyPrefix + id));
        }
    }
}
>>>>>>> Stashed changes
