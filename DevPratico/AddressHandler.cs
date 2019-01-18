using System.Text;
using System.Text.RegularExpressions;

namespace DevPratico
{
    public static class AddressHandler
    {
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
