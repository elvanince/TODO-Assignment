using AutoMapper;

namespace TODOBackend.Profiles
{
    /// <summary>
    /// Default profile for AutoMapper
    /// </summary>
    /// <remarks>See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#automapper</remarks>
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            
            CreateMap<Model.TODOItemModel, Dto.TODOItemModel>();
            CreateMap<Dto.UpdateTODOItem, Model.TODOItemModel>();
            CreateMap<Model.TODOItemModel, Model.TODOItemModel>();
        }
    }
}
