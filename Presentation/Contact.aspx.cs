using Domain.Models;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Contact : Page
    {
        private static int _id=0;
        private EmployeeModel _employee = new EmployeeModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               if( Request.QueryString["Id"] != null)
                {
                    _id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                    
                    if(_id != 0)
                    {
                        lblTitle.Text = "Editar Empleado";
                        btnSubmit.Text = "Actualizar";
                        _employee = _employee.GetEmployeeById(_id);
                        txtName.Text = _employee.Name;
                        txtLastName.Text = _employee.LastName;
                        txtEmail.Text = _employee.Email;
                        txtSalary.Text = _employee.Salary.ToString();
                      
                        


                    }
                    else
                    {

                        lblTitle.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Guardar";
                      
                    }

                }
                else
                {
                    Response.Redirect($"~/Default.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EmployeeModel entidad = new EmployeeModel()
            {
                Id = _id,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Salary = Convert.ToDecimal(txtSalary.Text),
                
            };

            if (_id != 0)
            {
                entidad.State = EntityState.Modified;
            }
            else
            {
                entidad.State = EntityState.Added;
            }
            bool valid = new Helpers.DataValidation(entidad).Validate();

            if (valid)
            {
                string result = entidad.SaveChanges();
                MessageBox.Show( result );
                Response.Redirect($"~/Default.aspx");

            }


        }
    }
}