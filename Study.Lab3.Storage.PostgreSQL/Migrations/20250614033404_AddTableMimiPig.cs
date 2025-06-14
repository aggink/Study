using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMimiPig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheKvn_Students_IsnStudent",
                table: "TheKvn");

            migrationBuilder.DropForeignKey(
                name: "FK_TheKvn_Subjects_IsnSubject",
                table: "TheKvn");

            migrationBuilder.DropForeignKey(
                name: "FK_TheProfcom_Students_IsnStudent",
                table: "TheProfcom");

            migrationBuilder.DropForeignKey(
                name: "FK_TheProfcom_Subjects_IsnSubject",
                table: "TheProfcom");

            migrationBuilder.DropForeignKey(
                name: "FK_TheProjectActivities_Students_IsnStudent",
                table: "TheProjectActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TheProjectActivities_Subjects_IsnSubject",
                table: "TheProjectActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TheProjectActivities",
                table: "TheProjectActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TheProfcom",
                table: "TheProfcom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TheKvn",
                table: "TheKvn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "TheProjectActivities",
                newName: "ProjectActivities");

            migrationBuilder.RenameTable(
                name: "TheProfcom",
                newName: "Profcoms");

            migrationBuilder.RenameTable(
                name: "TheKvn",
                newName: "Kvns");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "FitnessEquipments");

            migrationBuilder.RenameIndex(
                name: "IX_TheProjectActivities_IsnSubject",
                table: "ProjectActivities",
                newName: "IX_ProjectActivities_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_TheProjectActivities_IsnStudent",
                table: "ProjectActivities",
                newName: "IX_ProjectActivities_IsnStudent");

            migrationBuilder.RenameIndex(
                name: "IX_TheProfcom_IsnSubject",
                table: "Profcoms",
                newName: "IX_Profcoms_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_TheProfcom_IsnStudent",
                table: "Profcoms",
                newName: "IX_Profcoms_IsnStudent");

            migrationBuilder.RenameIndex(
                name: "IX_TheKvn_IsnSubject",
                table: "Kvns",
                newName: "IX_Kvns_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_TheKvn_IsnStudent",
                table: "Kvns",
                newName: "IX_Kvns_IsnStudent");

            migrationBuilder.AddColumn<Guid>(
                name: "IsnMiniPig",
                table: "Adoptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectActivities",
                table: "ProjectActivities",
                column: "IsnProjectActivities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profcoms",
                table: "Profcoms",
                column: "IsnProfcom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kvns",
                table: "Kvns",
                column: "IsnKvn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessEquipments",
                table: "FitnessEquipments",
                column: "IsnEquipment");

            migrationBuilder.CreateTable(
                name: "MiniPigs",
                columns: table => new
                {
                    IsnMiniPig = table.Column<Guid>(type: "uuid", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsVaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    IsSterilized = table.Column<bool>(type: "boolean", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailableForAdoption = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniPigs", x => x.IsnMiniPig);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnMiniPig",
                table: "Adoptions",
                column: "IsnMiniPig");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_MiniPigs_IsnMiniPig",
                table: "Adoptions",
                column: "IsnMiniPig",
                principalTable: "MiniPigs",
                principalColumn: "IsnMiniPig",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kvns_Students_IsnStudent",
                table: "Kvns",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kvns_Subjects_IsnSubject",
                table: "Kvns",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profcoms_Students_IsnStudent",
                table: "Profcoms",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profcoms_Subjects_IsnSubject",
                table: "Profcoms",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActivities_Students_IsnStudent",
                table: "ProjectActivities",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActivities_Subjects_IsnSubject",
                table: "ProjectActivities",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_MiniPigs_IsnMiniPig",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Kvns_Students_IsnStudent",
                table: "Kvns");

            migrationBuilder.DropForeignKey(
                name: "FK_Kvns_Subjects_IsnSubject",
                table: "Kvns");

            migrationBuilder.DropForeignKey(
                name: "FK_Profcoms_Students_IsnStudent",
                table: "Profcoms");

            migrationBuilder.DropForeignKey(
                name: "FK_Profcoms_Subjects_IsnSubject",
                table: "Profcoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActivities_Students_IsnStudent",
                table: "ProjectActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActivities_Subjects_IsnSubject",
                table: "ProjectActivities");

            migrationBuilder.DropTable(
                name: "MiniPigs");

            migrationBuilder.DropIndex(
                name: "IX_Adoptions_IsnMiniPig",
                table: "Adoptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectActivities",
                table: "ProjectActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profcoms",
                table: "Profcoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kvns",
                table: "Kvns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessEquipments",
                table: "FitnessEquipments");

            migrationBuilder.DropColumn(
                name: "IsnMiniPig",
                table: "Adoptions");

            migrationBuilder.RenameTable(
                name: "ProjectActivities",
                newName: "TheProjectActivities");

            migrationBuilder.RenameTable(
                name: "Profcoms",
                newName: "TheProfcom");

            migrationBuilder.RenameTable(
                name: "Kvns",
                newName: "TheKvn");

            migrationBuilder.RenameTable(
                name: "FitnessEquipments",
                newName: "Equipments");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectActivities_IsnSubject",
                table: "TheProjectActivities",
                newName: "IX_TheProjectActivities_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectActivities_IsnStudent",
                table: "TheProjectActivities",
                newName: "IX_TheProjectActivities_IsnStudent");

            migrationBuilder.RenameIndex(
                name: "IX_Profcoms_IsnSubject",
                table: "TheProfcom",
                newName: "IX_TheProfcom_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_Profcoms_IsnStudent",
                table: "TheProfcom",
                newName: "IX_TheProfcom_IsnStudent");

            migrationBuilder.RenameIndex(
                name: "IX_Kvns_IsnSubject",
                table: "TheKvn",
                newName: "IX_TheKvn_IsnSubject");

            migrationBuilder.RenameIndex(
                name: "IX_Kvns_IsnStudent",
                table: "TheKvn",
                newName: "IX_TheKvn_IsnStudent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheProjectActivities",
                table: "TheProjectActivities",
                column: "IsnProjectActivities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheProfcom",
                table: "TheProfcom",
                column: "IsnProfcom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheKvn",
                table: "TheKvn",
                column: "IsnKvn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "IsnEquipment");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKvn_Students_IsnStudent",
                table: "TheKvn",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheKvn_Subjects_IsnSubject",
                table: "TheKvn",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheProfcom_Students_IsnStudent",
                table: "TheProfcom",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheProfcom_Subjects_IsnSubject",
                table: "TheProfcom",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheProjectActivities_Students_IsnStudent",
                table: "TheProjectActivities",
                column: "IsnStudent",
                principalTable: "Students",
                principalColumn: "IsnStudent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheProjectActivities_Subjects_IsnSubject",
                table: "TheProjectActivities",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
