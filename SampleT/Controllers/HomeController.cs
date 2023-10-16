using Microsoft.AspNetCore.Mvc;
using SampleT.AppServices;
using SampleT.Models;

public class HomeController : Controller
{
    private readonly IEmailVerifyService _emailVerifyService;

    public HomeController(IEmailVerifyService emailVerifyService)
    {
        _emailVerifyService = emailVerifyService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        //var model = new EmailModel
        //{
        //    Emails = new List<string>()
        //};
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(EmailModel model)
    {
        List<EmailResult> results= await _emailVerifyService.VerifyEmail(model);
        return View(results);
    }
}
