using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceRoomManager.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Facilities_FacilityId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Description", "Image", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Houses The Hartley Library, IT Soultions, Study rooms, and many Facilities", "https://www.southampton.ac.uk/sites/default/files/styles/banner_medium/public/2020-06/aerial-view-highfield-sunny-day.jpg?h=2e5cdddf&itok=0yzClUVO", "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJW_B-i_ZzdEgR6xjnALzwrgY&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk", "B12" },
                    { 2, "New Mountbatten contains the following: School of Electronics & Computer Science. Physical Sciences and Engineering. Optoelectronics Research Centre. Comms, Signal Processing & Control ORC. Research ORC & Enterprise. Technical Support Staff. NANO. Electronic & Software Systems", "https://www.zeplerinstitute.com/sites/www.zeplerinstitute.ac.uk/files/zepler_exterior_2_0.jpg", "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJW_jlkvVzdEgRP4M0dE0Zozo&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk", "B53" },
                    { 3, "The Centenary Building also has an 80-seat Harvard lecture theatre, numerous private pod study spaces, bookable seminar rooms and large flat floored teaching spaces.", "https://pbs.twimg.com/media/EUV6_ypWkAAzhl4.jpg", "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJhbfAkaBzdEgRii3AIRj1Qp4&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk", "B100" },
                    { 4, "Home to our engineering and maritime engineering courses and has a number of world-class testing and research laboratories.", "https://www.bof.co.uk/assets/images/projects/University-of-Southampton-B178-Boldrewood/boldrewood-small-1.png", "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJe-3X6vVzdEgR9urRdV4flj4&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk", "B178" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Green Bar" },
                    { 2, "Starbucks" },
                    { 3, "Costa coffee" },
                    { 4, "Pret a Manger" },
                    { 5, "Highfield Pharmacy" },
                    { 6, "Terrace Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Capacity", "Description", "FacilityId", "Image", "Name" },
                values: new object[,]
                {
                    { 2, 2, 76, "Large rooms.", 1, "https://lh3.googleusercontent.com/proxy/m5EIKPse4yZo71SAdNQhr-MsQeRIHCVr506uQxCvMFIeFsUtBNeDAcgT0uvrda0gUj7Rfa84CkzjT6-zStm1WoWnh0TZvoJ_RisgnPH7lPI8zJQzZgIEcAHdlzJxESxwHP2QGjjBkJ8UAsHPU4ULHTVnwFkSHdsL7diXAsKNm0nZt_iGmDTlws2ZhuBQsu9rjOFUfynooXUaQIx1xPQ4_6L5hbKcP572ePFfW5qXjr29Pz606Q", "Lab" },
                    { 3, 3, 100, "Large study rooms.", 2, "https://cdn.southampton.ac.uk/assets/imported/transforms/site/slideshow/Media_Img/BC294B5E657C498A82D61D1F7AACD905/Study%20space%20and%20views.jpg_SIA_JPG_fit_to_width_XL.jpg", "Study" },
                    { 1, 1, 1, "Personal study space.", 3, "https://www.southampton.ac.uk/sites/default/files/styles/block_card_image_small/public/2020-07/students-studying-pods_0.jpg", "Study" },
                    { 4, 2, 150, "Large lab and advanced equipments.", 4, "https://www.tlc-business.co.uk/wp-content/uploads/2017/03/IMG_20170310_103343-1.jpg", "Lab" },
                    { 5, 4, 50, "Advanced lab equipments.", 5, "https://www.ecs.soton.ac.uk/sites/www.ecs.soton.ac.uk/files/University%20of%20Southampton%20STEM_IMG_9039_900x500.jpg", "Lab" },
                    { 6, 3, 100, "Large study rooms.", 6, "https://www.bof.co.uk/assets/images/projects/University-of-Southampton-B178-Boldrewood/boldrewood-small-3.png", "Study" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Facilities_FacilityId",
                table: "Rooms",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Facilities_FacilityId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Facilities_FacilityId",
                table: "Rooms",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
