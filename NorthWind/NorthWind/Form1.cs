using NorthWind.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Customers.Where(C =>  C.Country.ToLower() == "mexico").ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST1_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Select(c => new { c.ProductName,c.QuantityPerUnit }).ToList();
                
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST2_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Select(c => new {c.ProductId , c.ProductName }).ToList();

                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST3_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Where(c => c.Discontinued == true).Select(c => new { c.ProductId, c.ProductName }).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST4_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Select(c => new { c.ProductName,c.UnitPrice }).OrderByDescending(c => c.UnitPrice).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST5_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Where(c => c.UnitPrice < 20).Select(c => new { c.ProductId, c.ProductName, c.UnitPrice }).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST6_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Where(c => c.UnitPrice < 25 && c.UnitPrice > 15).Select(c => new { c.ProductId, c.ProductName, c.UnitPrice }).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST7_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Where(c => c.UnitPrice > DB.Products.Average(c => c.UnitPrice)).Select(c => new { c.ProductName, c.UnitPrice }).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST8_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Select(c => new { c.ProductName, c.UnitPrice }).OrderByDescending(c => c.UnitPrice).Take(10).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST9_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.GroupBy(c => c.Discontinued).Select(c => new { c.Key, V = c.Count() }).ToList() ;
                dataGridView1.DataSource = list;
            }
        }

        private void buttonQST10_Click(object sender, EventArgs e)
        {
            using (var DB = new NorthwindContext())
            {
                var list = DB.Products.Select(c => new {c.ProductName,c.UnitsOnOrder,c.UnitsInStock }).Where(c => c.UnitsInStock- c.UnitsOnOrder < 0).ToList();
                dataGridView1.DataSource = list;
            }
        }
    }
}
