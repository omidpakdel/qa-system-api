using AutoMapper;

namespace Application.Common.Base
{
    public class BaseHandler<T>
    {
        public BaseHandler(IMapper mapper)
        {
            Mapper = mapper;
        }
        protected IMapper Mapper { get; }
    }
}