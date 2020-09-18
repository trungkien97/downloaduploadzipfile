using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestEntityFamwork.Models
{
    public partial class EfContext : DbContext
    {
        public static string Connectionstring = string.Empty;
        public EfContext()
        {
            Database.OpenConnection();
        }

        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdministrativeArea> AdministrativeArea { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BankBranch> BankBranch { get; set; }
        public virtual DbSet<BeneficiaryGroup> BeneficiaryGroup { get; set; }
        public virtual DbSet<BenefitObject> BenefitObject { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Dboption> Dboption { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeFamily> EmployeeFamily { get; set; }
        public virtual DbSet<Ethnic> Ethnic { get; set; }
        public virtual DbSet<HealthInsuranceDeclaration> HealthInsuranceDeclaration { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<HospitalType> HospitalType { get; set; }
        public virtual DbSet<ImportColumn> ImportColumn { get; set; }
        public virtual DbSet<ImportFileTemplate> ImportFileTemplate { get; set; }
        public virtual DbSet<ImportWorksheet> ImportWorksheet { get; set; }
        public virtual DbSet<InsuranceOrganization> InsuranceOrganization { get; set; }
        public virtual DbSet<InsuranceStateSupportRate> InsuranceStateSupportRate { get; set; }
        public virtual DbSet<LongTermDisease> LongTermDisease { get; set; }
        public virtual DbSet<MiniumSalary> MiniumSalary { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationHistory> OrganizationHistory { get; set; }
        public virtual DbSet<OrganizationUnit> OrganizationUnit { get; set; }
        public virtual DbSet<ParticipationForm> ParticipationForm { get; set; }
        public virtual DbSet<PositionJob> PositionJob { get; set; }
        public virtual DbSet<Possition> Possition { get; set; }
        public virtual DbSet<ProfileBook> ProfileBook { get; set; }
        public virtual DbSet<ProfileBookAttachment> ProfileBookAttachment { get; set; }
        public virtual DbSet<ProfileBookDetail> ProfileBookDetail { get; set; }
        public virtual DbSet<ProfileBookFileAttachment> ProfileBookFileAttachment { get; set; }
        public virtual DbSet<ProfileFamilyDetail> ProfileFamilyDetail { get; set; }
        public virtual DbSet<Provincial> Provincial { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<SignatureConfig> SignatureConfig { get; set; }
        public virtual DbSet<SocialInsuranceDeclaration> SocialInsuranceDeclaration { get; set; }
        public virtual DbSet<SocialInsuranceForm> SocialInsuranceForm { get; set; }
        public virtual DbSet<SocialInsurancePaymentType> SocialInsurancePaymentType { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<ViewEmployee> ViewEmployee { get; set; }
        public virtual DbSet<ViewEmployeeFamily> ViewEmployeeFamily { get; set; }
        public virtual DbSet<Village> Village { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Connectionstring, x => x.ServerVersion("10.3.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativeArea>(entity =>
            {
                entity.HasComment("Địa bàn hành chính");

                entity.Property(e => e.AdministrativeAreaId)
                    .HasColumnName("AdministrativeAreaID")
                    .HasColumnType("int(11)")
                    .HasComment("ID");

                entity.Property(e => e.AdministrativeAreaCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasComment("Tình trạng");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.BankId)
                    .HasColumnName("BankID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã ngân hàng cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên ngân hàng cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<BankBranch>(entity =>
            {
                entity.Property(e => e.BankBranchId)
                    .HasColumnName("BankBranchID")
                    .HasDefaultValueSql("'uuid()'")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã ngân hàng cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã tỉnh tỉnh thành quản lý")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<BeneficiaryGroup>(entity =>
            {
                entity.HasComment("Danh mục nhóm hưởng");

                entity.Property(e => e.BeneficiaryGroupId)
                    .HasColumnName("BeneficiaryGroupID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.BeneficiaryGroupCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã nhóm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeneficiaryGroupName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên nhóm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceTermsCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã chế độ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(255)")
                    .HasComment("STT/ Sắp xếp");
            });

            modelBuilder.Entity<BenefitObject>(entity =>
            {
                entity.HasComment("Danh mục đối tượng mức hưởng");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(5)")
                    .HasComment("Mã đối tượng mức hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Mức hưởng");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên đối tượng mức hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateSupportRate)
                    .HasColumnType("int(3)")
                    .HasComment("Tỉ lệ ngân sách nhà nước hỗ trợ (đối với thủ tục 603)");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ContractId)
                    .HasColumnType("int(3)")
                    .HasComment("Id loại hợp đồng");

                entity.Property(e => e.ContractCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã loại hợp đồng")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ContractName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên loại hợp đồng")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Dboption>(entity =>
            {
                entity.ToTable("DBOption");

                entity.HasComment("Bảng lưu thông tin các config, hằng số dùng chung cho toàn bộ ứng dụng");

                entity.Property(e => e.DboptionId)
                    .HasColumnName("DBOptionID")
                    .HasDefaultValueSql("'uuid()'")
                    .HasComment("Khóa chính của bảng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.DboptionName)
                    .IsRequired()
                    .HasColumnName("DBOptionName")
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên key")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DboptionType)
                    .HasColumnName("DBOptionType")
                    .HasColumnType("int(10)")
                    .HasComment("Kiểu dữ liệu (0:String, 1:Integer, 2:Boolean, 3: Enum, 4: Tham chiếu đến bảng, 5: Kiểu số tiền)");

                entity.Property(e => e.DboptionValue)
                    .HasColumnName("DBOptionValue")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mô tả cho option ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsOnlyApplyOrganization)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("true nếu áp dụng cho 1 hoặc nhiều đơn vị được xác định ở trường OrganizationIDs");

                entity.Property(e => e.OrganizationIds)
                    .HasColumnName("OrganizationIDs")
                    .HasColumnType("varchar(255)")
                    .HasComment("Danh sách các organizationid (phân cách bởi dấu chấm phẩy)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.DocumentTypeId)
                    .HasColumnName("DocumentTypeID")
                    .HasColumnType("varchar(20)")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên loại giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Hồ sơ lao động, hồ sơ nhân viên");

                entity.HasIndex(e => e.DocumentTypeId)
                    .HasName("FK_Employee_DocumentTypeId");

                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("IX_Emp_EmployeeCode");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeID")
                    .IsUnique();

                entity.HasIndex(e => e.EthnicId)
                    .HasName("FK_Emp_Ethnic_EthnicID");

                entity.HasIndex(e => e.FullName)
                    .HasName("IX_Emp_EmployeeName");

                entity.HasIndex(e => e.NationalityId)
                    .HasName("FKEmp_Nationality_NationalityID");

                entity.HasIndex(e => e.SocialInsurancePaymentTypeId)
                    .HasName("FK_Emp_SocialInsurancePaymentTypeID_SocialInsurancePaymentTypeID");

                entity.HasIndex(e => e.TenantId)
                    .HasName("FK_Employee_TenantID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdditionalAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Các khoản bổ sung");

                entity.Property(e => e.AddressOnPaper)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ trên giấy tờ (VD hộ khẩu)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccountName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên chủ thẻ ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccountNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Số tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchId)
                    .HasColumnName("BankBranchID")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác)  Chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankId)
                    .HasColumnName("BankID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Ngân hàng");

                entity.Property(e => e.BenefitObjectId)
                    .HasColumnName("BenefitObjectID")
                    .HasColumnType("varchar(5)")
                    .HasComment("ID đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Quận/Huyện)");

                entity.Property(e => e.BirthProvincialId)
                    .HasColumnName("BirthProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthVillageId)
                    .HasColumnName("BirthVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Xã/Phường)");

                entity.Property(e => e.BookFamilyCode)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityDate)
                    .HasColumnType("date")
                    .HasComment("Ngày cấp chứng minh thư/ hộ chiếu");

                entity.Property(e => e.CitizenIdentityNo)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasComment("Số CMTND/Hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityPlaceId)
                    .HasColumnName("CitizenIdentityPlaceID")
                    .HasColumnType("int(11)")
                    .HasComment("Mã nơi cấp chứng minh thư nhân dân");

                entity.Property(e => e.CitizenIdentityPlaceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Số hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractType)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi vào database (dev)");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DateOfStartingAfixedTermLaborContract)
                    .HasColumnName("DateOfStartingAFixedTermLaborContract")
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu hợp đồng lao động xác định thời hạn");

                entity.Property(e => e.DateOfStartingAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm khác");

                entity.Property(e => e.DateOfStartingPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Nhà quản lý");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.DocumentNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Số giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeId)
                    .HasColumnName("DocumentTypeID")
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Loại giấy tờ (1- Sổ hộ khẩu,...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Ngày có hiệu lực/ Ngày ký");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasComment("Địa chỉ thư điện tử")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDateHoldsAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc khác");

                entity.Property(e => e.EndDateHoldsThePositionOfIntermediateTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.EndDateHoldsThePositionOfSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc cao
");

                entity.Property(e => e.EndDateOfLaborContractLessThan1MonthProbation)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc hợp đồng lao động (dưới 1 tháng, thử việc)");

                entity.Property(e => e.EndDateOfTheJobPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc làm là nhà quản lý");

                entity.Property(e => e.EndOfToxicHeavyHeavyIndustry)
                    .HasColumnType("datetime")
                    .HasComment(@" Ngày kết thúc ngành nghề nặng nhọc độc hại
");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("Dân tộc");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Ngày hết hiệu lực");

                entity.Property(e => e.ExtraSeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niêm vượt khung");

                entity.Property(e => e.FamilyCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã hộ gia đình")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FamilyHeadsName)
                    .HasColumnType("varchar(100)")
                    .HasComment("(Thông tin gia đình) Họ và tên chủ hộ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính: 0 nữ, 1 nam");

                entity.Property(e => e.GuardianName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên người giám hộ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HaveInsuranceBookNo)
                    .HasColumnType("bit(1)")
                    .HasComment("Có mã số BHXH hay ko 1: Có, 0: Không");

                entity.Property(e => e.HomeDistricId)
                    .HasColumnName("HomeDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Quận/huyện");

                entity.Property(e => e.HomePhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("(Thông tin gia đình) Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeProvinceId)
                    .HasColumnName("HomeProvinceID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Tỉnh/TP trực thuộc trung ương");

                entity.Property(e => e.HomeVillageId)
                    .HasColumnName("HomeVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Thôn/ xóm");

                entity.Property(e => e.HomeWardId)
                    .HasColumnName("HomeWardID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Xã/phường");

                entity.Property(e => e.HospitalId)
                    .HasColumnName("HospitalID")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Bệnh viện khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceBook)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("(Thông tin tham gia BHXH) Có số BHXH hay không (0-không, 1- có)");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) Mã số BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'")
                    .HasComment("Trạng thái tham gia BHXH (0 - Không tham gia, 1- Đang tham gia)");

                entity.Property(e => e.IsBaneful)
                    .HasColumnType("bit(1)")
                    .HasComment("Có phải là làm việc ở môi trường độc hại hay không ?");

                entity.Property(e => e.IsFamilyHead)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Có phải chủ hộ không: 1 là chủ hộ");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiniumSalaryId)
                    .HasColumnName("MiniumSalaryID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Lương tối thiểu vùng (FK)");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất  (dev)");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("Quốc tịch");

                entity.Property(e => e.OrganizationUnitId)
                    .HasColumnName("OrganizationUnitID")
                    .HasComment("ID bộ phận phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasComment("Văn phòng/Chi nhánh làm việc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherEmploymentContractStartDateLessThan1MonthProbationary)
                    .HasColumnType("datetime")
                    .HasComment(" Ngày bắt đầu hợp đồng lao động khác (dưới 1 tháng, thử việc)");

                entity.Property(e => e.OtherSupportAmount).HasColumnType("decimal(18,0)");

                entity.Property(e => e.ParticipationFormCode)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên hình thức tham gia/ tỷ lệ đóng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormRate)
                    .HasColumnType("decimal(10,2)")
                    .HasComment("Thong tin ti le dong ");

                entity.Property(e => e.PermanentDistricId)
                    .HasColumnName("PermanentDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Quận/Huyện)");

                entity.Property(e => e.PermanentProvincialId)
                    .HasColumnName("PermanentProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.PermanentVillageId)
                    .HasColumnName("PermanentVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Đỉa chị thường trú (Thôn, xóm....)");

                entity.Property(e => e.PermanentWardId)
                    .HasColumnName("PermanentWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Xã/Phường)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionAllowance)
                    .HasColumnType("decimal(4,2)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp chức vụ");

                entity.Property(e => e.PositionJob)
                    .HasColumnType("varchar(150)")
                    .HasComment("Vị trí làm việc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionJobCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Ma vi tri lam viec")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionId)
                    .HasColumnName("PossitionID")
                    .HasComment("Vị trí/Chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceBankId)
                    .HasColumnName("ProvinceBankID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tỉnh đăng ký tài khoản ngân hàng");

                entity.Property(e => e.ProvinceMedicalTreatmentId)
                    .HasColumnName("ProvinceMedicalTreatmentID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tỉnh đăng ký khám chữa bệnh");

                entity.Property(e => e.ReceiveDate).HasColumnType("datetime");

                entity.Property(e => e.ResidentialAreaType)
                    .HasColumnType("int(255)")
                    .HasComment("Vùng sinh sống (1-Thành thị, 2- Nông thôn...)");

                entity.Property(e => e.ResidentialDistricId)
                    .HasColumnName("ResidentialDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú  (Quận/Huyện)");

                entity.Property(e => e.ResidentialProvincialId)
                    .HasColumnName("ResidentialProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.ResidentialVillageAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú (Thôn/xóm...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialVillageId)
                    .HasColumnName("ResidentialVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú (Thôn/xóm...)");

                entity.Property(e => e.ResidentialWardId)
                    .HasColumnName("ResidentialWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú  (Xã/Phường)");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Mức lương");

                entity.Property(e => e.SalaryAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp lương");

                entity.Property(e => e.SalaryByCoefficient)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment(" Lương tính theo hệ số 1: lương tính theo hệ số, 0: theo mức lương");

                entity.Property(e => e.SalaryCoefficient)
                    .HasColumnType("decimal(21,3)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Hệ số lương");

                entity.Property(e => e.SeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niên nghề - %");

                entity.Property(e => e.SocialInsurancePaymentTypeId)
                    .HasColumnName("SocialInsurancePaymentTypeID")
                    .HasColumnType("int(11)")
                    .HasComment("Phương thức đóng bảo hiểm xã hội");

                entity.Property(e => e.StartDateOfHoldingPositionAsSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc cao
");

                entity.Property(e => e.StartDateOfHoldingPositionTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasComment("ID của công ty (Lấy từ bảng tenant)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TerminationDateOfLaborContract)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày kết thúc hợp đồng lao động xác định thời hạn

");

                entity.Property(e => e.TheDayWhenTheHeavyHeavyIndustryStarted)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu ngành nghề nặng nhọc độc hại");

                entity.Property(e => e.TheStartDateOfAnIndefiniteTermLaborContract)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày bắt đầu hợp đồng lao động không xác định thời hạn
");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_Employee_DocumentTypeId");

                entity.HasOne(d => d.Ethnic)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EthnicId)
                    .HasConstraintName("FK_Emp_Ethnic_Ethnic_EthnicID");

                entity.HasOne(d => d.SocialInsurancePaymentType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SocialInsurancePaymentTypeId)
                    .HasConstraintName("FK_Emp_SocialInsurancePaymentTypeID_SocialInsurancePaymentTypeID");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Employee_TenantID");
            });

            modelBuilder.Entity<EmployeeFamily>(entity =>
            {
                entity.HasComment("Bảng thông tin chi tiết gia đình của Nhân viên");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_EmployeeFamily_Emp_EmpID");

                entity.HasIndex(e => e.FullName);

                entity.Property(e => e.EmployeeFamilyId)
                    .HasColumnName("EmployeeFamilyID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Huyện sinh");

                entity.Property(e => e.BirthProvinceId)
                    .HasColumnName("BirthProvinceID")
                    .HasColumnType("int(11)")
                    .HasComment("Tỉnh sinh");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Xã khai sinh");

                entity.Property(e => e.CitizenIdentityNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("Khóa ngoại với bảng Employee")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("ID dân tộc");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính 0: Nữ, 1: Nam");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số sổ bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus).HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("ID quốc tịch");

                entity.Property(e => e.RelationIdwithHead)
                    .HasColumnName("RelationIDWithHead")
                    .HasColumnType("int(255)")
                    .HasComment("Quan hệ với chủ hộ (1- Bố, 2 - mẹ...)");

                entity.Property(e => e.RelationWithHeadCode)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationWithHeadName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortOrder).HasColumnType("int(5)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeFamily)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmployeeFamily_Emp_EmpID");
            });

            modelBuilder.Entity<Ethnic>(entity =>
            {
                entity.HasComment("Danh mục dân tộc");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.ActiveDate)
                    .HasColumnType("date")
                    .HasComment("Ngày hiệu lực");

                entity.Property(e => e.EthnicCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("date")
                    .HasComment("Ngày hết hiệu lực");
            });

            modelBuilder.Entity<HealthInsuranceDeclaration>(entity =>
            {
                entity.HasComment("Danh mục các phương án khai báo Bảo hiểm Y Tế");

                entity.Property(e => e.HealthInsuranceDeclarationId)
                    .HasColumnName("HealthInsuranceDeclarationID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.HealthInsuranceDeclarationCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã phương án BHYT")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HealthInsuranceDeclarationName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên phương án BHYT")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasComment("Danh mục bệnh viện");

                entity.HasIndex(e => e.HospitalTypeId)
                    .HasName("FK_HospitalType_Hospital_ID");

                entity.Property(e => e.HospitalId)
                    .HasColumnName("HospitalID")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã bệnh viện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên bệnh viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalTypeId)
                    .HasColumnName("HospitalTypeID")
                    .HasColumnType("int(2)")
                    .HasComment("Loại bệnh viện");

                entity.Property(e => e.ParentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("MÃ bệnh viện chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã tỉnh/ thành quản lý")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.HospitalType)
                    .WithMany(p => p.Hospital)
                    .HasForeignKey(d => d.HospitalTypeId)
                    .HasConstraintName("FK_HospitalType_Hospital_ID");
            });

            modelBuilder.Entity<HospitalType>(entity =>
            {
                entity.HasComment("Danh mục tuyến bệnh viện");

                entity.Property(e => e.HospitalTypeId)
                    .HasColumnName("HospitalTypeID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.HospitalTypeCode)
                    .IsRequired()
                    .HasColumnType("varchar(3)")
                    .HasComment("Mã tuyến")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tuyến bệnh viện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ImportColumn>(entity =>
            {
                entity.HasComment("Bảng dữ liệu các cột nhập khẩu");

                entity.HasIndex(e => e.ImportWorksheetId)
                    .HasName("FK_ImportWorksheet_ImportColumn_WorksheetID");

                entity.Property(e => e.ImportColumnId)
                    .HasColumnName("ImportColumnID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColumnDataType)
                    .HasColumnType("int(11)")
                    .HasComment("Kiểu dữ liệu");

                entity.Property(e => e.ColumnInsert)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên cột dữ liệu tương ứng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColumnPosition)
                    .HasColumnType("int(11)")
                    .HasComment("Vị trí của cột");

                entity.Property(e => e.ColumnTitle)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tiêu đề cột")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportWorksheetId)
                    .HasColumnName("ImportWorksheetID")
                    .HasComment("Khóa ngoại với bảng ImportWorksheet")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsRequired)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Là trường bắt buộc hay không (1- bắt buộc; 0- không bắt buộc)");

                entity.Property(e => e.ObjectReferenceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Enum/ Table tham chiếu tương ứng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ImportWorksheet)
                    .WithMany(p => p.ImportColumn)
                    .HasForeignKey(d => d.ImportWorksheetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ImportWorksheet_ImportColumn_WorksheetID");
            });

            modelBuilder.Entity<ImportFileTemplate>(entity =>
            {
                entity.HasComment("Bảng dữ liệu thông tin File nhập khẩu");

                entity.Property(e => e.ImportFileTemplateId)
                    .HasColumnName("ImportFileTemplateID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.FileFormat)
                    .HasColumnType("varchar(255)")
                    .HasComment("Định dạng File")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportFileTemplateCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã tệp nhập khẩu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportFileTemplateName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên tệp nhập khẩu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.ProcedureName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên store thực hiện nhập khẩu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TableImport)
                    .HasColumnType("varchar(255)")
                    .HasComment("Teen bảng nhập khẩu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalWorksheet)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Tổng số Worksheet");

                entity.Property(e => e.Version)
                    .HasColumnType("varchar(255)")
                    .HasComment("Phiên bản")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ImportWorksheet>(entity =>
            {
                entity.HasIndex(e => e.ImportFileTemplateId)
                    .HasName("FK_ImportFileTemplate_ImportWorksheet_ImportTemplateID");

                entity.Property(e => e.ImportWorksheetId)
                    .HasColumnName("ImportWorksheetID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportFileTemplateId)
                    .HasColumnName("ImportFileTemplateID")
                    .HasComment("Khóa ngoại bảng thông tin File nhập khẩu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportToTable)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên bảng sẽ Import dữ liệu vào")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImportWorksheetName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên worksheet")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsImport)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'")
                    .HasComment("Sử dụng để nhập khẩu hay không (1-có; 0- không)");

                entity.Property(e => e.RowEndImport)
                    .HasColumnType("int(10)")
                    .HasComment("Vị trí dòng dừng nhập khẩu dữ liệu");

                entity.Property(e => e.RowHeaderPosition)
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Vị trí dòng tiêu đề");

                entity.Property(e => e.RowStartImport)
                    .HasColumnType("int(10)")
                    .HasComment("Vị trí dòng bắt đầu nhập khẩu dữ liệu");

                entity.Property(e => e.WorksheetPosition)
                    .HasColumnType("int(10)")
                    .HasComment("Vị trí của Wprksheet");

                entity.HasOne(d => d.ImportFileTemplate)
                    .WithMany(p => p.ImportWorksheet)
                    .HasForeignKey(d => d.ImportFileTemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ImportFileTemplate_ImportWorksheet_ImportTemplateID");
            });

            modelBuilder.Entity<InsuranceOrganization>(entity =>
            {
                entity.HasComment("Danh mục cơ quan bảo hiểm");

                entity.Property(e => e.InsuranceOrganizationId)
                    .HasColumnName("InsuranceOrganizationID")
                    .HasDefaultValueSql("'uuid()'")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceOrganizationCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã cơ quan BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceOrganizationName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên cơ quan BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceOrganizationType)
                    .HasColumnType("int(2)")
                    .HasComment("Loại cơ quan bảo hiểm (1- BHXH)");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasComment("Sắp xếp");
            });

            modelBuilder.Entity<InsuranceStateSupportRate>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(3)")
                    .HasComment("id tỷ lệ nhà nước hỗ trợ");

                entity.Property(e => e.StateSupportRate)
                    .HasColumnType("int(5)")
                    .HasComment("Tỷ lệ nhà nước hỗ trợ");

                entity.Property(e => e.StateSupportRateName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên tỷ lệ nhà nước hỗ trợ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<LongTermDisease>(entity =>
            {
                entity.HasComment("Danh mục bệnh dài ngày");

                entity.Property(e => e.LongTermDiseaseId)
                    .HasColumnName("LongTermDiseaseID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.LongTermDiseaseIcd10)
                    .HasColumnName("LongTermDiseaseICD10")
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã bệnh theo IDC10")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LongTermDiseaseName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LongTermDiseaseTt33)
                    .HasColumnName("LongTermDiseaseTT33")
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã bệnh theo TT33")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LongTermDiseaseTt34)
                    .HasColumnName("LongTermDiseaseTT34")
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã bệnh theo TT34")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LongTermDiseaseTt46)
                    .HasColumnName("LongTermDiseaseTT46")
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã bệnh theo TT46")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(255)")
                    .HasComment("Sắp xếp/STT");
            });

            modelBuilder.Entity<MiniumSalary>(entity =>
            {
                entity.Property(e => e.MiniumSalaryId)
                    .HasColumnName("MiniumSalaryID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.AreaCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã vùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AreaName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiniumSalary1)
                    .HasColumnName("MiniumSalary")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("Mức lương tối thiểu");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.HasComment("Danh mục quốc tịch");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("OK");

                entity.Property(e => e.NationalityCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasComment("Thông tin đơn vị đăng ký sử dụng dịch vụ BHXH miền bắc");

                entity.HasIndex(e => e.TenantId)
                    .HasName("FK_Organization_TenantID");

                entity.HasIndex(e => new { e.OrganizationId, e.OrganizationCode, e.OrganizationName, e.Email, e.PhoneNumber })
                    .HasName("OrganizationID");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasDefaultValueSql("''")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessProduction)
                    .HasColumnType("varchar(500)")
                    .HasComment("Ngành nghề sản xuất kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessRegistrationLicenseNo)
                    .HasColumnType("varchar(100)")
                    .HasComment("Số quyết định thành lập, giấy phép kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BussinessAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ liên hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactEmail)
                    .HasColumnType("varchar(100)")
                    .HasComment("Email liên hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên người liên hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactPhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại liên hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasComment("Email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Inactive).HasComment("Trạng thái của đơn vị");

                entity.Property(e => e.InsuranceLinkStatus)
                    .HasColumnType("int(11)")
                    .HasComment("Trạng thái liên kết BHXH -  11: đăng ký thành công, 12: thay đổi thành công, 13: ngừng đăng ký thành công, 0: chưa đăng ký, 21: chờ xử lý đăng ký, 22: chờ xử lý thay đổi, 23: chờ xét duyệt ngừng đăng ký, 31: từ chối hồ sơ đăng ký, 32: từ chối thay đổi hồ sơ, 33: từ chối hồ sơ ngừng đăng ký");

                entity.Property(e => e.InsuranceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên cơ quan bảo hiểm xã hội Quản lý (VD: BHXH TP Hà Nội)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceOrganizationCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã cơ quan BHXH mà đơn vị đăng ký (trong danh mục cơ quan BHXH)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceReasonReject)
                    .HasColumnType("varchar(255)")
                    .HasComment("Lý do từ chối hồ sơ từ cơ quan bảo hiểm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.OrganizationCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã đơn vị")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên đơn vị đăng ký")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationType)
                    .HasColumnType("varchar(255)")
                    .HasComment("Loại hình đơn vị")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentOrganizationId)
                    .HasColumnName("ParentOrganizationID")
                    .HasComment("Mã đơn vị cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnType("int(11)")
                    .HasComment("Phương thức đóng (1,3,6) tháng");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại cơ quan")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlaceOfIssue)
                    .HasColumnType("varchar(100)")
                    .HasComment("Nơi cấp quyết định")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileCode)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tỉnh/Thành phố trực thuộc trung ương")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecipePostOffice)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Nhận kết quả qua đường bưu điện (1: có, 0: không)");

                entity.Property(e => e.TaxCode)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã công ty/ thuêbao (mã công ty trong bảng Tanent)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasComment("ID của công ty (link sang bảng Tenant)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Organization_TenantID");
            });

            modelBuilder.Entity<OrganizationHistory>(entity =>
            {
                entity.HasComment("Bảng lưu lịch sử thay đổi thông tin đơn vị ");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("FK_OrganizationHistory_OrganizationID");

                entity.Property(e => e.OrganizationHistoryId)
                    .HasColumnName("OrganizationHistoryID")
                    .HasColumnType("int(11)")
                    .HasComment("id lịch sử thay đổi thông tin đơn vị");

                entity.Property(e => e.ContentChanges)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentAttachment)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentNo)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("Số hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentStatus)
                    .HasColumnType("int(11)")
                    .HasComment("Trạng thái của hồ sơ 0:Chưa gửi,1: Chờ kết quả,2:Thiếu thông tin,3:Bị từ chối,4:Thành công");

                entity.Property(e => e.HistoryDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày lịch sử");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasComment("ID của tổ chức")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationInfo)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("Thông tin đơn vị thay đổi")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationHistory)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationHistory_OrganizationID");
            });

            modelBuilder.Entity<OrganizationUnit>(entity =>
            {
                entity.HasComment("Bảng lưu bộ phận phòng ban");

                entity.HasIndex(e => e.TenantId)
                    .HasName("FK_OrganizationUnit_TenantID");

                entity.Property(e => e.OrganizationUnitId)
                    .HasColumnName("OrganizationUnitID")
                    .HasComment("ID bộ phận phòng ban (do BHXH tự sinh ra)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ đơn vị")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AmisorganizationUnitId)
                    .HasColumnName("AMISOrganizationUnitID")
                    .HasComment("ID của bộ phận lấy từ AMIS platform về")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessRegistrationCode)
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã số đăng ký kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tạo bởi")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.CreatingBussinessType).HasColumnType("int(5)");

                entity.Property(e => e.DateOfIssue)
                    .HasColumnType("date")
                    .HasComment("Ngày phát hành");

                entity.Property(e => e.Inactive)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Có đang hoạt động hay không");

                entity.Property(e => e.IsBusiness)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Có phải là Doanh nghiệp hay không");

                entity.Property(e => e.IsParent)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Có phải công ty mẹ hay không");

                entity.Property(e => e.IsProduce)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Có phải là ....");

                entity.Property(e => e.IsSupport)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Có được hỗ trợ hay không");

                entity.Property(e => e.Maintask)
                    .HasColumnType("varchar(150)")
                    .HasComment("Công việc chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Misacode)
                    .HasColumnName("MISACode")
                    .HasColumnType("varchar(50)")
                    .HasComment("MISA code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(150)")
                    .HasComment("Sửa đổi bởi ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasComment("Ngày sửa đổi");

                entity.Property(e => e.OrganizationUnitCode)
                    .HasColumnType("char(20)")
                    .HasComment("Tên bộ phận phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("ID của đơn vị")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitTypeId)
                    .HasColumnName("OrganizationUnitTypeID")
                    .HasColumnType("int(5)")
                    .HasComment("ID Loại tổ chức");

                entity.Property(e => e.OrganizationUnitTypeName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên loại tổ chức")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasComment("Mã công ty mẹ, link đến trường AMISOrganizationUNitID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlaceOfIssue)
                    .HasColumnType("varchar(150)")
                    .HasComment("Nơi phát hành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuantityEmployee)
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Số lượng nhân viên");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.OrganizationUnit)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_OrganizationUnit_TenantID");
            });

            modelBuilder.Entity<ParticipationForm>(entity =>
            {
                entity.HasComment("Danh mục các hình thức tham gia bảo hiểm");

                entity.HasIndex(e => e.ParticipationFormId)
                    .HasName("ParticipationFormID");

                entity.Property(e => e.ParticipationFormId)
                    .HasColumnName("ParticipationFormID")
                    .HasDefaultValueSql("'uuid()'")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã hình thức/ đối tượng tham gia")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên hình thức/ đối tượng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(10,2)")
                    .HasComment("Tỉ lệ đóng");
            });

            modelBuilder.Entity<PositionJob>(entity =>
            {
                entity.Property(e => e.PositionJobId)
                    .HasColumnType("int(3)")
                    .HasComment("Id vị trí làm việc ");

                entity.Property(e => e.PositionJobCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã số vị trí làm việc ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PositionJobName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên vị trí làm việc ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Possition>(entity =>
            {
                entity.HasComment("Vị trí/ chức vụ");

                entity.HasIndex(e => e.TenantId)
                    .HasName("FK_Possition_TenantID");

                entity.Property(e => e.PossitionId)
                    .HasColumnName("PossitionID")
                    .HasDefaultValueSql("''")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Possition)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Possition_TenantID");
            });

            modelBuilder.Entity<ProfileBook>(entity =>
            {
                entity.HasComment("Sổ khai báo lao động tham gia BHXH");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("FK_PB_Organization_OrganizationID");

                entity.HasIndex(e => e.SocialInsuranceFormId)
                    .HasName("FK_InsuranceForm_InsuranceFormID");

                entity.Property(e => e.ProfileBookId)
                    .HasColumnName("ProfileBookID")
                    .HasDefaultValueSql("''")
                    .HasComment("Khóa chính sổ hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccount)
                    .HasColumnType("varchar(100)")
                    .HasComment("Số tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên ngân hàng ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã tỉnh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankProvincialName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên tỉnh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BenefitObjectCode)
                    .HasColumnType("varchar(5)")
                    .HasComment("ID đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BenefitObjectName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookCreationDate)
                    .HasColumnType("date")
                    .HasComment("Ngày lập hồ sơ (Đợt lập)");

                entity.Property(e => e.BookStatus)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("Trạng thái (0- chưa gửi, 1- chờ kết quả, 2- thiếu thông tin, 3- bị từ chối, 4- đã duyệt)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("Ngày tạo bản ghi vào database (dev)");

                entity.Property(e => e.FormCalcution)
                    .HasColumnType("int(3)")
                    .HasComment("hình thức tính (0, 1)");

                entity.Property(e => e.IsAttachProfile)
                    .HasColumnType("int(1)")
                    .HasComment("Có gửi kèm hồ sơ giấy hay không");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất  (dev)");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasComment("Đơn vị/Cơ quan")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số sổ hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookPeriod)
                    .HasColumnType("date")
                    .HasComment("Kỳ kê khai");

                entity.Property(e => e.ReasonLate)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceFormId)
                    .HasColumnName("SocialInsuranceFormID")
                    .HasColumnType("int(11)")
                    .HasComment("Loại thủ tục(Báo tăng lao động, báo giảm lao động...)");

                entity.Property(e => e.SourcePayment)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nguồn đóng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateSupportRate)
                    .HasColumnType("int(3)")
                    .HasComment("Tỉ lệ ngân sách nhà nước hỗ trợ");

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày nộp hồ sơ");

                entity.Property(e => e.SubmissionNo)
                    .HasColumnType("int(255)")
                    .HasComment("Lần nộp cho cơ quan BHXH (Tự động sinh theo thứ tự thời gian nộp)");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.ProfileBook)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PB_Organization_OrganizationID");
            });

            modelBuilder.Entity<ProfileBookAttachment>(entity =>
            {
                entity.HasComment("Bảng lữu trữ các thông tin dữ liệu văn bản hồ sơ đính kèm theo từng lao động trong hồ sơ");

                entity.HasIndex(e => e.ProfileBookAttachmentId)
                    .HasName("FK_PDA_PBD_ProfileAttachmentID")
                    .IsUnique();

                entity.HasIndex(e => e.ProfileBookDetailId)
                    .HasName("FK_PDA_PBD_ProfileBookDetailID");

                entity.Property(e => e.ProfileBookAttachmentId)
                    .HasColumnName("ProfileBookAttachmentID")
                    .HasDefaultValueSql("''")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttachFileId)
                    .HasColumnName("AttachFileID")
                    .HasComment("ID file đính kèm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttachFileType)
                    .HasColumnType("int(11)")
                    .HasComment("1: Scan sổ BHXH, 2: Scan văn bản chứng thực");

                entity.Property(e => e.AttachmentNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số văn bản")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttachmentPatch)
                    .HasColumnType("varchar(255)")
                    .HasComment("Đường dẫn lưu trữ tệp")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CommentAppraisal)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nội dung cần thẩm định")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CommentShort)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mô tả ngắn/ trích yếu văn bản")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasComment("Ngày có hiệu lực");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.ProfileBookAttachmentName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên tài liệu đính kèm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookDetailId)
                    .HasColumnName("ProfileBookDetailID")
                    .HasComment("FK với bảng hồ sơ chi tiết")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasComment("Ngày ban hành");

                entity.Property(e => e.PublicationOrganizationName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên cơ quan ban hành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProfileBookDetail)
                    .WithMany(p => p.ProfileBookAttachment)
                    .HasForeignKey(d => d.ProfileBookDetailId)
                    .HasConstraintName("FK_ProfileBookAttachment_ProfileBookDetailID");
            });

            modelBuilder.Entity<ProfileBookDetail>(entity =>
            {
                entity.HasComment("Chi tiết hồ sơ tham gia bảo hiểm");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_Employee_EmployeeID");

                entity.HasIndex(e => e.OrganizationUnitId)
                    .HasName("FK_ProfileBookDetail_OrganizationUnitID");

                entity.HasIndex(e => e.ProfileBookId)
                    .HasName("FK_ProfileBook_ProfileBookDetail_ProfileBookID");

                entity.Property(e => e.ProfileBookDetailId)
                    .HasColumnName("ProfileBookDetailID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActualWorkDay)
                    .HasColumnType("date")
                    .HasComment("Ngày đi làm thực tế");

                entity.Property(e => e.AdditionPeriod)
                    .HasColumnType("datetime")
                    .HasComment("Đợt bổ xung");

                entity.Property(e => e.AdditionalAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Các khoản bổ sung");

                entity.Property(e => e.AddressOnPaper)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ trên giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdoptionDay)
                    .HasColumnType("date")
                    .HasComment("Ngày nhận nuôi");

                entity.Property(e => e.AntenatalCareCondition)
                    .HasColumnType("varchar(50)")
                    .HasComment("Điều kiện khám thai: Trống: Thai bình thường")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApproveDayBefore)
                    .HasColumnType("date")
                    .HasComment("Ngày duyệt trước");

                entity.Property(e => e.AttachDocument)
                    .HasColumnType("varchar(1000)")
                    .HasComment("Hồ sơ kèm theo (áp dụng cho các thủ tục 607 -612)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BackToWorkDay)
                    .HasColumnType("date")
                    .HasComment("Ngày trở lại làm việc");

                entity.Property(e => e.BankAccountName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên chủ tài khoản")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccountNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Số tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Mã Chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchId)
                    .HasColumnName("BankBranchID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tên Chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Mã Ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankId)
                    .HasColumnName("BankID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BankName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tên Ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeneficiaryGroupCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã nhóm hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeneficiaryGroupId)
                    .HasColumnName("BeneficiaryGroupID")
                    .HasColumnType("int(11)")
                    .HasComment("ID nhóm hưởng");

                entity.Property(e => e.BeneficiaryGroupName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên nhóm hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BenefitObjectId)
                    .HasColumnName("BenefitObjectID")
                    .HasColumnType("varchar(5)")
                    .HasComment("Loại đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ khai sinh (Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ khai sinh (Mã Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BirthProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ khai sinh (Tỉnh/Thành phố trực thuộc TW)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ khai sinh (Mã tỉnh)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvincialId)
                    .HasColumnName("BirthProvincialID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ khai sinh (Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ khai sinh (Mã Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BookFamilyCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã hộ gia đình - trong màn hình thông tin tham gia BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessProduction)
                    .HasColumnType("varchar(500)")
                    .HasComment("Ngành nghề sản xuất kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ChangeContent)
                    .HasColumnType("varchar(1000)")
                    .HasComment("Nội dung thay đổi (áp dụng cho các thủ tục 607 -612)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ChildBirthDay)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh con");

                entity.Property(e => e.ChildDiedDay)
                    .HasColumnType("date")
                    .HasComment("Ngày con chết");

                entity.Property(e => e.ChildbirthCondition)
                    .HasColumnType("varchar(50)")
                    .HasComment("Điều kiện sinh con")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ChildrenDiedNumber)
                    .HasColumnType("int(3)")
                    .HasComment("Số con chết/Số thai chết lưu sau khi sinh");

                entity.Property(e => e.CitizenIdentityDate)
                    .HasColumnType("date")
                    .HasComment("Ngày cấp chứng minh thư/ hộ chiếu");

                entity.Property(e => e.CitizenIdentityNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số CMTND/Hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityNoOfMother)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số chứng minh thư nhân dân của mẹ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityPlaceCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Nơi cấp chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityPlaceId)
                    .HasColumnName("CitizenIdentityPlaceID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CitizenIdentityPlaceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên nơi cấp CMTND, hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ConclusionMotherNotEnoughHealthDay)
                    .HasColumnType("date")
                    .HasComment("Ngày kết luận mẹ không đủ sức khỏe chăm con");

                entity.Property(e => e.Contraceptive)
                    .HasColumnType("varchar(50)")
                    .HasComment("Biện pháp tránh thai")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã loại hợp đồng lao động")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên loại hợp đồng lao động")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Số hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractType)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("Ngày tạo bản ghi vào database (dev)");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DateOfStartingAfixedTermLaborContract)
                    .HasColumnName("DateOfStartingAFixedTermLaborContract")
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu hợp đồng lao động xác định thời hạn");

                entity.Property(e => e.DateOfStartingAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm khác");

                entity.Property(e => e.DateOfStartingPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Nhà quản lý");

                entity.Property(e => e.DayOffOfWeek)
                    .HasColumnType("varchar(100)")
                    .HasComment("Ngày nghỉ trong tuần")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeadDay)
                    .HasColumnType("date")
                    .HasComment("Ngày chết");

                entity.Property(e => e.DiseaseCode)
                    .HasColumnType("text")
                    .HasComment("Mã bệnh( Trường hợp không chọn được mã bệnh dài ngày từ danh mục bệnh dài ngày thì nhập tên bệnh))")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DiseaseName)
                    .HasColumnType("text")
                    .HasComment("Tên bệnh (Trường hợp không chọn được mã bệnh dài ngày từ danh mục bệnh dài ngày thì nhập tên bệnh)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.DocumentNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Số giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeId)
                    .HasColumnName("DocumentTypeID")
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Loại giấy tờ (1- Sổ hộ khẩu,...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasComment("Địa chỉ thư điện tử")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("FK Nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDateHoldsAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc khác");

                entity.Property(e => e.EndDateHoldsThePositionOfIntermediateTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.EndDateHoldsThePositionOfSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc cao");

                entity.Property(e => e.EndDateOfLaborContractLessThan1MonthProbation)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc hợp đồng lao động (dưới 1 tháng, thử việc)");

                entity.Property(e => e.EndDateOfTheJobPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc làm là nhà quản lý");

                entity.Property(e => e.EndOfToxicHeavyHeavyIndustry)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc ngành nghề nặng nhọc độc hại");

                entity.Property(e => e.EthnicCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EthnicName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExecutedPeriod)
                    .HasColumnType("datetime")
                    .HasComment("Đợt đã giải quyết");

                entity.Property(e => e.ExtraSeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niêm vượt khung");

                entity.Property(e => e.FamilyCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã hộ gia đình")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FamilyHeadsName)
                    .HasColumnType("varchar(100)")
                    .HasComment("(Thông tin gia đình) Họ và tên chủ hộ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FatherPaternityLeave)
                    .HasColumnType("varchar(50)")
                    .HasComment("Cha nghỉ chăm con")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH) Thống kê thông tin hồ sơ từ ngày");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính 0: Nữ, 1: Nam");

                entity.Property(e => e.GestationalAge)
                    .HasColumnType("int(2)")
                    .HasComment("Tuổi thai");

                entity.Property(e => e.GuardianName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HaveInsuranceBookNo)
                    .HasColumnType("bit(1)")
                    .HasComment("Có mã sổ BHXH hay không: 1 là có, 0  là ko có");

                entity.Property(e => e.HealthInsuranceCodeOfChild)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm y tế của con")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HealthInsuranceCodeOfMother)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã thẻ BHYT của mẹ ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HealthInsuranceLevel)
                    .HasColumnType("int(3)")
                    .HasComment("Mức hưởng");

                entity.Property(e => e.HealthInsuranceNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) Số thẻ bảo hiểm y tế")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã Quận/huyện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeDistricId)
                    .HasColumnName("HomeDistricID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HomeDistricName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Quận/huyện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("(Thông tin gia đình) Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeProvinceCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Tỉnh/TP trực thuộc trung ương")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeProvinceId)
                    .HasColumnName("HomeProvinceID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HomeProvinceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Tỉnh/TP trực thuộc trung ương")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeVillageCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã Thôn/ xóm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeVillageId)
                    .HasColumnName("HomeVillageID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HomeVillageName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Thôn/ xóm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã Xã/phường")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeWardId)
                    .HasColumnName("HomeWardID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HomeWardName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Xã/phường")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Mã Bệnh viện khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalId)
                    .HasColumnName("HospitalID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tên Bệnh viện khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalTypeCode)
                    .HasColumnType("varchar(3)")
                    .HasComment("Mã tuyến bênh viện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalTypeName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên tuyến bệnh viện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InspectionDay)
                    .HasColumnType("date")
                    .HasComment("Ngày giám định");

                entity.Property(e => e.InsuranceBook)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("(Thông tin tham gia BHXH) Có số BHXH hay không (0-không, 1- có)");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) Mã số BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'")
                    .HasComment("(Thông tin tham gia BHXH) Trạng thái tham gia BHXH (0 - Không tham gia, 1- Đang tham gia)");

                entity.Property(e => e.IsBaneful)
                    .HasColumnType("bit(1)")
                    .HasComment("Có làm việc trong môi trường độc hại hay không");

                entity.Property(e => e.IsEmployee)
                    .HasColumnType("bit(1)")
                    .HasComment("Có phải là nhân viên công ty hay không?");

                entity.Property(e => e.IsFamilyHead)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Có phải chủ hộ không");

                entity.Property(e => e.IsLocalSupportRate)
                    .HasColumnType("int(1)")
                    .HasComment("có phải là địa h\\phương hỗ trợ tỷ lệ");

                entity.Property(e => e.IsOtherSupportRate)
                    .HasColumnType("int(1)")
                    .HasComment("có phải là hỗ trợ khác theo tỷ lệ");

                entity.Property(e => e.IsPaternityLeave)
                    .HasColumnType("int(1)")
                    .HasComment("Có nghỉ dưỡng thai hay không");

                entity.Property(e => e.IsReduceDead)
                    .HasColumnType("int(1)")
                    .HasComment("Có giảm chết hay không");

                entity.Property(e => e.IsRegionalAllowanceHigher)
                    .HasColumnType("int(1)")
                    .HasComment("Có phụ cấp khu vực từ 0.7 trở lên");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LocalSupportAmount)
                    .HasColumnType("decimal(18,0)")
                    .HasComment("Số tiền cụ thể địa phương hỗ trợ");

                entity.Property(e => e.LocalSupportRate)
                    .HasColumnType("int(3)")
                    .HasComment("tỷ lệ địa phương hỗ trợ string");

                entity.Property(e => e.MedicalExaminationFee)
                    .HasColumnType("decimal(18,0)")
                    .HasComment("Phí giám định y khoa");

                entity.Property(e => e.MiniumSalaryCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Lương tối thiểu vùng (FK)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiniumSalaryId)
                    .HasColumnName("MiniumSalaryID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MiniumSalaryName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Lương tối thiểu vùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa  (dev)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất  (dev)");

                entity.Property(e => e.MoneyLeftToPay)
                    .HasColumnType("decimal(18,4)")
                    .HasDefaultValueSql("'0.0000'")
                    .HasComment("Số tiền còn lại phải đóng");

                entity.Property(e => e.MonthNumber)
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Số tháng ");

                entity.Property(e => e.MonthsParticipate)
                    .HasColumnType("int(3)")
                    .HasComment("Số tháng tham gia");

                entity.Property(e => e.MotherDiedDay)
                    .HasColumnType("date")
                    .HasComment("Ngày mẹ chết");

                entity.Property(e => e.NationalityCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Quốc tịch (Mặc định là QT Việt Nam)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NationalityName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NumberOfChildren)
                    .HasColumnType("int(3)")
                    .HasComment("Số con");

                entity.Property(e => e.ObjectiveInsurance)
                    .HasColumnType("varchar(255)")
                    .HasComment("Đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasComment("Công ty/ tổ chức")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitId)
                    .HasColumnName("OrganizationUnitID")
                    .HasComment("ID bộ phận phòng ban ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("Bộ phận phòng ban làm việc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherEmploymentContractStartDateLessThan1MonthProbationary)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu hợp đồng lao động khác (dưới 1 tháng, thử việc)");

                entity.Property(e => e.OtherSupportAmount)
                    .HasColumnType("decimal(18,0)")
                    .HasComment("Số tiền hỗ trợ khác");

                entity.Property(e => e.OtherSupportRate)
                    .HasColumnType("int(3)")
                    .HasComment("Tỉ lệ hỗ trợ khác");

                entity.Property(e => e.ParticipationFormCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Mã Hình thức tham gia/Tỷ lệ đóng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Mã Hình thức tham gia/Tỷ lệ đóng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentLevel)
                    .HasColumnType("decimal(18,4)")
                    .HasDefaultValueSql("'0.0000'")
                    .HasComment("Mức đóng = Mức lương * (1 + PCCV + PC vượt cấp) + PC lương + Các khoản bổ sung");

                entity.Property(e => e.PaymentMoney)
                    .HasColumnType("decimal(18,4)")
                    .HasDefaultValueSql("'0.0000'")
                    .HasComment("Số tiền đóng");

                entity.Property(e => e.PermanentDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Mã Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentDistricId)
                    .HasColumnName("PermanentDistricID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PermanentProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Tỉnh/Thành phố trực thuộc TW)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Mã Tỉnh thành trực thuộc TW)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentProvincialId)
                    .HasColumnName("PermanentProvincialID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PermanentVillageAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Đỉa chị thường trú (Thôn, xóm....)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Mã Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentWardId)
                    .HasColumnName("PermanentWardID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionAllowance)
                    .HasColumnType("decimal(4,2)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp chức vụ");

                entity.Property(e => e.PositionJob)
                    .HasColumnType("varchar(150)")
                    .HasComment("Vị trí làm việc ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionJobCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã vị trí việc làm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionId)
                    .HasColumnName("PossitionID")
                    .HasComment("Vị trí/Chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vị trí/ chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookId)
                    .HasColumnName("ProfileBookID")
                    .HasComment("Sổ hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceBankCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Mã Tỉnh/ TP đăng ký tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceBankId)
                    .HasColumnName("ProvinceBankID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProvinceBankName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tên Tỉnh/ TP đăng ký tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceMedicalTreatmentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Mã Tỉnh đăng ký khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceMedicalTreatmentId)
                    .HasColumnName("ProvinceMedicalTreatmentID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProvinceMedicalTreatmentName)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tên Tỉnh đăng ký khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReasonAdjust)
                    .HasColumnType("varchar(255)")
                    .HasComment("Lý do điều chỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("date")
                    .HasComment("Ngày biên lai");

                entity.Property(e => e.ReceiptMethod)
                    .HasColumnType("varchar(100)")
                    .HasComment("Hình thức nhận")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReceiptNumber)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số biên lai")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReductionRate)
                    .HasColumnType("varchar(50)")
                    .HasComment("Tỷ lệ suy giảm")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaExplain)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Vùng sinh sống (K1, K2.....)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaType)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ResidentialDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú  (Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ cư trú (Mã Quận/Huyện)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialDistricId)
                    .HasColumnName("ResidentialDistricID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ResidentialProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú (Tỉnh/Thành phố trực thuộc TW)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ cư trú (Mã Tỉnh/Thành cư trú)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialProvincialId)
                    .HasColumnName("ResidentialProvincialID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ResidentialVillageAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú (Thôn/xóm...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú  (Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Địa chỉ cư trú (Mã Xã/Phường)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialWardId)
                    .HasColumnName("ResidentialWardID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Mức lương");

                entity.Property(e => e.SalaryAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp lương");

                entity.Property(e => e.SalaryByCoefficient)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Lương tính theo hệ số");

                entity.Property(e => e.SalaryCoefficient)
                    .HasColumnType("decimal(21,3)")
                    .HasDefaultValueSql("'0.000'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Hệ số lương");

                entity.Property(e => e.SeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niên nghề - %");

                entity.Property(e => e.SocialInsuranceCodeOfChild)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm xã hội của con")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceCodeOfMother)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm xã hội của mẹ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceCodeOfPeopleRearing)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số BHXH của người nuôi dưỡng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceDeclarationCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin tham gia BHXH) Mã Phương án khai báo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceDeclarationId)
                    .HasColumnName("SocialInsuranceDeclarationID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SocialInsuranceDeclarationName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsurancePaymentAmount)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Số tiền đóng bảo hiểm xã hội");

                entity.Property(e => e.SocialInsurancePaymentRate)
                    .HasColumnType("decimal(3,1)")
                    .HasComment("Tỷ lệ đóng bảo hiểm xã hội");

                entity.Property(e => e.SocialInsurancePaymentTypeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Phương thức đóng bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsurancePaymentTypeId)
                    .HasColumnName("SocialInsurancePaymentTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SocialInsurancePaymentTypeName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortOrder)
                    .HasColumnType("int(20)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trường dùng để sắp xếp thứ tự các lao động trong hồ sơ (Bắt đầu từ 0)");

                entity.Property(e => e.StartDateOfHoldingPositionAsSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc cao");

                entity.Property(e => e.StartDateOfHoldingPositionTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.StateBudgetSupportAmount)
                    .HasColumnType("decimal(18,4)")
                    .HasDefaultValueSql("'0.0000'")
                    .HasComment("Số tiền ngân sách nhà nước hỗ trợ");

                entity.Property(e => e.StateSupportRate)
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("tỷ lệ ngân sách nhà nước hỗ trợ");

                entity.Property(e => e.SubmissionNumber).HasColumnType("int(5)");

                entity.Property(e => e.SuggestionDate)
                    .HasColumnType("date")
                    .HasComment("Ngày đơn vị đề nghị");

                entity.Property(e => e.SurgeryRecent)
                    .HasColumnType("varchar(50)")
                    .HasComment("Phẫu thuật hoặc thai dưới 32 tuần")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TerminationDateOfLaborContract)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc hợp đồng lao động xác định thời hạn");

                entity.Property(e => e.TheDayWhenTheHeavyHeavyIndustryStarted)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu ngành nghề nặng nhọc độc hại");

                entity.Property(e => e.TheStartDateOfAnIndefiniteTermLaborContract)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu hợp đồng lao động không xác định thời hạn");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH)Thống kê thông tin hồ sơ đến ngày");

                entity.Property(e => e.ValidateStatus)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trạng thái hợp lệ của hồ sơ (0: Thiếu thông tin; 1: Đủ thông tin)");

                entity.Property(e => e.VoucherSerial)
                    .HasColumnType("varchar(30)")
                    .HasComment("Số serial của chứng từ (do cskcb cấp trên cổng tiếp nhận dữ liệu Giám định BHYT)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.ProfileBookDetail)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileBookDetail_OrganizationUnitID");

                entity.HasOne(d => d.ProfileBook)
                    .WithMany(p => p.ProfileBookDetail)
                    .HasForeignKey(d => d.ProfileBookId)
                    .HasConstraintName("FK_ProfileBook_ProfileBookDetail_ProfileBookID");
            });

            modelBuilder.Entity<ProfileBookFileAttachment>(entity =>
            {
                entity.HasComment("File hồ sơ đề nghị đính kèm theo hồ sơ: chỉ có tác dụng với thủ tục 600c 600d");

                entity.HasIndex(e => e.ProfileBookId)
                    .HasName("FK_ProfileBookFileAttachment_ProfileBookID");

                entity.Property(e => e.ProfileBookFileAttachmentId)
                    .HasColumnName("ProfileBookFileAttachmentID")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProfileBookFileAttachmentName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên của hồ sơ đề nghị")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookId)
                    .HasColumnName("ProfileBookID")
                    .HasDefaultValueSql("''")
                    .HasComment("ID của hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortOrder)
                    .HasColumnType("int(11)")
                    .HasComment("Thứ tự sắp xếp các hồ sơ đề nghị");

                entity.HasOne(d => d.ProfileBook)
                    .WithMany(p => p.ProfileBookFileAttachment)
                    .HasForeignKey(d => d.ProfileBookId)
                    .HasConstraintName("FK_ProfileBookFileAttachment_ProfileBookID");
            });

            modelBuilder.Entity<ProfileFamilyDetail>(entity =>
            {
                entity.HasComment("Chi tiết Hồ sơ thành viên trong gia đình");

                entity.HasIndex(e => e.ProfileBookDetailId)
                    .HasName("FK_BookDetail");

                entity.HasIndex(e => e.ProfileFamilyDetailId)
                    .HasName("IX_PK_ProfileFamilyDetailID")
                    .IsUnique();

                entity.Property(e => e.ProfileFamilyDetailId)
                    .HasColumnName("ProfileFamilyDetailID")
                    .HasDefaultValueSql("'uuid()'")
                    .HasComment("Khóa chính thông tin gia đình")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Huyện sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BirthDistricName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Huyện sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvinceCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Tỉnh sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvinceId)
                    .HasColumnName("BirthProvinceID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BirthProvinceName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Tỉnh sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã Xã khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BirthWardName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Xã khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.EthnicCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("ID dân tộc");

                entity.Property(e => e.EthnicName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính 0: Nữ, 1: Nam");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số sổ bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasComment("Người thực hiện chỉnh sửa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.NationalityCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã quốc tịch( mặc định VN)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("ID quốc tịch");

                entity.Property(e => e.NationalityName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .HasColumnType("varchar(255)")
                    .HasComment("Ghi chú")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileBookDetailId)
                    .HasColumnName("ProfileBookDetailID")
                    .HasComment("Hồ sơ thông tin gia đình")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationIdwithHead)
                    .HasColumnName("RelationIDWithHead")
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Quan hệ với chủ hộ (1- Bố, 2 - mẹ...)");

                entity.Property(e => e.RelationWithHeadCode)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationWithHeadName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortOrder).HasColumnType("int(5)");

                entity.HasOne(d => d.ProfileBookDetail)
                    .WithMany(p => p.ProfileFamilyDetail)
                    .HasForeignKey(d => d.ProfileBookDetailId)
                    .HasConstraintName("FK_ProfileFamilyDetail_ProfileBookDetailID");
            });

            modelBuilder.Entity<Provincial>(entity =>
            {
                entity.HasComment("Danh mục Tỉnh thành");

                entity.Property(e => e.ProvincialId)
                    .HasColumnName("ProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.ProvincialCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasComment("Số thứ tự");
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.HasComment("Danh mục quan hệ");

                entity.Property(e => e.RelationId)
                    .HasColumnName("RelationID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.RelationCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã quan hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên quan hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(255)")
                    .HasComment("STT/Sắp xếp");
            });

            modelBuilder.Entity<SignatureConfig>(entity =>
            {
                entity.HasKey(e => e.OrganizationId)
                    .HasName("PRIMARY");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EsignAccessToken)
                    .HasColumnType("text")
                    .HasComment("AccessToken sau khi đăng nhập esign")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EsignCertId)
                    .HasColumnType("text")
                    .HasComment("Chứng thư số Esign")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EsignRefreshToken)
                    .HasColumnType("text")
                    .HasComment("RefreshToken sau khi đăng nhập esign")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromDate)
                    .HasColumnType("varchar(50)")
                    .HasComment("Bắt đầu từ ngày")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsEsign)
                    .HasColumnType("bit(1)")
                    .HasComment("Thiết lập cấu hình chữ ký sử dụng esign");

                entity.Property(e => e.IsOther)
                    .HasColumnType("bit(1)")
                    .HasComment("Thiết lập cấu hình chữ ký sử dụng dịch vụ khác");

                entity.Property(e => e.IsUsb)
                    .HasColumnType("bit(1)")
                    .HasComment("Thiết lập cấu hình chữ ký sử dụng USB");

                entity.Property(e => e.IssuerName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nhà cung cấp chứng thư số ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerialNumber)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số serial usb token")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubjectName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên chủ thể chứng thư số")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToDate)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SocialInsuranceDeclaration>(entity =>
            {
                entity.Property(e => e.SocialInsuranceDeclarationId)
                    .HasColumnName("SocialInsuranceDeclarationID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mô tả/Ghi chú")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceDeclarationCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã phương án khai báo BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceDeclarationName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên phương án khai báo BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceFormId)
                    .HasColumnName("SocialInsuranceFormID")
                    .HasColumnType("int(11)")
                    .HasComment("Thủ tục khai báo");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasComment("Sắp xếp");
            });

            modelBuilder.Entity<SocialInsuranceForm>(entity =>
            {
                entity.HasComment("Danh mục thủ tục bảo hiểm xã hội");

                entity.Property(e => e.SocialInsuranceFormId)
                    .HasColumnName("SocialInsuranceFormID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.Group)
                    .HasColumnType("int(11)")
                    .HasComment("0: Nhóm thủ tục BHXH, Cấp mới sổ thẻ; 1: Nhóm giải quyết chế độ BHXH; 2: Cấp lại sổ thẻ");

                entity.Property(e => e.SocialInsuranceFormCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã thủ tục")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceFormName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên thủ tục BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasComment("Sắp xếp/ STT");
            });

            modelBuilder.Entity<SocialInsurancePaymentType>(entity =>
            {
                entity.HasComment("Bảng phương án đóng BHXH");

                entity.Property(e => e.SocialInsurancePaymentTypeId)
                    .HasColumnName("SocialInsurancePaymentTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SocialInsurancePaymentTypeCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã phương thức đóng (Thông tin này quan trọng, sử dụng để gửi cho BHXH)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SocialInsurancePaymentTypeName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên phương thức đóng")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasComment("Thông tin công ty/ Thông tin thuê bao ");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasComment("ID công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessRegistrationCode)
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã số đăng ký kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfEstablishment)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thành lập công ty");

                entity.Property(e => e.DateOfIssue)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cấp số đăng ký kinh doanh");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasComment("Email công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fax)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số fax")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên người đại diện pháp lý")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlaceOfIssue)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp số đăng ký kinh doanh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tax)
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã số thuế của công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(100)")
                    .HasComment("Chức danh của người đại diện pháp lý")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TransactionName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên giao dịch/viết tắt")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Website)
                    .HasColumnType("varchar(255)")
                    .HasComment("Website công ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ViewEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Employee");

                entity.Property(e => e.AdditionalAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Các khoản bổ sung");

                entity.Property(e => e.AddressOnPaper)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ trên giấy tờ (VD hộ khẩu)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccountName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên chủ thẻ ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankAccountNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Số tài khoản ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchId)
                    .HasColumnName("BankBranchID")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác)  Chi nhánh ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankBranchName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên ngân hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã ngân hàng cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BankId)
                    .HasColumnName("BankID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Ngân hàng");

                entity.Property(e => e.BankName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên ngân hàng cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BenefitObjectId)
                    .HasColumnName("BenefitObjectID")
                    .HasColumnType("varchar(5)")
                    .HasComment("ID đối tượng hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Quận/Huyện)");

                entity.Property(e => e.BirthProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvincialId)
                    .HasColumnName("BirthProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthVillageId)
                    .HasColumnName("BirthVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh");

                entity.Property(e => e.BirthWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ khai sinh (Xã/Phường)");

                entity.Property(e => e.BookFamilyCode)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityDate)
                    .HasColumnType("date")
                    .HasComment("Ngày cấp chứng minh thư/ hộ chiếu");

                entity.Property(e => e.CitizenIdentityNo)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasComment("Số CMTND/Hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityPlaceCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityPlaceId)
                    .HasColumnName("CitizenIdentityPlaceID")
                    .HasColumnType("int(11)")
                    .HasComment("Mã nơi cấp chứng minh thư nhân dân");

                entity.Property(e => e.CitizenIdentityPlaceName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractName)
                    .HasColumnType("varchar(150)")
                    .HasComment("Tên loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Số hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractType)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DateOfStartingAfixedTermLaborContract)
                    .HasColumnName("DateOfStartingAFixedTermLaborContract")
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu hợp đồng lao động xác định thời hạn");

                entity.Property(e => e.DateOfStartingAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm khác");

                entity.Property(e => e.DateOfStartingPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Nhà quản lý");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.DocumentNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin gia đình) Số giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeId)
                    .HasColumnName("DocumentTypeID")
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Loại giấy tờ (1- Sổ hộ khẩu,...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DocumentTypeName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên loại giấy tờ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Ngày có hiệu lực/ Ngày ký");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasComment("Địa chỉ thư điện tử")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã hồ sơ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDateHoldsAnotherJobPosition)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc khác");

                entity.Property(e => e.EndDateHoldsThePositionOfIntermediateTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.EndDateHoldsThePositionOfSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày kết thúc giữ vị trí việc Chuyên môn kỹ thuật bậc cao
");

                entity.Property(e => e.EndDateOfLaborContractLessThan1MonthProbation)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc hợp đồng lao động (dưới 1 tháng, thử việc)");

                entity.Property(e => e.EndDateOfTheJobPositionAsManager)
                    .HasColumnType("datetime")
                    .HasComment("Ngày kết thúc giữ vị trí việc làm là nhà quản lý");

                entity.Property(e => e.EndOfToxicHeavyHeavyIndustry)
                    .HasColumnType("datetime")
                    .HasComment(@" Ngày kết thúc ngành nghề nặng nhọc độc hại
");

                entity.Property(e => e.EthnicCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("Dân tộc");

                entity.Property(e => e.EthnicName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Ngày hết hiệu lực");

                entity.Property(e => e.ExtraSeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niêm vượt khung");

                entity.Property(e => e.FamilyCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("(Thông tin gia đình) Mã hộ gia đình")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FamilyHeadsName)
                    .HasColumnType("varchar(100)")
                    .HasComment("(Thông tin gia đình) Họ và tên chủ hộ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính: 0 nữ, 1 nam");

                entity.Property(e => e.GuardianName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên người giám hộ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HaveInsuranceBookNo)
                    .HasColumnType("bit(1)")
                    .HasComment("Có mã số BHXH hay ko 1: Có, 0: Không");

                entity.Property(e => e.HealthInsuranceLevel)
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Mức hưởng");

                entity.Property(e => e.HomeDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeDistricId)
                    .HasColumnName("HomeDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Quận/huyện");

                entity.Property(e => e.HomeDistricName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("(Thông tin gia đình) Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeProvinceCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeProvinceId)
                    .HasColumnName("HomeProvinceID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Tỉnh/TP trực thuộc trung ương");

                entity.Property(e => e.HomeProvinceName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeVillageCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã thôn")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeVillageId)
                    .HasColumnName("HomeVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Thôn/ xóm");

                entity.Property(e => e.HomeVillageName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên thôn")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeWardId)
                    .HasColumnName("HomeWardID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin gia đình) Xã/phường");

                entity.Property(e => e.HomeWardName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã bệnh viện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalId)
                    .HasColumnName("HospitalID")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Bệnh viện khám chữa bệnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HospitalName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên bệnh viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceBook)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("(Thông tin tham gia BHXH) Có số BHXH hay không (0-không, 1- có)");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("(Thông tin tham gia BHXH) Mã số BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'")
                    .HasComment("Trạng thái tham gia BHXH (0 - Không tham gia, 1- Đang tham gia)");

                entity.Property(e => e.IsBaneful)
                    .HasColumnType("bit(1)")
                    .HasComment("Có phải là làm việc ở môi trường độc hại hay không ?");

                entity.Property(e => e.IsFamilyHead)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Có phải chủ hộ không: 1 là chủ hộ");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiniumSalaryCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã vùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiniumSalaryId)
                    .HasColumnName("MiniumSalaryID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Lương tối thiểu vùng (FK)");

                entity.Property(e => e.MiniumSalaryName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("Quốc tịch");

                entity.Property(e => e.NationalityName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ObjectiveInsurance)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên đối tượng mức hưởng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitId)
                    .HasColumnName("OrganizationUnitID")
                    .HasComment("ID bộ phận phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasComment("Văn phòng/Chi nhánh làm việc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherEmploymentContractStartDateLessThan1MonthProbationary)
                    .HasColumnType("datetime")
                    .HasComment(" Ngày bắt đầu hợp đồng lao động khác (dưới 1 tháng, thử việc)");

                entity.Property(e => e.OtherSupportAmount).HasColumnType("decimal(18,0)");

                entity.Property(e => e.ParticipationFormCode)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipationFormName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên hình thức tham gia/ tỷ lệ đóng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentDistricId)
                    .HasColumnName("PermanentDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Quận/Huyện)");

                entity.Property(e => e.PermanentProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentProvincialId)
                    .HasColumnName("PermanentProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.PermanentVillageId)
                    .HasColumnName("PermanentVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Đỉa chị thường trú (Thôn, xóm....)");

                entity.Property(e => e.PermanentWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermanentWardId)
                    .HasColumnName("PermanentWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ hộ khẩu thường trú (Xã/Phường)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionAllowance)
                    .HasColumnType("decimal(4,2)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp chức vụ");

                entity.Property(e => e.PositionJob)
                    .HasColumnType("varchar(150)")
                    .HasComment("Vị trí làm việc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionJobCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Ma vi tri lam viec")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionId)
                    .HasColumnName("PossitionID")
                    .HasComment("Vị trí/Chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PossitionName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên chức vụ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceBankCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceBankId)
                    .HasColumnName("ProvinceBankID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tỉnh đăng ký tài khoản ngân hàng");

                entity.Property(e => e.ProvinceBankName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceMedicalTreatmentCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceMedicalTreatmentId)
                    .HasColumnName("ProvinceMedicalTreatmentID")
                    .HasColumnType("int(11)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin khác) Tỉnh đăng ký khám chữa bệnh");

                entity.Property(e => e.ProvinceMedicalTreatmentName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaExplain)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaName)
                    .HasColumnType("varchar(2)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialAreaType)
                    .HasColumnType("int(255)")
                    .HasComment("Vùng sinh sống (1-Thành thị, 2- Nông thôn...)");

                entity.Property(e => e.ResidentialDistricAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialDistricId)
                    .HasColumnName("ResidentialDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú  (Quận/Huyện)");

                entity.Property(e => e.ResidentialProvincialAddress)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialProvincialCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialProvincialId)
                    .HasColumnName("ResidentialProvincialID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú (Tỉnh/Thành phố trực thuộc TW)");

                entity.Property(e => e.ResidentialVillageAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ cư trú (Thôn/xóm...)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialVillageId)
                    .HasColumnName("ResidentialVillageID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú (Thôn/xóm...)");

                entity.Property(e => e.ResidentialWardAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidentialWardId)
                    .HasColumnName("ResidentialWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Địa chỉ cư trú  (Xã/Phường)");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Mức lương");

                entity.Property(e => e.SalaryAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp lương");

                entity.Property(e => e.SalaryByCoefficient)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment(" Lương tính theo hệ số 1: lương tính theo hệ số, 0: theo mức lương");

                entity.Property(e => e.SalaryCoefficient)
                    .HasColumnType("decimal(21,3)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Hệ số lương");

                entity.Property(e => e.SeniorityAllowance)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("(Thông tin tham gia BHXH) (Thông tin mức đóng) Phụ cấp thâm niên nghề - %");

                entity.Property(e => e.SocialInsurancePaymentTypeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã phương thức đóng (Thông tin này quan trọng, sử dụng để gửi cho BHXH)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SocialInsurancePaymentTypeId)
                    .HasColumnName("SocialInsurancePaymentTypeID")
                    .HasColumnType("int(11)")
                    .HasComment("Phương thức đóng bảo hiểm xã hội");

                entity.Property(e => e.SocialInsurancePaymentTypeName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên phương thức đóng")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.StartDateOfHoldingPositionAsSeniorTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc cao
");

                entity.Property(e => e.StartDateOfHoldingPositionTechnicalSpecialist)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu giữ vị trí việc làm Chuyên môn kỹ thuật bậc trung");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantID")
                    .HasComment("ID của công ty (Lấy từ bảng tenant)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TerminationDateOfLaborContract)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày kết thúc hợp đồng lao động xác định thời hạn

");

                entity.Property(e => e.TheDayWhenTheHeavyHeavyIndustryStarted)
                    .HasColumnType("datetime")
                    .HasComment("Ngày bắt đầu ngành nghề nặng nhọc độc hại");

                entity.Property(e => e.TheStartDateOfAnIndefiniteTermLaborContract)
                    .HasColumnType("datetime")
                    .HasComment(@"Ngày bắt đầu hợp đồng lao động không xác định thời hạn
");
            });

            modelBuilder.Entity<ViewEmployeeFamily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_EmployeeFamily");

                entity.Property(e => e.BirthDistricCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDistricId)
                    .HasColumnName("BirthDistricID")
                    .HasColumnType("int(11)")
                    .HasComment("Huyện sinh");

                entity.Property(e => e.BirthDistricName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvinceCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthProvinceId)
                    .HasColumnName("BirthProvinceID")
                    .HasColumnType("int(11)")
                    .HasComment("Tỉnh sinh");

                entity.Property(e => e.BirthProvinceName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên tỉnh thành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthVillageAddress)
                    .HasColumnType("text")
                    .HasComment("Địa chỉ khai sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthWardId)
                    .HasColumnName("BirthWardID")
                    .HasColumnType("int(11)")
                    .HasComment("Xã khai sinh");

                entity.Property(e => e.BirthWardName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên địa bàn hành chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityNo)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DobdisplaySetting)
                    .HasColumnName("DOBDisplaySetting")
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("Kiểu hiển thị ngày sinh(1- ngày/tháng/năm; 2- tháng/ngày/năm;...)");

                entity.Property(e => e.EmployeeFamilyId)
                    .HasColumnName("EmployeeFamilyID")
                    .HasComment("Khóa chính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("Khóa ngoại với bảng Employee")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasColumnType("int(11)")
                    .HasComment("ID dân tộc");

                entity.Property(e => e.EthnicName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính 0: Nữ, 1: Nam");

                entity.Property(e => e.InsuranceBookNo)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số sổ bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã số bảo hiểm xã hội")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceStatus).HasColumnType("bit(1)");

                entity.Property(e => e.NationalityCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasColumnType("int(11)")
                    .HasComment("ID quốc tịch");

                entity.Property(e => e.NationalityName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên quốc tịch")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationIdwithHead)
                    .HasColumnName("RelationIDWithHead")
                    .HasColumnType("int(255)")
                    .HasComment("Quan hệ với chủ hộ (1- Bố, 2 - mẹ...)");

                entity.Property(e => e.RelationWithHeadCode)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã quan hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelationWithHeadName)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên quan hệ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortOrder).HasColumnType("int(5)");
            });

            modelBuilder.Entity<Village>(entity =>
            {
                entity.HasKey(e => e.VillageId)
                    .HasName("PRIMARY");

                entity.Property(e => e.VillageId)
                    .HasColumnName("VillageID")
                    .HasColumnType("int(11)")
                    .HasComment("PK");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasComment("Tình trạng");

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã thôn")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VillageHeadsCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã cán bộ/Nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VillageHeadsName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên trưởng thôn")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VillageName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên thôn")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WardCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã xã/ phường")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
    }
}
