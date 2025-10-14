using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSave.Migrations
{
    /// <inheritdoc />
    public partial class SmallAlterations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ROLE_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PROF_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "USERS_SYS",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNIT_MEA_ID",
                table: "UNIT_MEASURE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISPENSATION_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_MOVEMENT_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "LOCATION_ID_STOCK",
                table: "STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "STATE_ID",
                table: "STATES",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ROLE_USER_ID",
                table: "ROLE_USER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PROF_USER_ID",
                table: "PROFILE_USER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHARM_FORM_ID",
                table: "PHARMACEUTICAL_FORM",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CITY_ID",
                table: "NEIGHBOURHOOD",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "NEIGHBOURHOOD",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
                table: "MOVEMENT_TYPE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNIT_MEA_ID",
                table: "MEDICINES",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CATEGORY_MED_ID",
                table: "MEDICINES",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINES",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHARM_FORM_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MED_PHARM_FORM_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISPENSATION_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "ACT_INGRE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MED_ACTIVE_INGR_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_MANU_ID",
                table: "MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_MANUFACTURER",
                table: "MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MANUFAC_ID",
                table: "MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_STOCK",
                table: "LOCATION_STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "LOCATION_ID_STOCK",
                table: "LOCATION_STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHONE_NUMBER_USER",
                table: "CONTACT_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_USER_ID",
                table: "CONTACT_USER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHONE_NUMBER_MANU",
                table: "CONTACT_MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_MANU_ID",
                table: "CONTACT_MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "STATE_ID",
                table: "CITY",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CITY_ID",
                table: "CITY",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CATEGORY_MED_ID",
                table: "CATEGORY_MEDICINE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MANUFAC_ID",
                table: "BATCH_MEDICINE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "BATCH_MEDICINE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "ADDRESS_STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_STOCK",
                table: "ADDRESS_STOCK",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "ADDRESS_MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_MANUFACTURER",
                table: "ADDRESS_MANUFACTURER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ACT_INGRE_ID",
                table: "ACTIVE_INGREDIENT",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ROLE_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PROF_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "USERS_SYS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNIT_MEA_ID",
                table: "UNIT_MEASURE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISPENSATION_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_MOVEMENT_ID",
                table: "STOCK_MOVEMENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LOCATION_ID_STOCK",
                table: "STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "STATE_ID",
                table: "STATES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ROLE_USER_ID",
                table: "ROLE_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PROF_USER_ID",
                table: "PROFILE_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHARM_FORM_ID",
                table: "PHARMACEUTICAL_FORM",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CITY_ID",
                table: "NEIGHBOURHOOD",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "NEIGHBOURHOOD",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
                table: "MOVEMENT_TYPE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNIT_MEA_ID",
                table: "MEDICINES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CATEGORY_MED_ID",
                table: "MEDICINES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PHARM_FORM_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MED_PHARM_FORM_ID",
                table: "MEDICINE_PHARM_FORM",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISPENSATION_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MEDICINE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ACT_INGRE_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MED_ACTIVE_INGR_ID",
                table: "MEDICINE_ACTIVE_INGR",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_MANU_ID",
                table: "MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_MANUFACTURER",
                table: "MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MANUFAC_ID",
                table: "MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_STOCK",
                table: "LOCATION_STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LOCATION_ID_STOCK",
                table: "LOCATION_STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "PHONE_NUMBER_USER",
                table: "CONTACT_USER",
                type: "NUMBER(11)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_USER_ID",
                table: "CONTACT_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "PHONE_NUMBER_MANU",
                table: "CONTACT_MANUFACTURER",
                type: "NUMBER(11)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_MANU_ID",
                table: "CONTACT_MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "STATE_ID",
                table: "CITY",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CITY_ID",
                table: "CITY",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "CATEGORY_MED_ID",
                table: "CATEGORY_MEDICINE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "MANUFAC_ID",
                table: "BATCH_MEDICINE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "BATCH_MEDICINE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "ADDRESS_STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_STOCK",
                table: "ADDRESS_STOCK",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "NEIGH_ID",
                table: "ADDRESS_MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ADDRESS_ID_MANUFACTURER",
                table: "ADDRESS_MANUFACTURER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ACT_INGRE_ID",
                table: "ACTIVE_INGREDIENT",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }
    }
}
