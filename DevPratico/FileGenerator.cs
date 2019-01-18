using System.Data;
using System.IO;
using System.Text;

namespace DevPratico
{
    public class FileGenerator
    {
        public StringBuilder MainStringBuilder { get; set; }

        public FileGenerator()
        {
            MainStringBuilder = new StringBuilder();
        }

        public void ByNumberOfPages(DataTable dataTable)
        {
            MainStringBuilder.Clear();
            MainStringBuilder = Formatter.HeaderCreator();
            MainStringBuilder.AppendLine();

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

                    MainStringBuilder.Append(dr[0].ToString() + "; ");
                    MainStringBuilder.Append(Formatter.AddressContac(dr));
                    MainStringBuilder.Append(dr[6].ToString() + "; ");
                    MainStringBuilder.Append(dr[7].ToString());
                }

                MainStringBuilder.AppendLine();
            }

            using (StreamWriter writer = new StreamWriter("AteSeisPaginas.csv"))
            {
                writer.Write(MainStringBuilder.ToString());
            }

            MainStringBuilder.Clear();
            MainStringBuilder = Formatter.HeaderCreator();
            MainStringBuilder.AppendLine();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[i];
                var strNum = dr["NumeroPaginas"].ToString();
                int pages = int.Parse(strNum.Trim());

                if (pages > 6 && pages <= 12)
                {
                    if (pages % 2 == 1)
                    {
                        pages += 1;
                    }

                    dr["NumeroPaginas"] = pages;


                    MainStringBuilder.Append(dr[0].ToString() + "; ");
                    MainStringBuilder.Append(Formatter.AddressContac(dr));
                    MainStringBuilder.Append(dr[6].ToString() + "; ");
                    MainStringBuilder.Append(dr[7].ToString());
                }

                MainStringBuilder.AppendLine();
            }

            using (StreamWriter writer = new StreamWriter("AteDozePaginas.csv"))
            {
                writer.Write(MainStringBuilder.ToString());
            }

            MainStringBuilder.Clear();
            MainStringBuilder = Formatter.HeaderCreator();
            MainStringBuilder.AppendLine();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[i];
                var strNum = dr["NumeroPaginas"].ToString();
                int pages = int.Parse(strNum.Trim());

                if (pages > 12)
                {
                    if (pages % 2 == 1)
                    {
                        pages += 1;
                    }

                    dr["NumeroPaginas"] = pages;


                    MainStringBuilder.Append(dr[0].ToString() + "; ");
                    MainStringBuilder.Append(Formatter.AddressContac(dr));
                    MainStringBuilder.Append(dr[6].ToString() + "; ");
                    MainStringBuilder.Append(dr[7].ToString());
                }

                MainStringBuilder.AppendLine();
            }

            using (StreamWriter writer = new StreamWriter("MaisDeDozePaginas.csv"))
            {
                writer.Write(MainStringBuilder.ToString());
            }
        }
    }
}
