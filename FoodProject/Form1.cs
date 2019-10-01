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
using FoodProject.lib.excel;

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

        private void Select_Excel_File_Btn_Click(object sender, System.EventArgs e)
        {
            string fname = "";
            openFileDialog1.Title = "Excel File Dialog";
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog1.FileName;
            }

            Excel_Import excel_Import = new Excel_Import();
            excel_Import.ReadExcel(fname);
        }
    }
}