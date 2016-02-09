# EducaIBGE
Raspagem de dados, do IBGE, disponibilizando em forma de serviço filtrável dados específicos


## Progresso

* [SEE7](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE7&t=docentes-curso-superior-ensino-fundamental-rede)Docentes co superior no fundamental
* [SEE10](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE10&t=docentes-curso-superior-ensino-medio-rede) Docentes com Superior no médio (Acredito que esses 2 englobem o SEE8 e o SEE29 também)
* [SEE01](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE01&t=numero-medio-aluno-turma-ensino-fundamental) Número de aluno por turma no ensino fundamental (Usei valores absolutos pois os resultados dos valores relativos parecem incoerentes)
* [SEE4](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE4&t=numero-medio-aluno-turma-preescola-rede) Número de aluno por turma na pré-escola
* [PD320](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=PD320&t=pessoas-5-anos-mais-idade-alfabetizadas) Número de alfabetizados por grupo de idade
* [PD321](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=PD321&t=pessoas-5-anos-mais-idade-nao) Número de não alfabetizados pro grupo de idade (Acredito que o PD319 esteja contido nesses itens (PD320, PD321))
* [SEE31](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE31&t=reprovacao-serie-ensino-fundamental-8-9) Reprovacao por sério ensino fundamental de 8 e 9 anos (série nova)
* [SEE32](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=SEE32&t=reprovacao-serie-ensino-medio-serie-nova) Reprovacao por série ensino médio (série nova)
* [PD323](http://seriesestatisticas.ibge.gov.br/series.aspx?no=4&op=0&vcodigo=PD323&t=pessoas-10-anos-mais-idade-anos)Pessoas de 10 anos ou mais de idade, por anos de estudo


#Endpoints
##Todos os endpoints possuem filtros, que podem ser usados para obter dados mais específicos
* professores/superior (SEE7)(SEE10)
* alunos-por-sala (SEE01) (SEE4)
* alfabetizacao (PD320) (PD321)
* reprovacao (SEE31) (SEE32)
* anos-de-estudo (PD323)


