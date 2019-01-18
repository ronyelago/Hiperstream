using System.Data;
using System.Text;

namespace DevPratico
{
    public static class Formatter
    {
        public static StringBuilder HeaderCreator()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("NomeCliente; ");
            builder.Append("EnderecoCompleto; ");
            builder.Append("ValorFatura; ");
            builder.Append("NumeroPaginas;");

            return builder;
        }

        public static StringBuilder AddressContac(DataRow row)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(row[1].ToString().Trim() + ", ");
            builder.Append(row[2].ToString() + ", ");
            builder.Append(row[3].ToString() + ", ");
            builder.Append(row[4].ToString() + ", ");
            builder.Append(row[5].ToString().Trim() + "; ");

            return builder;
        }
    }
}
