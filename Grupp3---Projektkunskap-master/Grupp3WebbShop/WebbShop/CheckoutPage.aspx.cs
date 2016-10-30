using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using WebbShop.Classes;

namespace WebbShop
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.Text = "Proceed checkout";
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            GetCartInfo();



        }

        private void GetCartInfo()
        {
            List<CustomerWares> customerWareses = new List<CustomerWares>();
            if (Session["CustomerWares"] != null)
            {
                customerWareses = (List<CustomerWares>)Session["CustomerWares"];
            }
            //orderShipping.Text = orderShipping.Text.Replace(orderShipping.Text, "Shipping: " + checkoutDelivery.Text);
            //orderSubtotal.Text = orderSubtotal.Text.Replace(orderSubtotal.Text, "Order Subtotal: " + Session["ShoppingTotalCost"].ToString());
            //cartItemAmount.Text = cartItemAmount.Text.Replace(cartItemAmount.Text, "Total number of items: " + customerWareses.Count.ToString());
            //orderTotal.Text = orderTotal.Text.Replace(orderTotal.Text, "Order total: " + (Convert.ToDouble(Session["ShoppingTotalCost"]) + Convert.ToDouble(checkoutDelivery.SelectedValue)));
        }
        
        protected void submitButton_Click(object sender, EventArgs e)
        {
            submitButton.CausesValidation = true;
            SetBillingInfo();
            Response.Redirect("ConfirmationPage.aspx");
        }

        private void SetBillingInfo()
        {
            Session["FirstName"] = checkoutFirstname.Text;
            Session["LastName"] = checkoutLastname.Text;
            Session["Adress"] = checkoutAdress.Text;
            Session["City"] = checkoutCity.Text;
            Session["Zip"] = checkoutZip.Text;
            Session["PhoneNumber"] = checkoutPhonenumber.Text;
            Session["Email"] = checkoutEmail.Text;
            Session["Delivery"] = checkoutDelivery.Text;
            Session["PaymentList"] = paymentList.Text;
            Session["TotalCost"] = orderTotal.Text;
        }

        protected void checkoutDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderShipping.Text = orderShipping.Text.Replace(orderShipping.Text, "Shipping: " + checkoutDelivery.Text);
            orderTotal.Text = orderTotal.Text.Replace(orderTotal.Text, "Order total: " + (Convert.ToDouble(Session["ShoppingTotalCost"]) + Convert.ToDouble(checkoutDelivery.SelectedValue)));
        }
    }
}