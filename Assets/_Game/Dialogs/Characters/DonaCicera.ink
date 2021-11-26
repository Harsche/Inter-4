=== DONA_CICERA ===
{GameDay:
-   1:  -> Dona_Cicera_Day_01
-   2:  -> Dona_Cicera_Day_02
}


=== Dona_Cicera_Day_01 ===
{Dona_Cicera_Day_01:
-   1:  -> DONE
-   else:   -> DONE
}



=== Dona_Cicera_Day_02 ===
{lostKey: -> Found_Key}
{not Help_Make_Basket_01 && (ciceraFoundKey == true || Found_Key): -> Help_Make_Basket_01}
{Help_Make_Basket_01: -> Help_Make_Basket_02}
{Dona_Cicera_Day_02:
-   1:  -> D01
-   else:   -> Dona_Cicera_Random_Dialog
}

= D01
Luiz: Oi, Dona Cícera! A senhora ta bem? Porque a senhora ta aqui fora?
Dona Cícera: LUIZ! Que bom que ocê apareceu, meu fi!
Dona Cícera: Eu perdi a chave de casa e to trancada pra fora!
Dona Cícera: Acontece que nessa idade é complicado procurar uma coisinha tão pequena.
*   [Ajudar]
    Luiz: Eu posso procurar a chave pra senhora!
    Dona Cícera: Oh, fi, ocê é uma benção!
    Dona Cícera: O problema é que não faço ideia de onde ela possa estar!
    Dona Cícera: Andei o vilarejo inteiro pela manhã.
    Luiz: Não se preocupa, Dona Cícera!
    Luiz: Vou encontrar a chave e já trago pra senhora!
    -> DONE
*   [Não ajudar]
    Luiz: Que pena, Dona Cícera!
    Luiz: Eu queria saber se a senhora ia querer ajuda pra fazer as cestas de bambu seco.
    Dona Cícera: Vou querer sim!
    Dona Cícera: No fim de semana eu vou tentar vender as cestas naquele vilarejo aqui ao norte.
    Dona Cícera: Volta mais tarde que provavelmente á vou ter achado a chave.
    Luiz: Ta bom. Obrigado, Dona Cícera!
    ~ ciceraFoundKey = true
    -> DONE

= Help_Make_Basket_01
Dona Cícera: Aaah, ocê veio me ajudar com as cestas, né fi? Vem cá.
~ ciceraFoundKey = false
~ PlayCutscene(9)
-> DONE

= Help_Make_Basket_02
{Help_Make_Basket_02 > 1: -> Dona_Cicera_Random_Dialog}
~ PauseTimeline()
Dona Cícera: E a sua família, como que ta?
Luiz: Meus irmãos tão bem, mas a mãe hoje tava tossindo demais da conta!
Luiz: To mei preocupado com isso.
Dona Cícera: Oh, fi... sabe o que é bom pra tosse? Romã!
Dona Cícera: Seu João tinha comentado que tinha conseguido algumas!
Dona Cícera: Ocê pode pedir a ele!
Luiz: Uai, Dona Cícera! Ele me deu as romãs ontem mesmo!
Luiz: É só dar elas a mainha e ela vai sarar, é?
Dona Cícera: Isso aí, Luizinho! Olha só, já terminamos as cestas!
Dona Cícera: Eu consegui esses pães ontem com um mercador!
Dona Cícera: Ocê aceita eles por ter me ajudado?
Luiz: Aceito sim, Dona Cícera! Muito obrigada!
Dona Cícera: Eu que agradeço, Luiz!
~ ResumeTimeline()
{Seu_Joao_Day_02.D01: -> Getting_Dark}
-> DONE

= Found_Key
{Help_Make_Basket_01: -> Dona_Cicera_Random_Dialog}
Luiz: Tá aqui a chave, Dona Cícera!
Dona Cícera: Obrigada, Luizinho! Ocê salvou meu dia!
Luiz: Fico feliz, Dona Cícera!
Luiz: Aliás, eu queria saber se a senhora vai querer ajuda pra fazer as cestas de bambu seco.
Dona Cícera: Se ocê puder eu aceito sim! Vamo entrar.
~ lostKey = false
~ PlayCutscene(8)
-> DONE

== Dona_Cicera_Random_Dialog
{ shuffle once:

-   Dona Cícera: O meu marido partiu fazem uns anos e meus fi foram tudo pra cidade. Não voltaram mais nem pra me ve... Aí eu fiquei sozinha. Mas as suas visitas com seus irmão sempre me alegram!
    ->DONE
-   Dona Cícera: Quando eu e a Cida éramos jovens, a gente dizia que queria mudar lá pra cidade. A vida aqui sempre foi difícil... As vezes, parece que ninguém enxerga o nosso vilarejo...
    ->DONE
-   Dona Cícera: Eu queria ter sido atriz. Queria atuar em alguma peça, num daqueles lugares chiques lá. Como que fala? Teatro né, Luizinho? O teatro.
    ->DONE
-   Dona Cícera: Espero que chova logo. Quando der pra plantar de novo, eu vou plantar algumas frutas pra gente!
    ->DONE
}
