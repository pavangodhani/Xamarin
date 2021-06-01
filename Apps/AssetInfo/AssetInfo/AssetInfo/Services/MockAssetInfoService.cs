using AssetInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetInfo.Services
{
    public class MockAssetInfoService : IMockAssetInfoService
    {
        public List<Asset> _context { get; set; } = new List<Asset>()
        {
            new Asset()
            {
                Id = 1,
                MachineType = "C300",
                AssetName = "Cutter head",
                AssetSeriesNo = "S6"
            },
            new Asset()
            {
                Id = 2,
                MachineType = "C40",
                AssetName = "Cutter head",
                AssetSeriesNo = "S7"
            },
            new Asset()
            {
                Id = 3,
                MachineType = "C300",
                AssetName = "Blade safety cover",
                AssetSeriesNo = "S10"
            },
            new Asset()
            {
                Id = 4,
                MachineType = "C60",
                AssetName = "Blade safety cover",
                AssetSeriesNo = "S11"
            },
            new Asset()
            {
                Id = 5,
                MachineType = "C300",
                AssetName = "Deburring blades",
                AssetSeriesNo = "S6"
            },
            new Asset()
            {
                Id = 6,
                MachineType = "C60",
                AssetName = "Cutter head",
                AssetSeriesNo = "S8"
            },
            new Asset()
            {
                Id = 7,
                MachineType = "C60",
                AssetName = "Clamping fixture",
                AssetSeriesNo = "S2"
            },
            new Asset()
            {
                Id = 8,
                MachineType = "C40",
                AssetName = "Blade safety cover",
                AssetSeriesNo = "S11"
            },
            new Asset()
            {
                Id = 9,
                MachineType = "C40",
                AssetName = "Shutter gripper",
                AssetSeriesNo = "S3"
            },
        };

        public IEnumerable<Asset> GetAssets()
        {
            return _context;
        }

        public IEnumerable<Asset> GetAssetsForMachineType(string machineType)
        {
            return _context.Where(
                a => a.MachineType == machineType
                ).ToList<Asset>();
        }

        public IEnumerable<Asset> GetAssetsWithLatestSeriesNo()
        {
            var assetsWithLatestSeriesNo = new List<Asset>();

            foreach (var asset in _context.OrderByDescending(a => a.AssetSeriesNo))
            {
                if (assetsWithLatestSeriesNo.Contains(asset))
                {
                    continue;
                }

                assetsWithLatestSeriesNo.Add(asset);
            }

            return assetsWithLatestSeriesNo;
        }

        public IEnumerable<Asset> GetMachinesForAsset(string assetName)
        {
            return _context.Where
                (
                    a => a.AssetName.ToLower().Replace(" ", String.Empty) ==
                    assetName.ToLower().Replace(" ", String.Empty)
                ).ToList<Asset>();
        }
    }
}
