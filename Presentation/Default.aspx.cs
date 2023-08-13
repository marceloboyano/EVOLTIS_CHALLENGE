using Domain.Models;
using Domain.ValueObjects;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Presentation
{
    public partial class _Default : Page
    {
        private EmployeeModel _employee = new EmployeeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListEmployees();
        }
        private void ListEmployees()
        {
            try
            {
                GVEmployee.DataSource = _employee.GetAll();
                GVEmployee.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());

            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Contact.aspx?Id=0");


        }


        protected void Update_Click(object sender, EventArgs e)
        {


            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            Response.Redirect($"~/Contact.aspx?Id={id}");

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;

                string id = btn.CommandArgument;
                _employee.State = EntityState.Deleted;
                _employee.Id = Convert.ToInt32(id);
                string response = _employee.SaveChanges();
                ListEmployees();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }

        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GVEmployee.DataSource = _employee.GetEmployeeByName(txtSearch.Text);
                GVEmployee.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());

            }
        }

    }
}