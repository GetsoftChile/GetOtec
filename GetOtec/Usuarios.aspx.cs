using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using ENT;

namespace GetOtec
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    Buscar();
                    BuscarMandantes();
                    BuscarPerfil();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void Buscar()
        {
            Usuario user = new Usuario();
            grvUsuarios.DataSource = dal.GetBuscarUsuario(user);
            grvUsuarios.DataBind();
            grvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


        void BuscarMandantes()
        {
            Mandante man = new Mandante();
            man.Activo = 1;
            chkMandantes.DataSource = dal.GetBuscarMandante(man);
            chkMandantes.DataTextField = "NomMandante";
            chkMandantes.DataValueField = "IdMandante";
            chkMandantes.DataBind();
        }

        void BuscarPerfil()
        {
            Perfil per = new Perfil();
            ddlPerfil.DataSource = dal.GetBuscarPerfil(per);
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataTextField = "NomPerfil";
            ddlPerfil.DataBind();
        }

        public void limpiar(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    limpiar(control.Controls);
            }

            chkMandantes.ClearSelection();
        }



        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuLogo.HasFile)
                {
                    Usuario user = new Usuario();
                    string carpeta = "Assets/template/img/usuario/" + "logo_" + hfIdUsuario.Value + "_" + fuLogo.FileName;
                    fuLogo.SaveAs(Server.MapPath(carpeta));
                    //int IdUsuario = Convert.ToInt16(hfIdUsuario.Value);
                    user.Foto = carpeta;
                    user.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
                    dal.SetUpFotoUsuario(user);
                    //string idUsuario = Session["variableIdUsuario"].ToString();

                    //cambia inmediatamente si es el usuario actual.
                    if (Session["variableIdUsuario"].ToString() == hfIdUsuario.Value)
                    {
                        Session["variableImagenUsuario"] = carpeta;
                        imgLogo.Src = carpeta;
                    }
                    imgLogo.Src = carpeta;
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }


        protected void ddlPerfil_DataBound(object sender, EventArgs e)
        {
            ddlPerfil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                
                limpiar(this.Controls);
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdUsuario = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdUsuario");

                user.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                hfIdUsuario.Value = _lblIdUsuario.Text;

                DataTable dt = new DataTable();
                dt = dal.GetBuscarUsuario(user).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    txtRut.Text = item["Rut"].ToString();
                    txtNombre.Text = item["Nombre"].ToString();
                    txtLogin.Text = item["Login"].ToString();
                    txtEmail.Text = item["Email"].ToString();
                    txtClave.Attributes.Add("Value", item["Clave"].ToString());
                    txtAreaCargo.Text = item["AreaCargo"].ToString();
                    if (item["IdPerfil"].ToString() != string.Empty)
                    {
                        ddlPerfil.SelectedValue = item["IdPerfil"].ToString();
                    }
                    if (item["Activo"].ToString() != string.Empty)
                    {
                        ddlActivo.SelectedValue = item["Activo"].ToString();
                    }
                    imgLogo.Src = item["foto"].ToString();



                }

                foreach (DataRow item in dal.GetBuscarUsuarioMandante(user).Tables[0].Rows)
                {
                    string idCliente = Convert.ToString(item["IdMandante"]);
                    foreach (ListItem fila in chkMandantes.Items)
                    {
                        if (idCliente == fila.Value.ToString())
                        {
                            fila.Selected = true;
                        }
                    }
                }

                divImagenLogo.Visible = true;

                divSearch.Visible = false;
                divAddEdit.Visible = true;
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _lblIdUsuario = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdUsuario");
                user.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                userMan.IdUsuario = Convert.ToInt32(_lblIdUsuario.Text);
                dal.SetDelMensajes(user);
                dal.SetDelUsuarioMandante(userMan);
                dal.SetDelUsuario(user);

                Buscar();

                lblInformacion.Text = "Usuario Eliminado Correctamente";
                mdlInformacion.Show();
                
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {

            try
            {
                limpiar(this.Controls);
                divSearch.Visible = false;
                divAddEdit.Visible = true;
                hfIdUsuario.Value = string.Empty;
                divImagenLogo.Visible = false;
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioMandante userMan = new UsuarioMandante();

                user.Activo = Convert.ToInt32(ddlActivo.SelectedValue);
                user.AreaCargo = txtAreaCargo.Text;
                user.Clave = txtClave.Text;
                user.Email = txtEmail.Text;
                //if (fuLogo.HasFile)
                //{
                //    string carpeta = "assets/img/usuario/" + "logo_" + hfIdUsuario.Value + "_" + fuLogo.FileName;
                //    fuLogo.SaveAs(Server.MapPath(carpeta));
                //    user.Foto = carpeta;
                //}
                user.IdPerfil = Convert.ToInt32(ddlPerfil.SelectedValue);
                //user.IdUsuario 
                user.Login = txtLogin.Text;
                user.Nombre = txtNombre.Text;
                user.Rut = txtRut.Text;
                if (txtIdUsuarioDiscador.Text != string.Empty)
                {
                    user.IdUsuarioDiscador = Convert.ToInt32(txtIdUsuarioDiscador.Text);
                }

                //Nuevo o Editar
                if (hfIdUsuario.Value == string.Empty)
                {
                    //Nuevo
                    DataTable dtUser = new DataTable();
                    dtUser = dal.GetBuscarValUsuario(user).Tables[0];

                    if (dtUser.Rows.Count != 0)
                    {
                        lblInformacion.Text = "El usuario " + user.Login + " existe en la bd";
                        mdlInformacion.Show();
                        return;
                    }

                    user.IdUsuario = Convert.ToInt32(dal.SetInUpUsuario(user));
                    userMan.IdUsuario = user.IdUsuario;

                    foreach (ListItem item in chkMandantes.Items)
                    {
                        if (item.Selected == true)
                        {
                            string valorCheckIdCliente = item.Value;
                            userMan.IdMandante = Convert.ToInt32(valorCheckIdCliente);
                            dal.SetInUsuarioMandante(userMan);
                        }
                    }
                }
                else
                {
                    //Edición
                    user.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
                    Convert.ToInt32(dal.SetInUpUsuario(user));
                    userMan.IdUsuario = user.IdUsuario;
                    dal.SetDelUsuarioMandante(userMan);
                    foreach (ListItem item in chkMandantes.Items)
                    {
                        if (item.Selected == true)
                        {
                            string valorCheckIdCliente = item.Value;
                            userMan.IdMandante = Convert.ToInt32(valorCheckIdCliente);
                            dal.SetInUsuarioMandante(userMan);
                        }
                    }
                }

                Buscar();
                divSearch.Visible = true;
                divAddEdit.Visible = false;
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                //limpiar();
                divSearch.Visible = true;
                divAddEdit.Visible = false;
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
    }
}