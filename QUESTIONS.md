## Questões

### 1. Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?

Fiz a leitura do número e quebrei o número em uma lista de int quebrando a cada 3 casas entendendo como as centenas. Com a quebra pude criar uma iteração que permitiria criar números para qualquer medida de milhar por extenso. Dessa lista de int, representando as unidades de centenas, identifico a posição de cada item para me auxiliar na montagem do termo de unidade,da dezena e das centenas. Com isso classificado, pude aplicar o padrão decorator para montar o termo centenar de acordo com a existencia do número. Por exemplo, caso a casa da centena seja zero eu não aplico a decoração ficando somente com a dezena e a unidade. Caso a dezena não exista eu monto o número somente com a centena e a unidade.
O maior desafio evitar métodos verbosos e acoplar um pattern para resolver o desafio.

### 2. Como você lidou com a performance na implementação do desafio 2,considerando que o array pode ter até 1 milhão de números?

Ao começar a planejar o desafio minha preocupação era com o objeto recebido que já inicia com um certo peso de consumo de memoria. Evitar qualquer manipulação para a quebra de dados e foquei em consumir com maior capacidade de processamento da máquina, usei paralelismo com a capacidade de processador existente da máquina lendo o list com yield. Realizei lock no paralelismo no ato da soma. Acabou ficando um processamento bastante performático.
Nos testes adicionei um volume maior para processamento e acabei deixando o aplicativo sem um tratamento de tamanho da requisição. minha preocupação na implementação era se o lock pudesse causar muita trava no processamento. Usei métricas e acompanhamento de consumo de maquina com newrelic. 

### 3. Como você lidou com os possíveis erros de entrada na implementação do desafio 3, como uma divisão por zero ou uma expressão inválida?

Criei um tratamento de possibilidades que poderiam quebrar o algoritmo usando expressão regular. Então além da divisão por zero validei operadores nas extremidades, operados consecutivos e verificação de caracteres de texto na expressão recebida.

### 4. Como você implementou a função que remove objetos repetidos na implementação do desafio 4? Quais foram os principais desafios encontrados?

Fiz uso de uma lista auxiliar de Hashset ajudando a garantir que os itens já existentes na lista não serão adicionados novamente. Então no algoritmo eu percorro a lista recebida item a item adicionando no Hashset, o Add desse objeto me retorna um booleano que ajuda a identificar se o item foi adicionado ou se já existia na sua coleção. Após, adiciono uma nova lista somente com itens únicos.
O desafio maior era o tempo de computação para identificação de termos duplicados, o que motivou a realização do algoritmo criado.
