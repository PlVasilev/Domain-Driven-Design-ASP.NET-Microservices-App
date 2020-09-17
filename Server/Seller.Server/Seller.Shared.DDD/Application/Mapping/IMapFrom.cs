using AutoMapper;

namespace Seller.Shared.DDD.Application.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}
