using SampleT.Models;

namespace SampleT.AppServices
{
    public interface IEmailVerifyService
    {
        Task<List<EmailResult>> VerifyEmail(EmailModel emailModel);
    }
}
