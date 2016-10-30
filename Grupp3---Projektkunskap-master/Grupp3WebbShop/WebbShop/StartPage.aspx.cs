using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbShop.Classes;

namespace WebbShop
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulatePopularProductsRepeater();
                PopulateAsideRepeater();
            }
        }

        private void PopulatePopularProductsRepeater()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand("select top 16 * from(select *, row_number() over(partition by ProductCategoryID order by ProductCategoryID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1", sqlConnection);
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                ProductRepeater.DataSource = sqlDataReader;
                ProductRepeater.DataBind();

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
        private void PopulateAsideRepeater()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand("select top 5 * from(select *, row_number() over(partition by ProductCategoryID order by NEWID()) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where row_number = 1", sqlConnection);
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                RepeaterAside.DataSource = sqlDataReader;
                RepeaterAside.DataBind();

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
        protected void ProductRepeater_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cartButton")
            {
                MasterPage masterpage = (MasterPage)Page.Master;
                //Button addCartButton = (Button) e.Item.FindControl("cartButton");
                masterpage.AddToShoppingCartList(int.Parse((string)e.CommandArgument));
                Session["ProductID"] = e.CommandArgument.ToString();
                //Response.Redirect("/Pages/ProductDetails.aspx");
            }
            else if (e.CommandName == "hiddenButton")
            {
                Session["ProductID"] = e.CommandArgument.ToString();
                Response.Redirect("/Pages/ProductDetails.aspx");
            }

            {

            }

        }
        protected void AsideRepeater_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cartButton")
            {
                MasterPage masterpage = (MasterPage)Page.Master;
                //Button addCartButton = (Button) e.Item.FindControl("cartButton");
                masterpage.AddToShoppingCartList(int.Parse((string)e.CommandArgument));
                Session["ProductID"] = e.CommandArgument.ToString();
                //Response.Redirect("/Pages/ProductDetails.aspx");
            }
            else if (e.CommandName == "hiddenButton")
            {
                Session["ProductID"] = e.CommandArgument.ToString();
                Response.Redirect("/Pages/ProductDetails.aspx");
            }

            {

            }

        }
        protected string test(object input)
        {
            return ImageHandler.ConvertingPics(input);
        }
    }
}