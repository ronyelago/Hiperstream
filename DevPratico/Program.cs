﻿using System.Data;
using System.IO;
using System.Text;

namespace DevPratico
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Baseficticia.txt");

            var dataTable = Handler.FileToDataTable(path);

            //-Remova todos os registros com CEP Inválido(aplicar regras);
            int index = 0;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[index];

                if (!AddressHandler.CepValidate(dr["CEP"].ToString()))
                {
                    dr.Delete();
                    index -= 1;
                }

                index++;
            }

            dataTable.AcceptChanges();

            //- Separe os registros com faturas zeradas e grave em um arquivo (.csv) a parte;

            StringBuilder zeroeds = new StringBuilder();

            zeroeds = Formatter.HeaderCreator();
            zeroeds.AppendLine();

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[6].ToString() == "0")
                {
                    //
                    zeroeds.Append(dr[0].ToString() + "; ");

                    zeroeds.Append(Formatter.AddressContac(dr));
                    zeroeds.Append(dr[6].ToString() + "; ");
                    zeroeds.Append(dr[7].ToString());

                    zeroeds.AppendLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("FaturasZeradas.csv"))
            {
                writer.Write(zeroeds.ToString());
            }

            //- Agrupe os arquivos de saída por números de páginas de faturas

            FileGenerator generator = new FileGenerator();
            generator.ByNumberOfPages(dataTable);
        }
    }
}










