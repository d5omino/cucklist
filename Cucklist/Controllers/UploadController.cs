using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Cucklist.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cucklist.Controllers
{
    public class UploadController :Controller
    {
        public IContainerService ContainerService;
        public CloudBlobContainer Container;

        public UploadController(IContainerService containerservice)
        {
        ContainerService = containerservice;
        Container = ContainerService.GetBlobContainer();
        }
        [HttpPost]
        public async Task Upload(List<IFormFile> files)
        {
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
