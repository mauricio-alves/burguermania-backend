using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace burguermania_backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BaseDescription = table.Column<string>(type: "text", nullable: false),
                    FullDescription = table.Column<string>(type: "text", nullable: false),
                    PathImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BaseDescription = table.Column<string>(type: "text", nullable: false),
                    FullDescription = table.Column<string>(type: "text", nullable: false),
                    PathImage = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BaseDescription", "FullDescription", "Name", "PathImage" },
                values: new object[,]
                {
                    { 1, "Pão, hambúrguer, alface, tomate, queijo e maionese.", "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Vegan", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true" },
                    { 2, "Pão, hambúrguer, alface, tomate, queijo e maionese.", "Um sanduíche leve e nutritivo, perfeito para quem busca energia e sabor. Feito com um hambúrguer grelhado de peito de frango temperado com ervas finas e cúrcuma, servido em um pão integral artesanal. Acompanhado de folhas frescas de rúcula, espinafre e brotos de alfafa, além de rodelas crocantes de pepino, fatias finas de cenoura e uma pasta de iogurte grego com hortelã. Finalizado com um toque de azeite extravirgem e sementes de chia, proporcionando uma refeição equilibrada, repleta de texturas frescas e saudáveis.", "X-Fitness", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true" },
                    { 3, "Pão, hambúrguer, alface, tomate, queijo e maionese.", "Um sanduíche irresistível e indulgente para os amantes de sabores intensos. Composto por um hambúrguer suculento de 200g de carne bovina Angus, envolto em uma crosta de bacon crocante e coberto com uma generosa porção de queijo cheddar derretido. Servido em um pão brioche amanteigado, o recheio inclui cebolas fritas crocantes, fatias de tomate, alface americana, molho especial à base de maionese e alho, e um toque extra de ketchup e mostarda. Para finalizar, uma camada de pulled pork desfiado e uma pitada de páprica picante, garantindo uma explosão de sabores a cada mordida.", "X-Infarto", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true" },
                    { 4, "Pão, hambúrguer, alface, tomate, queijo e maionese.", "Uma experiência gastronômica sofisticada, criada para paladares exigentes. O hambúrguer trufado, preparado com carne Angus suculenta, é coroado com queijo brie derretido e cogumelos trufados, realçando a complexidade dos sabores. Servido em um pão brioche artesanal, ele é complementado por rúcula fresca e uma maionese artesanal levemente cítrica. Cada mordida é um convite a saborear a combinação perfeita entre ingredientes premium e texturas envolventes, fazendo do X-Gourmet uma escolha inesquecível.", "X-Gourmet", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true" },
                    { 5, "Pão, hambúrguer, alface, tomate, queijo e maionese.", "Uma celebração aos sabores que nunca saem de moda. O Cheeseburger Tradicional, com hambúrguer grelhado no ponto perfeito, é acompanhado por queijo cheddar derretido, alface fresca e tomate suculento, tudo dentro de um pão macio. Para os amantes de bacon, o X-Bacon entrega o crocante irresistível junto com molho barbecue. Já o X-Egg adiciona o toque especial do ovo frito com gema cremosa. Simples e deliciosos, os clássicos oferecem conforto e sabor em cada mordida.", "X-Clássicos", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em Processamento" },
                    { 3, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "mauricio@email.com", "Mauricio Alves", "password123" },
                    { 2, "fulano@email.com", "Fulano de Tal", "password123" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BaseDescription", "CategoryId", "FullDescription", "Name", "PathImage", "Price" },
                values: new object[,]
                {
                    { 1, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 1, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Alface-Premium", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 29.989999999999998 },
                    { 2, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 1, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Tomate", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 39.990000000000002 },
                    { 3, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 1, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Frutas", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 4, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 1, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Salada", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 5, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 2, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Fitness-Grelhado", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 29.989999999999998 },
                    { 6, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 2, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Proteína", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 39.990000000000002 },
                    { 7, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 2, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Low-Carb", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 8, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 2, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Light", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 9, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 3, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Mega-Bacon", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 29.989999999999998 },
                    { 10, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 3, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Parada-Cardíaca", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 39.990000000000002 },
                    { 11, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 3, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Queijo-Extra", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 12, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 3, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Triplo", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 13, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 4, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Trufado-Supreme", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 59.990000000000002 },
                    { 14, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 4, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Blue-Cheese-Delight", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 69.989999999999995 },
                    { 15, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 4, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Mediterrâneo", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 79.989999999999995 },
                    { 16, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 4, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Deluxe", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 89.989999999999995 },
                    { 17, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 5, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Cheeseburger-Tradicional", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 29.989999999999998 },
                    { 18, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 5, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Bacon", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 39.990000000000002 },
                    { 19, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 5, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Egg", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 },
                    { 20, "Pão, hambúrguer, alface, tomate, queijo e maionese.", 5, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Tudo", "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true", 49.990000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
