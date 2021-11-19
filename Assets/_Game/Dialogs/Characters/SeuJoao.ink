=== SEU_JOAO ===
{GameDay:
-   1:  -> Seu_Joao_Day_01
-   2:  -> Seu_Joao_Day_02
}

=== Seu_Joao_Day_01 ===
{Seu_Joao_Day_01:
-   1:  -> D01
-   else:   -> Random_Dialog
}

= D01
Seu João: Aooo, Luizinho! Como que cê ta, ein?
Luiz: Aooooo, seu João! Eu to bem, e o sinhô?
Luiz: Vim saber se posso ajudar o sinhô com o carvão hoje. To precisando...
Seu João: Eu to bão, uai! Oh, fi... As coisas não andam bem pra mim, não.
Seu João: Quase ninguém ta comprando carvão... eu num tenho como te paga, Luiz.
Luiz: Eu te ajudo, Seu João!
Seu João: Tem certeza, fi?
Luiz: Tenho sim!
JOGO: (MINIGAME DE CORTAR LENHA)
Seu João: Muito obrigado por me ajudar, Luizinho.
Seu João: Num queria te deixar ir de mão abanando, então fica com essas romãs.
Seu João: Eu consegui elas trocando carvão lá na cidade. Leva pro cê e pra sua família!
Luiz: Obrigado, seu João!
Seu João: Não tem de que, Luizinho!
-> LUIZ

= Random_Dialog

{ shuffle once:

-   Seu João: Sabe, Luiz, quando eu era pequeno, eu jogava bola com o Seu Miguel. A gente era craque!
    ->DONE
-   Seu João: Quando a chuva vier, ela vai enche o lago e a gente vai poder volta a plantar!
    ->DONE
-   Seu João: Vender carvão tem sido o único jeito de conseguir me manter... Obrigado por me ajudar nisso, Luiz!
    ->DONE
-   Seu João: A sua mãe foi uma muié guerreira desde sempre, ela te criou muito bem!
    ->DONE
}

=== Seu_Joao_Day_02 ===
{Seu_Joao_Day_02:
-   1:  -> D01
-   else:   -> Random_Dialog
}

= D01
Luiz: Boa tarde, Seu João!
Seu João: Opa, Luizinho! Como você tá?
Luiz: Eu to bem! Vim saber se posso ajudar com o carvão de novo!
Seu João: Poxa, Luiz! Eu não vou mais fazer carvão até vender o que tem aqui.
Luiz: Tudo bem, Seu João! Obrigada mesmo assim!
Seu João: De nada, fi! Sinto muito...
-> DONE

= Random_Dialog
-> DONE

=== Seu_Joao_Day_03 ===
{Cow_Day_03.D01: -> Cow_Died}
{Seu_Joao_Day_03:
-   1:  -> Random_Dialog
-   else:   -> Random_Dialog
}

= Cow_Died
Seu João: Com a seca, os bichin não dura muito, Luizinho.
Seu João: Fica difícil de dar água e comida... e Dondoca já não era nova.
Luiz: É... ela tava com a gente desde que eu era menorzinho...
Luiz: E o leite dela eu tava usando pra dar aos meus irmãos...
Seu João: Não chore não, vai ficar tudo bem.
Seu João: Já já a chuva vem e a gente sai desse aperto...
Luiz: Que Deus lhe ouça...
Seu João: Se precisar de alguma coisa, eu vou estar lá em casa.
-> Getting_Dark

= Random_Dialog
-> DONE



