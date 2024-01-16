using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {

        //bir interface başka bir interface'i implemente ederse, sanki implemente edilen interface içerisindekileri de kapsar gibi olur. Base classlar gibi düşün.
        T Data { get; }
    }
}
