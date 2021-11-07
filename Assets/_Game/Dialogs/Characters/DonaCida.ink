=== DONA_CIDA ===
{GameDay:
- 1:    ->Dona_Cida_Day_01
}


=== Dona_Cida_Day_01 ===
{Dona_Cida_Day_01:
-   1:  ->D01
-   else:   ->Random_Dialog
}

= D01
~ PauseTimeline()
Dona Cida: Bom dia, meu fi.
Luiz: Bom dia, dona Cida! O Junior ta? Queria chama ele pra joga bola, se a senhora deixa!
Dona Cida: Oh fi, num ta não. Junior saiu agora de pouco com o pai dele pra irem vende uns ovos das nossas galinha num vilarejo aqui de perto, eles vão passar uns dias lá. Ocê quer entrar?
*   [Entrar]
    ~ ChooseCutscene(0)
    ~ CloseDialog()
    Dona Cida: Como que ta a sua mãe e seus irmãozinhos, ein Luiz?
    Luiz: Eles tão bem, Dona Cida. Só minha mãe que ultimamente parece meio abatida...
    Dona Cida: Como assim, fi?
    Luiz: Ah, Dona Cida, eu num sei explica. Ela parece meio... cansada, meio fraca.
    Dona Cida: Essa seca ta castigando todo mundo. Sua mãe deve ta preocupada, é só isso. Se Deus quiser, logo a chuva vem!
    Luiz: Brigada, Dona Cida! Eu já vou indo! Fique com Deus.
    Dona Cida: Vá com Deus, Luiz!
    ~ ResumeTimeline()
    ->DONE
*   [Melhor não]
    ~ ChooseCutscene(1)
    ~ PauseTimeline()
    Luiz: Não se incomode não, Dona Cida! Eu passo aqui outra hora!
    Dona Cida: Ta bom, Luizinho!
    ~ ResumeTimeline()
    ->DONE
    
= Random_Dialog

{ shuffle once:

-    Dona Cida: Eu fico feliz por você e o Junior serem amigos. Tenho um carinho pelo cê como se ocê fosse meu neto, Luizinho!
    ->DONE
-    Dona Cida: Sabe um coisa que eu tenho saudade? Do cheiro da terra molhada, o cheiro da chuva... Sim, é um cheiro único.
    ->DONE
-    Dona Cida: Logo logo vai chover, meu fi. Eu tenho fé, eu oro todos os dias por isso!
    ->DONE
-    Dona Cida: Espero que o Junior e o meu fi voltem logo pra casa, que consigam vender tudo que levaram. Se for assim, eu posso até ajudar ocê e a sua mãe, Luiz!
    ->DONE
}

=== Pegar_Galinhas ===

= D01
Luiz: Eita! DONA CIDA, AS GALINHA DA SENHORA TÃO TUDO SOLTA AQUI!!!
Dona Cida: Oh meu Deus! Elas escaparam!
Luiz: Eu vou pegar elas pra senhora.
Dona Cida: É muito dificil pegar galinha, Luiz. São ligeiras demais.
Luiz: Então eu vou tentar só tocar elas pra dentro do cercado de novo.
->DONE

= D02
->DONE

