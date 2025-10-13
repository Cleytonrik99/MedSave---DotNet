using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSave.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIVE_INGREDIENT",
                columns: table => new
                {
                    ACT_INGRE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ACT_INGREDIENT = table.Column<string>(type: "VARCHAR2(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVE_INGREDIENT", x => x.ACT_INGRE_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY_MEDICINE",
                columns: table => new
                {
                    CATEGORY_MED_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CATEGORY = table.Column<string>(type: "VARCHAR2(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY_MEDICINE", x => x.CATEGORY_MED_ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT_MANUFACTURER",
                columns: table => new
                {
                    CONTACT_MANU_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMAIL_MANU = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    PHONE_NUMBER_MANU = table.Column<long>(type: "NUMBER(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT_MANUFACTURER", x => x.CONTACT_MANU_ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT_USER",
                columns: table => new
                {
                    CONTACT_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMAIL_USER = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    PHONE_NUMBER_USER = table.Column<long>(type: "NUMBER(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT_USER", x => x.CONTACT_USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVEMENT_TYPE",
                columns: table => new
                {
                    MOVEMENT_TYPE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TYPE_NAME = table.Column<string>(type: "VARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVEMENT_TYPE", x => x.MOVEMENT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHARMACEUTICAL_FORM",
                columns: table => new
                {
                    PHARM_FORM_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PHARMA_FORM = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHARMACEUTICAL_FORM", x => x.PHARM_FORM_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROFILE_USER",
                columns: table => new
                {
                    PROF_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_PROFILE = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFILE_USER", x => x.PROF_USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_USER",
                columns: table => new
                {
                    POS_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_ROLE = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_USER", x => x.POS_USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "STATES",
                columns: table => new
                {
                    STATE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    STATE_NAME = table.Column<string>(type: "VARCHAR2(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATES", x => x.STATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "UNIT_MEASURE",
                columns: table => new
                {
                    UNIT_MEA_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UNIT_MEASURE_MEDICINE = table.Column<string>(type: "VARCHAR2(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIT_MEASURE", x => x.UNIT_MEA_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS_SYS",
                columns: table => new
                {
                    USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME_USER = table.Column<string>(type: "VARCHAR2(150)", nullable: false),
                    LOGIN = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    PASSWORD_USER = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    POS_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    PROF_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    CONTACT_USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_SYS", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_CONTACT_USER_USERS_SYS",
                        column: x => x.CONTACT_USER_ID,
                        principalTable: "CONTACT_USER",
                        principalColumn: "CONTACT_USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROFILE_USER_USERS_SYS",
                        column: x => x.PROF_USER_ID,
                        principalTable: "PROFILE_USER",
                        principalColumn: "PROF_USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLE_USER_USERS_SYS",
                        column: x => x.POS_USER_ID,
                        principalTable: "ROLE_USER",
                        principalColumn: "POS_USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    CITY_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME_CITY = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    STATE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.CITY_ID);
                    table.ForeignKey(
                        name: "FK_STATES_CITY",
                        column: x => x.STATE_ID,
                        principalTable: "STATES",
                        principalColumn: "STATE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICINES",
                columns: table => new
                {
                    MEDICINE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME_MEDICATION = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    STATUS_MED = table.Column<string>(type: "VARCHAR2(20)", nullable: false),
                    CATEGORY_MED_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    UNIT_MEA_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICINES", x => x.MEDICINE_ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_MEDICINE_MEDICINES",
                        column: x => x.CATEGORY_MED_ID,
                        principalTable: "CATEGORY_MEDICINE",
                        principalColumn: "CATEGORY_MED_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UNIT_MEASURE_MEDICINES",
                        column: x => x.UNIT_MEA_ID,
                        principalTable: "UNIT_MEASURE",
                        principalColumn: "UNIT_MEA_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICINE_DISPENSE",
                columns: table => new
                {
                    DISPENSATION_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATE_DISPENSATION = table.Column<DateTime>(type: "DATE", nullable: false),
                    QUANTITY_DISPENSED = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    DESTINATION = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    OBSERVATION = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICINE_DISPENSE", x => x.DISPENSATION_ID);
                    table.ForeignKey(
                        name: "FK_USERS_SYS_MEDICINE_DISPENSE",
                        column: x => x.USER_ID,
                        principalTable: "USERS_SYS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NEIGHBOURHOOD",
                columns: table => new
                {
                    NEIGH_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NEIGH_NAME = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    CITY_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEIGHBOURHOOD", x => x.NEIGH_ID);
                    table.ForeignKey(
                        name: "FK_CITY_NEIGHBOURHOOD",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "CITY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICINE_ACTIVE_INGR",
                columns: table => new
                {
                    MED_ACTIVE_INGR_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MEDICINE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    ACT_INGRE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICINE_ACTIVE_INGR", x => x.MED_ACTIVE_INGR_ID);
                    table.ForeignKey(
                        name: "FK_ACTIVE_INGREDIENT_MEDICINE_ACTIVE_INGR",
                        column: x => x.ACT_INGRE_ID,
                        principalTable: "ACTIVE_INGREDIENT",
                        principalColumn: "ACT_INGRE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MEDICINES_MEDICINE_ACTIVE_INGR",
                        column: x => x.MEDICINE_ID,
                        principalTable: "MEDICINES",
                        principalColumn: "MEDICINE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICINE_PHARM_FORM",
                columns: table => new
                {
                    MED_PHARM_FORM_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MEDICINE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    PHARM_FORM_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICINE_PHARM_FORM", x => x.MED_PHARM_FORM_ID);
                    table.ForeignKey(
                        name: "FK_MEDICINES_MEDICINE_PHARM_FORM",
                        column: x => x.MEDICINE_ID,
                        principalTable: "MEDICINES",
                        principalColumn: "MEDICINE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHARMACEUTICAL_FORM_MEDICINE_PHARM_FORM",
                        column: x => x.PHARM_FORM_ID,
                        principalTable: "PHARMACEUTICAL_FORM",
                        principalColumn: "PHARM_FORM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS_MANUFACTURER",
                columns: table => new
                {
                    ADDRESS_ID_MANUFACTURER = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COMPLEMENT = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    NUMBER_MANU = table.Column<int>(type: "NUMBER(7)", nullable: false),
                    ADDRESS_DESCRIPTION = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    CEP = table.Column<int>(type: "NUMBER(8)", nullable: false),
                    NEIGH_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS_MANUFACTURER", x => x.ADDRESS_ID_MANUFACTURER);
                    table.ForeignKey(
                        name: "FK_NEIGHBOURHOOD_ADDRESS_MANUFACTURER",
                        column: x => x.NEIGH_ID,
                        principalTable: "NEIGHBOURHOOD",
                        principalColumn: "NEIGH_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS_STOCK",
                columns: table => new
                {
                    ADDRESS_ID_STOCK = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COMPLEMENT = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    NUMBER_STOCK = table.Column<int>(type: "NUMBER(7)", nullable: false),
                    ADDRESS_DESCRIPTION = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    CEP = table.Column<int>(type: "NUMBER(8)", nullable: false),
                    NEIGH_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS_STOCK", x => x.ADDRESS_ID_STOCK);
                    table.ForeignKey(
                        name: "FK_NEIGHBOURHOOD_ADDRESS_STOCK",
                        column: x => x.NEIGH_ID,
                        principalTable: "NEIGHBOURHOOD",
                        principalColumn: "NEIGH_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MANUFACTURER",
                columns: table => new
                {
                    MANUFAC_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME_MANU = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    CNPJ = table.Column<long>(type: "NUMBER(14)", nullable: false),
                    CONTACT_MANU_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    ADDRESS_ID_MANUFACTURER = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUFACTURER", x => x.MANUFAC_ID);
                    table.ForeignKey(
                        name: "FK_ADDRESS_MANUFACTURER_MANUFACTURER",
                        column: x => x.ADDRESS_ID_MANUFACTURER,
                        principalTable: "ADDRESS_MANUFACTURER",
                        principalColumn: "ADDRESS_ID_MANUFACTURER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTACT_MANUFACTURER_MANUFACTURER",
                        column: x => x.CONTACT_MANU_ID,
                        principalTable: "CONTACT_MANUFACTURER",
                        principalColumn: "CONTACT_MANU_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOCATION_STOCK",
                columns: table => new
                {
                    LOCATION_ID_STOCK = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME_LOCATION = table.Column<string>(type: "VARCHAR2(30)", nullable: false),
                    LOCATION_STOCK_NAME = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    ADDRESS_ID_STOCK = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION_STOCK", x => x.LOCATION_ID_STOCK);
                    table.ForeignKey(
                        name: "FK_ADDRESS_STOCK_LOCATION_STOCK",
                        column: x => x.ADDRESS_ID_STOCK,
                        principalTable: "ADDRESS_STOCK",
                        principalColumn: "ADDRESS_ID_STOCK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BATCH_MEDICINE",
                columns: table => new
                {
                    BATCH_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BATCH_NUMBER = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    CURRENT_QUANTITY = table.Column<int>(type: "NUMERIC", nullable: false),
                    MANUFACTURING_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    EXPIRATION_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MANUFAC_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BATCH_MEDICINE", x => x.BATCH_ID);
                    table.ForeignKey(
                        name: "FK_MANUFACTURER_BATCH_MEDICINE",
                        column: x => x.MANUFAC_ID,
                        principalTable: "MANUFACTURER",
                        principalColumn: "MANUFAC_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STOCK",
                columns: table => new
                {
                    STOCK_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QUANTITY = table.Column<byte>(type: "NUMBER(4)", nullable: false),
                    BATCH_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    MEDICINE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    LOCATION_ID_STOCK = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK", x => x.STOCK_ID);
                    table.ForeignKey(
                        name: "FK_BATCH_MEDICINE_STOCK",
                        column: x => x.BATCH_ID,
                        principalTable: "BATCH_MEDICINE",
                        principalColumn: "BATCH_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOCATION_STOCK_STOCK",
                        column: x => x.LOCATION_ID_STOCK,
                        principalTable: "LOCATION_STOCK",
                        principalColumn: "LOCATION_ID_STOCK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MEDICINES_STOCK",
                        column: x => x.MEDICINE_ID,
                        principalTable: "MEDICINES",
                        principalColumn: "MEDICINE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STOCK_MOVEMENT",
                columns: table => new
                {
                    STOCK_MOVEMENT_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QUANTITY_DISPENSED = table.Column<int>(type: "NUMBER(6)", nullable: false),
                    DATE_MOVIMENT = table.Column<DateTime>(type: "DATE", nullable: false),
                    MOVEMENT_TYPE_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    STOCK_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    DISPENSATION_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false),
                    USER_ID = table.Column<decimal>(type: "NUMBER(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_MOVEMENT", x => x.STOCK_MOVEMENT_ID);
                    table.ForeignKey(
                        name: "FK_MEDICINE_DISPENSE_STOCK_MOVEMENT",
                        column: x => x.DISPENSATION_ID,
                        principalTable: "MEDICINE_DISPENSE",
                        principalColumn: "DISPENSATION_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MOVEMENT_TYPE_STOCK_MOVEMENT",
                        column: x => x.MOVEMENT_TYPE_ID,
                        principalTable: "MOVEMENT_TYPE",
                        principalColumn: "MOVEMENT_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STOCK_STOCK_MOVEMENT",
                        column: x => x.STOCK_ID,
                        principalTable: "STOCK",
                        principalColumn: "STOCK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERS_SYS_STOCK_MOVEMENT",
                        column: x => x.USER_ID,
                        principalTable: "USERS_SYS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_MANUFACTURER_NEIGH_ID",
                table: "ADDRESS_MANUFACTURER",
                column: "NEIGH_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_STOCK_NEIGH_ID",
                table: "ADDRESS_STOCK",
                column: "NEIGH_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BATCH_MEDICINE_MANUFAC_ID",
                table: "BATCH_MEDICINE",
                column: "MANUFAC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_STATE_ID",
                table: "CITY",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "UK_CONTACT_MANU_EMAIL",
                table: "CONTACT_MANUFACTURER",
                column: "EMAIL_MANU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_CONTACT_MANU_PHONE",
                table: "CONTACT_MANUFACTURER",
                column: "PHONE_NUMBER_MANU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_CONTACT_USER_EMAIL",
                table: "CONTACT_USER",
                column: "EMAIL_USER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_CONTACT_USER_PHONE",
                table: "CONTACT_USER",
                column: "PHONE_NUMBER_USER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_STOCK_ADDRESS_ID_STOCK",
                table: "LOCATION_STOCK",
                column: "ADDRESS_ID_STOCK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MANUFACTURER_ADDRESS_ID_MANUFACTURER",
                table: "MANUFACTURER",
                column: "ADDRESS_ID_MANUFACTURER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MANUFACTURER_CONTACT_MANU_ID",
                table: "MANUFACTURER",
                column: "CONTACT_MANU_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_MANUFACTURER_CNPJ",
                table: "MANUFACTURER",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINE_ACTIVE_INGR_ACT_INGRE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                column: "ACT_INGRE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINE_ACTIVE_INGR_MEDICINE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                column: "MEDICINE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINE_DISPENSE_USER_ID",
                table: "MEDICINE_DISPENSE",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINE_PHARM_FORM_MEDICINE_ID",
                table: "MEDICINE_PHARM_FORM",
                column: "MEDICINE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINE_PHARM_FORM_PHARM_FORM_ID",
                table: "MEDICINE_PHARM_FORM",
                column: "PHARM_FORM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINES_CATEGORY_MED_ID",
                table: "MEDICINES",
                column: "CATEGORY_MED_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICINES_UNIT_MEA_ID",
                table: "MEDICINES",
                column: "UNIT_MEA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NEIGHBOURHOOD_CITY_ID",
                table: "NEIGHBOURHOOD",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_BATCH_ID",
                table: "STOCK",
                column: "BATCH_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_LOCATION_ID_STOCK",
                table: "STOCK",
                column: "LOCATION_ID_STOCK");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MEDICINE_ID",
                table: "STOCK",
                column: "MEDICINE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENT_DISPENSATION_ID",
                table: "STOCK_MOVEMENT",
                column: "DISPENSATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENT_MOVEMENT_TYPE_ID",
                table: "STOCK_MOVEMENT",
                column: "MOVEMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENT_STOCK_ID",
                table: "STOCK_MOVEMENT",
                column: "STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENT_USER_ID",
                table: "STOCK_MOVEMENT",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_SYS_CONTACT_USER_ID",
                table: "USERS_SYS",
                column: "CONTACT_USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_SYS_POS_USER_ID",
                table: "USERS_SYS",
                column: "POS_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_SYS_PROF_USER_ID",
                table: "USERS_SYS",
                column: "PROF_USER_ID");

            migrationBuilder.CreateIndex(
                name: "UK_USERS_SYS_LOGIN",
                table: "USERS_SYS",
                column: "LOGIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEDICINE_ACTIVE_INGR");

            migrationBuilder.DropTable(
                name: "MEDICINE_PHARM_FORM");

            migrationBuilder.DropTable(
                name: "STOCK_MOVEMENT");

            migrationBuilder.DropTable(
                name: "ACTIVE_INGREDIENT");

            migrationBuilder.DropTable(
                name: "PHARMACEUTICAL_FORM");

            migrationBuilder.DropTable(
                name: "MEDICINE_DISPENSE");

            migrationBuilder.DropTable(
                name: "MOVEMENT_TYPE");

            migrationBuilder.DropTable(
                name: "STOCK");

            migrationBuilder.DropTable(
                name: "USERS_SYS");

            migrationBuilder.DropTable(
                name: "BATCH_MEDICINE");

            migrationBuilder.DropTable(
                name: "LOCATION_STOCK");

            migrationBuilder.DropTable(
                name: "MEDICINES");

            migrationBuilder.DropTable(
                name: "CONTACT_USER");

            migrationBuilder.DropTable(
                name: "PROFILE_USER");

            migrationBuilder.DropTable(
                name: "ROLE_USER");

            migrationBuilder.DropTable(
                name: "MANUFACTURER");

            migrationBuilder.DropTable(
                name: "ADDRESS_STOCK");

            migrationBuilder.DropTable(
                name: "CATEGORY_MEDICINE");

            migrationBuilder.DropTable(
                name: "UNIT_MEASURE");

            migrationBuilder.DropTable(
                name: "ADDRESS_MANUFACTURER");

            migrationBuilder.DropTable(
                name: "CONTACT_MANUFACTURER");

            migrationBuilder.DropTable(
                name: "NEIGHBOURHOOD");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "STATES");
        }
    }
}
