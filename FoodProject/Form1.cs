using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodProject.lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FoodProject
{
    public partial class Form1 : Form
    {
        protected IJavaScriptExecutor js;
        protected ChromeDriver browser;
        Thread thrd;
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

        private void Button1_Click(object sender, System.EventArgs e)
        {
            MigrosWeb mig = new MigrosWeb(browser, js);
            thrd = new Thread(mig.price);
            thrd.Start();
            timer1.Start();

            toggleButton(button1);
            toggleButton(button2);
            toggleButton(button3);
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            CarrefoursaWeb ca = new CarrefoursaWeb(browser, js);
            thrd = new Thread(ca.price);
            thrd.Start();
            timer1.Start();

            toggleButton(button1);
            toggleButton(button2);
            toggleButton(button3);
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            thrd.Abort();

            toggleButton(button1);
            toggleButton(button2);
            toggleButton(button3);
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            ShowInfo();

        }

        private void ShowInfo()
        {
            label1.Text = InfoFormPrice.CurrentTitle;
            progressBar1.Maximum = InfoFormPrice.MaxProgressBar;
            progressBar1.Value = InfoFormPrice.CurrentProgressBar;
        }

        private void toggleButton(Button Tog)
        {
            if (Tog.Enabled) Tog.Enabled = false;
            else Tog.Enabled = true;
        }
    }
}