using AssetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetInfo.Services
{
    public interface IAssetInfoService
    {
        Task<IEnumerable<Asset>> GetAssets();
        
    }
}
