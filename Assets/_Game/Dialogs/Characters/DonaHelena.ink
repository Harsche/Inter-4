=== DONA_HELENA ===
{GameDay:
- 1:    ->Dona_Helena_Day_01
}


=== Dona_Helena_Day_01 ===
{Dona_Helena_Day_01:
-   1:  ->Random_Dialog
-   else:   ->Random_Dialog
}

= Random_Dialog

{ shuffle once:
-   Dona Helena: Eu e o Zé tamo junto já fazem uns 20 anos... Ele me pediu em namoro quando a gente tinha 17 anos!
    ->DONE
-   Dona Helena: Eu vim morar aqui porque eu perdi meus pais quando era jovenzinha. Foi o Zé que me deu esperança de novo.
    ->DONE
-   Dona Helena: Eu e sua mãe costumávamos vender as verduras que plantávamos junta, lá na cidade. Íamos com o Zé. Parece que faz tanto tempo.
    ->DONE
-   Dona Helena: Você tem os olhos da sua mãe. Ela sempre foi muito minha amiga!
    ->DONE
}
