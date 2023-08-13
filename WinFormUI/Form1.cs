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


			//var report = (from product in context.Products
			//			  join category in context.Categories
			//					 on product.CategoryID equals category.CategoryID
			//			  join orderdetail in context.OrderDetails
			//			  on product.ProductID equals orderdetail.ProductID
			//			  //group product by new {product.ProductName,orderdetail.Quantity} into grp
			//			  group product by new { category, orderdetail } into grp
			//			  select new
			//			  {
							 
			//				cc= grp.Sum(x=> x),
							  
			//			  });

			var report=context.Products
			 .Join(context.OrderDetails,
			 product=>product.ProductID,
			 orderDetail=>orderDetail.ProductID,
			 (product, orderDetail) => new
			 {
				 Category=product.Category.CategoryName,
				 ProductName = product.ProductName,
				 Price=orderDetail.UnitPrice * orderDetail.Quantity,
			 })
			 .GroupBy(result=>result.ProductName)
			 .Select(group => new
			 {
				 
				 ProductName= group.Key,
				 Price=group.Sum(result=>result.Price)
			 }
			 ).ToList();


			grdReport.DataSource = report.ToList();


		}

		

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwndDBContext context = new NorthwndDBContext();
            var report2 = context.Categories
			 .GroupJoin(context.Products,
			 category => category.CategoryID,
			 product => product.CategoryID,
			 (category, product) => new 
             {
                 CategoryName = category.CategoryName,
                 Product = product
             })

			.SelectMany(result=>result.Product.DefaultIfEmpty(),
			(result, product) => new
			{
				result.CategoryName,
				
				ProductName=product !=null ? product.ProductName:"No Product",
				TotalPrice=context.OrderDetails.Sum(orderProduct=>orderProduct.UnitPrice * orderProduct.Quantity)
			}).ToList();
			

            grdReport.DataSource = report2.ToList();
			
		}
	}
}