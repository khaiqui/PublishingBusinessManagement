using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublishingBusinessManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    au_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    au_lname = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    au_fname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false, defaultValue: "UNKNOWN"),
                    address = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    contract = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_auidind", x => x.au_id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    job_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_desc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "New Position - title not formalized yet"),
                    min_lvl = table.Column<byte>(type: "tinyint", nullable: false),
                    max_lvl = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__jobs__6E32B6A5318E3102", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    pub_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    pub_name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    country = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true, defaultValue: "USA")
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_pubind", x => x.pub_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    stor_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    stor_name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    stor_address = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPK_storeid", x => x.stor_id);
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
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    emp_id = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: false),
                    fname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    minit = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    lname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    job_id = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    job_lvl = table.Column<byte>(type: "tinyint", nullable: true, defaultValue: (byte)10),
                    pub_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false, defaultValue: "9952"),
                    hire_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp_id", x => x.emp_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__employee__job_id__5BE2A6F2",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "job_id");
                    table.ForeignKey(
                        name: "FK__employee__pub_id__5EBF139D",
                        column: x => x.pub_id,
                        principalTable: "publishers",
                        principalColumn: "pub_id");
                });

            migrationBuilder.CreateTable(
                name: "pub_info",
                columns: table => new
                {
                    pub_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    logo = table.Column<byte[]>(type: "image", nullable: true),
                    pr_info = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_pubinfo", x => x.pub_id);
                    table.ForeignKey(
                        name: "FK__pub_info__pub_id__571DF1D5",
                        column: x => x.pub_id,
                        principalTable: "publishers",
                        principalColumn: "pub_id");
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    title_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    title = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    type = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false, defaultValue: "UNDECIDED"),
                    pub_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true),
                    advance = table.Column<decimal>(type: "money", nullable: true),
                    royalty = table.Column<int>(type: "int", nullable: true),
                    ytd_sales = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_titleidind", x => x.title_id);
                    table.ForeignKey(
                        name: "FK__titles__pub_id__412EB0B6",
                        column: x => x.pub_id,
                        principalTable: "publishers",
                        principalColumn: "pub_id");
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    discounttype = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    stor_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    lowqty = table.Column<short>(type: "smallint", nullable: true),
                    highqty = table.Column<short>(type: "smallint", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__discounts__stor___4F7CD00D",
                        column: x => x.stor_id,
                        principalTable: "stores",
                        principalColumn: "stor_id");
                });

            migrationBuilder.CreateTable(
                name: "roysched",
                columns: table => new
                {
                    title_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    lorange = table.Column<int>(type: "int", nullable: true),
                    hirange = table.Column<int>(type: "int", nullable: true),
                    royalty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__roysched__title___4D94879B",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "title_id");
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    stor_id = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    ord_num = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    title_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    ord_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    qty = table.Column<short>(type: "smallint", nullable: false),
                    payterms = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_sales", x => new { x.stor_id, x.ord_num, x.title_id });
                    table.ForeignKey(
                        name: "FK__sales__stor_id__4AB81AF0",
                        column: x => x.stor_id,
                        principalTable: "stores",
                        principalColumn: "stor_id");
                    table.ForeignKey(
                        name: "FK__sales__title_id__4BAC3F29",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "title_id");
                });

            migrationBuilder.CreateTable(
                name: "titleauthor",
                columns: table => new
                {
                    au_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    title_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    au_ord = table.Column<byte>(type: "tinyint", nullable: true),
                    royaltyper = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UPKCL_taind", x => new { x.au_id, x.title_id });
                    table.ForeignKey(
                        name: "FK__titleauth__au_id__44FF419A",
                        column: x => x.au_id,
                        principalTable: "authors",
                        principalColumn: "au_id");
                    table.ForeignKey(
                        name: "FK__titleauth__title__45F365D3",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "title_id");
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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "aunmind",
                table: "authors",
                columns: new[] { "au_lname", "au_fname" });

            migrationBuilder.CreateIndex(
                name: "IX_discounts_stor_id",
                table: "discounts",
                column: "stor_id");

            migrationBuilder.CreateIndex(
                name: "employee_ind",
                table: "employee",
                columns: new[] { "lname", "fname", "minit" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_job_id",
                table: "employee",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_pub_id",
                table: "employee",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "titleidind",
                table: "roysched",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "titleidind",
                table: "sales",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "auidind",
                table: "titleauthor",
                column: "au_id");

            migrationBuilder.CreateIndex(
                name: "titleidind",
                table: "titleauthor",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_titles_pub_id",
                table: "titles",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "titleind",
                table: "titles",
                column: "title");
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
                name: "discounts");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "pub_info");

            migrationBuilder.DropTable(
                name: "roysched");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "titleauthor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
