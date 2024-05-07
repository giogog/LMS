﻿using Contracts;
using Domain.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Email;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;

    }
    public async Task<EmailResult> SendEmailAsync(string email, string subject, string htmlMessage)
    {
        try
        {
            var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.FromEmail, _emailSettings.Password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.FromEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);

            return new EmailResult { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new EmailResult { IsSuccess = false, ErrorMessage = ex.Message };
        }
    }
}
