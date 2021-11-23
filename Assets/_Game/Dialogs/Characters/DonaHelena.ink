=== DONA_HELENA ===
{GameDay:
-   1:  -> Dona_Helena_Day_01
-   2:  -> Dona_Helena_Day_02
-   3:  -> Dona_Helena_Day_03
-   4:  -> Dona_Helena_Day_04
}


=== Dona_Helena_Day_01 ===
{Dona_Helena_Day_01:
-   1:  -> Random_Dialog
-   else:   -> Random_Dialog
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

=== Dona_Helena_Day_02 ===
{Dona_Helena_Day_02:
-   1:  -> Random_Dialog
-   else:   -> Random_Dialog
}

= At_Night
Dona Helena: Boa noite, Luizinho! Precisava mesmo falar com você!
Dona Helena: Quer entrar?
Luiz: Boa noite, Dona Helena! Quero sim!
Seu José: Aoooo, Luiz!
Luiz: Boa noite, Seu Zé!
Dona Helena: Luiz, o que eu ia te falar era que o Zé precisa de ajuda.
Dona Helena: Ele precisa carregar a carroça pra levar mercadoria pra cidade!
Dona Helena: A gente queria saber se ocê num que o serviço.
Luiz: Eu aceito sim!
Dona Helena: Que bom, Luiz! Venha aqui amanhã cedo que vamos estar te esperando!
Luiz: Podeixar, Dona Helena! Bom, então eu já vou indo!
Seu José: Luiz, vá direto pra casa, viu?
Luiz: Uai, Seu Zé, por que?
Seu José: Luiz, Luiz! Você nunca ouviu falar da Cabra Cabriola não?
Luiz: Ouvi não!
Seu José: A Cabra Cabriola é um ser metade cabra, metade monstro.
Seu José: Ela tem uns dente afiado e fede que só!
Seu José: Ela se alimenta de gente que ela acha andando por aí a noite e de criança mal educada também!
Seu José: Se bobear, entra até nas casa pra pegar menino desobediente!
Seu José: Então não fique se aventurando pela rua a noite, rapaz!
Dona Helena: José! Para de assustar o menino!
Luiz: Valha meu Deus! Eu vou pra casa sim, Seu Zé! Até amanhã!
Dona Helena: Não fique com medo não, Luiz! Boa noite!
-> DONE

= Random_Dialog
-> DONE

=== Dona_Helena_Day_03 ===
{Dona_Helena_Day_03:
-   1:  -> D01
-   else:   -> Random_Dialog
}

= D01

-> DONE
Dona Helena: Luiz! Bom dia, como ocê tá?
Luiz: Oi, Dona Helena! Eu to bem, e a senhora?
Dona Helena: To bem, fi.
Dona Helena: Viu, vim te pergunta se ocê pode ajudar o Zé a encher a carroça pra levar pra cidade!
Dona Helena: Tem bastante coisa e ele não queria demorar a partir!
Luiz: Ajudo sim, Dona Helena, vamos lá!

= Random_Dialog
-> DONE

=== Dona_Helena_Day_04 ===
{Dona_Helena_Day_04:
-   1:  -> D01
-   2:  -> D02
-   3:  -> D03
-   else:   -> Random_Dialog
}

= D01
Dona Helena: Oi, Luiz!
Luiz: Opa, Dona Helena! Vim ver se Seu Zé já voltou! Preciso demais falar com ele!
Dona Helena: Luiz, ele ainda não chegou, mas deve chegar logo. Entra pra esperar, fi.
-> D02

= D02
Dona Helena: E sua mãe, Luiz?
Luiz: Piorou, Dona Helena...
Dona Helena: Meu Deus... Eu sinto muito.
Luiz: Eu to com medo, Dona Helena. E se...
Dona Helena: Não fique com medo não, meu bem. Logo as coisas vão se ajeitar! Eu tenho fé.
-> DONE

= D03
Seu José: Cheguei! Opaaa, Luiz! Eu consegui! Eu trouxe a Erva Cidreira!
Luiz: Seu Zé! Muito obrigado, mas eu precisava te pedir mais uma coisa!
Seu José: Uai, fi, pode falar!
Luiz: O senhor poderia, por favor, levar eu e minha mãe até a cidade?
Luiz: Eu quero levar ela até um médico... mas acho que ela não aguenta ir caminhando.
Luiz: Eu prometo que dou um jeito de pagar o senhor!
Luiz: Trabalho sempre com a carroça, faço o que for preciso!
Seu José: É claro que eu levo, Luizinho! E não precisa me pagar não, meu fi.
Seu José: Vocês aqui do vilarejo são como família pra eu e pra Lena!
Seu José: Eu fico é feliz por ter condição de poder te ajudar.
Luiz: Seu Zé... Muito obrigado! Muito obrigado mesmo.
Luiz: Eu nem sei o que dizer!
Seu José: Não precisa dizer nada não, fi.
Seu José: Vamos precisar sair amanhã cedo, porque hoje já tá tarde, okay?
Seu José: Fique prontinho com sua mãe, que passo lá na sua casa pra te ajudar com ela!
Luiz: Tudo bem, seu Zé! Eu vou ir ajeitar as coisas pra amanhã!
-> Getting_Dark

= Random_Dialog
-> DONE