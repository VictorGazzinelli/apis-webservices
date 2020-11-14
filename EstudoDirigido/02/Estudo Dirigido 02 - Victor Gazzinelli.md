# Estudo Dirigido 02

## PARTE 1 – Modelos de Maturidade de APIs
- Qual a diferença central entre os níveis 2 e 3 do modelo de maturidade de Richardson.
  - A diferença central entre os dois níveis é a presença de HATEOAS(Hypermedia as the Engine of Application State), que disponibiliza 'links' de hypermedia como 'sugestões' de possiveis pesquisas ou procedimentos a serem realizados pela API como parte da resposta da mesma. Por Exemplo: é provavel que após a realização de um depósito, você gostaria de verificar o seu saldo bancario.

- Examine a API https://developer.marvel.com/ Qual o nível de maturidade dessa API, conforme o modelo de maturidade Richardson.
  - Nível 3, ja que a mesma dispõe recursos, verbos HTTP, e HATEOAS.

- Projete uma API REST que suporte o cadastro de livros e carrinhos de compras para uma
    aplicação de e-commerce.

As seguintes operações devem ser implementadas:
- Criação de um livro
- Remoção de um livro
- Criação de um carrinho de compras
- Remoção de um carrinho de compras
- Adição de um livro a um carrinho de compras
- Listagem de um carrinho de compras e seus livros

- Qual o nível de maturidade dessa API, conforme classificação de Richardson.
  - Nivel 2, dispondo de recursos e verbos HTTP. O pulo do gato da aplicação esta em uma tabela/recurso carrinhoLivros onde um relacionamento n x n permite com que um carrinho tenha varios livros e um livro possa ser parte de varios carrinhos.


## PARTE 2 – Técnicas de Escalabilidade
- Examine a API da Marvel usada na aula anterior e o material de escalabilidade de APIs fornecido no nosso ambiente.
A partir do desenho da API e da resposta observada no seu ambiente Postman, que técnicas de escalabilidade você consegue identificar.
  - Organização baseada em recursos, padronização de endpoints, recursos dividos em coleção/item/coleção, Documentação, HTTPS, Versionamento e Paginação
- A API implementada pelo JSON Server suporta também mecanismos de escalabilidade. Leia a documentação disponível aqui https://github.com/typicode/json-server e indique que mecanismos são esses
  - Alem dos mesmos acima, o JSON Server permite mecanismos de filtro, ordenação, divisão, entre outros..

## PARTE 3 – Uso de Melhores Práticas REST
- Considere a API da Marvel usada na aula anterior. Olhe os 11 itens apresentados na seção 4.6.4 do livro texto. Enumere quais práticas você pode observar no desenho da API da Marvel. Forneça exemplos.
  - 1 - Origanização ao longo de recursos em todos os endpoints da API, 2 - Padronização entre os recursos junto a 4 - Crie API simples, divisão de rotas em recursos coleção/item/coleção, 7 - Documentação via Swagger, 8 - HTTPS, 9- Versão 1, 10 - Paginação de grande volume de dados e compressão gzip.

## PARTE 4 – Criação de uma API com Código Servidor Completo e Banco de Dados
- Olhe os 11 itens apresentados na seção 4.6.4 do livro texto do nosso curso Enumere quais práticas você pode observar no código criado.
  - 1,2,3,4,5,8,11