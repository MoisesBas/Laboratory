using FluentValidation;
using LabTest.Model.Core;
using LabTest.Repository;
using LabTest.Repository.Helper;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace LabTest.Model.Validator
{
  public  class TestTypeModelValidator : AbstractValidator<TestTypeModel>
    {
        private readonly LabTestDbContext _db;
        public TestTypeModelValidator(LabTestDbContext db)
        {
           // Contract.Requires<ArgumentNullException>(db != null, "db");
            _db = db;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please Input Type Name");
            RuleFor(p => p.Name).MaximumLength(150);
            RuleFor(p => p.Name).Must(BeUniqueImportance).WithMessage("Type must be unique in the List");
        }
        private bool BeUniqueImportance(string arg)
        {
            return _db.TestTypes.Where(x => x.Name.Equals(arg)).Count() == 0 ? true : false;
        }
    }
}
