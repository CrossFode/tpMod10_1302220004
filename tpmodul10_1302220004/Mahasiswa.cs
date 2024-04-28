using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_1302220004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {
        private static List<MahasiswaModel> arrMahasiswa = new List<MahasiswaModel>
        {
            new MahasiswaModel { Nama = "Fauzan arrizqy", Nim = "1302220004" },
            new MahasiswaModel { Nama = "M izhar fahriansyah", Nim = "1302220000" },
            new MahasiswaModel { Nama = "Nabiel ascar", Nim = "13022230001" },
            new MahasiswaModel { Nama = "Wildan hadi", Nim = "1302220032" }
        };

        [HttpGet]
        public IEnumerable<MahasiswaModel> Get()
        {
            return arrMahasiswa;
        }

        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            return arrMahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MahasiswaModel mahasiswa)
        {
            arrMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = arrMahasiswa.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            arrMahasiswa.RemoveAt(id);
            return NoContent();
        }
    }

    public class MahasiswaModel
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}