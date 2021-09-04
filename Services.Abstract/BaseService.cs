using AutoMapper;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public abstract class BaseService
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;
        public BaseService(IUnitOfWork uow,IMapper _mapper)
        {
            unitOfWork = uow;
            mapper = _mapper;
        }
    }
}
