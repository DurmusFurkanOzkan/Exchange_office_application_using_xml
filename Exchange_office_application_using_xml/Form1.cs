using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XML_Kullanımı_ve_Döviz_Ofisi_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String URLString = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(URLString);

            string dolar_alıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolar_al.Text = dolar_alıs;
            string dolar_satıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolar_sat.Text = dolar_satıs;
            string euro_alis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euro_al.Text = euro_alis;
            string euro_satis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euro_sat.Text = euro_satis;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = dolar_al.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = dolar_sat.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = euro_al.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = euro_sat.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kur;
            kur = double.Parse(textBox1.Text);
            double miktar;
            miktar = double.Parse(textBox2.Text);
            double tutar = miktar * kur;
            textBox3.Text = tutar.ToString();
            textBox4.Text = "-----------";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(".", ",");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double kur;
            kur = double.Parse(textBox1.Text);
            double miktar;
            miktar = double.Parse(textBox2.Text);
            int tutar = (int)(miktar / kur);
            double kalan = miktar % kur;
            textBox3.Text = tutar.ToString();
            textBox4.Text = kalan.ToString();
        }
    }
}
