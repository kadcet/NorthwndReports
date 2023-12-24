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


            var report = (from category in context.Categories
                          join product in context.Products on category.CategoryID equals product.CategoryID
                          join orderdetail in context.OrderDetails on product.ProductID equals orderdetail.ProductID
                          group new { category, product, orderdetail } by new { category.CategoryName, orderdetail.UnitPrice } into grp

                          select new CategoryOrderDetailVM
                          {
                              Kategori = grp.Key.CategoryName,
                              Satis = grp.Sum(x => x.orderdetail.UnitPrice),

                          });
            grdReport.DataSource = report.ToList();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Hangi kategorideki hangi üründen kaç TL lik satış yapılmış
            NorthwndDBContext dbContext = new NorthwndDBContext();
            var query = from ct in dbContext.Categories
                        join pr in dbContext.Products on ct.CategoryID equals pr.CategoryID
                        join od in dbContext.OrderDetails on pr.ProductID equals od.ProductID
                        group new { ct, pr, od } by new { ct.CategoryName, pr.ProductName } into groupedData
                        select new ProductOrderDetailVM
                        {
                            Kategori = groupedData.Key.CategoryName,
                            Urun = groupedData.Key.ProductName,
                            Fiyat = groupedData.Sum(x => x.od.UnitPrice)
                        };

            grdReport.DataSource = query.ToList();
        }
    }
}