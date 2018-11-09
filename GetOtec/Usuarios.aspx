<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="GetOtec.Usuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="breadcrumb sl-breadcrumb">
        <a class="breadcrumb-item" href="#">Administración</a>
        <span class="breadcrumb-item active">Usuarios</span>
    </nav>


    <div class="sl-pagebody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="row" id="divSearch" runat="server">
                    <div class="col-lg-12">

                        <div class="card rounded-10">
                            <div class="card-header card-header-default justify-content-between">
                                <h6 class="mg-b-0 tx-14 tx-white tx-normal">USUARIOS</h6>
                                <div class="card-option">
                                    <asp:LinkButton ID="BtnNew" OnClick="BtnNew_Click" runat="server" CssClass="btn btn-success active btn-icon rounded-circle mg-r-auto mg-b-auto" data-toggle="tooltip" data-placement="top" title="Crear un nuevo usuario">
                                    <%--<span class="fa fa-plus"></span>--%>
                                    <div><i class="fa fa-plus"></i></div>
                                    </asp:LinkButton>

                                </div>
                                <!-- card-option -->

                            </div>
                            <!-- card-header -->

                            <asp:GridView ID="grvUsuarios" runat="server" BorderColor="Transparent" CssClass="table table-hover table-sm table-responsive  table-info mg-b-0 tx-12"
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rut">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFoto" runat="server" Text='<%# Bind("foto") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblRut" runat="server" Text='<%# Bind("Rut") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                                    <asp:TemplateField HeaderText="Login">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLogin" runat="server" Visible="true" Text='<%# Bind("Login") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="NomPerfil" HeaderText="Perfil" />
                                    <asp:BoundField DataField="AreaCargo" HeaderText="Area Cargo" />
                                    <asp:TemplateField HeaderText="Activo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActivo" runat="server" Visible="false" Text='<%# Bind("Activo") %>'></asp:Label>
                                            <asp:Label ID="lblActivo2" runat="server" Text='<%# Bind("Activo2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Width="7%">
                                        <ItemTemplate>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <asp:LinkButton ID="BtnEditar" OnClick="BtnEditar_Click" runat="server" data-toggle="tooltip" data-placement="left" title="Eliminar Registro" CssClass="btn btn-sm btn-secondary btn-warning pestana" ToolTip="Editar Registro"><i class="fa fa-edit"></i></asp:LinkButton>
                                                <asp:LinkButton ID="BtnEliminar" OnClick="BtnEliminar_Click" CssClass="btn btn-sm btn-secondary btn-danger pestana" data-toggle="tooltip" data-placement="left" title="Eliminar Registro" OnClientClick="return confirm('¿Desea eliminar el registro?');" runat="server" ToolTip="Eliminar Registro"><i class="fa fa-trash"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <!-- card-body -->
                        </div>
                        <!-- card -->


                    </div>
                </div>




                <div runat="server" id="divAddEdit" class="box box-danger" visible="false">


                    <div class="card pd-20 pd-sm-40">
                        <h6 class="card-body-title">Top Label Layout</h6>
                        <p class="mg-b-20 mg-sm-b-30">A form with a label on top of each form control.</p>
                        <div class="form-layout">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="form-control-label">Rut:<span class="tx-danger">*</span></label>
                                    <asp:TextBox ID="txtRut" MaxLength="12" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:HiddenField ID="hfIdUsuario" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label class="form-control-label">Nombre:<span class="tx-danger">*</span></label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtEmail" class="form-control-label">Email:<span class="tx-danger">*</span></label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlPerfil" class="form-control-label">Perfil:<span class="tx-danger">*</span></label>
                                    <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control input-sm" OnDataBound="ddlPerfil_DataBound">
                                    </asp:DropDownList>

                                </div>
                                <div class="form-group" runat="server" visible="false">
                                    <label for="ddlPerfil">Procurador</label>
                                    <asp:DropDownList ID="ddlProcurador" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- col-4 -->
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label for="txtLogin" class="form-control-label">Login:<span class="tx-danger">*</span></label>
                                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtClave" class="form-control-label">Clave:<span class="tx-danger">*</span></label>
                                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAreaCargo" class="form-control-label">Area Cargo:</label>
                                    <asp:TextBox ID="txtAreaCargo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group" runat="server" visible="false">
                                    <label for="txtAreaCargo">Id Usuario Discador</label>
                                    <asp:TextBox ID="txtIdUsuarioDiscador" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="ddlActivo" class="form-control-label">Activo:</label>
                                    <asp:DropDownList ID="ddlActivo" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4" id="divImagenLogo" runat="server" visible="false">
                                <div class="form-group">
                                    <label class="form-control-label" style="text-align: center">Fotografia:</label>
                                    <img runat="server" id="imgLogo" src="/" class="img-circle img-responsive" style="height: 160px; width: 160px" alt="" />
                                </div>
                                <div class="form-group">
                                    <label></label>
                                    <asp:FileUpload runat="server" CssClass="form-control" ID="fuLogo" />
                                </div>
                                <div class="form-group">
                                    <label></label>
                                    <asp:Button ID="btnSubirImagen" OnClick="btnSubirImagen_Click" CssClass="btn btn-info btn-sm" Text="Subir Imagen" runat="server" CausesValidation="false" />
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <div class="well well-sm">
                                            <label for="chkMandantes">Mandantes</label>
                                            <asp:CheckBoxList ID="chkMandantes" runat="server" Width="100%"
                                                RepeatColumns="6"
                                                RepeatDirection="Horizontal"
                                                TextAlign="Right">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-layout-footer">
                                <asp:Button ID="BtnGuardar" Text="Guardar" CssClass="btn btn-success" OnClick="BtnGuardar_Click" runat="server" />
                                <asp:Button ID="BtnCancelar" Text="Cancelar" CssClass="btn btn-default" OnClick="BtnCancelar_Click" runat="server" CausesValidation="false" />
                            </div>
                            <!-- form-layout-footer -->
                        </div>
                    </div>


                </div>


                <asp:Button ID="btnActivarPopUp" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="mdlInformacion" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlInformacion" TargetControlID="btnActivarPopUp" BehaviorID="_mdlInformacion">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlInformacion" runat="server" Style="display: none; background: white; width: 40%; height: auto">
                    <%--MODALPOPUP CON BOOTSTRAP--%>
                    <div class="modal">
                        <div class="modal-header">
                            <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                            <h3 id="myModalLabel">Informacion</h3>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                        </div>
                    </div>
                    <%--MODALPOPUP CON BOOTSTRAP--%>
                </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- sl-pagebody -->
    <%--
    <script type="text/javascript">
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#<%= UpdatePanel1.ClientID %>.[data-toggle="tooltip"]').tooltip();

            }
        }
    </script>--%>
    <%--<script type="text/javascript">
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#<%= UpdatePanel1.ClientID %> [data-toggle=""]').tooltip({placement: 'right', html: true, trigger: 'hover'});
            }
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
