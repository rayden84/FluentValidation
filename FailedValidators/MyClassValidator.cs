using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidation
{
    public class MyClassValidator : AbstractValidator<MyClass>
    {
        public MyClassValidator()
        {
            RuleFor(c => c.Den).Equal(4);
            RuleFor(c => c.Num).Equal(3);
            RuleFor(c => c.IsEncoded).Equal(true);
        }
    }
}
