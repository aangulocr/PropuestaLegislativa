<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PropuestasLegislativas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2 id="aspnetTitle">Registro de Propuestas Legislativas</h2> 
        <asp:BulletedList ID="BulletedList1" runat="server" Font-Size="Small" ForeColor="#FF3300" list-Style="none" CssClass="list-unstyled"></asp:BulletedList>
        <section class="row" aria-labelledby="aspnetTitle" style="height: 675px">                                              
            <table style="width:100%; height: 435px;">
                <tr>
                    <td class="text-end" style="width: 201px; height: 48px">
                        <asp:Label ID="lbl_tipoId" runat="server" Text="Tipo de Identificación: " ForeColor="#3333FF" CssClass="align-content-center"></asp:Label>
                    </td>
                    <td class="text-center" style="height: 48px; width: 195px">
                        <asp:DropDownList ID="Ddl_identificacion"  runat="server" Width="178px" CssClass="offset-sm-0">
                            <asp:ListItem Value="- Identificación -">- Identificación -</asp:ListItem>
                            <asp:ListItem>Cédula Nacional</asp:ListItem>
                            <asp:ListItem>Cédula Residente</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="height: 48px; width: 162px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Ddl_identificacion" 
                                runat="server" ErrorMessage="Campo Requerido" ForeColor="Red" InitialValue="- Identificación -"> 
                            </asp:RequiredFieldValidator>
                    </td>
                    <td class="text-end" style="height: 48px; width: 199px">
                        <asp:Label ID="lbl_identificacion" runat="server" Text="ID" ForeColor="#3333FF">Digite su Identificación: </asp:Label>
                    </td>
                    <td class="text-center" style="height: 48px; width: 198px">
                        <asp:TextBox ID="txt_identificacion" placeholder="Digite su ID.." runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td style="height: 48px; width: 371px;">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_identificacion" MinimumValue="100000000" MaximumValue="599999999999" Type="Double" ErrorMessage="Formato de Cédula Incorrecto" ForeColor="Red"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_identificacion" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="text-end" style="width: 201px; height: 42px">
                        <asp:Label ID="lbl_nombre" runat="server" Text="Nombre" ForeColor="#3333FF">Nombre: </asp:Label>
                    </td>
                    <td class="text-center" style="height: 42px; width: 195px">
                        <asp:TextBox ID="txt_nombre" placeholder="Digite su Nombre" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 42px; width: 162px" class="text-start">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_nombre" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^\D{3,20}$" ErrorMessage="Formato de Nombre Incorrecto" ControlToValidate="txt_nombre" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>

                    <td class="text-end" style="height: 42px; width: 199px">
                        <asp:Label ID="lbl_apellido" runat="server" Text="Apellido" ForeColor="#3333FF">Apellido: </asp:Label>
                    </td>
                    <td class="text-center" style="height: 42px; width: 198px">
                        <asp:TextBox ID="txt_apellido" placeholder="Digite su Apellido" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 42px; width: 371px;" class="text-start">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_apellido" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^\D{3,20}$" ErrorMessage="Formato de Apellido Incorrecto" ControlToValidate="txt_apellido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="text-end" style="width: 201px; height: 48px">
                        <asp:Label ID="lbl_telefono" runat="server" Text="Telefono" ForeColor="#3333FF">Teléfono: </asp:Label>
                    </td>
                    <td class="text-center" style="width: 195px; height: 48px">
                        <asp:TextBox ID="txt_telefono" placeholder="Formato: 70451050" runat="server" TextMode="Phone" ></asp:TextBox>
                    </td>
                    <td style="width: 162px; height: 48px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_telefono" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                            runat="server" ValidationExpression="^[1-8]\d{7}$" 
                            ErrorMessage="Formato de Teléfono Incorrecto" 
                            ControlToValidate="txt_telefono" 
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 199px; height: 48px" class="text-end">
                        <asp:Label ID="lbl_email" runat="server" Text="Email" ForeColor="#3333FF">Email: </asp:Label>
                    </td>
                    <td style="width: 198px; height: 48px">
                        <asp:TextBox ID="txt_email" placeholder="Email..." runat="server" TextMode="Email" ></asp:TextBox>
                    </td>
                    <td style="height: 48px; width: 371px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_email" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="\S+@\S+\.\S+" ErrorMessage="Formato de Correo Incorrecto" ControlToValidate="txt_email" ForeColor="Red"></asp:RegularExpressionValidator>                      
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 201px; height: 14px;"></td>
                    <td style="width: 195px; height: 14px;"></td>
                    <td style="width: 162px; height: 14px;"></td>
                    <td style="width: 199px; height: 14px;"></td>
                    <td style="width: 198px; height: 14px;"></td>
                    <td style="height: 14px; width: 371px;"></td>
                </tr>
               
                <tr>                
                    <td class="text-end" style="width: 201px; height: 63px">
                        <asp:Label ID="lbl_provincia" runat="server" Text="Provincia: " ForeColor="#3333FF"></asp:Label>
                    </td>
                    <td class="text-center" style="width: 195px; height: 63px">
                        <asp:DropDownList ID="Ddl_provincia" runat="server" Height="23px" Width="157px" AutoPostBack="True" OnSelectedIndexChanged="Ddl_provincia_SelectedIndexChanged">
                            <asp:ListItem>- Provincia -</asp:ListItem>
                            <asp:ListItem>San José</asp:ListItem>
                            <asp:ListItem>Alajuela</asp:ListItem>
                            <asp:ListItem>Cartago</asp:ListItem>
                            <asp:ListItem>Heredia</asp:ListItem>
                            <asp:ListItem>Guanacaste</asp:ListItem>
                            <asp:ListItem>Puntarenas</asp:ListItem>
                            <asp:ListItem>Limón</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 162px; height: 63px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="Ddl_provincia" 
                            runat="server" ErrorMessage="Campo Requerido" ForeColor="Red" InitialValue="- Provincia -"> 
                        </asp:RequiredFieldValidator>
                        <br />
                    </td>
                    <td style="width: 199px; height: 63px;" class="text-end">
                        <asp:Label ID="lbl_canton" runat="server" Text="Cantón:" ForeColor="#3333FF"></asp:Label>
                    </td>
                    <td style="width: 198px; height: 63px;">
                        <asp:DropDownList ID="Ddl_canton" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="- Cantón -">- Cantón -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 371px; height: 63px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="Ddl_canton"
                            runat="server" ErrorMessage="Campo Requerido" ForeColor="Red" InitialValue="- Cantón -"> 
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
             
                 </table>  
                <div class="form-control">
                    <div class="align-self-center ms-5">
                        <asp:Label ID="Label1" runat="server" Text="Propuesta:" ForeColor="#3333FF">Propuesta Legislativa:</asp:Label>
                    </div >
                    <div class="text-center mb-3">                        
                        <asp:TextBox ID="txt_propuesta" runat="server" placeholder="Escribir Propuesta" Height="99px" Width="1060px" TextMode="MultiLine" Rows="8" Columns="50"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txt_propuesta" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="^[\s\S]{50,200}$" ErrorMessage="Permitido de 50 a 200 Caracteres" ControlToValidate="txt_propuesta" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="Btn_guardar" runat="server" CssClass="btn btn-primary" Text="GUARDAR" Width="197px" OnClick="Btn_guardar_Click" />
                        <asp:Button ID="Btn_limpiar" runat="server" CssClass="btn btn-danger" Text="LIMPIAR" Width="165px" OnClick="Btn_limpiar_Click" />
                    </div>
                </div>
        </section>

    </main>

</asp:Content>
