using Abp.Runtime.Security;
using BLL.Abstract;
using BLL.AlbumServices;
using DTOs.AlbumDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IWebHostEnvironment _environment;
        public CollectionController(IAlbumService albumService, IWebHostEnvironment environment)
        {
            _albumService = albumService;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int userId = (int)User.Identity.GetUserId();
                return View(await _albumService.GetAllAsync(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult AddAlbum()
        {
            return PartialView("_MyPartialView");
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromForm] AlbumToAddDto albumToAddDto)
        {
            try
            {
                var originalFileName = albumToAddDto.CoverImagePath.FileName;
                string fileExtension = albumToAddDto.CoverImagePath.FileName.Substring(albumToAddDto.CoverImagePath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + albumToAddDto.CoverImagePath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (albumToAddDto.CoverImagePath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await albumToAddDto.CoverImagePath.CopyToAsync(fileStream);
                    }
                }
                albumToAddDto.UserId = (int)User.Identity.GetUserId();
                await _albumService.AddAsync(albumToAddDto, fileName);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            await _albumService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}