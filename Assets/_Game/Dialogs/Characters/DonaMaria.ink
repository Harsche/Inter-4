=== DONA_MARIA ===
{GameDay:
-   1:  -> Dona_Maria_Day_01
-   2:  -> Dona_Maria_Day_02
-   3:  -> Dona_Maria_Day_03
-   4:  -> Dona_Maria_Day_04
-   5:  -> Dona_Maria_Day_05
}

=== Dona_Maria_Day_01 ===
{At_Night: -> At_Night_02 }
{Getting_Dark == 1: -> At_Night}
-> DONE

= At_Night
~ PauseTimeline()
Dona Maria: Aqui seu pratin, meu fi.
JOGO: Tem um pouco do feijão que sobrou de ontem com farinha de milho no prato.
~ ResumeTimeline()
-> DONE

= At_Night_02
~ PauseTimeline()
JOGO: Mamãe pega um prato. Há apenas farinha.
Luisa: Mainha, a senhora não vai comer feijão?
Dona Maria: A mainha não quer não, meu bem.
~ ResumeTimeline()
~ GameDay = 2
~ ChangeGameDay(GameDay)
~ ChangeDayTime(DAY)
->DONE

=== Dona_Maria_Day_02 ===
{Getting_Dark == 2: -> At_Night}
{milkDay2 == false && D03: -> Milk_Day_02}
{Dona_Maria_Day_02:
-   1:  -> D01
-   2:  -> D02
-   3:  -> D03
-   else:  -> DONE
}

= D01
~ PauseTimeline()
Dona Maria: Oh, Luiz, meu fi. Vamo lá busca a água, a gente precisa guarda tudo que puder.
~ newQuest("Siga a mamãe")
~ ResumeTimeline()
->DONE

= D02
~ PauseTimeline()
Luiz: Mainha, a ag-
Dona Maria: Vem, Luizinho, num se preocupa. A mainha vai dar um jeito, ta bem?
Luiz: Ta bem, mãe.
~ ResumeTimeline()
-> DONE

= D03
~ PauseTimeline()
Dona Maria: To me sentindo um tanto estranha, vamo pra casa. 
Luiz: Ta bom.
~ ResumeTimeline()
-> DONE

= Milk_Day_02
{not Cow_Day_02.D01:
Dona Maria: Ô, meu fi. Pode tirá um poco de leite da Dondoca e trazê pra mim?
~ newQuest("Ordenhe a Dondoca")
-> DONE
}
Dona Maria: Pronto, meu fi, pode ir faze suas coisa. Só não vai longe, tá?
Luiz: Sim, senhora!
~ newQuest("Vá falar com Dona Cícera")
~ newQuest("Vá falar com Seu João")
~ milkDay2 = true
~ SetPlayerAnimatorBool(PLAYERBUCKET, false)
~ SetPlayerAnimatorBool(PLAYERMLIK, false)
~ ChooseCutscene(0)
->DONE

= At_Night
{At_Night > 1: -> At_Night_02}
~ PauseTimeline()
Dona Maria: Oh, fi! Você voltou tarde!
Dona Maria: Eu acabei caindo no sono, por isso não te chamei!
Dona Maria: Os seus irmãos já comeram, mas eu deixei separado o seu pratinho!
Luiz: Mainha, ontem eu consegui umas romãs com Seu João.
Luiz: Dona Cícera disse que elas ajudam na tosse. Come elas, mãe!
Dona Maria: Come elas com seus irmão, meu fi! A mãe ta bem.
Luiz: Eu tenho duas. A senhora come uma e eu divido a outra com eles.
Dona Maria: Então ta bom! Muito obrigada, fi.
~ ResumeTimeline()
-> DONE

= At_Night_02
~ PauseTimeline()
JOGO: Há um prato de feijão e farinha. A panela de feijão está vazia.
JOGO: Temos apenas farinha a partir de agora...
~ GameDay = 3
~ ChangeGameDay(GameDay)
~ ChangeDayTime(DAY)
~ ResumeTimeline()
-> DONE

=== Dona_Maria_Day_03 ===
{Getting_Dark == 3:
{At_Night: -> At_Night_02}
-> At_Night
}
{Dona_Maria_Day_03:
-   1:  ->D01
-   2:  ->D02
-   else:  -> DONE
}

= D01
~ PauseTimeline()
Luiz: Mainha? Senhora ta bem?
Dona Maria: Oh, Luizinho, to sim... só to me sentindo mei fraca.
~ ResumeTimeline()
-> DONE

= D02
~ PauseTimeline()
JOGO: A testa dela está quente...
Luiz: Mainha, a senhora ta com febre...
Dona Maria: Não se preocupa, meu bem. Logo a mainha melhora!
Dona Maria: Eu to é com uma dor de cabeça daquelas...
Dona Maria: Fala com Seu Miguel pra mim, pergunta de algum remédio.
Luiz: Podeixa, mainha!
~ newQuest("Vá ajudar Seu Zé")
~ newQuest("Vá falar com Seu Miguel")
~ ResumeTimeline()
-> DONE

