<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" EnableEventValidation="false" CodeFile="UserLogin.aspx.vb" Inherits="Default3" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="keywords" content="Send Emails, Email Marketing, Bulk Emails, Send Bulk Emails, Emails Sender, Free Emails, Bulk, Business Tool, Promote, Marketing">
    <meta name="author" content="EBox Marketing Solutions, Bulk Email Marketing Tool">
    <meta name="robots" content="noindex,nofollow">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, shrink-to-fit=no">

    <title>User Login | Email Marketing Tool | EBox Marketing</title>
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
    <link rel="apple-touch-icon" type="image/x-icon" sizes="120x120" href="https://www.eboxmarketing.com/apple-touch-icon-120x120-precomposed.png" />
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
    <div class="limiter">
        <div class="container-login100">
            <div>
                <div class="col-sm-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="/index.aspx">Bulk Emails Service Page</a></li>
                            <li class="breadcrumb-item">User Login</li>
                            <%--<li class="breadcrumb-item Custom"><a href="/home.aspx"><i class="fa fa-home" aria-hidden="true"></i> Go Home</a></li>--%>
                        </ol>
                    </nav>
                </div>
                <div class="col-sm-12">
                    <div class="wrap-login100">
                        <div class="login100-pic js-tilt">
                            <img src="/image/LoginPage_Image.png" title="Login Page Image" alt="LoginPage_Image">
                        </div>
                        <div id="loading" runat="server" class="loader imHidden">
                            <img src="image/Loading2.gif" title="Loading Gif" alt="Loading" />
                        </div>
                        <form class="login100-form validate-form" runat="server">
                            <span class="login100-form-title">User Login
                            </span>
                            <div class="wrap-input100 validate-input" data-validate="Valid email is required: name@example.com">
                                <asp:TextBox class="input100" ID="email_TextBox" autocomplete="off" TextMode="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" required="true" runat="server" type="text" name="email" placeholder="Email" />
                                <span class="focus-input100"></span>
                                <span class="symbol-input100">
                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                </span>
                            </div>
                            <div class="wrap-input100 validate-input" data-validate="Password is required">
                                <asp:TextBox class="input100" type="password" ID="password_TextBox" runat="server" name="pass" placeholder="Password" />
                                <span class="focus-input100"></span>
                                <span class="symbol-input100">
                                    <i class="fa fa-lock" aria-hidden="true"></i>
                                </span>
                            </div>
                            <asp:Label CssClass="WarningLabel" ID="EventValidation4" runat="server"></asp:Label>
                            <div class="container-login100-form-btn">
                                <asp:LinkButton ID="LoginBtn" CssClass="login100-form-btn" OnClientClick="showDiv()" runat="server">
                            Sign in
                                </asp:LinkButton>
                                <div class="position-relative w-100">
                                <span class="OrText">Or</span>
                                <span class="borderspan"></span>
                                </div>
                                <asp:LinkButton ID="GmailLoginBtn" runat="server" CssClass="float-lg-right float-left"><img class="GoogleBtnimg" title="Google Sign In Image" src="img/name@example.com" alt="Google Sign In Button"/></asp:LinkButton>
                            </div>
                            <div class="text-center p-t-12">
                                <asp:LinkButton CssClass="txt2" ID="ChangeForgotPasswordBtn" runat="server">
                        <span class="text-info txt1">Request A New
                        Password?</span></asp:LinkButton>
                            </div>
                            <div class="text-center p-t-136 border-top pt-2 mt-2">
                                <%--<span class="txt2">New User? Start your 3 days trial today. </span>
                                <br />--%>
                                <a class="txt2 text-info" id="CreateyourAccount" runat="server" href="#">Create your Account
							 <i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                                </a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://use.fontawesome.com/2db8191a55.js"></script>
    <script>
        var input = document.getElementById('<%=password_TextBox.ClientID%>');
        input.addEventListener("keyup", function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                document.getElementById('<%=LoginBtn.ClientID%>').click();
            }
        });
        function showDiv() {
            document.getElementById('<%=loading.ClientID%>').className = "loader";
            document.getElementById('<%=loading.ClientID%>').focus();
        }
    </script>
</body>
</html>
