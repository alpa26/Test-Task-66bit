using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Тестовое.Data;

namespace Тестовое.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public List<FootBallTeam> listTeam { get; set; }

        [BindProperty]
        public FootballerAddModel FootballerLayout { get; set; }

        public List<Footballer> Footballers;
        public ApplicationContext _db { get; set; }

        public PrivacyModel(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return await UpdateLists();
        }

        public async Task<IActionResult> UpdateLists()
        {
            Footballers = await _db.Footballers.ToListAsync();
            Footballers.Sort((x, y) => x.Id.CompareTo(y.Id));
            listTeam = await _db.FootBallTeam.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return await UpdateLists();
            }
            _db.Footballers.Update(new Footballer()
            {
                Id = FootballerLayout.Id,
                Name = FootballerLayout.Name,
                Surname = FootballerLayout.Surname,
                Sex = FootballerLayout.Sex,
                DateOfBirthday = FootballerLayout.DateOfBirthday.ToShortDateString(),
                FootBallTeam = FootballerLayout.FootBallTeam,
                Country = FootballerLayout.Country
            }); 
            await _db.SaveChangesAsync();
            return Redirect("~/Privacy"); ;
        }
    }
}