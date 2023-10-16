using Newtonsoft.Json;
using SampleT.Models;
using System.Formats.Asn1;
using System.Globalization;

namespace SampleT.AppServices
{
    public class EmailVerifyService : IEmailVerifyService
    {
        public List<EmailResult> EmailResult = new List<EmailResult>();
        public async Task<List<EmailResult>> VerifyEmail(EmailModel emailModel)
        {
            if(emailModel.Email != null)
            {
                EmailResult.Add(new EmailResult { Email = emailModel.Email, Result= "Verified", Score=$"{0.6}" });
            }
            if(emailModel.File != null)
            {

                if (emailModel.File.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    using (var reader = new StreamReader(emailModel.File.OpenReadStream()))
                    {
                        var jsonContent = await reader.ReadToEndAsync();
                        List<EmailDTO> jsonData = JsonConvert.DeserializeObject<List<EmailDTO>>(jsonContent);

                        foreach (var data in jsonData)
                        {
                            foreach(var item in data.Email)
                            {
                                this.EmailResult.Add(
                                new EmailResult
                                {
                                    Email= "azam13bh@gmail.com  ",
                                    Result= "Verified",
                                    Score = ".08"
                                });

                            }
                        }
                    }
                }
            }
            return EmailResult;
        }
    }
}
