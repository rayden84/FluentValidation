using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Linq;

namespace FailedValidatorsTest {
  class Program {
    public static void Main(string[] args) {

      // set up a small test case with a test object

      MyClass cc = new MyClass {
        Num = 3,
        IsEncoded = true,
        Den = 5
      };

      MyClassValidator validator = new MyClassValidator();
      ValidationResult singleValidationResult = validator.Validate(cc);

      // try to get some objects from to object graph

      var rules = validator.OfType<PropertyRule>();
      var validators = rules.Select(r => r.CurrentValidator);

      // poke around with the result

      if (singleValidationResult.IsValid) {

      }
    }
  }
}
