using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Subject : ControllerBase
    {
        private readonly Db _db;
        public Subject(Db db) { _db = db; }

    }
}
