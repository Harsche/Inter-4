=== SEU_JOAO ===
{GameDay:
- 1:    ->Seu_Joao_Day_01
}
=== Seu_Joao_Day_01 ===
{Seu_Joao_Day_01:
-   1:  ->D01
-   else:   ->Random_Dialog
}

= D01
Seu João: Aooo, Luizinho! Como que cê ta, ein?
Luiz: Aooooo, seu João! Eu to bem, e o sinhô? Vim saber se posso ajudar o sinhô com o carvão hoje. To precisando...
Seu João: Eu to bão, uai! Oh, fi... As coisas não andam bem pra mim, não. Quase ninguém ta comprando carvão... eu num tenho como te paga, Luiz.
Luiz: Eu te ajudo, Seu João!
Seu João: Tem certeza, fi?
Luiz: Tenho sim!
JOGO: (MINIGAME DE CORTAR LENHA)
Seu João: Muito obrigado por me ajudar, Luizinho. Num queria te deixar ir de mão abanando, então fica com essas romãs.
Seu João: Eu consegui elas trocando carvão lá na cidade. Leva pro cê e pra sua família!
Luiz: Obrigado, seu João!
Seu João: Não tem de que, Luizinho!
->DONE

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





