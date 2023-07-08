using AutoMapper;
using SamStore.Order.Application.Models;
using SamStore.Order.Domain.Vouchers;

namespace SamStore.Order.API.Configurations
{
    public static class MappingConfiguration
    {
        public static void ConfigureObjectMapping(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(builder =>
            {
                builder.CreateMap<Voucher, VoucherDTO>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
