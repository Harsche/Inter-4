=== SEU_MIGUEL ===
{GameDay:
-   1:  -> Seu_Miguel_Day_01
-   3:  -> Seu_Miguel_Day_03
}

=== Seu_Miguel_Day_01 ===
{Seu_Miguel_Day_01:
-   1:  -> Random_Dialog
-   else:   -> Random_Dialog
}

= Random_Dialog

{ shuffle once:

-   Seu Miguel: Meu sonho era ser médico, mas aí eu não consegui. O que eu sei foi aprendendo com o tempo, com as coisas da vida. Eu fico feliz por poder ajudar os outros.
    ->DONE
-   Seu Miguel: Eu gosto demais do som da chuva batendo no telhado. Me traz uma paz. Não sei se é pelo som, ou por saber que vai ter água no dia seguinte.
    ->DONE
-   Seu Miguel: Eu vi a sua mãe crescer, ela sempre foi muito inteligente e simpática. Ocê puxou ela!
    ->DONE
-   Seu Miguel: Eu adoro animais. Quando era novinho, eu tinha um gatinho chamado Faísca, ele era muito animado, tava sempre brincando por aí.
    ->DONE
}

=== Seu_Miguel_Day_03 ===
{Seu_Miguel_Day_03.D02: -> Filled_Water_Box}
//{filledWaterBox: -> Filled_Water_Box}
{Seu_Miguel_Day_03:
-   1:  -> D01
-   2:  -> D02
-   else:   -> Random_Dialog
}

= D01
Luiz: Oooopa, Seu Miguel, ta bem?
Seu Miguel: Aoo, Luiz! To bão, e ocê?
Luiz: Eu to bem, quem não ta é minha mãe!
Seu Miguel: Entendi, fi. Entra, vamo conversar.
-> D02

= D02
Seu Miguel: O que ela ta sentindo, ein?
Luiz: Ela tem tossido muito.
Luiz: Ta com febre e disse que também ta com dor de cabeça...
Luiz: Eu já dei romã a ela, e o Seu Zé disse que vai trazer Erva Cidreira.
Seu Miguel: Olha, Luiz... O que eu posso fazer é um chá de Capim Santo.
Seu Miguel: Vai ajudar na dor de cabeça.
Seu Miguel: A Erva Cidreira, dizem que ajuda mesmo na febre.
Seu Miguel: Mas se ela estiver com alguma doença, isso só vai aliviar sintoma.
Luiz: E o que eu faço, Seu Miguel?
Seu Miguel: Seria bom ela ver um doutô.
Luiz: Mas eu não tenho como levar ela...
Luiz: Só tem médico lá na cidade e é muito longe...
Seu Miguel: A gente vai pensar em algo, ta?
Seu Miguel: Olha, eu preciso de água pra fazer o chá.
Seu Miguel: A pouca água que eu tinha acabou hoje cedo. Vocês ainda tem?
Luiz: Acabou hoje cedo também...
Seu Miguel: Eu vou trocar algumas coisas de casa num vilarejo aqui de perto.
Seu Miguel: Vou tentar conseguir uns galões, mas vai demorar pra eu voltar...
Seu Miguel: Olha, Luiz, tinha um poço aqui por perto, ao leste do vilarejo.
Seu Miguel: Hoje em dia acho que ninguém vai mais lá.
Seu Miguel: Ta todo mundo mei velho pra ficar carregando balde.
Seu Miguel: Mas quem sabe tem água lá! Talvez você possa ir dar uma olhada!
Seu Miguel: Aí você já traz água para o chá da sua mãe!
Luiz: Eu vou agora mesmo, Seu Miguel!
-> DONE

= Filled_Water_Box
Seu Miguel: Luiz, ocê demorou, fiquei preocupado, fi!
Luiz: Eu achei o poço! Aproveitei e enchi a caixa d'água do vilarejo.
Seu Miguel: Não acredito! Que benção, Luizinho.
Seu Miguel: O povo vai ficar feliz demais.
Luiz: Graças a Deus, Seu Miguel!
Seu Miguel: Amém! Vem, Luiz, vou fazer o chá.Amém! Vem, Luiz, vou fazer o chá.
Seu Miguel: Dê o chá pra sua mãe, e se Deus quiser ela vai melhorar!
Luiz: Muito obrigado, Seu Miguel!
-> DONE

= Random_Dialog
-> DONE