<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" EnableEventValidation="false"  CodeFile="ForgotPasswordForm.aspx.vb" Inherits="ForgotPassword" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    	<meta name="keywords" content="Send Emails, Email Marketing, Bulk Emails, Send Bulk Emails, Emails Sender, Free Emails, Bulk, Business Tool, Promote, Marketing">
        <meta name="author" content="EBox Marketing Solutions, Bulk Email Marketing Tool"> 
        <meta name="robots" content="noindex,nofollow">
		<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, shrink-to-fit=no">

		<title>Password Reset | Email Marketing Tool | EBox Marketing</title>
	    <link rel="canonical" href="https://www.eboxmarketing.com">
		<link rel="alternate" hreflang="es" href="https://www.eboxmarketing.com">
		<link rel="alternate" hreflang="fr" href="https://www.eboxmarketing.com">
		<link rel="alternate" hreflang="de" href="https://www.eboxmarketing.com">
		<meta name="description" content="Free Bulk Email Marketing tool, reach your clients today. Start sending mass emails to your clients today and promote your brand among potential customers.">

		<meta property="og:title" content="Send Mass Emails, Email Marketing Tool | EBox Marketing">
		<meta property="og:description" content="Free Bulk Email Marketing tool, reach your clients today. Start sending mass emails to your clients today and promote your brand among potential customers.">
		<meta property="og:image" content="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
		<meta property="og:image:secure_url" content="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
		<meta property="og:locale" content="en">
		<meta property="og:type" content="website">
		<meta property="og:url" content="https://www.eboxmarketing.com">
		<meta property="og:site_name" content="Send Mass Emails, Email Marketing Tool | EBox Marketing">
		
		<meta name="twitter:title" content="Send Mass Emails, Email Marketing Tool | EBox Marketing">
		<meta name="twitter:description" content="Free Bulk Email Marketing tool, reach your clients today. Start sending mass emails to your clients today and promote your brand among potential customers.">
		<meta name="twitter:image" content="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
		<meta name="twitter:card" content="summary_large_image">
		<meta name="twitter:site" content="https://www.eboxmarketing.com">
	
		<!-- Favicons -->
	    <link rel="shortcut icon" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico" type="image/x-icon">
	    <link rel="apple-touch-icon" type="image/x-icon" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
	    <link rel="apple-touch-icon" type="image/x-icon" sizes="72x72" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
	    <link rel="apple-touch-icon" type="image/x-icon" sizes="114x114" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
	    <link rel="apple-touch-icon" type="image/x-icon" sizes="144x144" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico">
		<link type="image/x-icon" href="https://www.eboxmarketing.com/image/EBoxMarketingFavicon.ico" rel="icon">
        <link rel="apple-touch-icon"  type="image/x-icon" sizes="120x120" href="https://www.eboxmarketing.com/apple-touch-icon-120x120-precomposed.png" /> 
        <link rel="apple-touch-icon" type="image/x-icon" sizes="152x152" href="https://www.eboxmarketing.com/apple-touch-icon-152x152-precomposed.png" />
		
    <!-- Bootstrap & Msg Box CSS File -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">

    <%--Custom Style Sheet--%>
    <link href="/css/style.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
     
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"></script>
    <script src="/Msgboxlib/ConfirmModal.js"></script>
    
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-F72NBNXD6F"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-F72NBNXD6F');
    </script>

    <script data-ad-client="ca-pub-5830711168897757" async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
</head>

<body>
    <div class="page-wrapper bg-gra-01 p-t-130 p-b-100 font-poppins">
        <div class="wrapper wrapper--w680">
            <nav aria-label="breadcrumb">
              <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="/Bulk-Email-Services-Page.aspx">Bulk Emails Service Page</a></li>
                <li class="breadcrumb-item">Forgot Password Page</li>
              </ol>
            </nav>
            <div class="card card-4">
                <div class="card-body">
                    <p class="title mb-3">Password Settings</p>
                    <form class="validate-form" id="form1" runat="server">

                        <asp:ScriptManager ID="RadScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                            <ContentTemplate>
                                
                                <div id="loading" runat="server" class="loader imHidden">
                                    <img src="image/Loading2.gif" alt="Loading" title="Loading Gif"/>
                                </div>
                                <script>
                                    function showDiv() {
                                        document.getElementById('<%=loading.ClientID%>').className = "loader";
                                        document.getElementById('<%=loading.ClientID%>').focus();
                                    }
                                </script>
                                <asp:Label CssClass="label" ID="EventValidation" Text=" " ForeColor="Red" runat="server"></asp:Label>
                                <div class="row row-space">
                                    <div class="col-12" id="EmailDiv" runat="server">
                                        <div class="input-group">
                                            <label class="label">Email Address</label>
                                            <asp:TextBox class="input--style-4" AutoPostBack="true" OnTextChanged="EmailAddress_TextChanged" required="true" ID="EmailAddress" TextMode="Email" runat="server" type="email" name="email" />
                                            <asp:Label CssClass="label" ID="EmailValidation" Text=" " ForeColor="Red" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-12" id="VerificationCodeDiv" runat="server">
                                        <div class="input-group">
                                            <label class="label">Verification Code</label>
                                            <asp:TextBox class="input--style-4" required="true" ID="VerificationCode" runat="server" />

                                            <asp:Label CssClass="label" ID="VerificationCodeValidation" Text=" " ForeColor="Red" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-6" id="NewPasswordDiv" runat="server">
                                        <div class="input-group">
                                            <label class="label">New Password</label>
                                            <asp:TextBox class="input--style-4" type="password" AutoPostBack="true" OnTextChanged="NewPassword_TextChanged" required="true" ID="NewPassword" runat="server" />

                                            <asp:Label CssClass="label" ID="NewPasswordValidation" Text=" " ForeColor="Red" runat="server"></asp:Label>
                                            <asp:Label CssClass="WarningLabel" ID="EventValidation4" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-6" id="ConfirmPasswordDiv" runat="server">
                                        <div class="input-group">
                                            <label class="label">Confirm Password</label>
                                            <asp:TextBox class="input--style-4" type="password"  AutoPostBack="true" OnTextChanged="ConfirmPassword_TextChanged" required="true" ID="ConfirmPassword" runat="server" />
                                            
                                            <asp:Label CssClass="WarningLabel" ID="EventValidation5" runat="server"></asp:Label>
                                            <asp:Label CssClass="label" ID="ConfirmPasswordValidation" Text=" " ForeColor="Red" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="p-t-15">
                                    <asp:linkButton  CssClass="btn btn--radius-2 btn--blue" OnClientClick="showDiv()" ID="SubmitBtn" runat="server">Submit</asp:linkButton>
                                    <asp:linkButton  CssClass="btn btn--radius-2 btn--blue" OnClientClick="showDiv()" ID="VerifyBtn" runat="server">Verify</asp:linkButton>
                                    <asp:linkButton  CssClass="btn btn--radius-2 btn--blue" OnClientClick="showDiv()" ID="SaveChangesBtn" runat="server">Save Changes</asp:linkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </form>
                </div>
            </div>
        </div>
    </div>
    
</body>

</html>
<!-- end document-->
