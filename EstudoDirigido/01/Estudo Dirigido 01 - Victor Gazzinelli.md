# Estudo Dirigido 01

## Parte 1 – Compreensão dos Fundamentos HTTP

- Quais os cabeçalhos HTTP enviados na requisição exemplo GET?
  - Cookie, Cache-Control, Postman-Token, Host, User-Agent, Accept, Accept-Encoding, Connection
- Quais os cabeçalhos HTTP recebidos na resposta exemplo GET?
  - Date, Content-Type, Content-Length, Connection, ETag, Vary, set-cookie
- Invoque a URL [https://postman-echo.com/get] do seu navegador? Você observa algo diferente?
  - Sim, o conteúdo do body vem modificado e minimizado, o user-agent bem como outras propriedades vem também modificadas
  ```json
  {"args":{},"headers":{"x-forwarded-proto":"https","x-forwarded-port":"443","host":"postman-echo.com","x-amzn-trace-id":"Root=1-5f76565b-3a9f4d6b0a45f57f2988bb21","upgrade-insecure-requests":"1","user-agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36","accept":"text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9","sec-fetch-site":"none","sec-fetch-mode":"navigate","sec-fetch-dest":"document","accept-encoding":"gzip, deflate, br","accept-language":"pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7"},"url":"https://postman-echo.com/get"}
  ```
- Qual a função do cabeçalho User-Agent na chamada dos métodos?
  - Identificar a partir de qual browser, sistema operacional, versão e outros dados partem do usuário requisitante.
- As requisições GET operam com otimização de compressão de dados? Justifique.
  - A otimização de compressão de dados pode partir de varios contextos, uma requisição GET pode operar com esta otimização quando o requisitante sabe manipular os dados que sofreram compressão, obtendo assim o conteudo original desejado.
- Introduza um parâmetro chamado CODIGO_CLIENTE na requisição POST. O que você observa de diferente na chamada e na resposta?
  - O conteudo do objeto "args" reproduz o parâmetro solicitado pelo requisitante
  ```json
    ...
      "args": {
        "CODIGO_CLIENTE": "1"
      },
    ...
  ```

## Parte 2 – Testes de Contratos HTTP

- Estenda esse código de testes para os outros métodos HTTP com limite de tolerância de 500ms para as operações de escrita e 200ms para as operações de leitura
   ```js
  // GET
    pm.test("Response time is less than 200ms", function () {
        pm.expect(pm.response.responseTime).to.be.below(200);
    });
  // POST
    pm.test("Response time is less than 500ms", function () {
        pm.expect(pm.response.responseTime).to.be.below(500);
    });
  // PUT 
    pm.test("Response time is less than 500ms", function () {
        pm.expect(pm.response.responseTime).to.be.below(500);
    });
  // DELETE
    pm.test("Response time is less than 500ms", function () {
      pm.expect(pm.response.responseTime).to.be.below(500);
    });
  ```

  ```json
  {
	"id": "be9fb7a0-bb9a-4e32-9ce0-13a3bd777ae4",
	"name": "Designing an API",
	"timestamp": "2020-10-01T22:43:28.555Z",
	"collection_id": "8cf722f9-68a8-4727-9bf7-42e8d6d8c184",
	"folder_id": 0,
	"environment_id": "0",
	"totalPass": 4,
	"totalFail": 0,
	"results": [
		{
			"id": "670b28b0-5f0f-43a0-ab27-075c85dfcb4f",
			"name": "Postman Echo GET",
			"url": "https://postman-echo.com/get",
			"time": 157,
			"responseCode": {
				"code": 200,
				"name": "OK"
			},
			"tests": {
				"Response time is less than 200ms": true
			},
			"testPassFailCounts": {
				"Response time is less than 200ms": {
					"pass": 1,
					"fail": 0
				}
			},
			"times": [
				157
			],
			"allTests": [
				{
					"Response time is less than 200ms": true
				}
			]
		},
		{
			"id": "ea00c37c-4297-437a-8336-c3bfaf6b0fbd",
			"name": "Postman Echo POST",
			"url": "https://postman-echo.com/post?CODIGO_CLIENTE=1",
			"time": 157,
			"responseCode": {
				"code": 200,
				"name": "OK"
			},
			"tests": {
				"Response time is less than 500ms": true
			},
			"testPassFailCounts": {
				"Response time is less than 500ms": {
					"pass": 1,
					"fail": 0
				}
			},
			"times": [
				157
			],
			"allTests": [
				{
					"Response time is less than 500ms": true
				}
			]
		},
		{
			"id": "5e219336-4037-49f7-b258-f742c39b9209",
			"name": "Postman Echo PUT",
			"url": "https://postman-echo.com/put",
			"time": 158,
			"responseCode": {
				"code": 200,
				"name": "OK"
			},
			"tests": {
				"Response time is less than 500ms": true
			},
			"testPassFailCounts": {
				"Response time is less than 500ms": {
					"pass": 1,
					"fail": 0
				}
			},
			"times": [
				158
			],
			"allTests": [
				{
					"Response time is less than 500ms": true
				}
			]
		},
		{
			"id": "49e67bec-d063-4e67-abcb-92fd82f69735",
			"name": "Postman Echo DELETE",
			"url": "https://postman-echo.com/delete",
			"time": 157,
			"responseCode": {
				"code": 200,
				"name": "OK"
			},
			"tests": {
				"Response time is less than 500ms": true
			},
			"testPassFailCounts": {
				"Response time is less than 500ms": {
					"pass": 1,
					"fail": 0
				}
			},
			"times": [
				157
			],
			"allTests": [
				{
					"Response time is less than 500ms": true
				}
			]
		}
	],
	"count": 1,
	"totalTime": 629,
	"collection": {
		"requests": [
			{
				"id": "670b28b0-5f0f-43a0-ab27-075c85dfcb4f",
				"method": "GET"
			},
			{
				"id": "ea00c37c-4297-437a-8336-c3bfaf6b0fbd",
				"method": "POST"
			},
			{
				"id": "5e219336-4037-49f7-b258-f742c39b9209",
				"method": "PUT"
			},
			{
				"id": "49e67bec-d063-4e67-abcb-92fd82f69735",
				"method": "DELETE"
			}
		]
	}
  ```
- Os seus testes são determinísticos (sempre irão gerar o mesmo resultado)? Justifique.
  - Não, os testes realizados não serão deterministicos, devido a natureza da conexão web, seria necessário realizar um benchmark com varios testes para estipular um valor médio de tempo de resposta baseado em uma mesma qualidade de conexão.

## Parte 3 – Consumo de uma API Real

- Listagem de todos os personagens da Marvel.
- Listagem das histórias que o capitão América participou.
- Listagem das revistas que o capitão América participou.
- Introduza testes de contrato sobre cada uma dessas APIs
  - ```json
  {
    "id": "0b7dc020-a5d6-41b1-8396-ba3757841e41",
    "name": "Testes API Marvel",
    "timestamp": "2020-10-01T23:58:47.593Z",
    "collection_id": "d2f3dbd8-2181-455f-b47a-8a9be0efc326",
    "folder_id": 0,
    "environment_id": "0",
    "totalPass": 3,
    "totalFail": 0,
    "results": [
      {
        "id": "1cd491a8-26ee-42aa-a2ba-bf08ba2bd76c",
        "name": "Info Capitão America",
        "url": "https://gateway.marvel.com/v1/public/characters/1009220?ts=1&apikey=49b79a1a7f1b7d8f70d399e1fff23b30&hash=551048cd2e85989d39c1f42113538e05",
        "time": 229,
        "responseCode": {
          "code": 200,
          "name": "OK"
        },
        "tests": {
          "Response time is less than 1500ms": true
        },
        "testPassFailCounts": {
          "Response time is less than 1500ms": {
            "pass": 1,
            "fail": 0
          }
        },
        "times": [
          229
        ],
        "allTests": [
          {
            "Response time is less than 1500ms": true
          }
        ]
      },
      {
        "id": "fb0746eb-cb14-4298-bbda-54744e04151b",
        "name": "Capitão America Histórias",
        "url": "https://gateway.marvel.com/v1/public/characters/1009220/series?ts=1&apikey=49b79a1a7f1b7d8f70d399e1fff23b30&hash=551048cd2e85989d39c1f42113538e05",
        "time": 503,
        "responseCode": {
          "code": 200,
          "name": "OK"
        },
        "tests": {
          "Response time is less than 1500ms": true
        },
        "testPassFailCounts": {
          "Response time is less than 1500ms": {
            "pass": 1,
            "fail": 0
          }
        },
        "times": [
          503
        ],
        "allTests": [
          {
            "Response time is less than 1500ms": true
          }
        ]
      },
      {
        "id": "9d0209d4-0cc2-43c7-b2d7-b0ce0aafdad0",
        "name": "Capitão America Revistas",
        "url": "https://gateway.marvel.com/v1/public/characters/1009220/comics?ts=1&apikey=49b79a1a7f1b7d8f70d399e1fff23b30&hash=551048cd2e85989d39c1f42113538e05",
        "time": 1399,
        "responseCode": {
          "code": 200,
          "name": "OK"
        },
        "tests": {
          "Response time is less than 1500ms": true
        },
        "testPassFailCounts": {
          "Response time is less than 1500ms": {
            "pass": 1,
            "fail": 0
          }
        },
        "times": [
          1399
        ],
        "allTests": [
          {
            "Response time is less than 1500ms": true
          }
        ]
      }
    ],
    "count": 1,
    "totalTime": 2131,
    "collection": {
      "requests": [
        {
          "id": "1cd491a8-26ee-42aa-a2ba-bf08ba2bd76c",
          "method": "GET"
        },
        {
          "id": "fb0746eb-cb14-4298-bbda-54744e04151b",
          "method": "GET"
        },
        {
          "id": "9d0209d4-0cc2-43c7-b2d7-b0ce0aafdad0",
          "method": "GET"
        }
      ]
    }
  }
    ```
- Explique o que cada um d os seguintes cabeçalhos de resposta da chamada de uma API da Marvel representa.
  - Content-Encoding : Tipo de algoritmo usado para compressão
  - ETag: Identificador da versão do recurso
  - Content-Type: Identificador sobre o formato que deve ser 'parseado' a resposta, no caso, sendo um json com encoding de utf-8
  - Date: Data da resposta em UTC
  - Connection: Estado da conexão 'keep-alive' ( ainda ativa )
  - Transfer-Encoding : Forma de encoding utilizada para transferir a entidade ao requisitante.