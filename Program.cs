// Screen Sound
string mensageDeBoasVindas = "Boas vindas ao Screen Sound";
List<string> listaDasBandas = new List<string>
{ "U2", "LinkPark", "Mamonas Assasinas", "Code Play" };

void ExibirLogo()
{
  Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
  Console.WriteLine(mensageDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
  ExibirLogo();
  Console.WriteLine();
  Console.WriteLine("Digite 1 para registrar uma banda");
  Console.WriteLine("Digite 2 para mostras todas as bandas");
  Console.WriteLine("Digite 3 para avaliar uma banda");
  Console.WriteLine("Digite 4 para exibir a média de uma banda");
  Console.WriteLine("Digite -1 para sair");
  Console.WriteLine();

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
        Console.WriteLine($"opção escolhida: {opcaoEscolhidaNumerica}");
        break;
      case 4:
        Console.WriteLine($"opção escolhida: {opcaoEscolhidaNumerica}");
        break;
      case -1:
        Console.WriteLine($"{opcaoEscolhidaNumerica} saindo do sitema");
        break;
      default:
        Console.WriteLine($"Opção ({opcaoEscolhidaNumerica}) invalida");
        Thread.Sleep(3000);
        ExibirOpcoesDoMenu();
        break;
    }
  } catch (Exception ex)
  {
    Console.Clear();
    Console.WriteLine($"Entrada invalida -> {ex.Message}");
    Thread.Sleep(5000);

    Console.Clear();
    ExibirOpcoesDoMenu();
  }

}

void RegistrarBanda()
{
  Console.Clear();
  ExibirTituloDaOpcao("Registro de bandas");
  Console.WriteLine();

  Console.Write("Digite o nome da banda que deseja: ");
  string nomeDaBanda = Console.ReadLine()!;

  listaDasBandas.Add(nomeDaBanda);

  Console.WriteLine();
  Console.WriteLine($"A banda ({nomeDaBanda}) foi registrada com sucesso");
  Thread.Sleep(2000);

  Console.Clear();
  ExibirOpcoesDoMenu();
}

void MostrarbandasRegistradas()
{
  Console.Clear();
  ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
  Console.WriteLine();

  if (listaDasBandas.Count <= 0)
  {
    Console.WriteLine("Sem bandas Cadastradas no momento");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirOpcoesDoMenu();
  }

  foreach (string nomeDaBanda in listaDasBandas)
    Console.WriteLine($"Banda: {nomeDaBanda}");

  Console.WriteLine();
  Console.WriteLine("Digite uma tecla para voltar a menu principal");

  Console.ReadLine();
  Console.Clear();
  ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
  string caractere = string.Empty;
  for (int i = 0; i < titulo.Length; i++)
    caractere += "*";

  Console.WriteLine(caractere);
  Console.WriteLine(titulo);
  Console.WriteLine(caractere);
}

ExibirOpcoesDoMenu();