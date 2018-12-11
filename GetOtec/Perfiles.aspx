<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="GetOtec.Perfiles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="breadcrumb sl-breadcrumb">
        <a class="breadcrumb-item" href="#">Administración</a>
        <span class="breadcrumb-item active">Perfiles</span>
    </nav>


    <div class="sl-pagebody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="row" id="divSearch" runat="server">
                    <div class="col-lg-12">

                        <div class="card rounded-10">
                            <div class="card-header card-header-default justify-content-between">
                                <h6 class="mg-b-0 tx-14 tx-white tx-normal">PERFILES</h6>
                                <div class="card-option">
                                    <asp:LinkButton ID="BtnNew" OnClick="BtnNew_Click" runat="server" CssClass="btn btn-success active btn-icon rounded-circle mg-r-auto mg-b-auto" data-toggle="tooltip" data-placement="top" title="Crear un nuevo usuario">
                                    <%--<span class="fa fa-plus"></span>--%>
                                    <div><i class="fa fa-plus"></i></div>
                                    </asp:LinkButton>

                                </div>
                                <!-- card-option -->

                            </div>
                            <!-- card-header -->

                            
                            <asp:GridView ID="GrvPerfiles" OnRowDataBound="GrvPerfiles_RowDataBound" runat="server" BorderColor="Transparent" CssClass="table table-hover table-sm table-responsive  table-info mg-b-0 tx-12"
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblIdPerfil" runat="server" Text='<%# Bind("IdPerfil") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Perfil">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPerfil" runat="server" Text='<%# Bind("NomPerfil") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Activo">
                                        <ItemTemplate>
                                            <asp:Label ID="LblActivo" runat="server" Visible="true" Text='<%# Bind("Activo") %>'></asp:Label>
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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
