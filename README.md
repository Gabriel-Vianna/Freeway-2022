<img src="./Assets/statics/cover.png" align="middle" width="3000"/>

# Freeway 2022

**Freeway 2022** é o remake do jogo Freeway originalmente lançado para o vídeo-game Atari em 1981.
A ideia deste projeto foi recriar o jogo original com uma atualizando na interface, e adicionar Inteligência Artificial, através da técnica de `Aprendizado por reforço` para treinar um agente do jogo a executar determinada tarefa. No nosso caso, atravessar a rodovia desviando de todos os veículos.

## Treinamento da IA

O objetivo inicial era recriar o jogo original, usando a game engine Unity eu recriei o layout do jogo e a simulação de um tráfego de carros em uma rodovia. 
Nesse momento eu ainda não estava preocupado com a interface, então usei poligonos para simular os objetos do jogo

<img src="./Assets/statics/scenario.gif" align="middle" width="2000"/>

Feito isso, agora minha principal preocupação seria usar este cenário criado para treinar o agente do jogo a atravessar a rua. A Unity possui uma biblioteca chamada [ML-Agents](https://github.com/Unity-Technologies/ml-agents) que te da muitas ferramentas para treinamento de um agente em um jogo, usando esta biblioteca eu fui capaz de começar os primeiros treinamentos da IA.

Durante os primeiros treinamentos, a aprendizagem do agente estava sendo influênciada pelo tráfego (Como deveria ser), porém o tráfego do jogo era previsível, os carros eram seguindo um ritmo constante e eram instanciados sempre da mesma forma, isso fez com que a IA aprendesse um padrão e não aprendesse a desviar dos carros independente da situação.

<img src="./Assets/statics/trainingResult.gif" align="middle" width="2000"/>

A partir dessa análise foi necessário alterar a forma como tráfego da rodovia se comportava, tornando a rodovia completamente aleatória, assim nossa IA precisaria aprender a atravessar um tráfego completamente caótico.

<img src="./Assets/statics/traffic.gif" align="middle" width="2000"/>

O último passo, e essencial, para que a IA pudesse desviar dos veículos com muito sucesso foi adicionar sensores de proximação no agente durante seu treinamento. Dessa forma o agente consegue prever a aproximação de vários obstáculos e se antecipar e planejar uma ação.

<img src="./Assets/statics/sensors.gif" align="middle" width="2000"/>

Por fim, temos nossa inteligência artificial treinada e atravessando a rua!

<img src="./Assets/statics/final.gif" align="middle" width="2000"/>