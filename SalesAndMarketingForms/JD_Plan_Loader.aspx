<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JD_Plan_Loader.aspx.cs" Inherits="SalesAndMarketingForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>JD Plan Loader</title>

    <link rel="stylesheet" href="~/assets/fonts/font-awesome.min.css"/>
    <link rel="stylesheet" href="~/assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css"/>
    <link rel="stylesheet" href="~/assets/css/Navigation-Clean.css"/>
    <link rel="stylesheet" href="~/assets/css/shards-demo.css"/>
    <link rel="stylesheet" href="~/assets/css/shards-demo.min.css"/>
    <link rel="stylesheet" href="~/assets/css/shards-extras.css"/>
    <link rel="stylesheet" href="~/assets/css/shards-extras.min.css"/>
    <link rel="stylesheet" href="~/assets/css/shards.css"/>
    <link rel="stylesheet" href="~/assets/css/shards.min.css"/>
    <link rel="stylesheet" href="~/assets/css/styles.css"/>
    

    <style type="text/css">

        .drillingWorkTypeLeft{

            font-family:Arial;
            margin:0 auto;
            border:1px solid blue;
            text-align:left;
            background-color: lightgoldenrodyellow;
         }

   .result{

            font-family:Arial;

            text-align:left;

         }
    .button{

            font-family:Arial;
          align-content:center;
            text-align:center;
            display: block;
            margin: auto;

         }
        .label {
           display:block;
           margin-left:5px;
            font-family: Arial;
            font-size : 12px;
             text-align: left;
             vertical-align: text-top;
            margin-bottom:0px;
                       
            }
        .auto-style1 {
            height: 48px;
        }
        .auto-style2 {
            width: 392px;
        }
        .auto-style3 {
            height: 48px;
            width: 392px;
        }
        .auto-style4 {
            height: 163px;
            
             margin: 0 auto;
        }
    </style>
</head>
<body>
<form id="Form1" runat="server" >
<div id="card-cover" class="container" style="margin-top: 50px;" onload="check();">
    <div id="inner-card" class="col text-center d-xl-flex justify-content-xl-center">
        <div id="mainPanel" class="card text-center">
            <div class="card-header">
                <h5 class="mb-0">Load JD plan data sheet</h5>
            </div>
            <div class="card-body" style="padding-top: 60px;padding-bottom: 60px; padding-left: 1px;padding-right: 1px;">
                <div id="stage1">
                   <table  class="auto-style4" >
            
            <tr >

                <td class="auto-style1" >
                    File:</td>
                <td class="auto-style1" >
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="389px" />
                </td>
            </tr>

           <tr>

                <td colspan ="2" style="align-items: center"  >
                    
                    <asp:Button ID="btnUploadfile" runat="server" Text="Upload" OnClick="btnUpdateStatus_Click" Width="291px" class="btn btn-secondary text-center" />
                    
                </td>
            </tr>
 
        </table>
                    
                    
                    
              
        </div>
<br />
              </div>
                <asp:Label ID="Label1" class="mb-0" runat="server" Text=""></asp:Label>
            </div>
        <div class="mb-0" ></div>
    </div>
    <div class="text-center" style="margin-top: 33px;">
        <p>© 2020 - CoE BI<br/></p>
    </div>
</div>

    <%--  --%>
    <script src="/bundles/modernizr?v=inCVuEFe6J4Q07A0AcRsbJic_UE5MwpRMNGcOtk94TE1"></script>

    <script src="/bundles/jquery?v=2u0aRenDpYxArEyILB59ETSCA2cfQkSMlxb6jbMBqf81"></script>

    <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/knockout-3.4.2.js"></script>
    <script src="/Scripts/app.js?v=2.1"></script>
    <script src="/Scripts/GENERAL.js?v=1.9"></script>
    <script src="/Scripts/Scripts_SSIS.js"></script>
    <script src="/Scripts/Scripts_UI.js?v=2.3"></script>
    






    
      <div  > 
   
          </div>
    </form>
</body>
</html>
