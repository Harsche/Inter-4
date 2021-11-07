=== PEDRO ===
{GameDay:
- 1:    ->Pedro_Day_01
}
=== Pedro_Day_01 ===
{Pedro_Day_01:
-   1:  ->Random_Dialog
-   else:   ->Random_Dialog
}

= Random_Dialog

{ shuffle once:

-   Pedro: Luiz, eu já sou crescido! Você pode me pedir ajuda se precisa! Eu já posso trabalhar também!
    ->DONE
-   Pedro: Lembra quando chovia e a gente voltava chei de barro pra casa? A mãe ficava brava, mas depois dava risada!
    ->DONE
-   Pedro: Um dia, quero ir na cidade e trazer presentes bem legais pra vocês! Tipo uma bola nova, ou chocolate! Ah, e uma bonequinha pra Luisa!
    ->DONE
-   Pedro: A Dona Cida sempre cuida da gente, ela lembra a vovó. Sinto falta dela.
    ->DONE
}