VAR GameDay = 1

EXTERNAL newQuest(questName)
EXTERNAL PauseTimeline()
EXTERNAL ResumeTimeline()
EXTERNAL PlayCutscene(cutsceneName)
EXTERNAL Debug(value)

INCLUDE Characters\DonaCida.ink
INCLUDE Characters\SeuJoao.ink
INCLUDE Characters\DonaCicera.ink
INCLUDE Characters\DonaHelena.ink
INCLUDE Characters\Joao.ink
INCLUDE Characters\Luisa.ink
INCLUDE Characters\Pedro.ink
INCLUDE Characters\SeuJose.ink
INCLUDE Characters\SeuMiguel.ink

== Day_01_Scene_01 ==
~ PauseTimeline()
Dona Maria: Acorda, Luiz. A gente precisa ir busca água na lagoa, se é que ainda tem água lá...
Luiz: Ontem tinha só lama, praticamente. Mas eu tenho esperança, mainha.
Dona Maria: Vamo, meu fi.
~ newQuest("Siga a mamãe")
~ ResumeTimeline()
->DONE 

== Day_01_Scene_02 ==
~ PauseTimeline()
Dona Maria: Se apresse, Luiz. A gente precisa pega água logo, antes que o poco que tem se evapore, meu fi.
->DONE

== Day_01_Scene_03 ==
Dona Maria: Bom, talvez se a gente passa a água numa camiseta, de pra tira a terra. Aí a gente ferve e já ta ótimo.
Dona Maria: ...
Luiz: Mainha, a senhora ta chorando?
Dona Maria: To não, meu fi. Vamo pa casa tirar leite da vaquinha para dá aos seus irmão.
~ ResumeTimeline()
->DONE

== Day_01_Scene_04 ==

= Dona_Maria
{ not Day_01_Scene_04.Cow:
Dona Maria: Ô, meu bem. Pode tirá um poco de leite da Dondoca e trazê pra mim prepará o café da manhã?

- else: Dona Maria: Pronto, meu fi, pode ir faze suas coisa. Só não vai longe, tá?
Luiz: Sim, senhora!
}
->DONE

= Cow
~ PauseTimeline()
Luiz: Bom dia, Dondoca! Ocê parece que ta mais magrinha do que ontem... mas vai ficar tudo bem, né Dondoca?
Dondoca: MUUUUUU!!
~ ResumeTimeline()
->DONE
    
    
=== Dona_Cida ===
->DONA_CIDA

=== Seu_Joao ===
->SEU_JOAO

=== Dona_Cicera ===
->DONA_CICERA

=== Dona_Helena ===
->DONA_HELENA

=== Joao ===
->JOAO

=== Luisa ===
->LUISA

=== Pedro ===
->PEDRO

=== Seu_Jose ===
->SEU_JOSE

=== Seu_Miguel ===
-> SEU_MIGUEL

== function newQuest(questName)
~ return