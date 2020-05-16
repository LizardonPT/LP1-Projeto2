# LP1-Projeto2
# Projeto 2 de Linguagens de Programação I 2019/2020

##  Felli

### Autoria - Grupo 10

- António Branco (a21906811)
  - Fez os enumeradores do projeto, arranjou os bugs do menu, fez o `WhiteTurn` e o `WhiteMovement`, tratou dos inputs do jogo, adicionou os turnos entre as peças brancas e as peças pretas, fez a estrutura para a as condições de vitoria e fez a estrutura do relatório.
  
- João Gonçalves (a21901696)
   - Fez a estrutura do método `Board` e iniciou as posições das peças no tabuleiro, comentou parte do código, fez debug no `BlackMovement` e adicionou a parte que atualiza a posição das peças no mesmo método, fez merge do `blackmovement`com o `fix menu crash`, fez ajustes ao código e debug, e escreveu o relatório.

- Vasco Duarte (a21905658)
  - Fez a estrutura principal do código, fez o menu, fez ajustes ao código, arranjou os bugs do `Board`, fez merge do branch `enum` e `master`, adicionou a classe para as peças, fez a análise dos movimentos possíveis no método `BlackMovement`, finalizou o movimeto das peças com as condições para as peças se poderem comer umas àsa outras, fez debug num modo geral e completou o código para as condições de vitória. 

### [Repositório git]() (WIP)

## Arquitetura da Solução (WIP)
O método `main` trata do menu do jogo, imprime as strings necessárias conforme os inputs dos jogadores no pré jogo.
Quando o jogador seleciona a opcão Play procede-se á criação do array `map` que serve de tabuleiro com as posições iniciais das peças e o método `Board` é chamado para desenhar o mesmo.
O método `main` procede para a seleção de cor por parte do jogador e depois para o método `GameLoop` que trata do resto do jogo.

O método `GameLoop` consiste num ciclo `do while` que apenas termina quando um dos jogadores ganhar. O ciclo está dividido em duas partes, turno do jogador das peças brancas e turno do jogador das peças pretas. Quando um dos turnos começa, o programa chama o método `WhiteWinVerification` ou `BlackWinVerification` conforme o turno para verificar se o adversário já ganhou o jogo. Ambos os métodos verificam se as peças do adversário já não estão em jogo. Se houver um vencedor é mostrada uma mensagem de vitória e o jogo termina, caso contrário, o jogo prossegue e o método do turno do jogador é chamado, `BlackTurn` ou `WhiteTurn` estes métodos retornam strings que mantêm o ciclo do jogo. Os métodos dos turnos pedem ao jogador que peça querem mexer consoante se as peças ainda estão ou não ainda em jogo. Se a peça ainda estiver em jogo chama os métodos `BlackMovement` e `WhiteMovement`.
Esses métodos verificam que peça foi escolhida e que movimentos essa peça pode fazer. Se a peça não puder fazer nenhum movimento retorna para o método anterior para uma nova peça ser selecionada. Se a peça selecionada puder fazer o movimento o jogador deve escolher entre qual dos movimentos ele quer que a peça faça.

## Fluxograma (WIP)
![alt text]()

### Referências (WIP)
https://stackoverflow.com/questions/16100/convert-a-string-to-an-enum-in-c-sharp
https://stackoverflow.com/questions/17400617/very-basic-use-of-enum-tryparse-doesnt-work
https://stackoverflow.com/questions/1082532/how-to-tryparse-for-enum-value