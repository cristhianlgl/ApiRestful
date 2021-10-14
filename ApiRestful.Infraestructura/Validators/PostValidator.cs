using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using ApiRestful.core.DTOs;

namespace ApiRestful.Infraestructura.Validators
{
    public class PostValidator: AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(1, 255);

            RuleFor(post => post.Date)
                .NotNull();                
        }
    }
}
