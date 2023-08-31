using BLL.Abstract;
using BLL.Concrete;
using DTOs.PhotoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _environment;
        public PhotoController(IPhotoService photoService,IWebHostEnvironment environment)
        {
            _photoService = photoService;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int id)
        {
            HttpContext.Session.SetInt32("AlbumId",id);
            return View(await _photoService.GetAllAsync(id));
        }
        public IActionResult Add()
        {
            return PartialView("_MyPhotoPartialView");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PhotoToAddDto imageToAddDto)
        {
            try
            {
                var originalFileName = imageToAddDto.PhotoPath.FileName;
                string fileExtension = imageToAddDto.PhotoPath.FileName.Substring(imageToAddDto.PhotoPath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + imageToAddDto.PhotoPath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (imageToAddDto.PhotoPath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await imageToAddDto.PhotoPath.CopyToAsync(fileStream);
                    }
                }
                imageToAddDto.AlbumId = (int)HttpContext.Session.GetInt32("AlbumId");
                await _photoService.AddAsync(imageToAddDto, fileName);

                return RedirectToAction("Index",new { id= imageToAddDto.AlbumId });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> DeletePhoto(int id,int albumId)
        {
            await _photoService.Delete(id);
            return RedirectToAction("Index", new {id=albumId});
        }
    }
}
