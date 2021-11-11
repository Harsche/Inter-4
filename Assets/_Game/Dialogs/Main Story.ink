VAR GameDay = 1
VAR lostKey = false
VAR filledWaterBox = false
// House 1 = Luiz
// House 2 = Seu João
// House 3 = Dona Cícera
// House 4 = Seu Miguel
// House 5 = Dona Cida
// House 6 = Dona Helena / Seu José

EXTERNAL newQuest(questName)
EXTERNAL PauseTimeline()
EXTERNAL ResumeTimeline()
EXTERNAL PlayCutscene(cutsceneNum)
EXTERNAL ChooseCutscene(choiceIndex)
EXTERNAL CloseDialog()
EXTERNAL Debug(value)
EXTERNAL ChangeGameDay(GameDay)

INCLUDE Characters\Luiz.ink
INCLUDE Characters\DonaCida.ink
INCLUDE Characters\SeuJoao.ink
INCLUDE Characters\DonaCicera.ink
INCLUDE Characters\DonaHelena.ink
INCLUDE Characters\Joao.ink
INCLUDE Characters\Luisa.ink
INCLUDE Characters\Pedro.ink
INCLUDE Characters\SeuJose.ink
INCLUDE Characters\SeuMiguel.ink
INCLUDE Characters\DonaMaria.ink
INCLUDE Characters\Cow.ink
INCLUDE Characters\Livia.ink
INCLUDE Characters\Medico.ink

== Day_01_Scene_01 ==
~ PauseTimeline()
Dona Maria: Acorda, Luiz. A gente precisa ir busca água na lagoa, se é que ainda tem água lá...
Luiz: Onte tinha só lama, praticamente. Ma eu tenho esperança, mainha.
Dona Maria: Vamo, meu fi.
~ newQuest("Siga a mamãe")
~ ResumeTimeline()
->DONE 

== Day_01_Scene_02 ==
~ PauseTimeline()
Dona Maria: Se apresse, Luiz. A gente precisa pega água logo, antes que o poco que tem se evapore, meu fi.
->DONE

== Day_01_Scene_03 ==
~ PauseTimeline()
Dona Maria: Bom, talvez se a gente passa a água numa camiseta, de pra tira a terra.
Dona Maria: Aí a gente ferve e já ta ótimo.
Dona Maria: ...
Luiz: Mainha, a senhora ta chorando?
Dona Maria: To não, meu fi. Vamo pa casa, vem.
~ ResumeTimeline()
->DONE

== Day_01_Scene_04 ==
= Dona_Maria
{ not Day_01_Scene_04.Cow:
Dona Maria: Ô, meu bem. Pode tirá um poco de leite da Dondoca e trazê pra mim prepará o café da manhã?
-> DONE
- else:
Dona Maria: Pronto, meu fi, pode ir faze suas coisa. Só não vai longe, tá?
Luiz: Sim, senhora!
~ PlayCutscene(4)
-> DONE
}

= Cow
~ PauseTimeline()
Luiz: Bom dia, Dondoca! Ocê parece que ta mais magrinha do que ontem...
Luiz: Mas vai ficar tudo bem, né Dondoca?
Dondoca: MUUUUUU!!
~ ResumeTimeline()
->DONE


=== Other_Dialogs

= No_One_Home
Luiz: Ninguém responde. Eles devem ter saído!
->DONE
 
=== Luiz ===
-> LUIZ

=== Dona_Cida ===
-> DONA_CIDA

=== Seu_Joao ===
-> SEU_JOAO

=== Dona_Cicera ===
-> DONA_CICERA

=== Dona_Helena ===
-> DONA_HELENA

=== Joao ===
-> JOAO

=== Luisa ===
-> LUISA

=== Pedro ===
-> PEDRO

=== Seu_Jose ===
-> SEU_JOSE

=== Seu_Miguel ===
-> SEU_MIGUEL

=== Livia ===
-> LIVIA

=== Medico ===
-> MEDICO

=== House_01
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
}

=== House_02
{GameDay:
-   1: -> SEU_JOAO
}

=== House_03
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
}

=== House_04
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
}

=== House_05
{GameDay:
-   1: ->DONA_CIDA
}

=== House_06
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
-   2: {Seu_Joao_Day_02.D01: -> Dona_Helena_Day_02.At_Night} -> Other_Dialogs.No_One_Home
}

== function newQuest(questName)
~ return