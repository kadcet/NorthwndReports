using Microsoft.EntityFrameworkCore;
using WinFormUI.Data;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hangi kategoriden kaç TL lik satış yapılmış
            NorthwndDBContext context = new NorthwndDBContext();

            var report = (from product in context.Set<Product>()
                          join category in context.Set<Category>()
                                 on product.CategoryID equals category.CategoryID
                          join orderdetail in context.Set<OrderDetail>() 
                          on product.ProductID equals orderdetail.ProductID
                          group product by product.ProductName into g
                          // group category by category.CategoryName into g
                          select new 
                          {
                              
                              g.Key, Count=g.Count(),

                          }) ;

            grdReport.DataSource = report.ToList();


        }
    }
}