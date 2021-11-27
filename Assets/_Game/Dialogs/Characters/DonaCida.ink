=== DONA_CIDA ===
{GameDay:
-   1:  -> Dona_Cida_Day_01
-   3:  -> Dona_Cida_Day_03
-   4:  -> Dona_Cida_Day_04
}


=== Dona_Cida_Day_01 ===
{Dona_Cida_Day_01:
-   1:  -> D01
-   else:   -> Random_Dialog
}

= D01
~ PauseTimeline()
Dona Cida: Bom dia, meu fi.
Luiz: Bom dia, dona Cida! O Junior ta? Queria chama ele pra joga bola, se a senhora deixa!
Dona Cida: Oh fi, num ta não. Junior saiu agora de pouco com o pai dele.
Dona Cida: Foram vende uns ovos das nossas galinha num vilarejo aqui de perto.
Dona Cida: Eles vão passar uns dias lá... Ocê quer entrar toma um café?
*   [Entrar]
    ~ ChooseCutscene(0)
    ~ CloseDialog()
    Dona Cida: Como que ta a sua mãe e seus irmãozinhos, ein Luiz?
    Luiz: Eles tão bem, Dona Cida. Só minha mãe que ultimamente parece meio abatida...
    Dona Cida: Como assim, fi?
    Luiz: Ah, Dona Cida, eu num sei explica. Ela parece meio... cansada, meio fraca.
    Dona Cida: Essa seca ta castigando todo mundo. Sua mãe deve ta preocupada, é só isso.
    Dona Cida: Se Deus quiser, logo a chuva vem!
    Luiz: Brigada, Dona Cida! Eu já vou indo! Fique com Deus.
    Dona Cida: Vá com Deus, Luiz!
    ~ ResumeTimeline()
    {Seu_Joao_Day_01.Chopped_Wood: -> LUIZ}
    ->DONE
*   [Melhor não]
    ~ ChooseCutscene(1)
    ~ PauseTimeline()
    Luiz: Não se incomode não, Dona Cida! Eu passo aqui outra hora!
    Dona Cida: Ta bom, Luizinho!
    ~ ResumeTimeline()
    {Seu_Joao_Day_01.Chopped_Wood: -> LUIZ}
    ->DONE
    
= Random_Dialog

{ shuffle once:

-    Dona Cida: Eu fico feliz por você e o Junior serem amigos. Tenho um carinho pelo cê como se ocê fosse meu neto, Luizinho!
    ->DONE
-    Dona Cida: Sabe um coisa que eu tenho saudade? Do cheiro da terra molhada, o cheiro da chuva... Sim, é um cheiro único.
    ->DONE
-    Dona Cida: Logo logo vai chover, meu fi. Eu tenho fé, eu oro todos os dias por isso!
    ->DONE
-    Dona Cida: Espero que o Junior e o meu fi voltem logo pra casa, que consigam vender tudo que levaram. Se for assim, eu posso até ajudar ocê e a sua mãe, Luiz!
    ->DONE
}

= D02
->DONE

=== Dona_Cida_Day_03 ===
{Dona_Cida_Day_03:
-   1:  -> D01
-   else:   -> Random_Dialog
}

