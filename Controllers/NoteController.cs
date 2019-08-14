using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace demo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly DemoContext _db;

        public NoteController(DemoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _db.Notes.ToList();
        }

        [HttpPost]
        public void Post()
        {
            var item = _db.Items.Include(x => x.Note).FirstOrDefault(x => x.Id == 1);
            if (item != null)
            {
                item.AddNote(DateTime.Now.ToString("F"));
                _db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete()
        {
            var item = _db.Items.Include(x => x.Note).FirstOrDefault(x => x.Id == 1);
            if (item != null)
            {
                item.DeleteNote();
                _db.SaveChanges();
            }
        }
    }
}
