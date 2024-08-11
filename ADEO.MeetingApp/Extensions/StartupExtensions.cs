using ADEO.MeetingApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADEO.MeetingApp.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void SetupDatabase(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<MeetingAppDBContext>(options =>
                        options.UseSqlServer(dbConnection,
                        o => o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName)));
        }
    }
}