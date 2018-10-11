using CbWebApp.Models.AccountViewModels;
using DnsClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CbWebApp.Validation
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class EmailDnsValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            RegisterViewModel registrar = validationContext.ObjectInstance as RegisterViewModel;

            if (registrar.Email == null)
            {
                throw new ArgumentException("E-mail é obrigatório");
            }

            Task.Run(() => IsValidAsync(registrar.Email));

            if (!IsValidAsync(registrar.Email).Result)
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            else
            {
                return ValidationResult.Success;
            }

        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }
            else
            {
                return $"{validationContext.DisplayName}: Este e-mai não possui um domain válido";
            }

        }
        private async Task<bool> IsValidAsync(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                string host = mailAddress.Host;
                return await CheckDnsEntriesAsync(host);
            }
            catch (FormatException)
            {
                return await Task.FromResult(false);
            }
        }

        private async Task<bool> CheckDnsEntriesAsync(string domain)
        {
            try
            {
                LookupClient lookup = new LookupClient
                {
                    Timeout = TimeSpan.FromSeconds(5)
                };

                IDnsQueryResponse result = await lookup.QueryAsync(domain, QueryType.MX).ConfigureAwait(false);

                IEnumerable<DnsClient.Protocol.DnsResourceRecord> records = result.Answers.Where(record => record.RecordType == DnsClient.Protocol.ResourceRecordType.A ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.AAAA ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.MX);
                return records.Any();
            }
            catch (DnsResponseException)
            {
                return false;
            }
        }
    }
}
