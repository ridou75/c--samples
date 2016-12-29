<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebPhotos.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Ashx Handler demonstration.</h2>
    </hgroup>

    <article>
        <p>        
            <!--<img src="ShowNextHandler.ashx" alt="test" />--> 
            <asp:Image ID="Photo" src="ShowNextHandler.ashx?Type=Image" runat="server" Height="400px"  ImageAlign="Middle" ViewStateMode="Enabled" />
        </p>

        <p>        
            <asp:Label ID="lblImage"  runat="server"></asp:Label>
        </p>
        <p>        
            &nbsp;<asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Show Next" />
        </p>
    </article>

    <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About">About</a></li>
            <li><a runat="server" href="~/Contact">Contact</a></li>
        </ul>
    </aside>
</asp:Content>