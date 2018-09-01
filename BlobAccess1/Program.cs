using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace BlobAccess1
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnection"));
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("images");
            cloudBlobContainer.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("img2.jpg");
            using (FileStream stream = File.OpenRead(@"C:\Study\Azure\Images\img1.jpg"))
            {
                cloudBlockBlob.UploadFromStream(stream);
            }
            Console.ReadKey();

        }
    }
}
