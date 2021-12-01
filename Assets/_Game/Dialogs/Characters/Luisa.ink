=== LUISA ===
{GameDay:
- 1:    ->Luisa_Day_01
- 2:    ->Luisa_Day_01
- 3:    ->Luisa_Day_01
- 4:    ->Luisa_Day_04
- 5:    ->Luisa_Day_01
}


=== Luisa_Day_01 ===
{Luisa_Day_01:
-   1:  -> Luisa_Random_Dialog
-   else:   -> Luisa_Random_Dialog
}

=== Luisa_Day_04 ===
{Luisa_Day_04:
-   1:  -> D01
-   else:   -> Luisa_Random_Dialog
}

= D01
Luiz: Luisa, cade a mainha?
Luisa: Ela foi no banheiro... foi várias vezes. A mainha ta doente, Luiz?
Luiz: Ela só não ta muito bem, mas não se preocupa, tá?
Luiz: Eu vou cuidar da mamãe e de vocês também!
João: Ela tava toda se tremendo, com calafrio...
Luiz: Dona Cida disse que ia me ajudar se a mamãe piorasse.
{Dona_Cida_Day_04.D02:
Luiz: Sim, fui falá com ela agorinha mesmo.
-> DONE
}
Luiz: Eu vou lá na casa dela!
~ newQuest("Vá falar com a Dona Cida")
-> DONE

== Luisa_Random_Dialog
{ shuffle once:

-   Luisa: Luiz, a mamãe é bem forte, né?
    ->DONE
-   Luisa: Quando eu crescer, quero ser igual a mamãe!
    ->DONE
-   Luisa: Eu quero ser professora! Quando eu ia pra escolinha, a professora era tão esperta e gentil!
    ->DONE
-   Luisa: O Caramelo é o melhor cachorro do mundo!
    ->DONE
}