using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace EducationMicroserviceProject.Discount.API.Options
{
    public static class OptionExt
    {
        public static IServiceCollection AddOptionsExt(this IServiceCollection services) 
        {
            services.AddOptions<MongoOption>().BindConfiguration(configSectionPath: nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);
            return services;
        }
    }
}
