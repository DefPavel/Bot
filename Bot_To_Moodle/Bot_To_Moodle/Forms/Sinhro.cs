using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bot_To_Moodle.Forms
{
    public partial class Sinhro : Form
    {
        public Sinhro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (IWebDriver Browser = new OperaDriver())
                {
                    //Ожидание 
                    // WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(5));

                    Browser.Manage().Window.Maximize();

                    Browser.Navigate().GoToUrl(@"http://ltsu.ru/login/index.php");
                    Browser.FindElement(By.Id("username")).SendKeys("operator-228");
                    Browser.FindElement(By.Id("password")).SendKeys("14976");
                    Browser.FindElement(By.Id("loginbtn")).Click();
                    Browser.Navigate().GoToUrl(textURL.Text);

                    System.Threading.Thread.Sleep(int.Parse(textTime.Text));

                    Browser.FindElement(By.CssSelector(".course-listing-actions div:nth-child(3) .dropdown a:first-child")).Click();

                    System.Threading.Thread.Sleep(int.Parse(textTime.Text));

                    Browser.FindElement(By.CssSelector(".dropdown-menu.dropdown-menu-right.menu.align-tr-br.show > a:nth-child(6)")).Click();
                    System.Threading.Thread.Sleep(2000);

                    List<IWebElement> items = Browser.FindElements(By.CssSelector("#course-category-listings #course-listing .listitem .coursename")).ToList();
                    List<string> new_item = new List<string>();

                    for (int i = 0; i < items.Count; i++)
                    {
                        new_item.Add(items[i].GetAttribute("href"));
                    }

                    for (int i = 0; i < new_item.Count; i++)
                    {
                        Browser.Navigate().GoToUrl(new_item[i].ToString());

                        // wait.Until(item => item.FindElement(By.CssSelector(".listing-actions.course-detail-listing-actions > a:nth-child(3)")).Displayed);
                        System.Threading.Thread.Sleep(1000);

                        Browser.FindElement(By.CssSelector(".listing-actions.course-detail-listing-actions > a:nth-child(3)")).Click();
                        System.Threading.Thread.Sleep(1000);
                        //папап
                        Browser.FindElement(By.CssSelector("#region-main-box .dropdown:first-child a:first-child")).Click();
                        System.Threading.Thread.Sleep(1000);

                        Browser.FindElement(By.CssSelector(".dropdown-menu.dropdown-menu-right.menu.align-tr-br.show div:nth-child(2)")).Click();

                        System.Threading.Thread.Sleep(1000);

                        Browser.FindElement(By.CssSelector(".custom-select.urlselect option:nth-child(3)")).Click();

                        System.Threading.Thread.Sleep(1000);

                        Browser.FindElement(By.Id("id_name")).SendKeys("Синхронизация с глобальной группой");

                        Browser.FindElement(By.CssSelector(".fcontainer.clearfix input:nth-child(3)")).SendKeys(textGroup.Text);

                        //Browser.FindElement()

                        System.Threading.Thread.Sleep(1000);

                        Browser.FindElement(By.CssSelector(".form-autocomplete-suggestions li:first-child")).Click();

                        Browser.FindElement(By.Id("mform1")).Submit();

                        System.Threading.Thread.Sleep(1000);

                        /* Browser.FindElement(By.CssSelector(".pull-right input")).Click();
                         System.Threading.Thread.Sleep(2000);
                         Browser.FindElement(By.CssSelector(".fcontainer.clearfix > #fitem_id_cohortlist > .felement > input")).SendKeys(textGroup.Text.Trim());
                         System.Threading.Thread.Sleep(2000);
                         Browser.FindElement(By.CssSelector(".fcontainer.clearfix > #fitem_id_cohortlist > .felement > ul > li:first-child")).Click();
                         //Может быть Здесь еще нужно поставить Sleep
                         Browser.FindElement(By.CssSelector(".modal-body > form")).Submit();
                         System.Threading.Thread.Sleep(int.Parse(textTime.Text));*/
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
          
        }
    }
}
