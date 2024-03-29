﻿using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;

namespace OpenMails.Services
{
    public class OutlookAuthService : IMailAuthService
    {
        static readonly string s_outlookLoginInstance = "https://login.microsoftonline.com/";
        static readonly string[] s_outlookLoginScopes = new string[] { "Mail.ReadWrite", "offline_access" };

        IPublicClientApplication _outlookLoginClient;

        public string Name => "Outlook";

        /// <summary>
        /// 获取已登录的 Outlook 邮件服务
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<IMailService> GetLoginedServicesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            IMailService? currentMailService = null;

            try
            {
                IAccount firstAccount = Microsoft.Identity.Client.PublicClientApplication.OperatingSystemAccount;
                var authResult = await _outlookLoginClient.AcquireTokenSilent(s_outlookLoginScopes, firstAccount)
                    .ExecuteAsync(cancellationToken);

                currentMailService = new OutlookMailService(authResult.AccessToken);
            }
            catch { }

            if (currentMailService is not null)
                yield return currentMailService;
        }


        public OutlookAuthService()
        {
            _outlookLoginClient = PublicClientApplicationBuilder.Create(AppSecrets.MicrosoftGraphClientId)
                .WithClientName("OpenMails")
                .WithClientVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString())
                .WithAuthority($"{s_outlookLoginInstance}{AppSecrets.MicrosoftGraphTenantId}")
                .WithDefaultRedirectUri()
                .WithBroker(true)
                .Build();
        }

        /// <summary>
        /// 登陆 Outlook 并取得其邮件服务
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IMailService?> LoginAsync(
            CancellationToken cancellationToken = default)
        {
            AuthenticationResult? authResult = null;

            try
            {
                authResult = await _outlookLoginClient.AcquireTokenInteractive(s_outlookLoginScopes)
                    .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                    .ExecuteAsync();

                return new OutlookMailService(authResult.AccessToken);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
