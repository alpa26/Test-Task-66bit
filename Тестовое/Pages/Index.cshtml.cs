using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Тестовое.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Тестовое.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApplicationContext _db { get; set; }
        public List<FootBallTeam> listTeam { get; set; }

        [BindProperty]
        public FootballerAddModel FootballerAddModel { get; set; }
        [BindProperty]
        public FootBallTeamAddModel FootBallTeamModel { get; set; }

        public IndexModel(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet()
        {
            listTeam =  await _db.FootBallTeam.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostFootBallTeamAsync()
        {
            if (ModelState["FootBallTeamModel.TeamName"].ValidationState == ModelValidationState.Invalid){
                listTeam = await _db.FootBallTeam.ToListAsync();
                return Page();
            }
            await _db.FootBallTeam.AddAsync(new FootBallTeam() { Name= FootBallTeamModel.TeamName });
            await _db.SaveChangesAsync();
            return  Redirect("~/Index"); 
        }

        public async Task<IActionResult> OnPostFootballerAsync()
        {
            if (!ModelIsValid()) {
                listTeam = await _db.FootBallTeam.ToListAsync();
                return Page();
            }
            Random rnd = new Random();
            Footballer footballer = new Footballer
            {
                Name = FootballerAddModel.Name,
                Surname = FootballerAddModel.Surname,
                Sex = FootballerAddModel.Sex,
                DateOfBirthday = FootballerAddModel.DateOfBirthday.ToShortDateString(),
                FootBallTeam = FootballerAddModel.FootBallTeam,
                Country = FootballerAddModel.Country
            };
            await _db.Footballers.AddAsync(footballer);
            await _db.SaveChangesAsync();   
            return Redirect("~/Index");
        }

        public bool ModelIsValid()
        {
            return ModelState["FootballerAddModel.Name"].ValidationState == ModelValidationState.Valid &&
                ModelState["FootballerAddModel.Surname"].ValidationState == ModelValidationState.Valid &&
                ModelState["FootballerAddModel.Sex"].ValidationState == ModelValidationState.Valid &&
                ModelState["FootballerAddModel.DateOfBirthday"].ValidationState == ModelValidationState.Valid &&
                ModelState["FootballerAddModel.FootBallTeam"].ValidationState == ModelValidationState.Valid &&
                ModelState["FootballerAddModel.Country"].ValidationState == ModelValidationState.Valid;
        }
    }

    public class FootBallTeamAddModel
    {
        [Required (ErrorMessage = "Не указано название")]
        public string TeamName { get; set; }
    }

    public class FootballerAddModel
    {
        [Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан пол")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Не указана дата")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirthday { get; set; }

        [Required (ErrorMessage = "Не указана команда")]
        public string FootBallTeam { get; set; }

        [Required(ErrorMessage = "Не указана страна")]
        public string Country { get; set; }
    }
}