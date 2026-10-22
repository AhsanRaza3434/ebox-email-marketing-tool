<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" EnableEventValidation="false" CodeFile="UserRegistration.aspx.vb" Inherits="Default3" %>



<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="keywords" content="Send Emails, Email Marketing, Bulk Emails, Send Bulk Emails, Emails Sender, Free Emails, Bulk, Business Tool, Promote, Marketing">
    <meta name="author" content="EBox Marketing Solutions, Bulk Email Marketing Tool">
    <meta name="robots" content="noindex,nofollow">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, shrink-to-fit=no">

    <title>User Registration | Email Marketing Tool | EBox Marketing</title>
    <link rel="canonical" href="https://www.eboxmarketing.com">
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
    <link href="/css/RegStyle.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"></script>
    <script src="/Msgboxlib/ConfirmModal.js"></script>

</head>
<body>
    <div class="main">
        <!-- Sign up form -->
        <form id="form1" runat="server">
            <asp:ScriptManager ID="RadScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="Sava_button" />
                </Triggers>
                <ContentTemplate>
                    <div id="loading" runat="server" class="loader imHidden">
                        <img src="image/Loading2.gif" alt="Loading" title="Loading Gif" />
                    </div>
                    <asp:Label CssClass="WarningLabel" ID="EventValidation" Text=" " runat="server"></asp:Label>
                    <section class="signup">
                        <div class="Regcontainer">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb rounded-0 bg-transparent m-0 py-3 border-bottom pl-4">
                                    <li class="breadcrumb-item"><a href="/Bulk-Email-Services-Page.aspx">Bulk Emails Service Page</a></li>
                                    <li class="breadcrumb-item">User Registration</li>
                                </ol>
                            </nav>
                            <div class="signup-content">
                                <div class="signup-form">
                                    <h2 class="form-title">Sign up</h2>
                                    <form method="POST" class="register-form" id="register-form">
                                        <div class="form-group">
                                            <label for="name" title="Name"><i class="fa fa-address-card material-icons-name"></i></label>
                                            <asp:TextBox placeholder="Enter your name" ID="author_first_name_TextBox" OnTextChanged="author_first_name_TextBox_TextChanged" AutoPostBack="true" runat="server" type="text" name="first_name" />
                                            <asp:Label CssClass="WarningLabel" ID="EventValidation1" Text="Full Name*" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="email"><i class="fa fa-at material-icons-name"></i></label>
                                            <asp:TextBox placeholder="Enter your email address" AutoPostBack="true" AutoCompleteType="Disabled" autocomplete="off" OnTextChanged="author_email_TextBox_TextChanged" ID="author_email_TextBox" TextMode="Email" runat="server" type="email" name="email" />
                                            <asp:Label CssClass="WarningLabel" ID="EventValidation3" Text="Must be a valid Email Address*" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="pass"><i class="fa fa-unlock material-icons-name"></i></label>
                                            <asp:TextBox placeholder="Enter a new password" AutoPostBack="true" type="password" OnTextChanged="author_password_TextBox_TextChanged2" ID="NewPassword" runat="server" />
                                            <asp:Label CssClass="WarningLabel" Text="Must be 6 characters long*" ID="EventValidation4" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="re-pass"><i class="fa fa-lock material-icons-name"></i></label>
                                            <asp:TextBox placeholder="Re-enter your password" AutoPostBack="true" type="password" OnTextChanged="author_password_TextBox_TextChanged" ID="author_password_TextBox" runat="server" />
                                            <asp:Label CssClass="WarningLabel" ID="EventValidation5" Text="Must match with the above password*" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group form-button">
                                            <asp:LinkButton CssClass="form-submit" ID="Sava_button" OnClientClick="showDiv()" runat="server">Submit</asp:LinkButton>
                                        </div>
                                    </form>
                                </div>
                                <div class="signup-image">
                                    <div class="row">
                                        <div class="col-sm-12 col-lg-12 mt-3 mb-3 ml-lg-5">
                                            <span class="SignUpOptionTxt">- Or -</span><asp:LinkButton ID="GmailLoginBtn" CssClass="SignUpBtnGoogle" runat="server"><img class="w-auto" height="46px" src="img/name@example.com" alt="Google Sign Up Button" title="Google Sign up Image"/></asp:LinkButton>
                                        </div>
                                        <div class="col-sm-12 col-lg-12">
                                            <figure>
                                                <img src="image/signup-image.jpg" title="Sign Up Image" alt="sing up image">
                                            </figure>
                                            <a href="/UserLogin.aspx" class="signup-image-link">I am already a member</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
    <script src="https://use.fontawesome.com/2db8191a55.js"></script>
    <script>
        var input = document.getElementById('<%=author_password_TextBox.ClientID%>');
        input.addEventListener("keyup", function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                document.getElementById('<%=Sava_button.ClientID%>').click();
            }
        });
        function showDiv() {
            document.getElementById('<%=loading.ClientID%>').className = "loader";
            document.getElementById('<%=loading.ClientID%>').focus();
        }
    </script>
</body>
</html>
<!-- end document-->
