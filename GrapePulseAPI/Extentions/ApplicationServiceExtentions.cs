using GradePulseAPI.Data.Repository;
using GradePulseAPI.Services;
using GradePulseAPI.Services.Mapping;
using GrapePulseAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace GradePulseAPI.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<SchoolDBContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("ConnectionStringSqlite"));
            });
            services.AddCors();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEntityToDtoMapping, EntityToDtoMapping>();
            services.AddScoped<IDtoToEnityMapping, DtoToEnityMapping>();
            
            return services;
        }
    }
}
