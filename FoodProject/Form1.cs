using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodProject.DAL;
using FoodProject.DAL.Repository;
using FoodProject.lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FoodProject
{
    public partial class Form1 : Form
    {
        protected IJavaScriptExecutor js;
        protected ChromeDriver browser;
        
        public Form1()
        {
            InitializeComponent();

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArguments("--lang=tr");
            browser = new ChromeDriver(service, options);
            js = (IJavaScriptExecutor)browser;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MigrosWeb mig = new MigrosWeb(browser,js);
            textBox1.Text = mig.price();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            User user = new User();
            user.Name = "Onat";
            user.LastName = "Aktaş";
            userRepository.AddUser(user);
        }
    }
}
