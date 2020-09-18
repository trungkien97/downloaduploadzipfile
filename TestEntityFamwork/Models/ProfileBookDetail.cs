﻿using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ProfileBookDetail
    {
        public ProfileBookDetail()
        {
            ProfileBookAttachment = new HashSet<ProfileBookAttachment>();
            ProfileFamilyDetail = new HashSet<ProfileFamilyDetail>();
        }

        public Guid ProfileBookDetailId { get; set; }
        public Guid ProfileBookId { get; set; }
        public Guid? EmployeeId { get; set; }
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
        public string NationalityCode { get; set; }
        public string NationalityName { get; set; }
        public Guid? OrganizationId { get; set; }
        public int? EthnicId { get; set; }
        public string EthnicCode { get; set; }
        public string EthnicName { get; set; }
        public string CitizenIdentityNo { get; set; }
        public int? CitizenIdentityPlaceId { get; set; }
        public string CitizenIdentityPlaceCode { get; set; }
        public string CitizenIdentityPlaceName { get; set; }
        public DateTime? CitizenIdentityDate { get; set; }
        public string ResidentialAreaExplain { get; set; }
        public int? ResidentialAreaType { get; set; }
        public string ResidentialAreaName { get; set; }
        public int? BirthProvincialId { get; set; }
        public string BirthProvincialCode { get; set; }
        public string BirthProvincialAddress { get; set; }
        public int? BirthDistricId { get; set; }
        public string BirthDistricCode { get; set; }
        public string BirthDistricAddress { get; set; }
        public int? BirthWardId { get; set; }
        public string BirthWardCode { get; set; }
        public string BirthWardAddress { get; set; }
        public string BirthVillageAddress { get; set; }
        public int? PermanentProvincialId { get; set; }
        public string PermanentProvincialCode { get; set; }
        public string PermanentProvincialAddress { get; set; }
        public int? PermanentDistricId { get; set; }
        public string PermanentDistricCode { get; set; }
        public string PermanentDistricAddress { get; set; }
        public int? PermanentWardId { get; set; }
        public string PermanentWardCode { get; set; }
        public string PermanentWardAddress { get; set; }
        public string PermanentVillageAddress { get; set; }
        public int? ResidentialProvincialId { get; set; }
        public string ResidentialProvincialCode { get; set; }
        public string ResidentialProvincialAddress { get; set; }
        public int? ResidentialDistricId { get; set; }
        public string ResidentialDistricCode { get; set; }
        public string ResidentialDistricAddress { get; set; }
        public int? ResidentialWardId { get; set; }
        public string ResidentialWardCode { get; set; }
        public string ResidentialWardAddress { get; set; }
        public string ResidentialVillageAddress { get; set; }
        public ulong InsuranceStatus { get; set; }
        public int? SocialInsuranceDeclarationId { get; set; }
        public string SocialInsuranceDeclarationCode { get; set; }
        public string SocialInsuranceDeclarationName { get; set; }
        public ulong InsuranceBook { get; set; }
        public string InsuranceBookNo { get; set; }
        public string HealthInsuranceNo { get; set; }
        public string ContractNo { get; set; }
        public string ContractType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ulong? SalaryByCoefficient { get; set; }
        public decimal? SalaryCoefficient { get; set; }
        public decimal? Salary { get; set; }
        public string ParticipationFormCode { get; set; }
        public string ParticipationFormName { get; set; }
        public int? MiniumSalaryId { get; set; }
        public string MiniumSalaryCode { get; set; }
        public string MiniumSalaryName { get; set; }
        public decimal? PositionAllowance { get; set; }
        public decimal? SeniorityAllowance { get; set; }
        public decimal? ExtraSeniorityAllowance { get; set; }
        public decimal? SalaryAllowance { get; set; }
        public decimal? AdditionalAllowance { get; set; }
        public int? ProvinceMedicalTreatmentId { get; set; }
        public string ProvinceMedicalTreatmentCode { get; set; }
        public string ProvinceMedicalTreatmentName { get; set; }
        public Guid? HospitalId { get; set; }
        public string HospitalCode { get; set; }
        public string HospitalName { get; set; }
        public int? BankId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public int? ProvinceBankId { get; set; }
        public string ProvinceBankCode { get; set; }
        public string ProvinceBankName { get; set; }
        public Guid? BankBranchId { get; set; }
        public string BankBranchCode { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNo { get; set; }
        public string FamilyCode { get; set; }
        public string FamilyHeadsName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentNo { get; set; }
        public int? HomeProvinceId { get; set; }
        public string HomeProvinceCode { get; set; }
        public string HomeProvinceName { get; set; }
        public int? HomeDistricId { get; set; }
        public string HomeDistricCode { get; set; }
        public string HomeDistricName { get; set; }
        public int? HomeWardId { get; set; }
        public string HomeWardCode { get; set; }
        public string HomeWardName { get; set; }
        public int? HomeVillageId { get; set; }
        public string HomeVillageCode { get; set; }
        public string HomeVillageName { get; set; }
        public int? ValidateStatus { get; set; }
        public decimal? SocialInsurancePaymentRate { get; set; }
        public decimal? SocialInsurancePaymentAmount { get; set; }
        public int? StateSupportRate { get; set; }
        public int? SocialInsurancePaymentTypeId { get; set; }
        public string SocialInsurancePaymentTypeName { get; set; }
        public string SocialInsurancePaymentTypeCode { get; set; }
        public int? IsRegionalAllowanceHigher { get; set; }
        public string ReceiptMethod { get; set; }
        public DateTime? AdditionPeriod { get; set; }
        public int? SubmissionNumber { get; set; }
        public DateTime? ExecutedPeriod { get; set; }
        public DateTime? ApproveDayBefore { get; set; }
        public int? BeneficiaryGroupId { get; set; }
        public string BeneficiaryGroupCode { get; set; }
        public string BeneficiaryGroupName { get; set; }
        public string ReasonAdjust { get; set; }
        public string VoucherSerial { get; set; }
        public DateTime? SuggestionDate { get; set; }
        public string DayOffOfWeek { get; set; }
        public string HospitalTypeCode { get; set; }
        public string HospitalTypeName { get; set; }
        public string DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public int? IsPaternityLeave { get; set; }
        public DateTime? ChildBirthDay { get; set; }
        public int? NumberOfChildren { get; set; }
        public string HealthInsuranceCodeOfChild { get; set; }
        public DateTime? BackToWorkDay { get; set; }
        public DateTime? InspectionDay { get; set; }
        public string ReductionRate { get; set; }
        public int? ChildrenDiedNumber { get; set; }
        public string AntenatalCareCondition { get; set; }
        public string Contraceptive { get; set; }
        public int? GestationalAge { get; set; }
        public string ChildbirthCondition { get; set; }
        public string FatherPaternityLeave { get; set; }
        public DateTime? AdoptionDay { get; set; }
        public DateTime? ActualWorkDay { get; set; }
        public DateTime? ChildDiedDay { get; set; }
        public DateTime? MotherDiedDay { get; set; }
        public DateTime? ConclusionMotherNotEnoughHealthDay { get; set; }
        public string SocialInsuranceCodeOfChild { get; set; }
        public string CitizenIdentityNoOfMother { get; set; }
        public string SocialInsuranceCodeOfMother { get; set; }
        public string HealthInsuranceCodeOfMother { get; set; }
        public string SocialInsuranceCodeOfPeopleRearing { get; set; }
        public decimal? MedicalExaminationFee { get; set; }
        public string BenefitObjectId { get; set; }
        public string ObjectiveInsurance { get; set; }
        public int? HealthInsuranceLevel { get; set; }
        public string SurgeryRecent { get; set; }
        public int? IsLocalSupportRate { get; set; }
        public int? LocalSupportRate { get; set; }
        public decimal? LocalSupportAmount { get; set; }
        public int? IsOtherSupportRate { get; set; }
        public int? OtherSupportRate { get; set; }
        public decimal? OtherSupportAmount { get; set; }
        public int IsFamilyHead { get; set; }
        public string AddressOnPaper { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string BookFamilyCode { get; set; }
        public decimal? PaymentLevel { get; set; }
        public int? MonthsParticipate { get; set; }
        public DateTime? DeadDay { get; set; }
        public int? IsReduceDead { get; set; }
        public string BusinessProduction { get; set; }
        public int? DobdisplaySetting { get; set; }
        public ulong HaveInsuranceBookNo { get; set; }
        public string GuardianName { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string ReceiptNumber { get; set; }
        public int? MonthNumber { get; set; }
        public ulong? IsEmployee { get; set; }
        public decimal? PaymentMoney { get; set; }
        public decimal? StateBudgetSupportAmount { get; set; }
        public decimal? MoneyLeftToPay { get; set; }
        public string ChangeContent { get; set; }
        public string AttachDocument { get; set; }
        public string BankAccountName { get; set; }
        public int? SortOrder { get; set; }
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

        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public virtual ProfileBook ProfileBook { get; set; }
        public virtual ICollection<ProfileBookAttachment> ProfileBookAttachment { get; set; }
        public virtual ICollection<ProfileFamilyDetail> ProfileFamilyDetail { get; set; }
    }
}