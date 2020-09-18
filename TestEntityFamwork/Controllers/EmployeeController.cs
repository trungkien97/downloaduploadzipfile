using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestEntityFamwork.Models;

namespace TestEntityFamwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly EfContext _context;

        public EmployeeController(EfContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(Guid id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
        [HttpPost("upload")]
        public string UploadFile(IFormFile file)
        {
            var name = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload" + Path.DirectorySeparatorChar + name);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            using (var stream = System.IO.File.Create(filePath))
            {
                file.CopyToAsync(stream);
            }
            return "test";
        }
        [HttpGet("Download/{filename}")]
        public async Task<IActionResult> Download(string filename)
        {
            try
            {
                // Sửa lại FilePath để fix lỗi trên server - nvkhai 17.8.2020
                var path = Path.Combine(Directory.GetCurrentDirectory(), "upload" + Path.DirectorySeparatorChar + filename);


                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(path), Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                //{".pdf", "application/pdf"},
                //{".doc", "application/vnd.ms-word"},
                //{".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                //{".png", "image/png"},
                //{".jpg", "image/jpeg"},
                //{".jpeg", "image/jpeg"},
                //{".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        [HttpGet("provincial")]
        public async Task<IActionResult> GetPrvincialFromIvan()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:56454/directory/api/v1/Banks");

                if (response !=null)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Ok(result);
                }
                else
                {
                    return Ok();
                }
            }
        }
        [HttpGet("zipfile")]
        public IActionResult ZipFile()
        {
            try
            {
                string directory = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".txt"));
                string zipFile = Path.Combine(Directory.GetCurrentDirectory(), "upload" + Path.DirectorySeparatorChar + "ZipFileLai.zip");
                if (System.IO.File.Exists(zipFile))
                {
                    System.IO.File.Delete(zipFile);
                }
                using (var zipOut = new ZipOutputStream(System.IO.File.Create(zipFile)))
                {
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        ZipEntry entry = new ZipEntry(fileInfo.Name);
                        FileStream fileStream = System.IO.File.OpenRead(file);
                        byte[] buffer = new byte[Convert.ToInt32(fileStream.Length)];
                        fileStream.Read(buffer, 0, (int)fileStream.Length);
                        entry.DateTime = fileInfo.LastWriteTime;
                        entry.Size = fileStream.Length;
                        fileStream.Close();

                        zipOut.PutNextEntry(entry);
                        zipOut.Write(buffer, 0, buffer.Length);
                    }

                    zipOut.Finish();
                    zipOut.Close();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
