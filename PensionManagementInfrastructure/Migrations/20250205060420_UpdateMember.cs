using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PensionManagementInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributionMonths",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContributionMonthsCount",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleForBenefit",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContributionMonths",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ContributionMonthsCount",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsEligibleForBenefit",
                table: "Members");
        }
    }
}