= D01
~ PauseTimeline()
Dona Cida: Boa noite, Luiz! O que que cê ta fazendo aqui fora uma hora dessa?
Dona Cida: Entra, meu fi!
Luiz: Boa noite, Dona Cida! Vou entrar sim!
Dona Cida: E então, Luizinho, como estão as coisas?
Luiz: Ah, Dona Cida, a minha mãe anda meio adoentada...
Luiz: Com dores, febre, cada dia algo novo aparece.
Dona Cida: Oh, fi, porque ocê não me disse antes?
Dona Cida: Se aparecer algum novo sintoma, passa aqui que a gente da um jeito, ta?
Luiz: Eu passo sim, Dona Cida! Que Deus lhe pague!
Dona Cida: Que tal ouvir uma história pra distrair um pouco a cabeça?
Dona Cida: Quando eu era criança, contavam várias lendas aqui do sertão, eu adorava!
*   [Quero ouvir]
    Dona Cida: Há muitos anos, uma tia minha sempre nos falava sobre a Cuca...
    Dona Cida: A Cuca, pelo que dizem, é uma bruxa com uma aparência terrível.
    Dona Cida: Sua cabeça é de jacaré e as unha são longas.
    Dona Cida: Dizem que quem ouve sua voz se arrepia inteiro.
    Dona Cida: A Bruxa Cuca sequestra crianças desobedientes.
    Dona Cida: Só Deus sabe o que ela faz com elas!
    Luiz: Nossa, me arrepiei todin, Dona Cida!
    Dona Cida: Pois é, Luiz. Falam ainda que ela só dorme uma vez a cada 7 anos!
    Luiz: Não é que eu tenha medo dessas histórias...
    Luiz: Mas o vilarejo a noite já é meio assustador.
    Dona Cida: Não fique assim, Luiz! São só histórias que o povo conta.
    Dona Cida: Mas é bom não arriscar, né fi?
    Luiz: É... e falando nisso de arriscar, eu acho que já vou pra casa.
    Dona Cida: Isso! Vá lá ver sua mãe. Boa noite, fi.
    Luiz: Boa noite, Dona Cida!
    ~ ResumeTimeline()
    -> DONE
*   [Não tenho tempo]
    Luiz: Obrigado, Dona Cida, mas eu preciso ir pra casa!
    Dona Cida: Ah, fi. Tudo bem! Vá com Deus. E não se preocupe, tá?
    Luiz: Amém!
    ~ ResumeTimeline()
    -> DONE

= Random_Dialog
-> DONE

=== Dona_Cida_Day_04 ===
{Dona_Cida_Day_04:
-   1:  -> D01
-   2:  -> D02
-   else:   -> Random_Dialog
}

= D01
~ PauseTimeline()
Dona Cida: Opa, Luiz. Como sua mãe ta, fi?
Luiz: Ela piorou, Dona Cida...
Dona Cida: Vem, fi.
~ ResumeTimeline()
-> D02

= D02
Dona Cida: O que ela tá sentindo?
Luiz: Os sintomas de antes não passaram, e agora ela ta tendo calafrio!
Luiz: E dor de barriga também.
Dona Cida: Um chá de boldo ajuda no calafrio, e um chá de mastruz na dor de barriga.
Dona Cida: O difícil é achar isso por aqui, no mei dessa seca ingrata.
Dona Cida: O melhor seria levar sua mãe no médico...
Luiz: O Seu Miguel disse o mesmo, mas eu não tenho como levar ela!
Luiz: Mainha ta fraca, não vai conseguir ir andando, e tem os meus irmãos...
Luiz: O Seu Zé ficou de trazer hoje um capim santo pra ajudar na febre.
Dona Cida: Luiz, o Zé tem uma carroça!
Dona Cida: Talvez ele possa levar sua mãe pra ver um médico!
Luiz: Uai, Dona Cida, não tinha pensado nisso! Mas ainda tem os meus irmãos.
Dona Cida: Oh, fi, eu fico aqui com eles! Não se preocupe com isso não!
Luiz: Nossa, Dona Cida, que Deus lhe pague!
Dona Cida: A senhora é um anjo! Vou ir ver se Seu Zé já voltou!
Dona Cida: Vá lá, meu fi!
~ newQuest("Vá falar com Seu Zé")
-> D03

= D03
~ PauseTimeline()
Luiz: Eita! DONA CIDA, AS GALINHA DA SENHORA TÃO TUDO SOLTA AQUI!
Dona Cida: Oh meu Deus! Elas escaparam!
Luiz: Eu vou pegar elas pra senhora.
Dona Cida: É muito dificil pegar galinha, Luiz. São ligeiras demais.
Luiz: Então eu vou tentar só tocar elas pra dentro do cercado de novo.
JOGO: (Minigame de pegar as galinhas)
~ newQuest("Coloque as galinhas no galinheiro")
~ ResumeTimeline()
-> Returned_Chickens

= Returned_Chickens
Dona Cida: Obrigada, Luizinho! Essas galinhas são importante demais aqui pra casa.
Luiz: Imagina, Dona Cida!
Luiz: O Junior já me disse que cês vivem de vender os ovin delas...
Dona Cida: Pois é, fi. Muito obrigada mesmo!
Luiz: Disponha!
-> DONE

= Random_Dialog
-> DONE

