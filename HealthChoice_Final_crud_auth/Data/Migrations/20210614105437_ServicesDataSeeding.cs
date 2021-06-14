using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class ServicesDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "servId", "servLocation", "servLogo", "servName", "servOverview", "servType", "servWebsite" },
                values: new object[] { 1, "https://www.google.com/maps/dir/24.8540805,46.7132804/Fitness+Time+Ladies,+King+Khalid+International+Airport,+Riyadh/@24.863979,46.7113634,14.15z/data=!4m9!4m8!1m1!4e1!1m5!1m1!1s0x3e2efb358b9bd1c1:0x60f9692740fd1349!2m2!1d46.7102291!2d24.8546555", "https://seeklogo.com/images/F/fitness-time-logo-19E1048F6C-seeklogo.com.png", "Fitness Time", "Exercise for Health is our motto – Fitness Time strives to provide the best sports and fitness services through our growing network of facilities across the Middle East and North Africa. We believe health goals can be achieved through overall mind and body fitness.", "Gym", "https://www.fitnesstime.com.sa/en-sa/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "servId", "servLocation", "servLogo", "servName", "servOverview", "servType", "servWebsite" },
                values: new object[] { 2, "https://www.google.com/search?q=boga&oq=boga&aqs=chrome..69i57j69i59l3j0j46l2j0i457j0i402j46.1468j0j4&sourceid=chrome&ie=UTF-8&safe=active&tbs=lrf:!1m4!1u3!2m2!3m1!1e1!2m1!1e3!3sIAE,lf:1,lf_ui:3&tbm=lcl&sxsrf=ALeKk00BE-1ps0u0RhIkiHDQ5_HPh-SOag:1623642183699&rflfq=1&num=10&rldimm=4194740120699254277&lqi=CgRib2dhSMmPh7KGsYCACFoKEAAYACIEYm9nYZIBCnJlc3RhdXJhbnQ&ved=2ahUKEwiu1ue8mpbxAhV07eAKHZbzD_UQvS4wAHoECAQQIA&rlst=f#rlfi=hd:;si:4194740120699254277,l,CgRib2dhSMmPh7KGsYCACFoKEAAYACIEYm9nYZIBCnJlc3RhdXJhbnQ;mv:[[24.8432004,46.7455346],[24.697642,46.6107527]];tbs:lrf:!1m4!1u3!2m2!3m1!1e1!2m1!1e3!3sIAE,lf:1,lf_ui:3", "https://media-exp1.licdn.com/dms/image/C4D1BAQGllg2SUkUMGA/company-background_10000/0/1575976861836?e=2159024400&v=beta&t=ODg29H-HRO7cdmDJXe8Teg-TWGxM8d4SmUWfEbJ3FZo", "Boga Super Food", "BOGA is a Saudi local restaurant chain that is created and owned by Tariq Al-Hussaini.And is Offers sandwiches, salads, and fresh juices", "Resturent", "https://www.instagram.com/boga_sa/?igshid=2ptrc8wda1uc" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "servId", "servLocation", "servLogo", "servName", "servOverview", "servType", "servWebsite" },
                values: new object[] { 3, "https://www.google.com/search?q=sport%20stores&oq=sport+stores&aqs=chrome..69i57j46i175i199j0i402j0l7.5628j0j9&sourceid=chrome&ie=UTF-8&safe=active&tbs=lf:1,lf_ui:10&tbm=lcl&sxsrf=ALeKk00f2RsQQ_0hPR9FhZkiq9OUP1w7Xw:1623642377772&rflfq=1&num=10&rldimm=5200966494054111993&lqi=CgxzcG9ydCBzdG9yZXNIoZCl-feqgIAIWh4QABABGAAYASIMc3BvcnQgc3RvcmVzKgYIAxAAEAGSARBzcG9ydHN3ZWFyX3N0b3JlmgEkQ2hkRFNVaE5NRzluUzBWSlEwRm5TVVJwZVV0aFZqbEJSUkFCqgEUEAEqECIMc3BvcnQgc3RvcmVzKAA&phdesc=pajse2hgjO8&ved=2ahUKEwifg62Zm5bxAhUsQEEAHVQoBJYQvS4wAHoECAYQLA&rlst=f#rlfi=hd:;si:11350449135811842640,l,CgxzcG9ydCBzdG9yZXNIgK6J482rgIAIWh4QABABGAAYASIMc3BvcnQgc3RvcmVzKgYIAxAAEAGSARRzcG9ydGluZ19nb29kc19zdG9yZaoBFBABKhAiDHNwb3J0IHN0b3JlcygA,y,jyheHfoLH9E;mv:[[24.825370900000003,46.8087284],[24.631175799999998,46.6077643]]", "https://c.static-nike.com/a/images/w_1920,c_limit/mdbgldn6yg1gg88jomci/image.jpg", "Nike Store", "Exercise for Health is our motto – Fitness Time strives to provide the best sports and fitness services through our growing network of facilities across the Middle East and North Africa. We believe health goals can be achieved through overall mind and body fitness.", "Store", "https://www.fitnesstime.com.sa/en-sa/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "servId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "servId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "servId",
                keyValue: 3);
        }
    }
}
