using API.Core.DbModels;
using API.Dtos;
using AutoMapper;
using AutoMapper.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public ProductUrlResolver(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
                //return null;
            }
            return null;
        }
    }
}
