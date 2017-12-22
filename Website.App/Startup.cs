﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using log4net.Repository;
using log4net;
using Lib.Framework.Core.Helpers;
using Lib.Framework.Core.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Lib.Framework.Core.Options;
using Lib.Framework.Core.IoC;
using Lib.Framework.Core.EfDbContext;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Website.App
{
    public class Startup
    {
        public static ILoggerRepository repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化log4net
            repository = LogManager.CreateRepository("NETCoreRepository");
            Log4NetHelper.SetConfig(repository, "log4net.config");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.Filters.Add(new GlobalExceptionFilter());
            });
            services.AddMemoryCache();//启用MemoryCache

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/business/order";
                options.LogoutPath = "/business/index";
            });
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "localhost";//redis连接字符串

            //    option.InstanceName = "";//Redis实例名称
            //});//启用Redis

            services.Configure<MemoryCacheEntryOptions>(
                    options => options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)); //设置MemoryCache缓存有效时间为5分钟。
                //.Configure<DistributedCacheEntryOptions>(option =>
                  //  option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5));//设置Redis缓存有效时间为5分钟。
            return InitIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/");
            });
        }

        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider InitIoC(IServiceCollection services)
        {
            //var connectionString = Configuration.GetConnectionString("MsSqlServer");
            //var dbContextOption = new DbContextOption
            //{
            //    ConnectionString = connectionString,
            //    ModelAssemblyName = "Website.Models",
            //    DbType = DbType.MSSQLSERVER
            //};
            //var codeGenerateOption = new CodeGenerateOption
            //{
            //    ModelsNamespace = "Website.Models",
            //    IRepositoriesNamespace = "Website.IRepositories",
            //    RepositoriesNamespace = "Website.Repositories",
            //    IServicsNamespace = "Website.IServices",
            //    ServicesNamespace = "Website.Services"
            //};
            IoCContainer.Register(Configuration);//注册配置
            //IoCContainer.Register(dbContextOption);//注册数据库配置信息
            //IoCContainer.Register(codeGenerateOption);//注册代码生成器相关配置信息
            //IoCContainer.Register(typeof(DefaultDbContext));//注册EF上下文
            //IoCContainer.Register("Website.Repositories", "Website.IRepositories");//注册仓储
            //IoCContainer.Register("Website.Services", "Website.IServices");//注册service
            return IoCContainer.Build(services);
        }
    }
}
