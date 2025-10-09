using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSave.Migrations
{
    /// <inheritdoc />
    public partial class SmallAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PROF_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "POS_USER_ID",
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
                name: "PROF_USER_ID",
                table: "PROFILE_USER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "POS_USER_ID",
                table: "POSITION_USER",
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
                name: "PHARM_FORM_ID",
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
                name: "ACT_INGRE_ID",
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
                name: "USER_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
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
                name: "CONTACT_USER_ID",
                table: "CONTACT_USER",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

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
                table: "BATCH",
                type: "NUMBER(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "BATCH",
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
                name: "PROF_USER_ID",
                table: "USERS_SYS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "POS_USER_ID",
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
                name: "PROF_USER_ID",
                table: "PROFILE_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "POS_USER_ID",
                table: "POSITION_USER",
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
                name: "PHARM_FORM_ID",
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
                name: "ACT_INGRE_ID",
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
                name: "USER_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "STOCK_ID",
                table: "MEDICINE_DISPENSE",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MOVEMENT_TYPE_ID",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "CONTACT_USER_ID",
                table: "CONTACT_USER",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

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
                table: "BATCH",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BATCH_ID",
                table: "BATCH",
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
