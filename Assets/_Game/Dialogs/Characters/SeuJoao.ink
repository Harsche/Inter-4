=== SEU_JOAO ===
{GameDay:
-   1:  -> Seu_Joao_Day_01
-   2:  -> Seu_Joao_Day_02
-   3:  -> Seu_Joao_Day_03
}

=== Seu_Joao_Day_01 ===
{woodChopped == 3: -> Chopped_Wood}
{Seu_Joao_Day_01:
-   1:  -> D01
-   else:   -> Seu_Joao_Random_Dialog
}

= D01
~ PauseTimeline()
Seu João: Aooo, Luizinho! Como que cê ta, ein?
Luiz: Aooooo, seu João! Eu to bem, e o sinhô?
Luiz: Vim saber se posso ajudar o sinhô com o carvão hoje. To precisando...
Seu João: Eu to bão, uai! Oh, fi... As coisas não andam bem pra mim, não.
Seu João: Quase ninguém ta comprando carvão... eu num tenho como te paga, Luiz.
Luiz: Eu te ajudo, Seu João!
Seu João: Tem certeza, fi?
Luiz: Tenho sim!
~ RemoveQuest("Vá falar com Seu João")
~ newQuest("Corte a lenha")
~ ResumeTimeline()
~ chopTask = true
-> DONE

= Chopped_Wood
~ chopTask = false
Seu João: Muito obrigado por me ajudar, Luizinho.
Seu João: Num queria te deixar ir de mão abanando, então fica com essas romãs.
Seu João: Eu consegui elas trocando carvão lá na cidade. Leva pro cê e pra sua família!
Luiz: Obrigado, seu João!
Seu João: Não tem de que, Luizinho!
~ RemoveQuest("Corte a lenha")
~ SetPlayerAnimatorBool(PLAYERAXE, false)
{Dona_Cida_Day_01.D01 : -> Luiz}
-> DONE


=== Seu_Joao_Day_02 ===
{Seu_Joao_Day_02:
-   1:  -> D01
-   else:   -> Seu_Joao_Random_Dialog
}

= D01
~ PauseTimeline()
Luiz: Boa tarde, Seu João!
Seu João: Opa, Luizinho! Como você tá?
Luiz: Eu to bem! Vim saber se posso ajudar com o carvão de novo!
Seu João: Poxa, Luiz! Eu não vou mais fazer carvão até vender o que tem aqui.
Luiz: Tudo bem, Seu João! Obrigada mesmo assim!
Seu João: De nada, fi! Sinto muito...
~ RemoveQuest("Vá falar com Seu João")
~ ResumeTimeline()
{Dona_Cicera_Day_02.Help_Make_Basket_02: -> Getting_Dark}
-> DONE


=== Seu_Joao_Day_03 ===
{Seu_Joao_Day_03:
-   1:  -> D01
-   2:  -> Cow_Died
-   3:  -> After_Cow_Died
-   else:   -> Seu_Joao_Random_Dialog
}

= D01
~ PauseTimeline()
Seu João: Aooo, Luizinho! Uai, porque que ocê ta com essa cara?
~ ResumeTimeline()
-> DONE


= Cow_Died
~ PauseTimeline()
Seu João: Com a seca, os bichin não dura muito, Luizinho.
Seu João: Fica difícil de dar água e comida... e Dondoca já não era nova.
Luiz: É... ela tava com a gente desde que eu era menorzinho...
Luiz: E o leite dela eu tava usando pra dar aos meus irmãos...
Seu João: Não chore não, vai ficar tudo bem.
Seu João: Já já a chuva vem e a gente sai desse aperto...
Luiz: Que Deus lhe ouça...
Seu João: Se precisar de alguma coisa, eu vou estar lá em casa.
~ RemoveQuest("Vá falar com o Seu João")
~ ResumeTimeline()
-> DONE

= After_Cow_Died
{Seu_Miguel_Day_03.Filled_Water_Box && Seu_Jose_Day_03.D03:
-> Getting_Dark
}
-> DONE

=== Seu_Joao_Random_Dialog ===
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
