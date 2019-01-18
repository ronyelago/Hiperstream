using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace DevPratico
{
    public static class Handler
    {


        //Este metodo espera um path de arquivo que sera 
        //convertido para um DataTable e retornado
        public static DataTable FileToDataTable(string path)
        {
            DataTable dataTable = new DataTable();
            var rawFile = File.ReadAllLines(path);

            if (rawFile.Length > 0)
            {
                //linha que representara os nomes das colunas
                string firstLine = rawFile[0];
                //cria o array com todos os nomes das colunas
                string[] headerLabels = firstLine.Split(";");

                //adiciona as colunas ao DataTable
                foreach (var header in headerLabels)
                {
                    dataTable.Columns.Add(new DataColumn(header));
                }

                //inserindo dados no DataTable
                for (int i = 1; i < rawFile.Length; i++)
                {
                    //cria um array com os dados de cada linha
                    //cada item do array corresponde a um dado de coluna
                    string[] line = rawFile[i].Split(";");

                    //cria uma linha que sera adicionada ao DataTable
                    DataRow dataRow = dataTable.NewRow();

                    //preenche a nova linha com os dados do array
                    for (int j = 0; j < dataRow.ItemArray.Length; j++)
                    {
                        dataRow[j] = line[j];
                    }

                    //adiciona a nova linha ao DataTable
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        //Validacao de cep 
        //Regras => 8 digitos, numeros nao podem ser todos repetidos
        //e nao pode ser null nem vazio
        public static bool CepValidate(string cep)
        {
            cep = cep.Trim();

            if (string.IsNullOrEmpty(cep) || cep.Length != 8 || Regex.IsMatch(cep, (@"^.*(?:(\d)\1{7})$")))
            {
                return false;
            }

            return true;
        }
    }
}
