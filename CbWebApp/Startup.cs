#region Namespaces
using CbWebApp.Models;
using CbWebApp.Services;
using CbWebApp.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CbWebApp.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Immutable;
#endregion

namespace CbWebApp
{
    /// <summary>
    /// Classe responsável configurações do middleware pipeline.
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Com essa expressão não há necessidade de colocar o Atributo em todos os controles e seus métodos.
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                //options.Filters.Add(new RequireHttpsAttribute());
            });

            // See the Key into a xml generated file by this project for encryting porpouses. 
            //services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(30));
            //services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"c:\"));

            // DataBases Contexts
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CbConn")), ServiceLifetime.Scoped);

            services.AddDbContext<DB_A40F70_cbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("CbConn")), ServiceLifetime.Scoped);

            #region Identity

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Signin settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3); //default 30
                options.Lockout.MaxFailedAccessAttempts = 3; // default 10
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "CbCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            // policy e Roles
            // perfis: MASTER, SÓCIO, ASSOCIADO e SECRETÁRIO
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequerMaster", policy => policy.RequireRole("Master"));
                options.AddPolicy("RequerSocio", policy => policy.RequireRole("Socio"));
                options.AddPolicy("RequerAssociado", policy => policy.RequireRole("Associado"));
                options.AddPolicy("RequerSecretario", policy => policy.RequireRole("Secretario"));
                options.AddPolicy("MasterSocioAssociado", policy => policy.RequireRole("Master", "Socio", "Associado"));
            });

            #endregion

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IContratoService, ContratoService>();

            // Adciona como Singleton o Startup.
            //services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                //app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region Security

            // This is for HTTPS
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            //app.UseHsts(options => options.Preload().MaxAge(days: 365).IncludeSubdomains());

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                await next();
            });

            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseXfo(options => options.Deny());

            //app.UseHeaderRemover("Content-Type", "X-Powered-By");

            //app.UseCsp(opts => opts
            //                   .BlockAllMixedContent()
            //                   .StyleSources(s => s.UnsafeInline().CustomSources("https://use.fontawesome.com").UnsafeInline())
            //                   .StyleSources(s => s.UnsafeInline().CustomSources("https://fonts.googleapis.com").UnsafeInline())
            //                   .FontSources(s => s.Self())
            //                   .FormActions(s => s.Self())
            //                   .FrameAncestors(s => s.Self())
            //                   .ImageSources(s => s.Self())
            //                   .ScriptSources(s => s.UnsafeInline().CustomSources("https://ajax.aspnetcdn.com").UnsafeInline()));

            app.UseAuthentication();

            #endregion

            app.UseStaticFiles();

            // Aqui escreve na tela através do middleware caso encontre o navegador do FireFox chamando o Método FirefoxRoute
            app.MapWhen(context => context.Request.Headers["User-Agent"].First().Contains("Firefox"), FirefoxRoute);

            // tem que ser UseMvc sempre o último da lista. 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Criar um usuario admin e roles
            Task.Run(() => CreateUserRoles(services));
        }

        private IEnumerable<Claim> GetClaimFromCookie(HttpContext httpContext, string cookieName, string cookieSchema)
        {
            IOptionsMonitor<CookieAuthenticationOptions> opt = httpContext.RequestServices.GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>();
            string cookie = opt.CurrentValue.CookieManager.GetRequestCookie(httpContext, cookieName);

            if (!string.IsNullOrEmpty(cookie))
            {
                IDataProtector dataProtector = opt.CurrentValue.DataProtectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", cookieSchema, "v2");
                TicketDataFormat ticketDataFormat = new TicketDataFormat(dataProtector);
                AuthenticationTicket ticket = ticketDataFormat.Unprotect(cookie);

                return ticket.Principal.Claims;
            }
            return null;
        }

        #region Criar Roles e Usuarios Method
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;

            Boolean checkRoleMaster = await RoleManager.RoleExistsAsync("Master");
            Boolean checkRoleSocio = await RoleManager.RoleExistsAsync("Socio");
            Boolean checkRoleAssociado = await RoleManager.RoleExistsAsync("Associado");
            Boolean checkRoleSecretario = await RoleManager.RoleExistsAsync("Secretario");
            Boolean checkRoleCliente = await RoleManager.RoleExistsAsync("Cliente");
            Boolean checkRoleProspecçao = await RoleManager.RoleExistsAsync("Prospecçao");

            // criar role
            if (!checkRoleMaster)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Master"));
            }
            if (!checkRoleSocio)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Socio"));
            }
            if (!checkRoleAssociado)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Associado"));
            }
            if (!checkRoleSecretario)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Secretario"));
            }
            if (!checkRoleCliente)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Cliente"));
            }
            if (!checkRoleProspecçao)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Prospecçao"));
            }

            // criar usuário admin
           /* ApplicationUser user = await UserManager.FindByEmailAsync("admin@admin.com")*/;
            //if (user == null)
            //{
            //    ApplicationUser novoUsuario = new ApplicationUser { Nome = "admin", UserName = "admin", Email = "admin@admin.com" };
            //    await UserManager.CreateAsync(novoUsuario, "admin");
            //    await UserManager.AddToRoleAsync(novoUsuario, "Admin");
            //}
        }
        #endregion

        #region FireFoxCheck Method

        private void FirefoxRoute(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Alpha e Beta by Sergio. Use este sistema inicialmente no Google Chrome onde foi testado!");
            });
        }

        #endregion

    }

}