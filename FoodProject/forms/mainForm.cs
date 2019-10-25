using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodProject.lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FoodProject.DAL;
using FoodProject.DAL.Repositories;

namespace FoodProject
{
    public partial class mainForm : Form
    {
        protected IJavaScriptExecutor jsFirst;
        protected IJavaScriptExecutor jsSecond;
        protected ChromeDriver browserFirst;
        protected ChromeDriver browserSecond;
        Thread thrd;
        public mainForm()
        {
            InitializeComponent();
        }

        public void BrowserInitial2()
        {
            if (browserFirst != null) browserFirst.Close();
            if (browserSecond != null) browserSecond.Close();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            if(config.Default.BrowserOn != true)
                options.AddArgument("--headless");
            options.AddArguments("--lang=tr");

            browserFirst = new ChromeDriver(service, options);
            jsFirst = (IJavaScriptExecutor)browserFirst;

            browserSecond = new ChromeDriver(service, options);
            jsSecond = (IJavaScriptExecutor)browserSecond;
        }

        public void BrowserInitial1()
        {
            if (browserFirst != null) browserFirst.Close();
            if (browserSecond != null) browserSecond.Close();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            if (config.Default.BrowserOn != true)
                options.AddArgument("--headless");
            options.AddArguments("--lang=tr");

            browserFirst = new ChromeDriver(service, options);
            jsFirst = (IJavaScriptExecutor)browserFirst;
        }


        private void Button1_Click(object sender, System.EventArgs e)
        {
            BrowserInitial1();
            MigrosWeb mig = new MigrosWeb(browserFirst, jsFirst);
            thrd = new Thread(mig.price);
            thrd.Start();
            timer1.Start();



        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            BrowserInitial1();
            CarrefoursaWeb ca = new CarrefoursaWeb(browserFirst, jsFirst);
            thrd = new Thread(ca.price);
            thrd.Start();
            timer1.Start();

        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            thrd.Abort();

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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            /*
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            product.Name = "Erik";
            product.MarketId = 1;
            product.CategoryId = 1;
            Product product1 = productRepository.Add(product);
             */
        }


        private void Button4_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Altunbilekler mar = new Altunbilekler(browserFirst, jsFirst,browserSecond,jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();

        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Basgim mar = new Basgim(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Irmaklar mar = new Irmaklar(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Onur mar = new Onur(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Oruc mar = new Oruc(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Rota mar = new Rota(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Sekerciler mar = new Sekerciler(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Seyhanlar mar = new Seyhanlar(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            BrowserInitial2();
            Show mar = new Show(browserFirst, jsFirst, browserSecond, jsSecond);
            thrd = new Thread(mar.products);
            thrd.Start();
            timer1.Start();
        }
    }
}