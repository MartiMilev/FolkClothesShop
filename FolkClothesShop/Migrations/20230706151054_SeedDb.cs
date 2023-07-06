using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolkClothesShop.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AdminId", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Най-хубавата носия", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267074128_569156850818756_8705324827277707870_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=3aF7k0tMHR8AX8rR1kC&_nc_ht=scontent.fsof8-1.fna&oh=00_AfDjjNWBjjVAlfUH-4pRZC4FNu6hqh8OJ0B_O9Pvs1oKbg&oe=64AB134F", 56.00m, "Тракийска носия" },
                    { 2, 1, 2, "Най-хубавата дамска носия", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/242844727_517782082622900_481886533923826782_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=E6ONkspewXsAX8tTOFH&_nc_ht=scontent.fsof8-1.fna&oh=00_AfAaV-sf-iIaP9RBpFb30yEaGtMgZb1c555Ab7X_J_QCiQ&oe=64AB6E19", 78.00m, "Тракийска носия" },
                    { 3, 1, 2, "Най-хубавата носия", "https://scontent.fsof8-1.fna.fbcdn.net/v/t1.6435-9/146874580_353052245762552_3031650708666144962_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=730e14&_nc_ohc=GAZN-Vz7d_MAX9jfRNN&_nc_ht=scontent.fsof8-1.fna&oh=00_AfBbpeg0Sn4CV_eEvg9Qm3uXhNKS1n3lq0dvC2hH51iq5w&oe=64CE4CFA", 78.00m, "Родопска носия" },
                    { 4, 1, 1, "Най-хубавата носия", "https://scontent.fsof8-1.fna.fbcdn.net/v/t1.6435-9/147282029_353052235762553_8637670463306638015_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=730e14&_nc_ohc=ZhdcZIAVKckAX975rw7&_nc_ht=scontent.fsof8-1.fna&oh=00_AfCRtPxohx0G0dWYR6Tr8GwXQXGsPykLAgAf3aVIm1n5Vw&oe=64CE37DE", 78.00m, "Родопска носия" },
                    { 5, 1, 1, "Потурчета за малките сладурчета", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267565025_569157017485406_4196785183282386807_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=pvEtN8UWiv8AX_lCcE1&_nc_ht=scontent.fsof8-1.fna&oh=00_AfAvwr7GlR7KJAS2ZNAdejCMCIoynczLWR3BnskeRT08Zg&oe=64ABE6FA", 12.00m, "Потури" },
                    { 6, 1, 1, "Калпак за малкия юнак", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267325300_569156934152081_3269888927601348101_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=pQqNHetzV8wAX_zd8wl&_nc_ht=scontent.fsof8-1.fna&oh=00_AfD2VPZM7skYf3oNZ3_hJ1oezTTDuDwg4XUmtXEkwa4EHg&oe=64ABF1DE", 11.00m, "Калпак" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
