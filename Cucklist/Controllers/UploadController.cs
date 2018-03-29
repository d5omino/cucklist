using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Cucklist.Data;
using Cucklist.Models;
using Cucklist.Models.UploadViewModels;
using Cucklist.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cucklist.Controllers
{
    public class UploadController :Controller
    {
        //Properties and Fields//
        public IContainerService ContainerService;
        public CloudBlobContainer Container;
        public ApplicationDbContext _context;
        public UserManager<ApplicationUser> _usermanager;
        public IHttpContextAccessor _httpcontext { get; set; }

        //Constructors//
        public UploadController(IContainerService containerservice,ApplicationDbContext context,UserManager<ApplicationUser> usermanager)
        {
        ContainerService = containerservice;
        Container = ContainerService.GetBlobContainer();
        _context = context;
        _usermanager = usermanager;

        }

        //Methods//
        //task based method that takes care of the physical upload of filies and images into an azure based storage account using blobs for each image. returns a list of cloudblockblobs that were added with this transaction//
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
        foreach ( IFormFile file in files )
        {
        FileInfo fileinfo = new FileInfo(file.FileName);
        CloudBlockBlob blob = Container.GetBlockBlobReference(fileinfo.Name);
        Stream filestream = file.OpenReadStream();
        Uri blobUri= blob.Uri;
        using ( filestream )
        {
        await blob.UploadFromStreamAsync(filestream);
        await CreateFileRecord(blob);
        }
        };
        return Redirect("/Manage/Index");
        }
        //creates database record of image with link//
        public async Task CreateFileRecord(CloudBlockBlob blob)
        {
        var Owner = _usermanager.GetUserAsync(User);
        string path = blob.Uri.ToString();
        if ( path.EndsWith(".mpg") || path.EndsWith(".avi") || path.EndsWith(".mp4") )
        {
        Video video=new Video(path);
        video.Owner = await Owner;
        _context.Add(video);
        }
        if ( path.EndsWith(".png") || path.EndsWith(".gif") || path.EndsWith(".jpg") )
        {
        Image image = new Image(path);
        image.Owner = await Owner;
        _context.Add(image);
        }
        if ( path.EndsWith(".wav") || path.EndsWith(".mp3") || path.EndsWith(".wma") || path.EndsWith(".m4a") )
        {
        Audio image = new Audio(path);
        image.Owner = await Owner;
        _context.Add(image);
        }
        await _context.SaveChangesAsync();

        }

        //uploads//whole method is basicly acting as UI ViewModel//
        public IActionResult Uploads()
        {
        //get current user//
        Task<ApplicationUser> user = _usermanager.GetUserAsync(User);
        //instantiate viewmodel "IndexViewModel" for Uploads//
        //create list of images,videos , and clips filtered by user//
        List<Image> Images= _context.Image.Where(i=>i.Owner==user.Result).ToList();
        List<Video> Videos= _context.Video.Where(v=>v.Owner==user.Result).ToList();
        List<Audio> Clips= _context.Audio.Where(v=>v.Owner==user.Result).ToList();


        //Pass Images and Videos to View via model//
        IndexViewModel model = new IndexViewModel(Images,Videos,Clips);

        return View(model);
        }

    }

}
