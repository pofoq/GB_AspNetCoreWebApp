using System.Collections.Generic;

namespace Timesheets.BusinessLayer.Abstractions.Mappers
{
    public interface IMapper<TDto, TModel>
    {
        TDto Map(TModel model);
        IEnumerable<TDto> Map(IEnumerable<TModel> models);
        TModel Map(TDto dto);
        IEnumerable<TModel> Map(IEnumerable<TDto> dtos);
    }
}
