// Screen Sound
string mensageDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string>
//{ "U2", "LinkPark", "Mamonas Assasinas", "Code Play" };

Dictionary<string, List<int>> listaDasBandas = new Dictionary<string, List<int>>();
listaDasBandas.Add("Link Park", new List<int> { 1, 2, 10 });
listaDasBandas.Add("The Beatles", new List<int>());
listaDasBandas.Add("Ira", new List<int> { 1, 2, 10 });

void ExibirLogo()
{
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
  Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine(mensageDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
  ExibirLogo();
  Console.WriteLine("\r\nDigite 1 para registrar uma banda");
  Console.WriteLine("Digite 2 para mostras todas as bandas");
  Console.WriteLine("Digite 3 para avaliar uma banda");
  Console.WriteLine("Digite 4 para exibir a média de uma banda");
  Console.WriteLine("Digite -1 para sair\r\n");

  try
  {
    Console.Write("Digite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
      case 1:
        RegistrarBanda();
        break;
      case 2:
        MostrarbandasRegistradas();
        break;
      case 3:
        AvaliacaoUmaBanda();
        break;
      case 4:
        ExibirAvaliacaoDeBanda();
        break;
      case -1:
        Console.WriteLine($"{opcaoEscolhidaNumerica} saindo do sitema");
        Environment.Exit(0);
        break;
      default:
        Console.WriteLine($"Opção ({opcaoEscolhidaNumerica}) invalida");
        Thread.Sleep(3000);
        ExibirOpcoesDoMenu();
        break;
    }
  }
  catch (Exception ex)
  {
    Console.Clear();
    Console.WriteLine($"Entrada invalida -> {ex.Message}");
    Thread.Sleep(5000);

    Console.Clear();
    ExibirOpcoesDoMenu();
  }

}

void RegistrarBanda(string? nomeBanda = null)
{
  Console.Clear();
  ExibirTituloDaOpcao("Registro de bandas");

  if (nomeBanda is null)
  {
    Console.Write("Digite o nome da banda que deseja: ");
    string nomeDaBanda = Console.ReadLine()!;

    listaDasBandas.Add(nomeDaBanda, new List<int>());

    Console.WriteLine($"\r\nA banda ({nomeDaBanda}) foi registrada com sucesso");
    Thread.Sleep(2000);

    Console.Clear();
    ExibirOpcoesDoMenu();
  }
  else
  {
    listaDasBandas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"\r\nA banda ({nomeBanda}) foi registrada com sucesso");
  }

}

void MostrarbandasRegistradas()
{
  Console.Clear();
  ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

  if (listaDasBandas.Count <= 0)
  {
    Console.WriteLine("Sem bandas Cadastradas no momento");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirOpcoesDoMenu();
  }

  foreach (string nomeDaBanda in listaDasBandas.Keys)
    Console.WriteLine($"Banda: {nomeDaBanda}");

  Console.WriteLine("\r\nDigite uma tecla para voltar a menu principal");

  Console.ReadLine();
  Console.Clear();
  ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
  string asteriscos = string.Empty.PadLeft(titulo.Length, '*');

  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine(asteriscos);
  Console.ForegroundColor = ConsoleColor.Blue;
  Console.WriteLine(titulo);
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine($"{asteriscos}\r\n");
  Console.ForegroundColor = ConsoleColor.White;
}

void AvaliacaoUmaBanda()
{
  Console.Clear();
  ExibirTituloDaOpcao("Avaliar uma banda");

  Console.Write("Digite o nome da banda que deseja avaliar: ");
  string nomeDaBanda = Console.ReadLine()!;
  bool bandaExiste = listaDasBandas.ContainsKey(nomeDaBanda);

  if (bandaExiste)
  {
    Console.Write($"Qual a nota que a banda ({nomeDaBanda}) merece: ");
    int nota = int.Parse(Console.ReadLine()!);

    listaDasBandas[nomeDaBanda].Add(nota);

    Console.WriteLine($"\r\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
  }
  else
  {
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");

    Console.WriteLine("Banda informada não cadastrada.\r\nO que deseja fazer?\r\n");
    Console.WriteLine("1 - cadastrar essa banda");
    Console.WriteLine("2 - Voltar para o Menu principal");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    while (opcaoEscolhidaNumerica != 2)
      switch (opcaoEscolhidaNumerica)
      {
        case 1:
          RegistrarBanda(nomeDaBanda);
          Thread.Sleep(4000);
          Console.Clear();
          AvaliacaoUmaBanda();
          break;
        case 2:
          Console.Clear();
          ExibirOpcoesDoMenu();
          break;
        default:
          Console.WriteLine("Porfavor escolha uma opção valida");
          Console.WriteLine("1 - cadastrar essa banda");
          Console.WriteLine("2 - Voltar para o Menu principal");

          opcaoEscolhida = Console.ReadLine()!;
          opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
          break;
      }
  }
}

void ExibirAvaliacaoDeBanda()
{
  Console.Clear();
  ExibirTituloDaOpcao("Avaliações da Banda");

  Console.WriteLine("1 - selecionar banda para ver avaliação");
  Console.WriteLine("2 - Voltar para o Menu principal");
  string opcaoEscolhida = Console.ReadLine()!;

  try
  {
    switch (opcaoEscolhida)
    {
      case "1":
        bool selecionarOutraBanda = false;
        do
        {
          Console.Clear();
          ExibirTituloDaOpcao("Avaliações da Banda");
          Console.Write("Digite o nome da banda que deseja ver as avaliações: ");
          string nomeDaBanda = Console.ReadLine()!;

          bool bandaExite = listaDasBandas.ContainsKey(nomeDaBanda);
          if (bandaExite)
          {
            Console.Clear();
            ExibirTituloDaOpcao("Avaliações da Banda");
            Console.Write($"Banda {nomeDaBanda} - ");
            double media = 0;
            foreach (var banda in listaDasBandas[nomeDaBanda])
            {
              media += banda;
            }
            double mediaArre = Math.Ceiling(media / listaDasBandas.Count);
            Console.WriteLine($"{mediaArre} estrela(s)");

            Console.Write("\r\nGostaria de ver outra banda? \r\n1 - Sim \r\n2 - Não e (Voltar ao menu principal): ");
            selecionarOutraBanda = Console.ReadLine() == "1" ? true : false;
          }
          else
          {
            Console.Clear();
            ExibirTituloDaOpcao("Avaliações da Banda");
            Console.WriteLine("Banda não localizada.\r\nDeseja ver outra banda?");
            Console.WriteLine("1 - selecionar banda para ver avaliações");
            Console.WriteLine("2 - Voltar para o Menu principal");

            opcaoEscolhida = Console.ReadLine()!;
          }
        }
        while (selecionarOutraBanda);

        Console.WriteLine("Voltando para o menu principal");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
        break;
      case "2":
        Console.Clear();
        ExibirOpcoesDoMenu();
        break;
      default:
        Console.Clear();
        ExibirAvaliacaoDeBanda();
        break;
    }
  }
  catch (Exception ex)
  {
    Console.Clear();
    ExibirTituloDaOpcao("Avaliações da Banda"); ;
    Console.WriteLine("Porfavor escolha uma opção valida");
    Console.WriteLine("1 - selecionar banda para ver avaliação");
    Console.WriteLine("2 - Voltar para o Menu principal");

    opcaoEscolhida = Console.ReadLine()!;
  }




}

ExibirOpcoesDoMenu();