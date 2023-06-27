using Application.Common.Constants;
using Application.Common.DTOs.Registration;
using Application.Common.Exceptions;
using Application.Common.RazorModels;
using Application.Common.ViewModels.Authorization;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IRazorRenderService _razorRenderService;
        private readonly IEmailService _emailService;
        private readonly IJWTService _jwtService;

        public AccountController(IAccountService accountService,
            IConfiguration configuration,
            IRazorRenderService razorRenderService,
            IEmailService emailService,
            IJWTService jWTService)
        {
            _accountService = accountService;
            _configuration = configuration;
            _razorRenderService = razorRenderService;
            _emailService = emailService;
            _jwtService = jWTService;
        }

        [HttpGet("confirm-email")]
        public async Task<ContentResult> ConfirmEmailAsync(string userId, string token)
        {
            await _accountService.ConfirmEmailAsync(userId, token);

            var templatePath = Path.Combine(RazorTemplateConstants.RazorTemplatesFolder, RazorTemplateConstants.EmailConfirmed);

            var page = await _razorRenderService.RenderTemplateToStringAsync<string>(templatePath, string.Empty);

            return new ContentResult
            {
                Content = page,
                ContentType = "text/html"
            };
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrationAsync(RegistrationDTO model)
        {
            var user = await _accountService.RegisterAsync(model);

            var confirmationLink = await _accountService.GenerateEmailConfirmationLinkAsync(user,
                _configuration["CallBackUrl"] ?? SettingConstants.CallBackUrl);

            var templatePath = Path.Combine(RazorTemplateConstants.RazorTemplatesFolder, RazorTemplateConstants.EmailConfirmation);

            var emailBody = await _razorRenderService.RenderTemplateToStringAsync<EmailConfirmationRV>(templatePath,
                new EmailConfirmationRV
                {
                    ConfirmationLink = confirmationLink,
                    Userame = user.Nickname
                });

            if (user.Email == null)
            {
                throw new CustomHttpException("Email is null", HttpStatusCode.BadRequest);
            }

            await _emailService.SendEmailAsync(user.Email, EmailConstants.EmailConfirmationSubject, emailBody);

            var result = new AuthorizationVM
            {
                AccessToken = await _jwtService.GenerateSecurityTokenAsync(user),
                IsAccountConfirmed = user.EmailConfirmed,
                TokenType = AuthConstants.TokenType,
                UserId = user.Id,
            };

            return Ok(result);
        }
    }
}
