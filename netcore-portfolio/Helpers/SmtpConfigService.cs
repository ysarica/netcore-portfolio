using Microsoft.EntityFrameworkCore;
using netcore_portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Helpers
{
    public class SmtpConfigService
    {
        private readonly Context _dbContext;

        public SmtpConfigService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SmtpConfigs> GetSmtpConfigAsync()
        {
            var config = await _dbContext.SmtpConfigs.FirstOrDefaultAsync();
            if (config == null)
            {
                throw new Exception("SMTP configuration not found in database.");
            }

            return new SmtpConfigs
            {
                Server = config.Server,
                Port = config.Port,
                EnableSSL = config.EnableSSL,
                UserName = config.UserName,
                Password = config.Password
            };
        }
    }
}