= At_Night
Luiz: Mainha?
Dona Maria: Luiz? É ocê, meu filho?
Luiz: Sou eu sim, mainha. Eu to aqui...
Luiz: Eu falei com Seu Miguel, ele mandou esse chá de Capim Santo pra senhora.
Dona Maria: Obrigada, meu fi. Hoje, a gente só tem um pouco de farinha.
Dona Maria: Mas a mainha deixou seu pratinho separado ali na pia...
~ PlayCutscene(23)
-> DONE

= At_Night_02
~ PauseTimeline()
Pedro: Mainha... a gente não tem mais feijão?
Dona Maria: Acabou ontem, meu fi... mainha vai conseguir mais assim que ficar melhor.
Dona Maria: A mãe promete, tá?
~ GameDay = 4
~ ChangeGameDay(GameDay)
~ ChangeDayTime(DAY)
~ ResumeTimeline()
->DONE

=== Dona_Maria_Day_04 ===
{Give_Food: -> Give_Food}
{Getting_Dark == 4: -> At_Night}
{Dona_Maria_Day_04: -> DONE}
-> DONE

= At_Night
{At_Night == 2: -> At_Night_02}
~ PauseTimeline()
Luiz: Já voltei!
Dona Maria: Oi fi...
JOGO: A voz dela parece mais fraca do que estava hoje cedo...
Luiz: Eu falei com Seu Zé, e amanhã vamos te levar pra cidade. Ocê vai no médico!
Dona Maria: Sinto muito por estar dando esse trabalhp, fi.
Dona Maria: Ocê... já é mesmo um homenzinho... O meu Luizinho ta crescido. Obrigada.
Luiz: Não agradeça não, mainha! A senhora faz muito mais pela gente!
Luisa: Mainha, eu to com fome...
João: Eu também...
JOGO: A farinha acabou ontem. Não há nada no armário.
Dona Maria: Eu... eu não tenho -
Luiz: Eu tenho uns pães e umas macaxeiras!
Luiz: Consegui fazendo uns trabalhinhos! Venham cá que eu vou dividir!
~ ResumeTimeline()
~ PlayCutscene(30)
-> DONE
    
= At_Night_02
~ PauseTimeline()
JOGO: Caramelo parece estar com fome.
*   [Dar um pouco]
    -> Give_Food
*   [Há pouca comida]
    -> Dont_Give_Food
    
= Give_Food
{Give_Food:

    -   1:
    ~ ChooseCutscene(0)
    Luiz: Logo, vamo te mais do que isso, ta Caramelo?
    ~ ResumeTimeline()
    -> DONE
    
    -   2:
    ~ PauseTimeline()
    Luiz: Olha, Caramelo, mesmo que eu leve mainha ao médico amanhã...
    Luiz: Não sei como arranjar mais comida... 
    Luiz: Que Deus nos ajude.
    ~ GameDay = 5
    ~ ChangeGameDay(GameDay)
    ~ ChangeDayTime(DAY)
    ~ ResumeTimeline()
    -> DONE
}

= Dont_Give_Food
    ~ ChooseCutscene(1)
    ~ PauseTimeline()
    ~ GameDay = 5
    ~ ChangeGameDay(GameDay)
    ~ ChangeDayTime(DAY)
    ~ ResumeTimeline()
    ->DONE
    
=== Dona_Maria_Day_05 ===
{Dona_Maria_Day_04:
-   1:  -> D01
-   2:  -> D02
-   3:  -> D03
-   else:  -> DONE
}

= D01
Dona Maria: LUIIIIIIZ! Entre pra jantar, meu fi!
~ SetCutscenePlayable("35")
-> D02

= D02
~ PauseTimeline()
Dona Maria: Já servi seu pratinho, meu filho!
JOGO: O prato com arroz e feijão é colorido por legumes e carne! O cheiro é ótimo!
Luiz: Obrigada, mainha!
~ ResumeTimeline()
-> DONE

= D03
~ PauseTimeline()
Dona Maria: Ainda bem que aquele pessoal da ONG apareceu, né fi?
Luiz: É sim, mainha!
Luiz: Nem dá pra acreditar que ainda existem pessoas tão boas!
Luiz: A ponto de doarem pra esses projetos só pra ajudar a gente...
Luiz: Sem nem conhecer a gente!
Dona Maria: É, Luizinho, é uma corrente do bem!
Dona Maria: Assim como a nossa relação com nossos vizinhos!
Dona Maria: Um ajuda o outro, e assim vamos vivendo...
~ ResumeTimeline()
-> DONE