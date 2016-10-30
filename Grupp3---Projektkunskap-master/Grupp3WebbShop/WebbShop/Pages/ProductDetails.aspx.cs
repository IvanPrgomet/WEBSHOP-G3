using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebbShop.Classes;

namespace WebbShop.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetsAndPopulateRepeater(CategoryRepeater, 1);
            GetsAndPopulateRepeater(ImageRepeater, 2);
            }
            
        }

        protected string CallConvertPics(object input)
        {
            return ImageHandler.ConvertingPics(input);
        }
        private void GetsAndPopulateRepeater(Repeater populateRepeater, int test)
        {
            string expr1 = (string)Session["Expr1"];
            int pCID = 0;
            int.TryParse((string)Session["ProductID"], out pCID);

            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksLT2012"].ConnectionString;
            SqlConnection sqlConnection =
                              new SqlConnection(connectionString);
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            if (test == 1)
            { 
                 sqlCommand = new SqlCommand(CheckIfNull(pCID, test), sqlConnection);
           
            
            }
            else if (test == 2)
            {
                 sqlCommand = new SqlCommand(CheckIfNull(pCID, test), sqlConnection);
            }
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                //CategoryRepeater.DataSource = sqlDataReader;
                //CategoryRepeater.DataBind();
                populateRepeater.DataSource = sqlDataReader;
                populateRepeater.DataBind();

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
        private string CheckIfNull(int pCID, int test)
        {
            string expr1 = (string)Session["Expr1"];
            string selectQuery = null;
            if (test == 1)
            { 
            

            selectQuery =
                "select * from(select *, row_number() over(partition by ProductModelID order by ProductModelID) as row_number from AdventureWorksLT2012.dbo.CustomView) as rows where ProductID = " + pCID + " AND culture='en'";

            return selectQuery;
            }
            else if (test == 2)
        {
            selectQuery =
                    "select * from(select *, row_number() over(partition by Color order by Color) as row_number from AdventureWorksLT2012.dbo.CustomView where Expr1 ='" + expr1 + "') as rows where row_number = 1 AND culture='en'";
            return selectQuery;
        }
            return selectQuery;

        }

        private void PopulateImageRepeater()
        {
            
        }

        private void PopulateColorDropDownList()
        {
           
        }

        protected void CategoryRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                MasterPage masterpage = (MasterPage)Page.Master;
                if (masterpage != null) masterpage.AddToShoppingCartList(int.Parse((string)e.CommandArgument));
                Session["ProductID"] = e.CommandArgument.ToString();
            }

            //SqlConnection sqlConnection = new SqlConnection("server=localhost;database=AdventureWorks2012; Integrated Security=true");
            //string selectQuery = "SELECT * FROM Production.ProductCategory";
            //SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
            //SqlDataReader sqlDataReader = null;
            ////list1.Items.Clear();
            //try
            //{
            //    sqlConnection.Open();
            //    sqlDataReader = sqlCommand.ExecuteReader();
            //    while (sqlDataReader.Read())
            //    {
            //        ListItem item = new ListItem(sqlDataReader["Name"].ToString(), sqlDataReader["ProductCategoryID"].ToString());



            //    }

            //}
            //catch (Exception)
            //{
            //    //Label1.Text = "Failed to get items from data base";
            //    //Label1.Visible = true;
            //}
            //finally
            //{
            //    if (sqlDataReader != null)
            //    {
            //        sqlDataReader.Close();
            //        sqlDataReader.Dispose();
            //    }
            //    sqlCommand.Dispose();
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
        }
    }
}