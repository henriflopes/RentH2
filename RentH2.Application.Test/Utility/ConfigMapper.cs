using AutoMapper;
using RentH2.Infrastructure.Configuration;

namespace RentH2.Application.Test.Utility
{
    public abstract class ConfigBase
    {
        protected IMapper _mapper;
        protected ConfigBase()
        {
            if (_mapper == null)
            {
                var mappingConfig = MappingConfig.RegisterMaps();
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
