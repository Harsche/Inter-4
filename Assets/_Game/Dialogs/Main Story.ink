EXTERNAL newQuest(questName)
EXTERNAL pauseTimeline()
EXTERNAL resumeTimeline()

->Day_01_Scene_01

== Day_01_Scene_01 ==
~ pauseTimeline()
Dona Maria: Acorda, Luiz. A gente precisa ir busca água na lagoa, se é que ainda tem água lá...
Luiz: Ontem tinha só lama, praticamente. Mas eu tenho esperança, mainha.
Dona Maria: Vamo, meu fi.
~ newQuest("Siga a mamãe")
~ resumeTimeline()
->DONE 


== Day_01_Scene_02 ==
~ pauseTimeline()
Dona Maria: Se apresse, Luiz. A gente precisa pega água logo, antes que o poco que tem se evapore, meu fi.
->DONE

== Day_01_Scene_03 ==
Dona Maria: Bom, talvez se a gente passa a água numa camiseta, de pra tira a terra. Aí a gente ferve e já ta ótimo.
Dona Maria: ...
Luiz: Mainha, a senhora ta chorando?
Dona Maria: To não, meu fi. Vamo pa casa, vem.
~ resumeTimeline()
->DONE

== function newQuest(questName)
~ return