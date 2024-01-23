using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Application.Requests;
using Business.Dtos.AsyncContent.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AsyncContentRequestValidator : AbstractValidator<CreateAsyncContentRequest>
    {
        public AsyncContentRequestValidator()
        {
            
        }
    }
}
