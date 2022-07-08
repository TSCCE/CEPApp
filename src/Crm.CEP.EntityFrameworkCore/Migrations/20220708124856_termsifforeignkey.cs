using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.CEP.Migrations
{
    public partial class termsifforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCoupons_AppTermsConditionss_TermsId",
                table: "AppCoupons");

            migrationBuilder.AlterColumn<long>(
                name: "TermsId",
                table: "AppCoupons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCoupons_AppTermsConditionss_TermsId",
                table: "AppCoupons",
                column: "TermsId",
                principalTable: "AppTermsConditionss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCoupons_AppTermsConditionss_TermsId",
                table: "AppCoupons");

            migrationBuilder.AlterColumn<long>(
                name: "TermsId",
                table: "AppCoupons",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCoupons_AppTermsConditionss_TermsId",
                table: "AppCoupons",
                column: "TermsId",
                principalTable: "AppTermsConditionss",
                principalColumn: "Id");
        }
    }
}
