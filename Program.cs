using System;
using System.Reflection;

namespace Aula01Variaveis // Note: actual namespace depends on the project name. 
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Observe o menu abaixo e digite o número referente a opção desejada: ");
           Console.WriteLine("1 - Concatenar Palavras");
           Console.WriteLine("2 - Verficar Dia da Semana");
           Console.WriteLine("3 - Calcular Média");
           Console.WriteLine("4 - Calcular Tabuada");
           Console.WriteLine("5 - DetalharData");
           Console.WriteLine("6 - CalcularDescontoINSS");

           int opcaoEscolhida = int.Parse(Console.ReadLine());

           switch (opcaoEscolhida)
           {
               case 1:
                 ConcatenarPalavras();
                 break;
               case 2:
                 VerificarAulasEtec();
                 break;
               case 3:
                 CalcularMedia();
                 break;
                case 4:
                 CalcularTabuada();
                  break;
                case 5:
                  DetalharData();
                  break;
                case 6:
                   CalcularDescontoINSS();
                   break;
                default:
                  Console.WriteLine("Opção Inválida");
                  break;
           }
        }

        public static void ConcatenarPalavras()
        {
            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();

            string frase1 = $"Olá {nome}, hoje é {DateTime.Now}";
            Console.WriteLine(frase1);
            Console.WriteLine(" ");

            Console.WriteLine("Quanto custa um dólar em reais? ");
            decimal valorDolarReais = decimal.Parse(Console.ReadLine());
            string frase2 = string.Format("Hoje é {0:dddd}, o dólar está custando {1:c2} ", DateTime.Now, valorDolarReais);
            Console.WriteLine(frase2);

            Console.WriteLine(" ");
            string cabecalho = string.Format("{0:dddd}, de {0:dd} de {0:MMMM} de {0:yyyy} - {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(cabecalho.ToUpper());
        }

        public static void VerificarAulasEtec()
        {
            Console.WriteLine("Digite a data");
            DateTime data = DateTime.Parse(Console.ReadLine());

            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Final de semana não tem aula! Revisarei exercícios.");
            }
            else
            {
                Console.WriteLine("Dia da semana! Bora pra Etec");
            }
        }

        public static void CalcularMedia()
        {
            Console.WriteLine("Digite a primeira nota");
            decimal nota1 = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a segunda nota");
            decimal nota2 = decimal.Parse(Console.ReadLine());

            decimal media = (nota1 + nota2) / 2;
            Console.WriteLine($"A média é {media}");

            if(media >= 7)
                Console.WriteLine("Aprovado");
            else if(media < 7 && media >= 4 )
                Console.WriteLine("Recuperação");
            else
                Console.WriteLine("Reprovado");
        }
        public static void CalcularTabuada()
        {
            Console.WriteLine("Digite a tabuada que deseja calcular");
            int tabuada = int.Parse(Console.ReadLine());
            int contador = 0;

            while(contador <= 10)
            {
                string mensagem = string.Format("{0} X {1} = {2}", tabuada, contador, tabuada * contador);
                Console.WriteLine(mensagem);
                contador++;
            }
        }
        public static void DetalharData()
        {
            Console.WriteLine("Digite a data: ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            string diaSemana = data.ToString("dddd");
            string diaMes = data.ToString("MMMM");
            if (diaSemana.Equals("domingo"))
            {
                string horaAtual = DateTime.Now.ToString("HH:mm");
                Console.WriteLine($"Hoje é domingo, {horaAtual}");
            }
            else{
                 Console.WriteLine($"o dia é {diaSemana} de {diaMes}");
            }
        }
        public static void CalcularDescontoINSS()
        {
        Console.Write("Digite o salário: ");
        string salarioString = Console.ReadLine();

            if (decimal.TryParse(salarioString, out decimal salario))
            {
                decimal inss = 0;

                if (salario <= 1212.00m)
                {
                    inss = salario * 0.075m;
                }
                else if (salario <= 2427.35m)
                {
                    inss = (1212.00m * 0.075m) + ((salario - 1212.00m) * 0.09m);
                }
                else if (salario <= 3641.03m)
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((salario - 2427.35m) * 0.12m);
                }
                else if (salario <= 7087.22m)
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((3641.03m - 2427.35m) * 0.12m) + ((salario - 3641.03m) * 0.14m);
                }
                else
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((3641.03m - 2427.35m) * 0.12m) + ((7087.22m - 3641.03m) * 0.14m);
                }

                decimal salarioLiquido = salario - inss;

                Console.WriteLine($"INSS a pagar: R$ {inss}");
                Console.WriteLine($"Salário com desconto do INSS: R$ {salarioLiquido}");
            }
         }
}
    }  