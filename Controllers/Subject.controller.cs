using UMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace UMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly Db _db;
        public SubjectController(Db db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _db.Set<Subject>().ToListAsync();
            return Ok(subjects);
        }

    }
}
