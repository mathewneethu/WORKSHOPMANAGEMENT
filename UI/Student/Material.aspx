<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Material.aspx.cs" Inherits="Student_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>

        <td class="auto-style1">

     <asp:GridView ID="grdMaterial" runat="server" style="text-align: center" Width="100%" >
                    <Columns>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# Eval("MaterialPath") %>' Text="Download"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </td>

            </tr>
        </table>
</asp:Content>

