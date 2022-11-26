using InformationSlipManagement.Models;
using System.Text;

namespace InformationSlipManagement.Manager
{
    public class InformationSlipManager 
    {
        public string InformationSlipEditor(List<Root> Root)
        {
            StringBuilder sb = new StringBuilder(); // Oluşacak text üzerinde fazla değişiklik olması nedeniyle SB tercih ettim.

            int lineNumber = 1;
            int largestYAxisCount = 0; //sıralamada satır atlatmak için kullandığım En büyük Y Ekseni değişkeni

            Root = Root.OrderBy(x => x.boundingPoly.vertices.Sum(x => x.y)).ToList(); //Y eksenine odaklı bir sıralama yapacağımız için Y ekseni değerlerine göre küçükten büyüğe sıralama yaptım.

            for (int i = 0; i < Root.Count;)
            {
                if (Root[i].locale == null)
                {
                    if (Root[i].boundingPoly.vertices.Any(x => x.y < largestYAxisCount))
                    {
                        sb.Append(" ");
                        sb.Append(Root[i].description);              //
                    }                                                //  
                    else                                             //Çıktıyı almamızı sağlayan algoritma
                    {                                                //
                        if (largestYAxisCount != 0)                  //
                        {                                            //
                            sb.Append("\n");
                        }

                        largestYAxisCount = Root[i].boundingPoly.vertices.OrderByDescending(x => x.y).FirstOrDefault().y;

                        sb.Append(lineNumber + "  " + Root[i].description);
                        lineNumber++;
                    }

                }
                i++;
            }

            return sb.ToString();
        }
    }
}
