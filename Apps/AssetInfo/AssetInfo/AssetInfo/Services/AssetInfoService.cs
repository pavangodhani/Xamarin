using AssetInfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetInfo.Services
{
    public class AssetInfoService : IAssetInfoService
    {
        readonly HttpClient _client;

        public AssetInfoService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            ICollection<Asset> assets = new List<Asset>();

            Uri uri = new Uri("http://10.0.2.2:41426/api/assets");

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                assets = JsonConvert.DeserializeObject<List<Asset>>(content);
            }

            return assets;
        }
    }
}
