using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemObslugiPrzychodni
{
    public interface IPasswordMailer
    {
        Task SendNewPasswordAsync(string to, string newPassword);
    }

    public sealed class PasswordMailer : IPasswordMailer
    {
        private readonly IConfiguration _cfg;
        public PasswordMailer(IConfiguration cfg) => _cfg = cfg;

        public async Task SendNewPasswordAsync(string to, string newPassword)
        {
            var msg = new MimeMessage();
            msg.From.Add(MailboxAddress.Parse(_cfg["Mail:From"]));
            msg.To.Add(MailboxAddress.Parse(to));
            msg.Subject = "Twoje nowe hasło – System Obsługi Przychodni";
            msg.Body = new BodyBuilder
            {
                HtmlBody = $"""
                <p>Witaj,</p>
                <p>Twoje nowe hasło to: <b>{newPassword}</b></p>
                <p>Zaloguj się i natychmiast je zmień.</p>
            """
            }.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(_cfg["Mail:Host"],
                                    int.Parse(_cfg["Mail:Port"]),
                                    SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_cfg["Mail:User"], _cfg["Mail:Pass"]);
            await smtp.SendAsync(msg);
            await smtp.DisconnectAsync(true);
        }
    }
}
