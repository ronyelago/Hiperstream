using System.Data;
using System.IO;
using System.Text;

namespace DevPratico
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\Baseficticia.txt");

            var dataTable = Handler.FileToDataTable(path);

            //-Remova todos os registros com CEP Inválido(aplicar regras);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[i];

                if (!Handler.CepValidate(dr["CEP"].ToString()))
                {
                    dr.Delete();
                }
            }

            dataTable.AcceptChanges();

            //- Separe os registros com faturas zeradas e grave em um arquivo (.csv) a parte;

            StringBuilder zeroeds = new StringBuilder();

            zeroeds.Append("NomeCliente;");
            zeroeds.Append("EnderecoCompleto;");
            zeroeds.Append("ValorFatura;");
            zeroeds.Append("NumeroPaginas;");

            zeroeds.AppendLine();

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[6].ToString() == "0")
                {
                    //
                    zeroeds.Append(dr[0].ToString() + "; ");

                    StringBuilder address = new StringBuilder();
                    address.Append(dr[1].ToString());
                    address.Append(dr[2].ToString() + " ");
                    address.Append(dr[3].ToString() + " ");
                    address.Append(dr[4].ToString() + " ");
                    address.Append(dr[5].ToString() + "; ");

                    zeroeds.Append(address);
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

            //registros com ate 6 paginas

            StringBuilder sixPages = new StringBuilder();

            sixPages.Append("NomeCliente;");
            sixPages.Append("EnderecoCompleto;");
            sixPages.Append("ValorFatura;");
            sixPages.Append("NumeroPaginas;");
            sixPages.AppendLine();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[i];
                var strNum = dr["NumeroPaginas"].ToString();
                int pages = int.Parse(strNum.Trim());

                if (pages <= 6)
                {
                    if (pages % 2 == 1)
                    {
                        pages += 1;
                    }

                    dr["NumeroPaginas"] = pages;


                    sixPages.Append(dr[0].ToString() + "; ");

                    StringBuilder endereco = new StringBuilder();
                    endereco.Append(dr[1].ToString());
                    endereco.Append(dr[2].ToString() + " ");
                    endereco.Append(dr[3].ToString() + " ");
                    endereco.Append(dr[4].ToString() + " ");
                    endereco.Append(dr[5].ToString() + "; ");

                    sixPages.Append(endereco);
                    sixPages.Append(dr[6].ToString() + "; ");
                    sixPages.Append(dr[7].ToString());
                }

                sixPages.AppendLine();
            }

            using (StreamWriter writer = new StreamWriter("AteSeisPaginas.csv"))
            {
                writer.Write(sixPages.ToString());
            }

            //registros com ate 12 paginas
        }
    }
}










