using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style.XmlAccess;
using UMS.DTOs;
using UMS.Models;

namespace UMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly Db _db;

        public FacultyController(Db db)
        {
            _db = db;
        }

        [HttpGet("Download-Excel")]
        public async Task<IActionResult> GetAllFacultiesAsExcel()
        {
            var faculties = await _db.Set<Faculty>().ToListAsync();

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Faculties");
                workSheet.Cells["A1"].LoadFromCollection(faculties, true);
                var excelBytes = package.GetAsByteArray();
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Faculties.xlsx");
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Faculty[]))]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await _db.Set<Faculty>().ToListAsync();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Faculty_))]
        public async Task<IActionResult> GetFaculty(Guid id)
        {
            var faculty = await _db.FindAsync<Faculty>(id);

            return faculty != null ? Ok(faculty) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Guid))]
        public async Task<IActionResult> AddFaculty([FromBody] Faculty_ faculty)
        {
            if (faculty == null)
            {
                return BadRequest();
            }

            Faculty fac = new Faculty
            {
                faculty = faculty.faculty,
                Id = Guid.NewGuid()
            };

            await _db.AddAsync<Faculty>(fac);
            await _db.SaveChangesAsync();
            return Ok(fac.Id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(202, Type = typeof(Faculty))]
        [ProducesResponseType(204, Type = typeof(NoContent))]
        public async Task<IActionResult> DeleteFaculty(Guid id)
        {
            var faculty = await _db.FindAsync<Faculty>(id);
            if (faculty == null)
                return NoContent();
            _db.Remove(faculty);
            await _db.SaveChangesAsync();
            return Accepted(faculty);
        }
    }
}
