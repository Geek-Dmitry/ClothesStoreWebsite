using AutoMapper;
using AutoMapper.Configuration;
using ClothesStoreWebsite.EfStuff.Repositories;
using ClothesStoreWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using СlothesStoreWebsite.EfStuff;
using СlothesStoreWebsite.EfStuff.Model;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace СlothesStoreWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ClothesStoreWebsiteDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<UserRepository>(diContainer =>
            new UserRepository(diContainer.GetService<ClothesStoreWebsiteDbContext>()));

            services.AddScoped<ProductRepository>(diContainer =>
            new ProductRepository(diContainer.GetService<ClothesStoreWebsiteDbContext>()));

            MapperRegistration(services);

            services.AddControllersWithViews();
        }

        private void MapBoth<Type1, Type2>(MapperConfigurationExpression configExpression)
        {
            configExpression.CreateMap<Type1, Type2>();
            configExpression.CreateMap<Type2, Type1>();
        }

        private void MapperRegistration(IServiceCollection services)
        {
            MapperConfigurationExpression configExpression = new MapperConfigurationExpression();

            MapBoth<Product, ProductViewModel>(configExpression);
            MapBoth<User, LoginViewModel>(configExpression);
            MapBoth<User, SignupViewModel>(configExpression);
            MapBoth<User, UserAccountViewModel>(configExpression);

            var mapperConfiguration = new MapperConfiguration(configExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(c => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
