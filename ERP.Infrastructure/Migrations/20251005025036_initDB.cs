#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hierarchy");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "Seeding");

            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.CreateSequence<int>(
                name: "UserId");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Seal = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Seeding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "EGP"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                schema: "Seeding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "Seeding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.CheckConstraint("CK_Unit_Quantity", "Quantity >= 1 AND Quantity <= 1.7976931348623157E+308");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsMainBranch = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Seeding",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, defaultValue: "/Images/Users/DefaultUser.jpg"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Purchasing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Inventory",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Debtor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.Id);
                    table.CheckConstraint("CK_CustomerAccount_Creditor", "Creditor >= 0 AND Creditor <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_CustomerAccount_Debtor", "Debtor >= 0 AND Debtor <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_CustomerAccount_Total", "Total >= 0 AND Total <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "NEXT VALUE FOR UserId"),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsUser = table.Column<bool>(type: "bit", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.CheckConstraint("CK_Employee_IsActive", "IsActive IN (0,1)");
                    table.CheckConstraint("CK_Employee_IsUser", "IsUser IN (0,1)");
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Hierarchy",
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierAccounts",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Debtor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAccounts", x => x.Id);
                    table.CheckConstraint("CK_SupplierAccount_Creditor", "Creditor >= 0 AND Creditor <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_SupplierAccount_Debtor", "Debtor >= 0 AND Debtor <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_SupplierAccount_Total", "Total >= 0 AND Total <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_SupplierAccounts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_Product_Price", "Price >= 0 AND Price <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_Products_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Inventory",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Seeding",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Employees_UserId",
                        column: x => x.UserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Employees_UserId",
                        column: x => x.UserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Employees_UserId",
                        column: x => x.UserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Employees_UserId",
                        column: x => x.UserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentVouchers",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVouchers", x => x.Id);
                    table.CheckConstraint("CK_PaymentVoucher_AmountPaid", "AmountPaid >= 0 AND AmountPaid <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_PaymentVouchers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentVouchers_Employees_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentVouchers_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Seeding",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentVouchers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                schema: "Purchasing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PurchaseInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    BeforeDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalWritten = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Seeding",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptVouchers",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVouchers", x => x.Id);
                    table.CheckConstraint("CK_PaymentVoucher_AmountPaid1", "AmountPaid >= 0 AND AmountPaid <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_ReceiptVouchers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptVouchers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptVouchers_Employees_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptVouchers_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Seeding",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoices",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleInvoiceKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SaleInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    BeforeDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalWritten = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Seeding",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AdminstratorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Hierarchy",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Employees_AdminstratorId",
                        column: x => x.AdminstratorId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceItems",
                schema: "Purchasing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceItems", x => x.Id);
                    table.CheckConstraint("CK_PurchaseInvoiceItem_quantity", "quantity >= 1 AND quantity <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_PurchaseInvoiceItem_Total", "Total >= 0 AND Total <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_PurchaseInvoiceItem_UnitPrice", "UnitPrice >= 0 AND UnitPrice <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Inventory",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoiceItems",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    SaleInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoiceItems", x => x.Id);
                    table.CheckConstraint("CK_SaleInvoiceItem_quantity", "quantity >= 1 AND quantity <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_SaleInvoiceItem_Total", "Total >= 0 AND Total <= 1.7976931348623157E+308");
                    table.CheckConstraint("CK_SaleInvoiceItem_UnitPrice", "UnitPrice >= 0 AND UnitPrice <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_SaleInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceItems_SaleInvoices_SaleInvoiceId",
                        column: x => x.SaleInvoiceId,
                        principalSchema: "Sales",
                        principalTable: "SaleInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Inventory",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.CheckConstraint("CK_Stock_Quantity", "Quantity >= 1 AND Quantity <= 1.7976931348623157E+308");
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Inventory",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreHistories",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreHistories_Employees_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreHistories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Inventory",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockHistories",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockHistories_Employees_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Hierarchy",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockHistories_Stocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "Inventory",
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CurrencyId",
                schema: "Hierarchy",
                table: "Branches",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                schema: "Hierarchy",
                table: "Branches",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BranchId",
                schema: "Inventory",
                table: "Brands",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name_BranchId",
                schema: "Inventory",
                table: "Brands",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BrandId",
                schema: "Inventory",
                table: "Categories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name_BrandId",
                schema: "Inventory",
                table: "Categories",
                columns: new[] { "Name", "BrandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                schema: "Hierarchy",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                schema: "Seeding",
                table: "Currencies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                schema: "Seeding",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerId",
                schema: "Accounting",
                table: "CustomerAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                schema: "Sales",
                table: "Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email_BranchId",
                schema: "Sales",
                table: "Customers",
                columns: new[] { "Email", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name_BranchId",
                schema: "Sales",
                table: "Customers",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber_BranchId",
                schema: "Sales",
                table: "Customers",
                columns: new[] { "PhoneNumber", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                schema: "Hierarchy",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_BranchId",
                schema: "Hierarchy",
                table: "Departments",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Hierarchy",
                table: "Employees",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                schema: "Hierarchy",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                schema: "Hierarchy",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                schema: "Hierarchy",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "Hierarchy",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Hierarchy",
                table: "Employees",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Name",
                schema: "Seeding",
                table: "PaymentMethods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVouchers_BranchId",
                schema: "Finance",
                table: "PaymentVouchers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVouchers_CreatedByUserId",
                schema: "Finance",
                table: "PaymentVouchers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVouchers_PaymentMethodId",
                schema: "Finance",
                table: "PaymentVouchers",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVouchers_SupplierId",
                schema: "Finance",
                table: "PaymentVouchers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BranchId",
                schema: "Inventory",
                table: "Products",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Inventory",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_BranchId",
                schema: "Inventory",
                table: "Products",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                schema: "Inventory",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_ProductId",
                schema: "Purchasing",
                table: "PurchaseInvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_PurchaseInvoiceId_ProductId",
                schema: "Purchasing",
                table: "PurchaseInvoiceItems",
                columns: new[] { "PurchaseInvoiceId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_StoreId",
                schema: "Purchasing",
                table: "PurchaseInvoiceItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_BranchId",
                schema: "Purchasing",
                table: "PurchaseInvoices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_EmployeeId",
                schema: "Purchasing",
                table: "PurchaseInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_PaymentMethodId",
                schema: "Purchasing",
                table: "PurchaseInvoices",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_SupplierId",
                schema: "Purchasing",
                table: "PurchaseInvoices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVouchers_BranchId",
                schema: "Finance",
                table: "ReceiptVouchers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVouchers_CreatedByUserId",
                schema: "Finance",
                table: "ReceiptVouchers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVouchers_CustomerId",
                schema: "Finance",
                table: "ReceiptVouchers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVouchers_PaymentMethodId",
                schema: "Finance",
                table: "ReceiptVouchers",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceItems_ProductId",
                schema: "Sales",
                table: "SaleInvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceItems_SaleInvoiceId_ProductId",
                schema: "Sales",
                table: "SaleInvoiceItems",
                columns: new[] { "SaleInvoiceId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceItems_StoreId",
                schema: "Sales",
                table: "SaleInvoiceItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_BranchId",
                schema: "Sales",
                table: "SaleInvoices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_CustomerId",
                schema: "Sales",
                table: "SaleInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_EmployeeId",
                schema: "Sales",
                table: "SaleInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_PaymentMethodId",
                schema: "Sales",
                table: "SaleInvoices",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_CreatedByUserId",
                schema: "Inventory",
                table: "StockHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_StockId",
                schema: "Inventory",
                table: "StockHistories",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Inventory",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StoreId",
                schema: "Inventory",
                table: "Stocks",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHistories_CreatedByUserId",
                schema: "Inventory",
                table: "StoreHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHistories_StoreId",
                schema: "Inventory",
                table: "StoreHistories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminstratorId",
                schema: "Inventory",
                table: "Stores",
                column: "AdminstratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BranchId",
                schema: "Inventory",
                table: "Stores",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Name_BranchId",
                schema: "Inventory",
                table: "Stores",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAccounts_SupplierId",
                schema: "Accounting",
                table: "SupplierAccounts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BranchId",
                schema: "Purchasing",
                table: "Suppliers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Email_BranchId",
                schema: "Purchasing",
                table: "Suppliers",
                columns: new[] { "Email", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name_BranchId",
                schema: "Purchasing",
                table: "Suppliers",
                columns: new[] { "Name", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PhoneNumber_BranchId",
                schema: "Purchasing",
                table: "Suppliers",
                columns: new[] { "PhoneNumber", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Name",
                schema: "Seeding",
                table: "Units",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Hierarchy");

            migrationBuilder.DropTable(
                name: "CustomerAccounts",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PaymentVouchers",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceItems",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "ReceiptVouchers",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "SaleInvoiceItems",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "StockHistories",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "StoreHistories",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SupplierAccounts",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SaleInvoices",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PaymentMethods",
                schema: "Seeding");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "Seeding");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Hierarchy");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Hierarchy");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "Hierarchy");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Seeding");

            migrationBuilder.DropSequence(
                name: "UserId");
        }
    }
}
