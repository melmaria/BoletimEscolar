using NPOI.SS.UserModel;

namespace BoletimEscolar.Models
{
    public class LerArquivoExcel
    {
        public static List<Escola> LerExcel(string caminhoArquivo)
        {
            var boletins = new List<Escola>();

            IWorkbook workbook = WorkbookFactory.Create(caminhoArquivo);
            ISheet sheet = workbook.GetSheetAt(0);

            for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    var nomeAluno = row.GetCell(0).StringCellValue;
                    var nomeMateria = row.GetCell(1).StringCellValue;
                    var nomeProfessor = row.GetCell(2).StringCellValue;
                    var serie = row.GetCell(3).StringCellValue;
                    var nota = double.Parse(row.GetCell(4).StringCellValue) / 10;
                    var telefone = row.GetCell(5).StringCellValue;
                    var sexo = row.GetCell(6).StringCellValue;


                    var boletim = new Escola(nomeAluno, nomeMateria, nomeProfessor, serie, nota, telefone, sexo);
                    boletins.Add(boletim);
                }
            }

            return boletins;
        }
    }
}