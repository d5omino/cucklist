using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Cucklist.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cucklist.Controllers
{
    public class ImageController :Controller
    {
        [HttpPost]
        public async Task Upload(List<IFormFile> files)
        {
        ContainerService CS = new ContainerService();
        CloudBlobContainer Container = CS.GetBlobContainer();
        foreach ( IFormFile file in files )
        {

        FileInfo fileinfo = new FileInfo(file.FileName);
        CloudBlockBlob blob = Container.GetBlockBlobReference(fileinfo.Name);
        Stream filestream = file.OpenReadStream();


        using ( filestream )
        {
        await blob.UploadFromStreamAsync(filestream);
        }



        };
        Response.Redirect("/Manage/index");
        }


    }
}
