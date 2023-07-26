using CrudBucketMVC.DataAccess;
using CrudBucketMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudBucketMVC.Controllers
{
    public class TeamsController : Controller
    {
        private readonly CrudBucketContext _context;

        public TeamsController(CrudBucketContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("/teams")]
        public IActionResult Create(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return Redirect($"/teams/{team.Id}");
        }

        [Route("/teams/{id:int}")]
        public IActionResult Show(int id)
        {
            var team = _context.Teams.Find(id);
            return View(team);
        }

        [Route("/teams/{id:int}/edit")]
        public IActionResult Edit(int id)
        {
            var team = _context.Teams.Find(id);
            return View(team);
        }

        [HttpPost]
        [Route("teams/{id:int}")]
        public IActionResult Update(int id, Team team)
        {
            team.Id = id;
            _context.Teams.Update(team);
            _context.SaveChanges();
            return Redirect($"/teams/{id}");
        }

        [HttpPost]
        [Route("teams/delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var team = _context.Teams.Find(id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return Redirect("/teams");
        }
    }
}
