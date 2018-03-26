using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Cucklist.Data;
using Cucklist.Models;
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
        public async Task<List<CloudBlockBlob>> UploadImage(List<IFormFile> files)
        {

        List<CloudBlockBlob> uploads = new List<CloudBlockBlob>();
        foreach ( IFormFile file in files )
        {
        FileInfo fileinfo = new FileInfo(file.FileName);
        CloudBlockBlob blob = Container.GetBlockBlobReference(fileinfo.Name);
        Stream filestream = file.OpenReadStream();
        Uri blobUri= blob.Uri;


        using ( filestream )
        {
        await blob.UploadFromStreamAsync(filestream);
        uploads.Add(blob);
        }

        };
        return uploads;
        }
        //creates database record of image with link//
        public async Task<List<Image>> CreateImageRecord(List<CloudBlockBlob> uploads)
        {
        List<Image> UploadedImages = new List<Image>();
        var Owner = _usermanager.GetUserAsync(User);

        foreach ( CloudBlockBlob blob in uploads )
        {

        string path = blob.Uri.ToString();


        Image image = new Image();
        image.ImagePath = path;
        image.ImageOwner = await Owner;
        _context.Add(image);
        await _context.SaveChangesAsync();
        UploadedImages.Add(image);

        }
        return UploadedImages;
        }
        //calls both uploadimage and createimagerecord and returns you to your view//
        public async Task Upload(List<IFormFile> files)
        {
        List<Image> UploadedImages = await CreateImageRecord(UploadImage(files).Result);
        Response.Redirect("/Manage/Index");
        }
        //uploads//
        public IActionResult Uploads()
        {
        //get current user//
        Task<ApplicationUser> user = _usermanager.GetUserAsync(User);

        //create list of images filtered by user//
        List<Image> Images= _context.Image.Where(i=>i.ImageOwner==user.Result).ToList();

        //Pass Images to VIew//
        ViewData["Images"] = Images;

        return View();
        }
    }
}
