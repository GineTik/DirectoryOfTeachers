using DirectoryOfTeacher.BussinessLogic.Services.Implementations;
using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.Teacher;
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
            services.AddButtons();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString), 
                contextLifetime: ServiceLifetime.Transient, 
                optionsLifetime: ServiceLifetime.Transient);
            
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherCharacteristicService, TeacherCharacteristicService>();

            services.AddTransient<IPresenter<IEnumerable<TeacherShortDTO>>, TeachersShortPresenter>();
            services.AddTransient<IPresenter<TeacherFullDTO>, TeacherFullPresentation>();
        }
    }
}
