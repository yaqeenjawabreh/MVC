using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task8.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requestItems_products_ProductId",
                table: "requestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_requestItems_supplyRequests_SupplyRequestId",
                table: "requestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId",
                table: "supplyRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supplyRequests",
                table: "supplyRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requestItems",
                table: "requestItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "supplyRequests",
                newName: "SupplyRequests");

            migrationBuilder.RenameTable(
                name: "requestItems",
                newName: "RequestItems");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_supplyRequests_UserId",
                table: "SupplyRequests",
                newName: "IX_SupplyRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_requestItems_SupplyRequestId",
                table: "RequestItems",
                newName: "IX_RequestItems_SupplyRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_requestItems_ProductId",
                table: "RequestItems",
                newName: "IX_RequestItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplyRequests",
                table: "SupplyRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestItems",
                table: "RequestItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Products_ProductId",
                table: "RequestItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_SupplyRequests_SupplyRequestId",
                table: "RequestItems",
                column: "SupplyRequestId",
                principalTable: "SupplyRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequests_AspNetUsers_UserId",
                table: "SupplyRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Products_ProductId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_SupplyRequests_SupplyRequestId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequests_AspNetUsers_UserId",
                table: "SupplyRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplyRequests",
                table: "SupplyRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestItems",
                table: "RequestItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "SupplyRequests",
                newName: "supplyRequests");

            migrationBuilder.RenameTable(
                name: "RequestItems",
                newName: "requestItems");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyRequests_UserId",
                table: "supplyRequests",
                newName: "IX_supplyRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_SupplyRequestId",
                table: "requestItems",
                newName: "IX_requestItems_SupplyRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_ProductId",
                table: "requestItems",
                newName: "IX_requestItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_supplyRequests",
                table: "supplyRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requestItems",
                table: "requestItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_requestItems_products_ProductId",
                table: "requestItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requestItems_supplyRequests_SupplyRequestId",
                table: "requestItems",
                column: "SupplyRequestId",
                principalTable: "supplyRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId",
                table: "supplyRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
