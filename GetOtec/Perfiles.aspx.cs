using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;

namespace GetOtec
{
    public partial class Perfiles : System.Web.UI.Page
    {
        PerfilAccess PerfilDal = new PerfilAccess();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BuscarPerfil();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void BuscarPerfil()
        {
            Perfil per = new Perfil();
            GrvPerfiles.DataSource = PerfilDal.GetBuscarPerfil(per);
            GrvPerfiles.DataBind();
            GrvPerfiles.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void GrvPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _LblActivo = (Label)e.Row.FindControl("LblActivo");

                if (_LblActivo.Text == "1")
                {
                    _LblActivo.Text = "Si";
                }
                else
                {
                    _LblActivo.Text = "No";
                }
            }
        }
    }
}