<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
            http://asp.net/mvc</a>.
    </p>
    <table style="width: 100%">
        <thead>
            <tr>
                <th>
                    ID
                </th>
                <th>
                    First Name
                </th>
                <th>
                    Last Name
                </th>
                <th>
                    Phone #
                </th>
                <th>
                    Email
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    00012
                </td>
                <td>
                    Zahoor
                </td>
                <td>
                    Waqas
                </td>
                <td>
                    03004411136
                </td>
                <td>
                    waqaszahoor@msn.com
                </td>
            </tr>

            <tr>
                <td>
                    00013
                </td>
                <td>
                    Zahoor
                </td>
                <td>
                    Waqas
                </td>
                <td>
                    03004411136
                </td>
                <td>
                    waqaszahoor@msn.com
                </td>
            </tr>

            <tr>
                <td>
                    00014
                </td>
                <td>
                    Zahoor
                </td>
                <td>
                    Waqas
                </td>
                <td>
                    03004411136
                </td>
                <td>
                    waqaszahoor@msn.com
                </td>
            </tr>
            <tr>
                <td>
                    00015
                </td>
                <td>
                    Zahoor
                </td>
                <td>
                    Waqas
                </td>
                <td>
                    03004411136
                </td>
                <td>
                    waqaszahoor@msn.com
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
