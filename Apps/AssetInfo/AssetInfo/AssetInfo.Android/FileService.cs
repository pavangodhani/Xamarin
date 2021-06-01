using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssetInfo.Droid;
using AssetInfo.Services;
using Java.Util.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace AssetInfo.Droid
{
    public class FileService : IFileService
    {
        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }

        public void CreateFile(string fileName, string textMessage)
        {
            //var fileName = "AssetInfo.txt";
            var destination = Path.Combine(GetRootPath(), fileName);

            File.WriteAllText(destination, textMessage);
        }

        public void ZipFile(string zipFileName)
        {
            List<string> fullFileName = new List<string>()
                   {
                       Path.Combine(GetRootPath(), "AssetInfo.txt")
                   };

            string fullZipFileName = Path.Combine(GetRootPath(), zipFileName);

            using (FileStream fs = 
                new FileStream(fullZipFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (ZipOutputStream zs = new ZipOutputStream(fs))
                {
                    foreach (var file in fullFileName)
                    {
                        string fileName = Path.GetFileName(file);

                        ZipEntry zipEntry = new ZipEntry(fileName);
                        zs.PutNextEntry(zipEntry);
                        byte[] fileContent = System.IO.File.ReadAllBytes(file);
                        zs.Write(fileContent);
                        zs.CloseEntry();
                    }
                    zs.Close();
                }
                fs.Close();
            }
        }
    }
}