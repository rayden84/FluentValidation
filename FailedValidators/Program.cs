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

      // use the "new" failedvalidator property and poke around with it

      var failedValidators = singleValidationResult.Errors.Select(e => e.FailedValidator);
      var passedValidators = validators.Except(failedValidators);

      // this is essentially the line that I was looking for
      // don't know if it works with more complicated/nested rules/rules set

      var passedRules = rules.Where(r => passedValidators.Contains(r.CurrentValidator));

      if (singleValidationResult.IsValid) {
        // do whatever is necessary
      }
    }
  }
}
