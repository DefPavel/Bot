using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bot_To_Moodle
{
    public partial class FormPerson : Form
    {
        public FormPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IWebDriver Browser = new OperaDriver();
            try
            {
                if ((textGroup.Text.Length != 0) || (textURL.Text.Length != 0))
                {

                    using (IWebDriver Browser = new OperaDriver())
                    {
                        //Ожидание 
                       // WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(5));

                        Browser.Manage().Window.Maximize();

                        Browser.Navigate().GoToUrl(@"http://ltsu.ru/login/index.php");
                        Browser.FindElement(By.Id("username")).SendKeys("admin");
                        Browser.FindElement(By.Id("password")).SendKeys("ULT@015um");
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
                            Browser.FindElement(By.CssSelector(".pull-right input")).Click();
                            System.Threading.Thread.Sleep(2000);
                            Browser.FindElement(By.CssSelector(".fcontainer.clearfix > #fitem_id_cohortlist > .felement > input")).SendKeys(textGroup.Text.Trim());
                            System.Threading.Thread.Sleep(2000);
                            Browser.FindElement(By.CssSelector(".fcontainer.clearfix > #fitem_id_cohortlist > .felement > ul > li:first-child")).Click();
                            //Может быть Здесь еще нужно поставить Sleep
                            Browser.FindElement(By.CssSelector(".modal-body > form")).Submit();
                            System.Threading.Thread.Sleep(int.Parse(textTime.Text));
                        }

                    }


                }
                
                else MessageBox.Show("Введите текст");

            }
            catch(NoSuchElementException element)
            {
                MessageBox.Show("Не найден элемент на сайте!!!!" +"\n"+ element.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           // finally { Browser.Dispose(); }

           
        }

        private void FormPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Menu().Show();
        }
    }
}
