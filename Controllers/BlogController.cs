using BlogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Model;
using Microsoft.EntityFrameworkCore;

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
            if (writing == null)
            {
                return BadRequest("Yazı boş olamaz.");
            }
            if (writing.Id != 0)
            {
                return BadRequest("Yazı oluştururken lütfen Id girmeyiniz.");
            }

            // Yorumlar varsa, yazıya ait yorumları ilişkilendir.
            if (writing.Comments != null && writing.Comments.Any())
            {
                foreach (var comment in writing.Comments)
                {
                    comment.CommentedAt = DateTime.Now; // Yorumların tarihini ayarla.
                    // Yorumları yazıya ilişkilendir.
                    comment.Writing = writing;
                }
            }

            _context.Writings.Add(writing);
            _context.SaveChanges();
            return Ok("Yazı oluşturuldu.");
        }

        // Bir yazıya yorum eklenebilmeli.
        [HttpPost("[action]")]
        public IActionResult CommentBlog([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("Yorum boş olamaz.");
            }
            if (comment.Id != 0)
            {
                return BadRequest("Yorum oluştururken lütfen Id girmeyiniz.");
            }

            comment.CommentedAt = DateTime.Now;

            var writing = _context.Writings.SingleOrDefault(x => x.Id == comment.Writing.Id);
            if (writing == null)
            {
                return NotFound("Yorum eklemek istediğiniz yazı bulunamadı.");
            }

            // Yorumları yazıya ekle.
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok("Yorum eklendi.");
        }
    }
}
