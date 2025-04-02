using BlogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        // Yazılar ve yorumlar listelenebilmeli.
        [HttpGet("[action]")]
        public IActionResult BlogList()
        {
            var blogList = _context.Writings.Include(x => x.Comments).ToList();
            if (blogList == null || !blogList.Any())
            {
                return NotFound("Herhangi bir Blog yazısı bulunamadı.");
            }
            return Ok(blogList);
        }

        // Yeni yazı oluşturulabilmeli.
        [HttpPost("[action]")]
        public IActionResult CreateBlog([FromBody] Writing writing)
        {
            if (writing == null || writing.Id != 0)
                return BadRequest("Geçersiz post verisi.");
            writing.Comments = null;
            _context.Writings.Add(writing);
            _context.SaveChanges();
            return Ok(writing);
        }

        // Bir yazıya yorum eklenebilmeli.
        [HttpPost("[action]")]
        public IActionResult CommentBlog([FromBody] Comment comment)
        {
            if (comment == null)
                return BadRequest("Yorum verisi boş.");

            var writing = _context.Writings.FirstOrDefault(w => w.Id == comment.WritingId);
            if (writing == null)
                return NotFound("Yorum eklemek istediğiniz yazı bulunamadı.");

            if (comment.Id != 0)
                return BadRequest("Yorum oluştururken lütfen Id girmeyiniz.");

            // İlişkiyi ayarla.
            comment.CommentedAt = DateTime.Now;
            comment.Writing = writing;

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok(comment);
        }
    }
}
