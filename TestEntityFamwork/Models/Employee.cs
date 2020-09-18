using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeFamily = new HashSet<EmployeeFamily>();
        }

        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? PossitionId { get; set; }
        public string PossitionName { get; set; }
        public int? NationalityId { get; set; }
        public string OrganizationUnitName { get; set; }
        public Guid OrganizationUnitId { get; set; }
        public int? EthnicId { get; set; }
        public int? CitizenIdentityPlaceId { get; set; }
        public string CitizenIdentityNo { get; set; }
        public string CitizenIdentityPlaceName { get; set; }
        public DateTime? CitizenIdentityDate { get; set; }
        public int? ResidentialAreaType { get; set; }
        public ulong InsuranceStatus { get; set; }
        public int? BirthProvincialId { get; set; }
        public int? BirthDistricId { get; set; }
        public int? BirthWardId { get; set; }
        public int? BirthVillageId { get; set; }
        public int? PermanentProvincialId { get; set; }
        public int? PermanentDistricId { get; set; }
        public int? PermanentWardId { get; set; }
        public int? PermanentVillageId { get; set; }
        public int? ResidentialProvincialId { get; set; }
        public int? ResidentialDistricId { get; set; }
        public int? ResidentialWardId { get; set; }
        public int? ResidentialVillageId { get; set; }
        public string ResidentialVillageAddress { get; set; }
        public string FamilyCode { get; set; }
        public string FamilyHeadsName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string DocumentTypeId { get; set; }
        public string DocumentNo { get; set; }
        public int? HomeProvinceId { get; set; }
        public int? HomeDistricId { get; set; }
        public int? HomeWardId { get; set; }
        public int? HomeVillageId { get; set; }
        public ulong InsuranceBook { get; set; }
        public string InsuranceBookNo { get; set; }
        public string ContractNo { get; set; }
        public string ContractType { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public ulong SalaryByCoefficient { get; set; }
        public decimal? SalaryCoefficient { get; set; }
        public decimal? Salary { get; set; }
        public int? MiniumSalaryId { get; set; }
        public decimal? PositionAllowance { get; set; }
        public decimal? SeniorityAllowance { get; set; }
        public decimal? ExtraSeniorityAllowance { get; set; }
        public decimal? SalaryAllowance { get; set; }
        public decimal? AdditionalAllowance { get; set; }
        public int? ProvinceMedicalTreatmentId { get; set; }
        public Guid? HospitalId { get; set; }
        public int? BankId { get; set; }
        public int? ProvinceBankId { get; set; }
        public Guid? BankBranchId { get; set; }
        public string BankAccountNo { get; set; }
        public string BenefitObjectId { get; set; }
        public int? SocialInsurancePaymentTypeId { get; set; }
        public string BirthVillageAddress { get; set; }
        public string AddressOnPaper { get; set; }
        public int IsFamilyHead { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string BookFamilyCode { get; set; }
        public decimal? OtherSupportAmount { get; set; }
        public int? DobdisplaySetting { get; set; }
        public ulong HaveInsuranceBookNo { get; set; }
        public string GuardianName { get; set; }
        public string BankAccountName { get; set; }
        public DateTime? DateOfStartingPositionAsManager { get; set; }
        public DateTime? EndDateOfTheJobPositionAsManager { get; set; }
        public DateTime? StartDateOfHoldingPositionAsSeniorTechnicalSpecialist { get; set; }
        public DateTime? EndDateHoldsThePositionOfSeniorTechnicalSpecialist { get; set; }
        public DateTime? StartDateOfHoldingPositionTechnicalSpecialist { get; set; }
        public DateTime? EndDateHoldsThePositionOfIntermediateTechnicalSpecialist { get; set; }
        public DateTime? DateOfStartingAnotherJobPosition { get; set; }
        public DateTime? EndDateHoldsAnotherJobPosition { get; set; }
        public DateTime? TheDayWhenTheHeavyHeavyIndustryStarted { get; set; }
        public DateTime? EndOfToxicHeavyHeavyIndustry { get; set; }
        public DateTime? TheStartDateOfAnIndefiniteTermLaborContract { get; set; }
        public DateTime? DateOfStartingAfixedTermLaborContract { get; set; }
        public DateTime? TerminationDateOfLaborContract { get; set; }
        public DateTime? OtherEmploymentContractStartDateLessThan1MonthProbationary { get; set; }
        public DateTime? EndDateOfLaborContractLessThan1MonthProbation { get; set; }
        public ulong? IsBaneful { get; set; }
        public string PositionJob { get; set; }
        public string PositionJobCode { get; set; }
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
        public Guid TenantId { get; set; }
        public string ParticipationFormName { get; set; }
        public decimal? ParticipationFormRate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string ParticipationFormCode { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Ethnic Ethnic { get; set; }
        public virtual SocialInsurancePaymentType SocialInsurancePaymentType { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamily { get; set; }
    }
}
