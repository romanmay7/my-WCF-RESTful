<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myWCF_RESTfulService_WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript">
        var gamedata
        $(document).ready(function () {
            $('#btnGetGame').click(function () {
                var gameId = $('#ID').val();
                event.preventDefault(); //Prevent ASP.NET WebForm's Submit Request,which will Refresh the Page

                $.ajax({
                    url: 'http://localhost:8080/GetGame/' + gameId,
                    type: 'GET',
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        gamedata=data
                        console.log(data);
                        $('#Title').val(data.Title);
                        $('#Genre').val(data.Genre);
                        $('#Developer').val(data.Developer);
                        $('#Publisher').val(data.Publisher);
                        $('#Year').val(data.Year);

                    },
                    error: function (err) {
                        alert(err)
                    }
                });
                
                setValues()
            });
        });

    </script>
    <div class="jumbotron">
        <h3>ASP.NET WEB Client for WCF RESTful Service</h3>
        <p class="lead">&nbsp;</p>
        
        <p>ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="ID" type="text" /> <button id="btnGetGame"class="btn btn-primary btn-lg">&nbsp;Get Game</button></p>
        <p>Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="Title" type="text" /></p>
        <p>Genre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Genre" type="text" /></p>
        <p>Developer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Developer" type="text" /></p>
        <p>Publisher&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Publisher" type="text" /></p>
        <p>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Year" type="text" /></p>
    </div>

    </div>

</asp:Content>
