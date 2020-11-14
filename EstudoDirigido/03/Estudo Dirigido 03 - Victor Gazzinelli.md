## PARTE 1 – Desenho de APIs com o Padrão Open API

- Identifique na documentação OpenAPI os seguintes elementos. Explique a sintaxe OpenAPI dos elementos acima identificados.
 - Modelagem do recurso Animal (Pet)
  - O schema indica o recurso Pet e todos os sub-recursos vinculados a ele, no caso, as caracteristicas do pet bem como seus tipos primitivos que compõem o objeto/recurso em questão.
 - Operação de criação de um novo animal na loja de animais POST /pet
  - o Path indica o caminho do endpoint no qual a chamada é realizado, logo em seguida o verbo que indica a ação de escrita (POST), parametros (se houver), junto de um resumo da responsabilidade do endpoint e suas possiveis respostas Http e modelo.

- Crie a sua própria especificação de API. Você deve criar uma API para manipular livros em uma livraria virtual com as operações básicas de adição, atualização de dados, remoção e pesquisa. O esquema do seu livro deve ter as seguintes informações.

  - ISBN (Código alfanumérico de 13 letras). Representa a chave primária de um livro.
  - Nome
  - Ano de publicação
  - Autor
  - Preço

## PARTE 2 – Criação de uma API com o padrão gRPC

- Aponte três similaridades entre gRPC e REST/HTTP
  - Podem operar sobre o protocolo HTTP
  - Dão suporte a tipos de conteúdo JSON
  - Suportam transporte via TLS
- Aponte três diferenças entre gRPC e REST/HTTP
  - gRPC requer um contrato via arquivos .proto, enquanto REST pode contar com um contrato via OpenAPI
  - gRPC pode utilizar de cargas mais leves atraves de Protobuf, enquanto REST utiliza de dados como XML e JSON que podem se tornar pesados
  - gRPC é arquitetado para realizar chamadas assincronas, enquanto REST pode tambem optar por chamadas sincronas, 'garantindo' a execução de uma chamada.