using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Data
{
    public class MiniECommerceDbContextFactory : IDesignTimeDbContextFactory<MiniECommerceDbContext>
    {
        public MiniECommerceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                //trỏ đến đúng thư mục API vì khi chạy 'dotnet ef' thì đang ở Infrastructure
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../API")))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MiniECommerceDbContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new MiniECommerceDbContext(optionsBuilder.Options);
        }
    }
}