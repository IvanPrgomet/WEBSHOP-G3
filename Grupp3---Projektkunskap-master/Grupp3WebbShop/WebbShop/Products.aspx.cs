using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using WebbShop.Classes;
using Image = System.Drawing.Image;
using WebbShop.Classes;

namespace WebbShop
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (Session["searchBarText"] != null)
            {
                SearchPopulateRepeater();
            }
            else
            {


                if (!IsPostBack)
                {
                    GetPriceFilltering();
                    SetPriceFilltering();
                    CategoryFilterMethod();
                    GetsAndPopulateRepeater();
                    GetMinAndMaxPrice();
                }
                if (Request.Form["__EVENTTARGET"] == "sliderEvent")
                {
                    OnPostBack();
                }
            }
        }
        private void GetMinAndMaxPrice()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand("select max(ListPrice) as maxPrice, min(ListPrice) as minPrice From AdventureWorksLT2012.dbo.CustomView", sqlConnection);
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var minmumPrice = sqlDataReader["minPrice"];
                    var maxmumPrice = sqlDataReader["maxPrice"];
                    Session["MaxValueForRange"] = "" + (Convert.ToInt32(Math.Round(Convert.ToDouble(maxmumPrice.ToString()))) + 100);
                    Session["MinValueForRange"] = "0";
                }

                Session["MaxValue"] = Session["MaxValueForRange"];
                Session["MinValue"] = Session["MinValueForRange"];
                maxPriceForRange.Value = (string)Session["MaxValueForRange"];
                minPriceForRange.Value = (string)Session["MinValueForRange"];
            }
            catch (Exception hh)
            {
                //Label1.Text = "Failed to get items from data base";
                //Label1.Visible = true;
                Response.Write(hh);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        private void SetPriceFilltering()
        {
            Session["MaxValue"] = maxPrice.Value;
            Session["MinValue"] = minPrice.Value;
        }

        private void GetPriceFilltering()
        {
            maxPrice.Value = (string)Session["MaxValue"];
            minPrice.Value = (string)Session["MinValue"];
        }

        private void GetsAndPopulateRepeater()
        {
            int pCID = 0;
            int.TryParse((string)Session["ProductCategoryID"], out pCID);

            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand(CheckIfNull(pCID), sqlConnection);
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                CategoryRepeater.DataSource = sqlDataReader;
                CategoryRepeater.DataBind();

            }
            catch (Exception hh)
            {
                //Label1.Text = "Failed to get items from data base";
                //Label1.Visible = true;
                Response.Write(hh);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        protected void CategoryFilterMethod()
        {
            int pCID = 0;
            int.TryParse((string)Session["ProductCategoryID"], out pCID);
            CategoryLable.Width = Unit.Percentage(100);
            if (!string.IsNullOrWhiteSpace((string)Session["ProductCategoryID"]))
            {
                CategoryLable.Text = (string)Session["ProductCategoryName"];
            }
            else
            {
                CategoryLable.Text = "Everything";
            }

            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            SqlCommand sqlCommand2 = new SqlCommand(CheckIfNullFilter(pCID), sqlConnection);
            SqlDataReader sqlDataReader = null;





            try
            {

                sqlConnection.Open();
                sqlDataReader = sqlCommand2.ExecuteReader(CommandBehavior.SequentialAccess);
                FilterCategoryRepeater.DataSource = sqlDataReader;
                FilterCategoryRepeater.DataBind();
                while (sqlDataReader.Read())
                {
                    FilterCategoryRepeater.DataSource = sqlDataReader;

                    FilterCategoryRepeater.DataBind();
                }
            }
            catch (Exception hh)
            {
                //Label1.Text = "Failed to get items from data base";
                //Label1.Visible = true;
                Response.Write(hh);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();

                }
                sqlCommand2.Dispose();
                sqlConnection.Close();
            }
        }

        private string CheckIfNullFilter(int pCID)
        {

            string selectQuery = null;
            if (pCID != 0 && pCID < 5)
            {
                Session["CurrentParentID"] = "" + pCID;
                selectQuery = "select ProductCategoryID, Name  from AdventureWorksLT2012.SalesLT.ProductCategory where ParentProductCategoryID = " + pCID + " ORDER BY ProductCategoryID";
                // "select* from(select ProductCategoryID, Expr3, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1 and ProductCategoryID = " + pCID;
                return selectQuery;
            }
            else if (!string.IsNullOrWhiteSpace((string)Session["CurrentParentID"]))
            {
                int currentParentID = 0;
                int.TryParse((string)Session["CurrentParentID"], out currentParentID);
                selectQuery = "select ProductCategoryID, Name  from AdventureWorksLT2012.SalesLT.ProductCategory where ParentProductCategoryID = " + currentParentID + " ORDER BY ProductCategoryID";
                // "select* from(select ProductCategoryID, Expr3, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1 and ProductCategoryID = " + currentParentID;
            }
            else
                selectQuery = "select ProductCategoryID, Name  from AdventureWorksLT2012.SalesLT.ProductCategory ORDER BY ProductCategoryID";
            //"select* from(select ProductCategoryID, Expr3, row_number() over(partition by ProductCategoryID order by ProductCategoryID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1  ORDER BY ProductCategoryID";

            return selectQuery;
        }

        //protected static string ConvertingPics(object input)
        //{
        //    var test = (byte[])input;
        //    MemoryStream imageStream = new MemoryStream(test);
        //    var base64 = Convert.ToBase64String(imageStream.ToArray());
        //    return ("data:image/gif;base64," + base64);
        //}

        private string CheckIfNull(int pCID)
        {

            int maxPrice = 200;
            int minPrice = 0;
            int.TryParse((string)Session["MinValue"], out minPrice);
            int.TryParse((string)Session["MaxValue"], out maxPrice);
            string selectQuery = null;
            if (pCID != 0 && pCID < 5)
            {
                selectQuery =
                    "select * from( select *, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1 and ParentProductCategoryID = " +
                    pCID + " and ListPrice <= " + maxPrice + " and ListPrice >= " + minPrice; //+ " AND Culture = 'en'";
                return selectQuery;
            }
            else if (pCID > 4)
            {
                selectQuery =
                    "select * from( select *, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1 and ProductCategoryID = " +
                    pCID + " and ListPrice <= " + maxPrice + " and ListPrice >= " + minPrice; //+ " AND Culture = 'en'";
                return selectQuery;
            }
            else
                selectQuery =
                    "select * from( select *, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1 and ListPrice <= " + maxPrice + " and ListPrice >= " + minPrice;

            return selectQuery;


        }
        protected void LinkButtonCategoryFilter_Command(object sender, CommandEventArgs e)
        {
            int thisID = 0;
            int.TryParse(e.CommandArgument.ToString(), out thisID);
            if (thisID == 1)
            {
                string categoryName = "Bikes";
                Session["ProductCategoryName"] = categoryName;
            }
            else if (thisID == 2)
            {
                string categoryName = "Components";
                Session["ProductCategoryName"] = categoryName;
            }
            else if (thisID == 3)
            {
                string categoryName = "Clothing";
                Session["ProductCategoryName"] = categoryName;
            }
            else if (thisID == 4)
            {
                string categoryName = "Accessories";
                Session["ProductCategoryName"] = categoryName;
            }
            Session["ProductCategoryID"] = e.CommandArgument;
            OnPostBack();
        }

        protected string OnPostBack()
        {
            SetPriceFilltering();
            GetPriceFilltering();
            CategoryFilterMethod();
            GetsAndPopulateRepeater();
            return "Jakob";
        }

        protected void CategoryRepeater_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cartButton")
            {
                MasterPage masterpage = (MasterPage)Page.Master;
                //Button addCartButton = (Button) e.Item.FindControl("cartButton");
                //masterpage.ShowShoppingCartContents(int.Parse((string)e.CommandArgument));
                masterpage.AddToShoppingCartList(int.Parse((string)e.CommandArgument));
                Session["ProductID"] = e.CommandArgument.ToString();
                //Response.Redirect("/Pages/ProductDetails.aspx");
            }
            else if (e.CommandName == "hiddenButton")
            {
                
                Session["ProductID"] = e.CommandArgument.ToString().Substring(0,e.CommandArgument.ToString().IndexOf(','));
                Session["Expr1"] = e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf(',') + 1, e.CommandArgument.ToString().Length - 4);
                Response.Redirect("/Pages/ProductDetails.aspx");
            }
            {

            }
        }
        protected string test(object input)
        {
            return ImageHandler.ConvertingPics(input);
        }
        private void SearchPopulateRepeater()
        {
            string searchText = (string)Session["searchBarText"];

            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            string sqlQuery = "SELECT * FROM dbo.CustomView WHERE Name LIKE '%" + searchText + "%'";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                CategoryRepeater.DataSource = sqlDataReader;
                CategoryRepeater.DataBind();

            }
            catch (Exception hh)
            {
                //Label1.Text = "Failed to get items from data base";
                //Label1.Visible = true;
                Response.Write(hh);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }
}


