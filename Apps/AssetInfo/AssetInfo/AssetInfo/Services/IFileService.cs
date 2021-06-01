using System;
using System.Collections.Generic;
using System.Text;

namespace AssetInfo.Services
{
    public interface IFileService
    {
        void CreateFile(string fileName, string textMessage);
        void ZipFile(string zipFileName);
    }
}
