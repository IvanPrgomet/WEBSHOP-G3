using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebbShop
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetBillingInfo();
        }

        private void GetBillingInfo()
        {
            firstName.Text = firstName.Text + Session["FirstName"].ToString();
            lastName.Text = lastName.Text + Session["LastName"].ToString();
            adress.Text = adress.Text + Session["Adress"].ToString();
            city.Text = city.Text + Session["City"].ToString();
            zip.Text = zip.Text + Session["Zip"].ToString();
            phoneNumber.Text = phoneNumber.Text + Session["PhoneNumber"].ToString();
            email.Text = email.Text + Session["Email"].ToString();
            delivery.Text = delivery.Text + Session["Delivery"].ToString();
            cardOption.Text = cardOption.Text + Session["PaymentList"].ToString();
            //subTotal.Text = subTotal.Text + Session["ShoppingTotalCost"].ToString() + "kr";
            //shipping.Text = shipping.Text + Session["Delivery"].ToString() + "kr";
            //totalCost.Text = totalCost.Text + Session["TotalCost"].ToString() + "kr";
            //cartItems.Text = cartItems.Text + Session["ItemsInShoppingCart"].ToString();
            Session["SavedProductList"] = null;
        }
    }
}