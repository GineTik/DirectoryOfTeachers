using DirectoryOfTeacher.BussinessLogic.Services.Implementations;
using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Framework.Configures;
using DirectoryOfTeachers.Framework.Configures.ServicesExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace DirectoryOfTeachers.Bot.Configures
{
    public class DIConfigure : IConfigure<ServiceCollection>
    {
        public void Configure(ServiceCollection services)
        {
            services.AddCommands();
            services.AddDialogs();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            
            services.AddTransient<ITeacherService, TeacherService>();
        }
    }
}
