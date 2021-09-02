<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Evento.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function MostrarPopupMensagem() {
            $("#modalMsg").modal('show');
        }
        function EsconderPopupDados() {
            $("#modalDados").modal('hide');
        }
    </script>
    <div class="modal fade" id="modalMsg">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">

                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>

                    <h4 class="modal-title" id="h1" runat="server">Modal title</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <label id="lblMsgPopup" runat="server">
                        </label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
    <div style="margin: 1%">
        <form runat="server">
            <asp:GridView ID="GVEventos" runat="server" CellPadding="4" CssClass="table" ForeColor="#333333"
                GridLines="None" OnRowCommand="GVEventos_RowCommand" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="Data" HeaderText="Data" />
                    <asp:BoundField DataField="QtdPessoas" HeaderText="Quantidade de Pessoas" />
                    <asp:BoundField DataField="QtdMaxPermitida" HeaderText="Quantidade Máxima Permitida" />
                    <asp:BoundField DataField="ValorPorPessoa" HeaderText="Valor por Pessoa" />
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR"
                                CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" />
                            <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR"
                                CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </form>
    </div>
</asp:Content>
