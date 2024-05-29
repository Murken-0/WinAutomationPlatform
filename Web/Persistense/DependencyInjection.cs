using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Persistense
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistense(this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});
			return services;
		}
	}
}
