using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncCourse.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AsyncCourseRequestValidator : AbstractValidator<CreateAsyncCourseRequest>
    {
        public AsyncCourseRequestValidator()
        {

        }
    }
}
