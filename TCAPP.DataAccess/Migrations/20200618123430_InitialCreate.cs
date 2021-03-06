﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCAPP.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentRelationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer(11)", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRelationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer(11)", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaValueType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer(11)", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaValueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false),
                    Multiple = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Email = table.Column<string>(type: "varchar(512)", nullable: false),
                    Password = table.Column<string>(type: "varchar(512)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", nullable: false),
                    IdContentType = table.Column<int>(type: "integer(11)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Content_PK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_ContentType",
                        column: x => x.IdContentType,
                        principalTable: "ContentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParentTaxonomy",
                columns: table => new
                {
                    IdTaxonomy = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdParentTaxonomy = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentTaxonomy", x => new { x.IdTaxonomy, x.IdParentTaxonomy });
                    table.ForeignKey(
                        name: "FK_ParentTaxonomy_ChildrenTaxonomy",
                        column: x => x.IdParentTaxonomy,
                        principalTable: "Taxonomy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParentTaxonomy_Taxonomy",
                        column: x => x.IdTaxonomy,
                        principalTable: "Taxonomy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentBoolMetaValue",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdMetaValueType = table.Column<int>(type: "integer(11)", nullable: false),
                    Value = table.Column<bool>(type: "bool", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBoolMetaValue", x => new { x.IdContent, x.IdMetaValueType });
                    table.ForeignKey(
                        name: "FK_ContentBoolMetaValue_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentBoolMetaValueType_MetaValueType",
                        column: x => x.IdMetaValueType,
                        principalTable: "MetaValueType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentFloatMetaValue",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdMetaValueType = table.Column<int>(type: "integer(11)", nullable: false),
                    Value = table.Column<int>(type: "integer(11)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFloatMetaValue", x => new { x.IdContent, x.IdMetaValueType });
                    table.ForeignKey(
                        name: "FK_ContentFloatMetaValue_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentFloatMetaValueType_MetaValueType",
                        column: x => x.IdMetaValueType,
                        principalTable: "MetaValueType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentStringMetaValue",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdMetaValueType = table.Column<int>(type: "integer(11)", nullable: false),
                    Value = table.Column<string>(type: "varchar(1024)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFloatMetaValue", x => new { x.IdContent, x.IdMetaValueType });
                    table.ForeignKey(
                        name: "FK_ContentStringMetaValue_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentStringMetaValueType_MetaValueType",
                        column: x => x.IdMetaValueType,
                        principalTable: "MetaValueType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentTaxonomy",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdTaxonomy = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTaxonomy", x => new { x.IdContent, x.IdTaxonomy });
                    table.ForeignKey(
                        name: "FK_ContentTaxonomy_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentTaxonomy_Taxonomy",
                        column: x => x.IdTaxonomy,
                        principalTable: "Taxonomy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentTextMetaValue",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdMetaValueType = table.Column<int>(type: "integer(11)", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTextMetaValue", x => new { x.IdContent, x.IdMetaValueType });
                    table.ForeignKey(
                        name: "FK_ContentTextMetaValue_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentTextMetaValue_MetaValueType",
                        column: x => x.IdMetaValueType,
                        principalTable: "MetaValueType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParentContent",
                columns: table => new
                {
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdParentContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentContent", x => new { x.IdContent, x.IdParentContent });
                    table.ForeignKey(
                        name: "FK_ParentContent_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParentContent_ChildrenContent",
                        column: x => x.IdParentContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContent",
                columns: table => new
                {
                    IdUser = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdContent = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    IdContentRelationType = table.Column<int>(type: "integer(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContent", x => new { x.IdUser, x.IdContent, x.IdContentRelationType });
                    table.ForeignKey(
                        name: "FK_UserContent_Content",
                        column: x => x.IdContent,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContent_ContentRelationType",
                        column: x => x.IdContentRelationType,
                        principalTable: "ContentRelationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContent_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_IdContentType",
                table: "Content",
                column: "IdContentType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBoolMetaValue_IdMetaValueType",
                table: "ContentBoolMetaValue",
                column: "IdMetaValueType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFloatMetaValue_IdMetaValueType",
                table: "ContentFloatMetaValue",
                column: "IdMetaValueType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentStringMetaValue_IdMetaValueType",
                table: "ContentStringMetaValue",
                column: "IdMetaValueType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTaxonomy_IdTaxonomy",
                table: "ContentTaxonomy",
                column: "IdTaxonomy");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTextMetaValue_IdMetaValueType",
                table: "ContentTextMetaValue",
                column: "IdMetaValueType");

            migrationBuilder.CreateIndex(
                name: "IX_ParentContent_IdParentContent",
                table: "ParentContent",
                column: "IdParentContent");

            migrationBuilder.CreateIndex(
                name: "IX_ParentTaxonomy_IdParentTaxonomy",
                table: "ParentTaxonomy",
                column: "IdParentTaxonomy");

            migrationBuilder.CreateIndex(
                name: "IX_UserContent_IdContent",
                table: "UserContent",
                column: "IdContent");

            migrationBuilder.CreateIndex(
                name: "IX_UserContent_IdContentRelationType",
                table: "UserContent",
                column: "IdContentRelationType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentBoolMetaValue");

            migrationBuilder.DropTable(
                name: "ContentFloatMetaValue");

            migrationBuilder.DropTable(
                name: "ContentStringMetaValue");

            migrationBuilder.DropTable(
                name: "ContentTaxonomy");

            migrationBuilder.DropTable(
                name: "ContentTextMetaValue");

            migrationBuilder.DropTable(
                name: "ParentContent");

            migrationBuilder.DropTable(
                name: "ParentTaxonomy");

            migrationBuilder.DropTable(
                name: "UserContent");

            migrationBuilder.DropTable(
                name: "MetaValueType");

            migrationBuilder.DropTable(
                name: "Taxonomy");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "ContentRelationType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ContentType");
        }
    }
}
