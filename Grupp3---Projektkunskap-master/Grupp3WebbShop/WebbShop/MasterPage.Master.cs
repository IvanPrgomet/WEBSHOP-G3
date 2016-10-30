using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebbShop.Classes;

namespace WebbShop
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DrawShoppingCart();
            }

            HandleMenuButtons();
            
        }

        protected void DrawShoppingCart()
        {
            List<CustomerWares> customerWareses = new List<CustomerWares>();
            if (Session["CustomerWares"] != null)
            {
                customerWareses = Session["CustomerWares"] as List<CustomerWares>;
                showItemsInCart.Text = customerWareses.Count.ToString();

            }
            else
            {
                Session["CustomerWares"] = null;
                showItemsInCart.Text = "0";
            }
            
            ShoppingCartRepeater.DataSource = customerWareses;
            ShoppingCartRepeater.DataBind();
        }
        internal void AddToShoppingCartList(int itemID, int amount = 1)
        {
            List<CustomerWares> customerWareses = new List<CustomerWares>();
            if (Session["CustomerWares"] != null)
            {
                customerWareses = (List<CustomerWares>)Session["CustomerWares"];
            }
            using (var shoppingCartSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString))
            {
                shoppingCartSqlCon.Open();
                string sqlProductQuery = "SELECT * From SalesLT.Product WHERE ProductID = '" + itemID + "'";

                using (SqlCommand productIdCmd = new SqlCommand(sqlProductQuery, shoppingCartSqlCon))
                {
                    using (SqlDataReader productIdReader = productIdCmd.ExecuteReader())
                    {
                        //double total =double.Parse(Session["total"].ToString());
                        productIdReader.Read();
                        customerWareses.Add(new CustomerWares() { Amount = amount, Id = itemID, Name = productIdReader["Name"].ToString(), Price = double.Parse(productIdReader["ListPrice"].ToString()) });
                        //total += double.Parse(productIdReader["ListPrice"].ToString());
                        //Session["total"] = total;
                    }
                }
            }
            Session["CustomerWares"] = customerWareses;
            DrawShoppingCart();
        }

        //public string CalculateTotal()
        //{
        //    List<CustomerWares> customerWareses = new List<CustomerWares>();
        //    customerWareses = (List<CustomerWares>)Session["CustomerWares"];
        //    double total=customerWareses.ForEach()
        //    //double sum;
        //    //foreach (var Price in calc)
        //    //{
        //    //    sum += (double)calc.Price;
        //    //}
        //    return "a";
        //}
        private void HandleMenuButtons()
        {
            ImageButton bikeButton = (ImageButton)FindControl("bikeCategoryButton");
            bikeButton.Click += BikeButton_Click;
            ImageButton accessoryButton = (ImageButton)FindControl("bikeAccessoriesButton");
            accessoryButton.Click += AccessoriesButton_Click;
            ImageButton clothingButton = (ImageButton)FindControl("bikeClothingButton");
            clothingButton.Click += ClothingButton_Click;
            ImageButton componentButton = (ImageButton)FindControl("bikeComponentsButton");
            componentButton.Click += ComponentButton_Click;
        }
        private void ComponentButton_Click(object sender, ImageClickEventArgs e)
        {
            string category = "2";
            string categoryName = "Components";
            Session["ProductCategoryName"] = categoryName;
            Session["ProductCategoryID"] = category;
            Response.Redirect("/Products.aspx");
        }

        private void ClothingButton_Click(object sender, ImageClickEventArgs e)
        {
            string category = "3";
            string categoryName = "Clothing";
            Session["ProductCategoryName"] = categoryName;
            Session["ProductCategoryID"] = category;
            Response.Redirect("/Products.aspx");
        }

        private void AccessoriesButton_Click(object sender, ImageClickEventArgs e)
        {
            string category = "4";
            string categoryName = "Accessories";
            Session["ProductCategoryName"] = categoryName;
            Session["ProductCategoryID"] = category;
            Response.Redirect("/Products.aspx");
        }

        private void BikeButton_Click(object sender, ImageClickEventArgs e)
        {
            string category = "1";
            string categoryName = "Bikes";
            Session["ProductCategoryName"] = categoryName;
            Session["ProductCategoryID"] = category;
            Response.Redirect("/Products.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Session["searchBarText"] = searchBar.Text;
            Response.Redirect("/Products.aspx");
        }

        protected void ShoppingCartRepeater_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ClearCart")
            {
                Session.Remove("CustomerWares");
                DrawShoppingCart();
            }else if (e.CommandName == "DeleteItem")
            {
                List<CustomerWares> customerWareses = new List<CustomerWares>();
                customerWareses = Session["CustomerWares"] as List<CustomerWares>;
                if (customerWareses != null) customerWareses.RemoveAll(item => item.Id == int.Parse(e.CommandArgument.ToString()));
                Session["CustomerWares"] = customerWareses;
                DrawShoppingCart();
            }

        }
    }
}