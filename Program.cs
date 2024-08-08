using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using BoletimEscolar.Models;

internal class Program
{
  private static readonly string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "Boletim.xls");
  private static readonly List<Escola> boletins = LerArquivoExcel.LerExcel(caminhoArquivo);

  private static void Main(string[] args)
  {
     Console.WriteLine("Questão 1:\n");
    LINQ.QuantidadeAlunos(boletins);
    Console.WriteLine("Questão 2:\n");
    LINQ.QuantidadeProfessores(boletins);
    Console.WriteLine("Questão 3:\n");
    LINQ.QuantidadeDeTurmas(boletins);
    LINQ.QuantidadeDeDisciplinas(boletins);
    Console.WriteLine("Questão 4:\n");
    LINQ.AlunosAprovadosEReprovados(boletins);
    Console.WriteLine("Questão 5:\n");
    LINQ.NotaMaisAlta(boletins);
    Console.WriteLine("Questão 6:\n");
    LINQ.MediaNotaPorSerie(boletins);
    Console.WriteLine("Questão 7:\n");
    LINQ.QuantidadeMeninosEMeninas(boletins);
    
  }
}