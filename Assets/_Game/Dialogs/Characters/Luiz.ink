=== LUIZ ===
{GameDay:
-   1:  -> Luiz_Day_01
-   2:  -> Luiz_Day_02
-   3:  -> Luiz_Day_03
-   4:  -> Luiz_Day_04
}

=== Getting_Dark ===
{GameDay == 4:
Luiz: Já está escurecendo... vou direto pra casa ver mainha!
~ SetCutscenePlayable("30")
~ ChangeDayTime(NIGHT)
-> DONE
}
{GameDay == 3:
~ SetCutscenePlayable("23")
}
{GameDay == 2:
~ SetCutscenePlayable("12")
}
Luiz: Já está escurecendo... é melhor eu ir pra casa!
{GameDay == 1:
Dona Maria: Entra, meu fi! Já ta tarde!
~ SetCutscenePlayable("05")
}
~ ChangeDayTime(NIGHT)
-> DONE

=== Luiz_Day_01 ===
{Luiz_Day_01:
-   1:  -> D01
}

= D01
-> Getting_Dark

=== Luiz_Day_02 ===
{Luiz_Day_02:
-   1:  -> D01
}

= D01
-> Getting_Dark


=== Luiz_Day_03 ===
{Luiz_Day_01:
-   1:  -> D01
-   2:  -> D02
}

= D01
Luiz: É o único balde que eu tenho, vai ser ele mesmo...
-> DONE

= D02
Luiz: TEM ÁGUA! Minha nossa, a mainha ia fica feliz demais de ver isso!
Luiz: Eu vou já levar para a caixa d'água do vilarejo.
Luiz: Acho que uns 5 baldes já dá!
Luiz: Só preciso tomar cuidado porque o balde ta furado...
Luiz: Bom, é o que eu tenho. Vou precisar ser rápido!
~ newQuest("Encha a caixa d'agua do vilarejo")
-> DONE

=== Luiz_Day_04 ===
{Luiz_Day_04:
-   1:  -> D01
}

= D01
Luiz: Luisa, cade a mainha?
Luisa: Ela foi no banheiro... foi várias vezes. A mainha ta doente, Luiz?
Luiz: Ela só não ta muito bem, mas não se preocupa, tá?
Luiz: Eu vou cuidar da mamãe e de vocês também!
João: Ela tava toda se tremendo, com calafrio...
Luiz: Dona Cida disse que ia me ajudar se a mamãe piorasse.
Luiz: Eu vou lá na casa dela!
~ newQuest("Vá falar com Dona Cida")
-> DONE
