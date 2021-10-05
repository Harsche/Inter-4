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
Dona Maria: To não, meu fi. Vamo pa casa tirar leite da vaquinha para dá aos seus irmão.
~ resumeTimeline()
->DONE

== Day_01_Scene_04 ==

= Dona_Maria
{ not Day_01_Scene_04.Cow:
Dona Maria: Ô, meu bem. Pode tirá um poco de leite da Dondoca e trazê pra mim prepará o café da manhã?
}

{ Day_01_Scene_04.Cow:
Dona Maria: Pronto, meu fi, pode ir faze suas coisa. Só não vai longe, tá?
Luiz: Sim, senhora!
}
->DONE

= Cow
~ pauseTimeline()
Luiz: Bom dia, Dondoca! Ocê parece que ta mais magrinha do que ontem... mas vai ficar tudo bem, né Dondoca?
Dondoca: MUUUUUU!!
~ resumeTimeline()
->DONE

== function newQuest(questName)
~ return