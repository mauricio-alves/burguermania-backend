using WebAPI.Models;

namespace WebAPI.Data;

// Dados iniciais para popular as tabelas de status, usuários, categorias e produtos no banco de dados
public static class SeedData
{
  public static List<Status> Status = new List<Status>
  {
    new Status
    {
      Id = 1,
      Name = "Pendente"
    },
    new Status
    {
      Id = 2,
      Name = "Em Processamento"
    },
    new Status
    {
      Id = 3,
      Name = "Finalizado"
    }
  };

    public static List<User> Users = new List<User>
  {
    new User
    {
      Id = 1,
      Name = "Mauricio Alves",
      Email = "mauricio@email.com",
      Password = "password123" 
    },
    new User
    {
      Id = 2,
      Name = "Fulano de Tal",
      Email = "fulano@email.com",
      Password = "password123" 
    }
  };

  public static List<Category> Categories = new List<Category>
  {
    new Category
    {
      Id = 1,
      Name = "X-Vegan",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 2,
      Name = "X-Fitness",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um sanduíche leve e nutritivo, perfeito para quem busca energia e sabor. Feito com um hambúrguer grelhado de peito de frango temperado com ervas finas e cúrcuma, servido em um pão integral artesanal. Acompanhado de folhas frescas de rúcula, espinafre e brotos de alfafa, além de rodelas crocantes de pepino, fatias finas de cenoura e uma pasta de iogurte grego com hortelã. Finalizado com um toque de azeite extravirgem e sementes de chia, proporcionando uma refeição equilibrada, repleta de texturas frescas e saudáveis.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 3,
      Name = "X-Infarto",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um sanduíche irresistível e indulgente para os amantes de sabores intensos. Composto por um hambúrguer suculento de 200g de carne bovina Angus, envolto em uma crosta de bacon crocante e coberto com uma generosa porção de queijo cheddar derretido. Servido em um pão brioche amanteigado, o recheio inclui cebolas fritas crocantes, fatias de tomate, alface americana, molho especial à base de maionese e alho, e um toque extra de ketchup e mostarda. Para finalizar, uma camada de pulled pork desfiado e uma pitada de páprica picante, garantindo uma explosão de sabores a cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 4,
      Name = "X-Gourmet",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Uma experiência gastronômica sofisticada, criada para paladares exigentes. O hambúrguer trufado, preparado com carne Angus suculenta, é coroado com queijo brie derretido e cogumelos trufados, realçando a complexidade dos sabores. Servido em um pão brioche artesanal, ele é complementado por rúcula fresca e uma maionese artesanal levemente cítrica. Cada mordida é um convite a saborear a combinação perfeita entre ingredientes premium e texturas envolventes, fazendo do X-Gourmet uma escolha inesquecível.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 5,
      Name = "X-Clássicos",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Uma celebração aos sabores que nunca saem de moda. O Cheeseburger Tradicional, com hambúrguer grelhado no ponto perfeito, é acompanhado por queijo cheddar derretido, alface fresca e tomate suculento, tudo dentro de um pão macio. Para os amantes de bacon, o X-Bacon entrega o crocante irresistível junto com molho barbecue. Já o X-Egg adiciona o toque especial do ovo frito com gema cremosa. Simples e deliciosos, os clássicos oferecem conforto e sabor em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true"
    }
  };

  public static List<Product> Products = new List<Product>
  {
    new Product
    {
      Id = 1,
      Name = "X-Alface-Premium",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 29.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 2,
      Name = "X-Tomate",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 39.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 3,
      Name = "X-Frutas",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 4,
      Name = "X-Salada",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 5,
      Name = "X-Fitness-Grelhado",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 29.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 6,
      Name = "X-Proteína",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 39.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 7,
      Name = "X-Low-Carb",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 8,
      Name = "X-Light",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 9,
      Name = "X-Mega-Bacon",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 29.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 10,
      Name = "X-Parada-Cardíaca",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 39.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 11,
      Name = "X-Queijo-Extra",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 12,
      Name = "X-Triplo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 13,
      Name = "X-Trufado-Supreme",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 59.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 14,
      Name = "X-Blue-Cheese-Delight",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 69.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 15,
      Name = "X-Mediterrâneo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 79.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 16,
      Name = "X-Deluxe",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 89.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 17,
      Name = "X-Cheeseburger-Tradicional",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 29.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 18,
      Name = "X-Bacon",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 39.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 19,
      Name = "X-Egg",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 20,
      Name = "X-Tudo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/mauricio-alves/burguermania-frontend/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 49.99,
      CategoryId = 5
    }
  };
}
