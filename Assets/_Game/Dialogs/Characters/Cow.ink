=== COW ===
{GameDay:
-   1:  -> Cow_Day_01
-   2:  -> Cow_Day_02
-   3:  -> Cow_Day_03
}

=== Cow_Day_01 ===
{Cow_Day_01:
-   1:  -> D01
}

= D01
->DONE

=== Cow_Day_02 ===
{Cow_Day_02:
-   1:  -> D01
-   else:  -> DONE
}

= D01
Luiz: Opa, Dondoca!
Luiz: Hoje deu pouco leite como nunca tinha dado. Ocê ta bem?
Dondoca: ...
->DONE

=== Cow_Day_03 ===
{Cow_Day_03:
-   1:  -> D01
-   else:  -> DONE
}

= D01
Luiz: Dondoca? Dondoquinha?
JOGO: Dondoca não se move.
Luiz: Dondoca, porque ocê ta aí deitada?
-> DONE

