namespace BoletimEscolar.Models
{
    public  class Escola 
    {
        public string NomeAluno { get; protected set; }
        public string NomeMateria { get; protected set; }
        public string NomeProfessor { get; protected set; }
        public string Serie { get; protected set; }
        public double Nota { get; protected set; }
        public string Telefone { get; protected set; }
        public string Sexo { get; protected set; }

        public Escola(
            string nomeAluno,
            string nomeMateria,
            string nomeProfessor,
            string serie,
            double nota,
            string telefone,
            string sexo)
        {
                SetNomeAluno(nomeAluno);
                SetNomeMateria(nomeMateria);
                SetNomeProfessor(nomeProfessor);
                SetSerie(serie);
                SetNota(nota);
                SetTelefone(telefone);
                SetSexo(sexo);

        }

       public  void SetNomeAluno(string nomeAluno)
       {
          if (string.IsNullOrWhiteSpace(nomeAluno))
            throw new ArgumentNullException(nameof(nomeAluno));

         NomeAluno = nomeAluno;
       }
       public  void SetNomeMateria(string nomeMateria)
       {
         if (string.IsNullOrWhiteSpace(nomeMateria))
            throw new ArgumentNullException(nameof(nomeMateria));
        NomeMateria = nomeMateria;
       }
       public  void SetNomeProfessor(string nomeProfessor)
       {
        if (string.IsNullOrWhiteSpace(nomeProfessor))
           throw new ArgumentNullException(nameof(nomeProfessor));
        NomeProfessor = nomeProfessor;
       }
       public void SetSerie(string serie)
       {
        if (string.IsNullOrWhiteSpace(serie))
            throw new ArgumentOutOfRangeException(nameof(serie));
        Serie = serie;
       }
       public void SetNota(double nota)
       {
        if (nota < 0 && nota > 10)
            throw new ArgumentOutOfRangeException(nameof(nota));
        Nota = nota;
       }
       public void SetTelefone(string telefone)
       {
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Telefone inválido.");
        Telefone = telefone;
       }
       public void SetSexo(string sexo)
       {
        if (string.IsNullOrWhiteSpace(sexo))
            throw new ArgumentException("Sexo inválido.");
        Sexo = sexo;

       }

    }
}