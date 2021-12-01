=== SEU_JOSE ===
{GameDay:
-   1:  -> Seu_Jose_Day_01
-   3:  -> Seu_Jose_Day_03
}

=== Seu_Jose_Day_01 ===
{Seu_Jose_Day_01:
-   1:  -> Seu_Jose_Random_Dialog
-   else:   -> Seu_Jose_Random_Dialog
}

=== Seu_Jose_Day_03 ===
{Seu_Jose_Day_03:
-   1:  -> D01
-   2:  -> D02
-   3:  -> D03
-   4:  -> After_Cutscene
-   else:   -> Seu_Jose_Random_Dialog
}

= D01
~ PauseTimeline()
Luiz: Opa, Seu Zé! Ta bão?
Seu José: Aoooo, Luizinho! Eu to bão, e ocê?
Luiz: To bão, uai!
Seu José: Vamo lá, Luiz! Ocê pega as coisas mais leves e vai colocando na carroça.
Seu José: Eu vou buscar as coisas mais pesadas.
Luiz: Podeixa, Seu Zé!
~ ResumeTimeline()
~ PlayCutscene(15)
-> DONE

= D02
~ PauseTimeline()
Dona Helena: Oooopa, Luiz!
Luiz: Opa, Dona Helena!
Dona Helena: Oh fi, tava pensando... e hoje eu não vi sua mãe!
Dona Helena: Ela ta bem? Ela sempre passa aqui e me cumprimenta!
Luiz: Ah, ela ta meio mal desde ontem... Hoje nem saiu da cama.
Luiz: Eu acho que ela tava com febre, Dona Helena.
Dona Helena: Oh, meu Deus! Zé, ocê acha que consegue um pouco de erva cidreira?
Dona Helena: Ela cura febre que é uma beleza.
Seu José: Olha... tudo que eu tenho conseguido, é na troca, aí fica difícil garantir!
Seu José: Mas eu prometo que se eu conseguir um dinheirinho vendendo algo, eu trago a erva cidreira.
Seu José: Não fique encaducado não, meu fi!
Luiz: Ta bem, seu Zé! Muito obrigado!
~ ResumeTimeline()
-> DONE

= D03
~ PauseTimeline()
Seu José: Bom, terminamo aqui, Luiz! Eu já vou indo!
Seu José: Volto amanhã, se Deus quiser com a erva cidreira pra sua mãe!
Dona Helena: Isso mesmo! E Luiz, fica com essas macaxeiras, por ter ajudado o Zé!
Luiz: Oh, Dona Helena, muito obrigado!
~ RemoveQuest("Vá ajudar Seu Zé")
~ ResumeTimeline()
-> DONE

= After_Cutscene
{Seu_Joao_Day_03.Cow_Died && Seu_Miguel_Day_03.Filled_Water_Box:
-> Getting_Dark
}
-> DONE

== Seu_Jose_Random_Dialog

{ shuffle once:

-   Seu José: Eu conheci a Lena quando a gente tinha 15 anos. Ela veio pra cá morar com a vó dela. Foi amor à primeira vista.
    -> DONE
-   Seu José: Eu e a Lena gostávamos de correr na chuva quando éramos mais jovens. Esses dias eram incríveis.
    -> DONE
-   Seu José: Eu herdei a carroça do meu painho... E o meu jeguin, o Raio, também.
    -> DONE
-   Seu José: Graças a Deus eu ainda consigo vender algumas coisinhas lá na cidade. Até a seca passar, esse tem sido o único jeito de tocar a vida.
    -> DONE
}
