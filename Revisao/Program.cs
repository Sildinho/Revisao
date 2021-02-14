using System;

//  DIO "Primeiros passos com .NET + C#" - aula "Uma síntese do que é .NET" 14/02/2021
namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Write("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.Write("\nInforme a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decima.");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        Console.WriteLine();                    
                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var numeroAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                numeroAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / numeroAlunos;

                        Conceito conceitoGeral;
                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");

                        Console.WriteLine();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); // o valor informado esta fora das opções
                }
                opcaoUsuario = ObterOpcaoUsuario();                
            }
        }
            

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Menu de opções:  \n");
            Console.WriteLine("1 - Inserir novo aluno?");
            Console.WriteLine("2 - Listar alunos?");
            Console.WriteLine("3 - Calcular média geral?");
            Console.WriteLine("X - Sair \n");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();           
            return opcaoUsuario;
        }
    }
}