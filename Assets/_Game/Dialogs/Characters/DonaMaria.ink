=== DONA_MARIA ===
{GameDay:
-   1:  -> Dona_Maria_Day_01
-   2:  -> Dona_Maria_Day_02
-   3:  -> Dona_Maria_Day_03
}

=== Dona_Maria_Day_01 ===
{Dona_Maria_Day_01:
-   1:  ->D01
}

= D01
Dona Maria: LUIIIIZ! Entra, meu fi! Já ta tarde!
->DONE

=== Dona_Maria_Day_02 ===
{Seu_Joao_Day_02: -> D04} 
{Dona_Maria_Day_02:
-   1:  ->D01
-   2:  ->D01
-   3:  ->D01
}

= D01
Dona Maria: Oh, Luiz, meu fi. Vamo lá busca a água, a gente precisa guarda tudo que puder.
->DONE

= D02
Dona Maria: Vem, fi, vamo pra casa.
Luiz: Mas, mainha, e a ag-
Dona Maria: Vem, Luizinho, num se preocupa. A mainha vai dar um jeito, ta bem?
Luiz: Ta bem, mãe.
->DONE

= D03
Dona Maria: Luiz, eu vou pra casa, to me sentindo um tanto estranha.
Dona Maria: Não se esqueça de tirar o leite pros seus irmão.
Luiz: Podeixa, mainha!
->DONE

= D04
Dona Maria: Oh, fi! Você voltou tarde!
Dona Maria: Eu acabei caindo no sono, por isso não te chamei!
Dona Maria: Os seus irmãos já comeram, mas eu deixei separado o seu pratinho!
Luiz: Mainha, ontem eu consegui umas romãs com Seu João.
Luiz: Dona Cícera disse que elas ajudam na tosse. Come elas, mãe!
Dona Maria: Come elas com seus irmão, meu fi! A mãe ta bem.
Luiz: Eu tenho duas. A senhora come uma e eu divido a outra com eles.
Dona Maria: Então ta bom! Muito obrigada, fi.
JOGO: Há um prato de arroz e farinha. A panela de arroz está vazia.
JOGO: Temos apenas farinha a partir de agora...
~ GameDay = 3
//~ ChangeGameDay(GameDay)
-> DONE

=== Dona_Maria_Day_03 ===
{Getting_Dark == 3: -> At_Night}
{Dona_Maria_Day_03:
-   1:  ->D01
}

= D01
Luiz: Mainha? Senhora ta bem?
Dona Maria: Oh, Luizinho, to sim... só to me sentindo mei fraca.
JOGO: A testa dela está quente...
Luiz: Mainha, a senhora ta com febre...
Dona Maria: Não se preocupa, meu bem. Logo a mainha melhora!
Dona Maria: Eu to é com uma dor de cabeça daquelas...
Dona Maria: Fala com Seu Miguel pra mim, pergunta de algum remédio.
Luiz: Podeixa, mainha!
-> DONE

= At_Night
Luiz: Mainha?
Dona Maria: Luiz? É ocê, meu filho?
Luiz: Sou eu sim, mainha. Eu to aqui...
Luiz: Eu falei com Seu Miguel, ele mandou esse chá de Capim Santo pra senhora.
Dona Maria: Obrigada, meu fi. Hoje, a gente só tem um pouco de farinha.
Dona Maria: Mas a mainha deixou seu pratinho separado ali na pia...
Pedro: Mainha... a gente não tem mais arroz?
Dona Maria: Acabou ontem, meu fi... mainha vai conseguir mais assim que ficar melhor.
Dona Maria: A mãe promete, tá?
~ GameDay = 4
//~ ChangeGameDay(GameDay)
->DONE