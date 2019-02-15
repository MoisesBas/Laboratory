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
  public  class PatientModelValidator: AbstractValidator<PatientReadModel>
    {
        private readonly LabTestDbContext _db;
        public PatientModelValidator(LabTestDbContext db)
        {
           // Contract.Requires<ArgumentNullException>(db != null, "db");
            _db = db;
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Please Input Apps Name");
            RuleFor(p => p.FirstName).MaximumLength(150);
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Please Input Apps Name");
            RuleFor(p => p.LastName).MaximumLength(150);
            RuleFor(p => p.MiddleName).NotEmpty().WithMessage("Please Input Apps Name");
            RuleFor(p => p.MiddleName).MaximumLength(150);
            RuleFor(p => p).Must(BeUniqueImportance).WithMessage("Patient must be unique in the List");
        }
        private bool BeUniqueImportance(PatientReadModel arg)
        {
            return _db.Patients.Where(x => x.FirstName.ToUpper()
                                            .Trim().Equals(arg.FirstName.ToUpper().Trim()) &&
                                           x.LastName.ToUpper()
                                           .Trim().Equals(arg.LastName.ToUpper().Trim())
                                           && x.MiddleName.ToUpper().Trim().Equals(arg.MiddleName.ToUpper().Trim())).Count()
                          == 0 ? true : false;
        }
    }
}
