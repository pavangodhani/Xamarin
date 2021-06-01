using AssetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetInfo.Services
{
    public interface IMockAssetInfoService
    {
        List<Asset> _context { get; set; }
        IEnumerable<Asset> GetAssets();
        IEnumerable<Asset> GetAssetsForMachineType(string machineType);
        IEnumerable<Asset> GetAssetsWithLatestSeriesNo();
        IEnumerable<Asset> GetMachinesForAsset(string assetName);
    }
}
