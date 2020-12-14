using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bot_To_Moodle
{
    public partial class Insert_Special : Form
    {
        public Insert_Special()
        {
            InitializeComponent();
        }
        List<Predmet> listP = new List<Predmet>();
        private void button1_Click(object sender, EventArgs e)
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
            catch (InvalidCastException) { MessageBox.Show("Не верный формат данных в файле!(Должен быть только String!!!)"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Insert_Special_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Menu().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text.Length != 0 )
                {
                    using (IWebDriver Browser = new OperaDriver())
                    {
                        Browser.Manage().Window.Maximize();

                        System.Threading.Thread.Sleep(1000);

                        Browser.Navigate().GoToUrl(@"http://ltsu.ru/login/index.php");

                        Browser.FindElement(By.Id("username")).SendKeys("admin");
                        Browser.FindElement(By.Id("password")).SendKeys("ULT@015um");
                        Browser.FindElement(By.Id("loginbtn")).Click();

                       

                        foreach (Predmet p in listP)
                        {

                            Browser.Navigate().GoToUrl(textBox1.Text);

                            System.Threading.Thread.Sleep(1000);

                            Browser.FindElement(By.CssSelector(".listing-actions.category-listing-actions a:first-child")).Click();

                            Browser.FindElement(By.Id("id_name")).SendKeys(p.namePredmet);

                            Browser.FindElement(By.Id("id_submitbutton")).Click();

                            System.Threading.Thread.Sleep(1000);

                        }
                    }

                }
                else { MessageBox.Show("Введите URL!"); }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
