using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddMessenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageEmbeds",
                columns: table => new
                {
                    Isn = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnPost = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEmbeds", x => x.Isn);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Isn = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnUploader = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Isn);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Isn = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnProfilePicture = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    Website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AboutMe = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Isn);
                    table.ForeignKey(
                        name: "FK_Users_Images_IsnProfilePicture",
                        column: x => x.IsnProfilePicture,
                        principalTable: "Images",
                        principalColumn: "Isn");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Isn = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnUser = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Isn);
                    table.ForeignKey(
                        name: "FK_Posts_Users_IsnUser",
                        column: x => x.IsnUser,
                        principalTable: "Users",
                        principalColumn: "Isn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageEmbeds_IsnImage",
                table: "ImageEmbeds",
                column: "IsnImage");

            migrationBuilder.CreateIndex(
                name: "IX_ImageEmbeds_IsnPost",
                table: "ImageEmbeds",
                column: "IsnPost");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsnUploader",
                table: "Images",
                column: "IsnUploader");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsnUser",
                table: "Posts",
                column: "IsnUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsnProfilePicture",
                table: "Users",
                column: "IsnProfilePicture");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEmbeds_Images_IsnImage",
                table: "ImageEmbeds",
                column: "IsnImage",
                principalTable: "Images",
                principalColumn: "Isn",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEmbeds_Posts_IsnPost",
                table: "ImageEmbeds",
                column: "IsnPost",
                principalTable: "Posts",
                principalColumn: "Isn",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_IsnUploader",
                table: "Images",
                column: "IsnUploader",
                principalTable: "Users",
                principalColumn: "Isn",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_IsnProfilePicture",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ImageEmbeds");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
