VAR GameDay = 1
VAR lostKey = false
VAR filledWaterBox = false
VAR woodChopped = 0
VAR milkDay2 = false
VAR changedDay = false
VAR chopTask = false
VAR waterTask = false
VAR ciceraFoundKey = false

CONST DAY = "Day"
CONST NIGHT = "Night"

CONST PLAYERBUCKET = "Bucket"
CONST PLAYERAXE = "Axe"
CONST PLAYERMLIK = "Milk"

// House 1 = Luiz
// House 2 = Seu João
// House 3 = Dona Cícera
// House 4 = Seu Miguel
// House 5 = Dona Cida
// House 6 = Dona Helena / Seu José

EXTERNAL newQuest(questName)
EXTERNAL PauseTimeline()
EXTERNAL ResumeTimeline()
EXTERNAL SetCutscenePlayable(cutsceneNum)
EXTERNAL PlayCutscene(cutsceneNum)
EXTERNAL ChooseCutscene(choiceIndex)
EXTERNAL CloseDialog()
EXTERNAL Debug(value)
EXTERNAL ChangeGameDay(GameDay)
EXTERNAL ChangeDayTime(Time)
EXTERNAL SetPlayerAnimatorBool(parameter, value)

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
= Dona_Maria_Scene_04
{ not Day_01_Scene_04.Milk_Cow:
Dona Maria: Ô, meu bem, faz favor. Vá tirar um poco de leite da Dondoca.
~ newQuest("Ordenhe a Dondoca")
-> DONE
- else:
Dona Maria: Pronto, meu fi, pode ir faze suas coisa. Só não vai longe, tá?
Luiz: Sim, senhora!
~ newQuest("Vá falar com Dona Cida")
~ newQuest("Vá falar com Seu João")
~ SetPlayerAnimatorBool(PLAYERBUCKET, false)
~ SetPlayerAnimatorBool(PLAYERMLIK, false)
~ ChooseCutscene(0)
-> DONE
}

= Milk_Cow
~ PauseTimeline()
Luiz: Bom dia, Dondoca! Ocê parece que ta mais magrinha do que ontem...
Luiz: Mas vai ficar tudo bem, né Dondoca?
Dondoca: MUUUUUU!!
~ ResumeTimeline()
->DONE


=== Other_Dialogs ===

= No_One_Home
Luiz: Ninguém responde. Eles devem ter saído!
-> DONE

= Need_Axe
Luiz: Preciso do machado para poder cortar lenha.
-> DONE

= Need_Bucket
Luiz: Acho melhor pegar um balde primeiro.
-> DONE

= Door_Locked
Luiz: A porta tá trancada...
-> DONE
 
=== Luiz ===
-> LUIZ

=== Dona_Maria ==
-> DONA_MARIA

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

===  Cow ===
-> COW


=== House_02
{GameDay:
-   1:  ~ PlayCutscene(4)
-   2:  -> Day_02
-   3: {Cow_Day_03: 
            ~ PlayCutscene(20)
            -> DONE
        } -> Other_Dialogs.No_One_Home
-   4: -> Other_Dialogs.No_One_Home
}
-> DONE

= Day_02
{Seu_Joao_Day_02.D01:
Luiz: Acho que não tenho mais como ajudar o Seu João...
-> DONE
}
~ PlayCutscene(10)
-> DONE

=== House_03
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
-   2: -> Other_Dialogs.Door_Locked
-   3: -> Other_Dialogs.No_One_Home
-   4: -> Other_Dialogs.No_One_Home
}

=== House_04
{GameDay:
-   1: -> Other_Dialogs.No_One_Home
-   2: -> Other_Dialogs.No_One_Home
-   3: ~ PlayCutscene(17)
-   4: -> Other_Dialogs.No_One_Home
}
--> DONE

=== House_05
{GameDay:
-   1:  ~ PlayCutscene(3)
        -> DONE
-   2: -> Other_Dialogs.No_One_Home
-   3: {Getting_Dark == 3: 
            ~ PlayCutscene(22)
            -> DONE
        } -> Other_Dialogs.No_One_Home
-   4: -> DONA_CIDA
}


=== House_06
{GameDay:
-   1:  -> Other_Dialogs.No_One_Home
        -> DONE
-   2: {Seu_Joao_Day_02.D01 && Dona_Cicera_Day_02.D01: 
    ~ PlayCutscene(11)
    -> DONE
    } 
    -> Other_Dialogs.No_One_Home
-   3: -> Other_Dialogs.Door_Locked
-   4: {Dona_Cida_Day_04.Returned_Chickens: -> DONA_HELENA } -> Other_Dialogs.No_One_Home
}
-> DONE

// FUNCTION BINDINGS

== function newQuest(questName)
~ return

== function PauseTimeline()
~ return

== function ResumeTimeline()
~ return

== function PlayCutscene(cutsceneNum)
~ return

== function ChooseCutscene(choiceIndex)
~ return

== function CloseDialog()
~ return

== function Debug(value)
~ return

== function ChangeGameDay(day)
~ return

== function ChangeDayTime(time)
~ return

== function SetPlayerAnimatorBool(parameter, value)
~ return