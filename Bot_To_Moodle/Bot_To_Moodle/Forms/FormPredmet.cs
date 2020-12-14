using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bot_To_Moodle
{
    public partial class FormPredmet : Form
    {
        public FormPredmet()
        {
            InitializeComponent();
        }
        List<Predmet> listP = new List<Predmet>();

        private void FormPredmet_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            new Menu().Show();
        }

        static int GenerateDigt(Random r)
        {
            return r.Next();
        }

        private int Randoms()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                GenerateDigt(r);

            }
            return r.Next(100, 1000);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.grid.DataSource = null;
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {

                            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            DataSet result = excelReader.AsDataSet();
                            if (excelReader.RowCount > 0)
                            {
                                while (excelReader.Read())
                                {
                                    listP.Add(new Predmet
                                    {
                                        namePredmet = excelReader.GetString(0)
                                    });

                                }

                            }
                            else
                            {
                                MessageBox.Show("Пустой файл");
                            }

                            this.grid.DataSource = listP;

                        }
                    }
                }
            }
            catch(InvalidCastException) { MessageBox.Show("Не верный формат данных в файле!(Должен быть только String!!!)"); }
            catch(Exception ex) { MessageBox.Show(ex.Message); }


         
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            try
            {


                if (textURL.Text.Length != 0)
                {
                    using (IWebDriver Browser = new OperaDriver())
                    {
                        string idGroup = string.Empty;

                        Browser.Manage().Window.Maximize();

                        System.Threading.Thread.Sleep(1000);

                        Browser.Navigate().GoToUrl(@"http://ltsu.ru/login/index.php");

                        Browser.FindElement(By.Id("username")).SendKeys("admin");
                        Browser.FindElement(By.Id("password")).SendKeys("ULT@015um");
                        Browser.FindElement(By.Id("loginbtn")).Click();

                        Browser.Navigate().GoToUrl(textURL.Text);

                        MatchCollection match = Regex.Matches(textURL.Text, @"(\d+)");

                        foreach (Match m in match)
                        {
                            idGroup = (m.Groups[1].ToString());
                        }

                        System.Threading.Thread.Sleep(2000);

                        Browser.Navigate().GoToUrl($"http://ltsu.ru/course/edit.php?category={idGroup}&returnto=catmanage");

                        System.Threading.Thread.Sleep(2000);

                        foreach (Predmet p in listP)
                        {
                            int random = Randoms();

                            Browser.FindElement(By.Id("id_fullname")).Clear();
                            Browser.FindElement(By.Id("id_shortname")).Clear();
                            Browser.FindElement(By.Id("id_fullname")).SendKeys(p.namePredmet);
                            if (p.namePredmet.Length < 100)
                            {
                                Browser.FindElement(By.Id("id_shortname")).SendKeys(p.namePredmet + "_" + random.ToString());
                            }
                            else
                            {
                                Browser.FindElement(By.Id("id_shortname")).SendKeys(p.namePredmet.Split(' ') + "_" + random.ToString());
                            }
                            System.Threading.Thread.Sleep(1000);
                            Browser.FindElement(By.Id("id_saveanddisplay")).Click();

                            System.Threading.Thread.Sleep(1000);
                            Browser.Navigate().Back();

                            System.Threading.Thread.Sleep(2000);
                        }
                   
                    }


                }
                else MessageBox.Show("Введите URL");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
