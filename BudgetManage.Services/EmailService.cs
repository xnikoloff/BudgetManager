using BudgetManage.Services.Interfaces;
using BudgetManager.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services
{
    internal class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private readonly IConfiguration _config;
        private readonly string _from = "hristiyan.at.nikoloff@gmail.com";
        private readonly string _to = "hristiyan.at.nikoloff@gmail.com";
        /*private readonly string _header = "Здравейте";
        private readonly string _footer = "С уважение," + "<br/>" +
                                          "BudgetManager";*/

        public EmailService(SmtpClient smtpClient, IConfiguration config)
        {
            _smtpClient = smtpClient;
            _config = config;
        }

        public async Task Send(string topic, EmailTemplateViewModel dto)
        {
            string emailTemplate = dto.TodoTitle + " " + dto.StartDate + "" + dto.EndDate;

            using (_smtpClient = new SmtpClient(_config.GetValue<string>("Email:Smtp:Host"),
                (_config.GetValue<int>("Email:Smtp:Port"))))
            {
                _smtpClient.EnableSsl = true;

                NetworkCredential networkCred = new NetworkCredential(_config.GetValue<string>("Email:Smtp:Username"),
                    _config.GetValue<string>("Email:Smtp:Password"));

                _smtpClient.Credentials = networkCred;

                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage message = new MailMessage(_from, $"{_to}", topic, emailTemplate);
                message.IsBodyHtml = true;
                //message.CC.Add(cc);

                await _smtpClient.SendMailAsync(message);

            }
        }
    }
}
