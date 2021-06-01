using System;
using System.Collections.Generic;
using System.Text;

namespace AssetInfo.Models
{
    public class Asset : IEquatable<Asset>
    {
        public int Id { get; set; }
        public string MachineType { get; set; }
        public string AssetName { get; set; }
        public string AssetSeriesNo { get; set; }

        public bool Equals(Asset asset)
        {
            return this.AssetName.Equals(asset.AssetName) && 
                this.AssetSeriesNo != asset.AssetSeriesNo;
        }
    }
}
