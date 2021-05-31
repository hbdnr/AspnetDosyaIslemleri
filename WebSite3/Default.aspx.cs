using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string yol = @"C:\Users\Yusuf\Desktop\Dersler 3-2\Web tasarımı ve programlama\odevler\hafta 10\WebSite3\veri";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (Path.GetExtension(yol + "\\" + FileUpload1.FileName) == ".pdf" || Path.GetExtension(yol + "\\" + FileUpload1.FileName) == ".docx")
            {
                FileUpload1.SaveAs(Server.MapPath("veri") + "\\" + FileUpload1.FileName);
                Label1.Text = "Eklendi...";
            }else
            {
                Response.Write("Boş Girdiniz veya Dosya türü hatalıdır...");

            }

        }else
        {
            Response.Write("Boş Girdiniz veya Dosya türü hatalıdır...");

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        long toplam = 0;
        string[] gelen = Directory.GetFiles(yol, "*.*", SearchOption.AllDirectories);
        foreach (string k in gelen)
        {
            FileInfo aa = new FileInfo(k);
            toplam += aa.Length;
        }

        Label2.Text = "Bayt: " + toplam.ToString() + " --- KiloBayt: " + ((double)toplam / (double)1024).ToString() + " --- MegaBayt: " + ((double)toplam / (double)1048576).ToString() + " --- GigaBayt: " + ((double)toplam / (double)1073741824).ToString();
    }
}