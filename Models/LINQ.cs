

namespace BoletimEscolar.Models
{
    public static class LINQ
    {
        //! QUESTÃO 1:
        public static void QuantidadeAlunos(List<Escola> boletins)
        {
            var alunos = boletins.GroupBy(x => x.NomeAluno).Distinct().ToList();
            Console.WriteLine($"Total de alunos: {alunos.Count()}");

        }
        //! QUESTÃO 2:
        public static void QuantidadeProfessores(List<Escola> boletins)
        {
            var professores = boletins.GroupBy(x => x.NomeProfessor).Distinct().ToList();
            Console.WriteLine($"Total de professores: {professores.Count()}");
        }
        //! QUESTÃO 3:
        // CONTAR QUANTAS TURMAS EXISTEM
        public static void QuantidadeDeTurmas(List<Escola> boletins)
        {
            var turmas = boletins.GroupBy(g => g.Serie).Count();
            Console.WriteLine($"Número de séries: {turmas}");
        }

        //! 3.1 
        // CONTAR QUANTAS DISCIPLINAS EXISTEM
        public static void QuantidadeDeDisciplinas(List<Escola> boletins)
        {
            var turmas = boletins.GroupBy(g => g.NomeMateria).Count();
            Console.WriteLine($"Número de matérias: {turmas}");
        }

        //! QUESTÃO 4:
        public static void AlunosAprovadosEReprovados(List<Escola> boletins)
        {
            var mediaDeAlunos = boletins.GroupBy(x => new
            {
                NomeAluno = x.NomeAluno,
                Telefone = x.Telefone
            }).Select(g => new
            {
                Aluno = g.Key.NomeAluno,
                Telefone = g.Key.Telefone,
                MediaDoAluno = g.Average(x => x.Nota)
            }).ToList();

            var quantidadeReprovados = mediaDeAlunos.Where(x => x.MediaDoAluno < 7).Count();
            var quantidadeAprovados = mediaDeAlunos.Where(x => x.MediaDoAluno >= 7).Count();

            Console.WriteLine($"{quantidadeReprovados} alunos foram reprovados.");
            Console.WriteLine($"{quantidadeAprovados} alunos foram aprovados.");

            foreach (var alunoReprovado in mediaDeAlunos)
            {
                if (alunoReprovado.MediaDoAluno < 7)
                {
                    Console.WriteLine($"{alunoReprovado.Aluno} - {alunoReprovado.Telefone}");
                }
            }
        }
        //! QUESTÃO 5 Crie uma lista por série e matéria, a nota mais alta de cada turma e disciplina e o nome do aluno. Em caso de mais de uma nota, evidenciar a lista de alunos:
        public static void NotaMaisAlta(List<Escola> boletins)
        {

            var maiorNota = boletins.GroupBy(x => new
            {
                x.Serie,
                x.NomeMateria
            })
                                .Select(g => new
                                {
                                    g.Key.Serie,
                                    g.Key.NomeMateria,
                                    Aluno = g.OrderByDescending(x => x.Nota).First().NomeAluno,
                                    Nota = g.Max(x => x.Nota)
                                })
                                .OrderBy(x => x.Serie)
                                .ThenBy(x => x.NomeMateria);

            for (int c = 0; c < maiorNota.Count(); c++)
            {
                Console.WriteLine($"{maiorNota.ElementAt(c).Serie} - {maiorNota.ElementAt(c).NomeMateria} - {maiorNota.ElementAt(c).Aluno} - {maiorNota.ElementAt(c).Nota}");
                Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }

        }
        //! QUESTÃO 6 Qual foi a média de nota de cada série? Qual série teve a média mais alta?:
        public static void MediaNotaPorSerie(List<Escola> boletins)
        {
            var mediaNotaPorSerie = boletins.GroupBy(x => x.Serie)
                                             .Select(g => new
                                             {
                                                 Serie = g.Key,
                                                 MediaNota = g.Average(x => x.Nota)
                                             })
                                             .OrderByDescending(x => x.MediaNota);
            foreach (var a in mediaNotaPorSerie)
            {
                Console.WriteLine($"{a.Serie} - {a.MediaNota}");
            }

        }
        //! QUESTÃO 7:
        public static void QuantidadeMeninosEMeninas(List<Escola> boletins)
        {
            var quantidadePorSexo = boletins.GroupBy(x => new { x.Sexo, x.NomeAluno })
                                            .Select(g => new
                                            {
                                                Sexo = g.Key,
                                                Nome = g.Key.NomeAluno,
                                                Quantidade = g.Count()
                                            }).Distinct();
            foreach (var a in quantidadePorSexo)
            {
                Console.WriteLine($"{a.Sexo} - {a.Quantidade}");
            }
        }

    }
}