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
    }
}
