<%@ Page Title="" Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/BulkEmails.master" ValidateRequest="false" EnableEventValidation="false" CodeFile="Bulk-Email-Services-Page.aspx.vb" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Send Mass Emails | Email Marketing Tool | EBox Marketing</title>
    <meta name="description" content="Free Bulk Email Marketing tool, reach your clients today. Start sending mass emails to your clients today and promote your brand among potential customers.">
    <link rel="canonical" href="https://www.eboxmarketing.com/Bulk-Email-Services-Page">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="body">
        <!--==========================
    Intro Section
  ============================-->
        <section id="intro">
            <div class="intro-content">
                <h1>EBox Marketing Solutions<br>
                    <span>Free Email Marketing Tool For Your Business!</span></h1>
                <p>The most advanced digital solution to reach your clients with a single click.</p>
            </div>
        </section>
        <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
            crossorigin="anonymous"></script>
        <!-- Hori_Ads -->
        <ins class="adsbygoogle"
            style="display: block; margin: 12px 0; text-align: center;"
            data-ad-client="ca-pub-5830711168897757"
            data-ad-slot="2231876748"
            data-ad-format="auto"
            data-full-width-responsive="true"></ins>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
        <!-- #intro -->
        <form id="form1" runat="server">

            <main id="AboutUs">
                <!--==========================
      About Section
    ============================-->
                <section id="about" class="wow fadeInUp">
                    <div class="AboutInner">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 content">
                                    <div class="section-header">
                                        <h2>With the most cutting-edge technology</h2>
                                    </div>
                                    <h3>EBox is providing a free and fully customized solution to start reaching your potential clients around the world with a single click.
                                    <br />
                                        <br />
                                        <i class="fa fa-eercast"></i>
                                        Helps you send thousands of emails daily for free.
                                    <br />
                                        <br />
                                        <i class="fa fa-eercast"></i>
                                        Keeps you away from the spam folder of your clients.
                                    <br />
                                        <br />
                                        <i class="fa fa-eercast"></i>
                                        Updates you with the status of each email in real-time.
                                    <br />
                                        <br />
                                        <i class="fa fa-eercast"></i>
                                        Helps you deliver the most customized email ever possible.
                                    </h3>
                                </div>
                                <div class="col-lg-6 about-img">
                                    <img src="img/about-img.jpg" title="Ebox Mass Email Marketing Image" alt="Free Mass Email Marketing Image">
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- #about -->
                <!--==========================
      Services Section
    ============================-->
                <section id="services" class="wow fadeInUp">
                    <div class="container">
                        <div class="section-header">
                            <h2>Features & Working</h2>
                            <p class="text-left w-100">Simple yet the most effective automated process with the help of most advanced algorithms to help you land right in the inbox of your clients without costing you a single penny.</p>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="box wow fadeInLeft">
                                    <div class="icon"><i class="fa fa-file-text-o"></i></div>
                                    <h4 class="title">Upload a .CSV file</h4>
                                    <p class="description">To get started, you're gonna need a list of your potential clients in a .csv file and upload it.</p>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="box wow fadeInRight">
                                    <div class="icon"><i class="fa fa-picture-o"></i></div>
                                    <h4 class="title">Write The Most Catchy Subject</h4>
                                    <p class="description">The key to your potential customer's heart is a catchy subject. Make sure you write a good one. </p>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="box wow fadeInLeft" data-wow-delay="0.2s">
                                    <div class="icon"><i class="fa fa-paper-plane"></i></div>
                                    <h4 class="title">Don't Forget Your Attachments</h4>
                                    <p class="description">Clients love pictorial representation of something. Make sure you give a glimpse of your brand in that.</p>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="box wow fadeInRight" data-wow-delay="0.2s">
                                    <div class="icon"><i class="fa fa-map"></i></div>
                                    <h4 class="title">Sit Back & Relax!</h4>
                                    <p class="description">While you relax, we deliver your important emails to your clients right in their inboxes.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
                        crossorigin="anonymous"></script>
                    <!-- Verti_Ads -->
                    <ins class="adsbygoogle"
                        style="display: block; margin: 12px 0; text-align: center;"
                        data-ad-client="ca-pub-5830711168897757"
                        data-ad-slot="7662305000"
                        data-ad-format="auto"
                        data-full-width-responsive="true"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>
                </section>
                <%--<asp:ScriptManager ID="RadScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div id="loading" runat="server" class="Payment imHidden">
                            <img src="image/Payment.gif" alt="Payment Transaction gif" />
                            <asp:Label ID="Label1" Text="Please be patient... It may take a while." CssClass="Loader_Text" runat="server"> </asp:Label>
                        </div>
                        <!-- #services -->
                        <div class="Packages_Section wow fadeInUp">
                            <div class="container">
                                <div class="row">
                                    <div class="col-12">
                                        <section>
                                            <div class="section-header mb-5">
                                                <h2>Choose what suits you best!</h2>
                                                <p class="text-left w-100" id="Packages">Your product can outlive you only if you choose the right way to keep it alive. Choose wisely!</p>
                                            </div>
                                        </section>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="pricingTable blue">
                                            <div class="pricingTable-header">
                                                <h3 class="title">3 Days Trial</h3>
                                            </div>
                                            <div class="price-value">Free</div>
                                            <ul class="pricing-content">
                                                <li><span class="text-info">300</span> Emails for <span class="text-info">3</span> Days</li>
                                                <li>Import <span class="text-info">100</span> Emails Daily</li>
                                                <li>Export Emails Data</li>
                                                <li>Manage Existing Emails</li>
                                                <li>Email Customization Tools</li>
                                                <li class="disable">Dashboard Analytics</li>
                                                <li class="disable">No Follow Up Emails</li>
                                                <li class="disable">Check Email Status</li>
                                                <li class="disable"><span class="text-info">0%</span> Special Discount On Annual Subscription</li>
                                            </ul>
                                            <div class="pricingTable-signup">
                                                <span id="TrialSubscribedText" runat="server">Subscribed</span>
                                                <a id="FreeTrialPackageClick" runat="server">Sign Up</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="pricingTable ">
                                            <div class="pricingTable-header">
                                                <h3 class="title">Business</h3>
                                            </div>
                                            <div class="price-value"><span id="PaymentText"></span>$59 Monthly</div>
                                            <ul class="pricing-content" id="SignUpPackages">
                                                <li><span class="text-danger">15,000</span> Emails Monthly</li>
                                                <li>Import <span class="text-danger">500</span> Emails Daily</li>
                                                <li>Export Emails Data</li>
                                                <li>Manage Existing Emails</li>
                                                <li>Email Customization Tools</li>
                                                <li>Dashboard Analytics</li>
                                                <li><span class="text-danger">15,000</span> Follow Up Emails</li>
                                                <li>Check Email Status</li>
                                                <li><span class="text-danger">10%</span> Discount On Annual Subscription ($637)</li>
                                            </ul>
                                            <div class="pricingTable-signup">
                                                <span id="BusinessPackageText" runat="server">Subscribed</span>
                                                <a id="BusinessPackageClick" runat="server">Subscribe</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="pricingTable cyan">
                                            <div class="pricingTable-header">
                                                <div class="bestOffer_Sticker">
                                                    <img src="img/BestSeller.png" alt="Ebox Top Selling Subscription" />
                                                </div>
                                                <h3 class="title">Premium</h3>
                                            </div>
                                            <div class="price-value">$99 Monthly</div>
                                            <ul class="pricing-content">
                                                <li><span class="text-success">Unlimited</span> Emails Monthly</li>
                                                <li>Import <span class="text-success">Unlimited</span> Emails Daily</li>
                                                <li>Export Emails Data</li>
                                                <li>Manage Existing Emails</li>
                                                <li>Email Customization Tools</li>
                                                <li>Dashboard Analytics</li>
                                                <li><span class="text-success">Unlimited</span> Follow Up Emails</li>
                                                <li>Check Email Status</li>
                                                <li><span class="text-success">15%</span> Discount On Annual Subscription ($1010)</li>
                                            </ul>
                                            <div class="pricingTable-signup">
                                                <span id="PremiumPackageText" runat="server">Subscribed</span>
                                                <a id="PremiumPackageClick" runat="server">Subscribe</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <p id="packageInstructionsText" runat="server" class="PackageRequirements">Instructions: Sign up for trial first or login with your existing credentials, then proceed to upgrade your plans according to your business needs.</p>
                                <p id="packagePoliciesURL" runat="server" class="PackageRequirements">For more information, please read <a href="PrivacyPolicy.html" target="_blank">Privacy Policy</a> and <a href="RefundPolicy.html" target="_blank">Refund Policy</a>. If you have any questions about these Policies, please contact us at <a href="https://mail.google.com/mail/u/0/?fs=1&to=help@eboxmarketing.com&su=A+Chance+To+Make+A+Difference&body=Dear+EBox,+I+have+some+valuable+information+to+share+with+you.+I+have+noticed+that+%3Ctype+your+valuable+suggestions+and+feedbacks+here%3E.Thank+you.&tf=cm" target="_blank">help@eboxmarketing.com</a>.</p>
                                <div class="modal fade bd-example-modal-sm mt-5" id="GooglePayModal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-md">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close d-contents text-primary" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true" class="m-auto d-flex"><i class="fa fa-arrow-left" aria-hidden="true"></i></span>
                                                </button>
                                                <h4 class="modal-title w-100 text-center font-weight-bold">Select Payment Type & Method</h4>
                                            </div>
                                            <div class="modal-body">
                                            <div class="SubscriptionPackageType_Body pb-0 mb-3">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                         <h4 class="modal-title">Payment Type:</h4>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="subscriptionPrice" runat="server" CssClass="d-none"></asp:Label>
                                                            <asp:Label ID="subscriptionType" runat="server" CssClass="d-none"></asp:Label>
                                                            <asp:TextBox ID="PaymentStatus" Text="payment status" CssClass="d-none" OnTextChanged="PaymentStatus_TextChanged" AutoPostBack="true" runat="server">
                                                            </asp:TextBox>
                                                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" CssClass="RadioButtonsCss m-0 my-3 d-block" RepeatDirection="Vertical" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                                                                <asp:ListItem Value="0" Selected="True">Monthly</asp:ListItem>
                                                                <asp:ListItem Value="1">Annually</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="SubscriptionDetails_Body">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                         <h4 class="modal-title">Product Details:</h4>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="SubscriptionDetails_Inner">
                                                            <div class="row">
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Header">
                                                                        <h3>Package Type:</h3>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Description">
                                                                        <span id="PackageTypeText" runat="server"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Header">
                                                                        <h3>Payable Amount:</h3>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Description">
                                                                        <span id="PayableAmountText" runat="server"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Header">
                                                                        <h3>Sendable Emails:</h3>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Description">
                                                                        <span id="SendableEmailsText" runat="server"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Header">
                                                                        <h3>Starting Date:</h3>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Description">
                                                                        <span id="StartingDateText" runat="server"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Header">
                                                                        <h3>Expiry Date:</h3>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12 col-lg-6">
                                                                    <div class="SubscriptionDetails_Description">
                                                                        <span id="ExpiryDateText" runat="server"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="SubscriptionPaymentMethod_Body border-0">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                         <h4 class="modal-title">Payment Method:</h4>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div id="container"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <!--==========================
      Call To Action Section
    ============================-->
                <section id="call-to-action" class="wow fadeInUp">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-9 text-center text-lg-left">
                                <h3 class="cta-title">Have something to share?</h3>
                                <p class="cta-text pb-2">No worries! just Whatsapp us your valuable suggestions & feedbacks and let us know that we still need to make some progress. We'll figure out the rest of it.</p>
                            </div>
                            <div class="col-lg-3 cta-btn-container text-center">
                                <a class="cta-btn align-middle" title="EBox Whatsapp Link" target="_blank" href="https://api.whatsapp.com/send?phone=00920000000000&text=Hi!%20I%20have%20a%20suggestion%20to%20share.">Whatsapp Us Now</a>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- #call-to-action -->
                <%--Clients Section--%>

                <section id="clients" class="section-bg">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <section>
                                    <div class="section-header">
                                        <h2>Join The List Of Our Happy Clients!</h2>
                                        <p class="text-left w-100">We would love to have you alongside our happy and beloved clients. From small businesses and organizations to large enterprises.</p>
                                    </div>
                                </section>
                            </div>
                        </div>
                        <div class="row no-gutters clients-wrap clearfix wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-1.png" title="Client 1" class="img-fluid" alt="Client 1">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-2.png" title="Client 2" class="img-fluid" alt="Client 2">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-3.png" title="Client 3" class="img-fluid" alt="Client 3">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-4.png" title="Client 4" class="img-fluid" alt="Client 4">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-5.png" title="Client 5" class="img-fluid" alt="Client 5">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-6.png" title="Client 6" class="img-fluid" alt="Client 6">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-7.png" title="Client 7" class="img-fluid" alt="Client 7">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <div class="client-logo">
                                    <img src="https://www.eboxmarketing.com/img/clients/client-8.png" title="Client 8" class="img-fluid" alt="Client 8">
                                </div>
                            </div>
                        </div>
                        <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
                            crossorigin="anonymous"></script>
                        <!-- Horizontal_ad_2 -->
                        <ins class="adsbygoogle"
                            style="display: block"
                            data-ad-client="ca-pub-5830711168897757"
                            data-ad-slot="8990950117"
                            data-ad-format="auto"
                            data-full-width-responsive="true"></ins>
                        <script>
                            (adsbygoogle = window.adsbygoogle || []).push({});
                        </script>
                        <span id="Tutorial"></span>
                        <span id="FAQ"></span>
                    </div>
                </section>

                <%--Clients Section--%>

                <!-- #Tutorial Section -->

                <%--<div class="container-fluid tutorial_BG bg-gray border-top py-5 mt-0 d-none">
                    <div class="container">
                        <section>
                            <div class="row">
                                <div class="col-12">
                                    <section>
                                        <div class="section-header">
                                            <h2>Video Tutorial - How to Send Mails In Bulk</h2>
                                            <p class="text-left w-100">Find it hard to understand how it all works? Say no more. Watch the tutorial - step by step and elevate your brand.</p>
                                        </div>
                                    </section>
                                </div>
                                <div class="col-lg-6 content">
                                    <iframe width="420" height="345" class="IframeVideo_Tutorial" src="https://www.youtube.com/embed/1OUxKtMvShs"></iframe>
                                </div>
                                <div class="col-lg-6 tutorial-img">
                                    <img src="img/TutorialImage.png" alt="Mass Email Tutorial Image">
                                </div>
                            </div>
                        </section>
                    </div>
                </div>--%>

                <!-- #Tutorial Section -->
                <!-- Accordion -->
                <div class="container-fluid bg-gray border-top py-5 mt-0" id="FAQDiv">
                    <div class="container">
                        <section>
                            <div class="row">
                                <div class="col-12">
                                    <section id="FAQ2">
                                        <div class="section-header">
                                            <h2>Frequently Asked Questions</h2>
                                            <p class="text-left w-100">Have questions in mind? Don't you worry, we have got your back.</p>
                                        </div>
                                    </section>
                                </div>
                                <div class="col-12 mx-auto">
                                    <div class="accordion" id="accordionExample">
                                        <div class="card">
                                            <div class="card-header" id="headingOne">
                                                <p class="mb-0">
                                                    <button class="btn btn-link btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">How can I make customers read through my email?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne" class="collapse show fade" aria-labelledby="headingOne" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Customers open emails they connect with and those, which sound relevant. So, the first thing you need to do is to understand your customer’s expectations and things that matter to them the most.<br />
                                                    <br />
                                                    <b>Don't forget to use our most important feature:</b> When you write an email body, type @ClientName or @ClientCompany keywords and provide receiver's name and their business name, it will automatically replace those keywords with their real name and company name in every individual email w.r.t their names and company names.
                                                <br />
                                                    <br />
                                                    <b>For Example:</b>
                                                    <br />
                                                    Write, "Dear Mr/Mrs. @ClientName,"
                                                <br />
                                                    <br />
                                                    "I have heard a lot about your company @ClientCompany and I have noticed that you are looking for a solution to increase your sales..."
                                                <br />
                                                    <br />
                                                    Whenever you shoot an email ask yourself, “Does the email content, especially the subject line matter to my customer?”<br />
                                                    <br />
                                                    Customers instantly connect to emails, which are personalized and when the call to action is relevant. Also, if you create an urgency they do read and respond as well.<br />
                                                    <br />
                                                    Focus on the value you create for the customer and the benefits you are offering.<br />
                                                </div>
                                            </div>
                                            <div class="card-header" id="headingOne2">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne2" aria-expanded="true" aria-controls="collapseOne2">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">Will my sales hike due to an email marketing campaign?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne2" class="collapse fade" aria-labelledby="headingOne2" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    <p>
                                                        Email campaigns can surely hike sales, provided you stimulate and inspire the audience towards investing their money in your brand/ products.<br />
                                                        <br />
                                                        When would you buy a product?<br />
                                                        <br />
                                                        When it provides a solution to an existing or future problem. When you trust the brand and you connect (emotionally and rationally) with the message/signal the advertiser is trying to convey to you.<br />
                                                        <br />
                                                        Well, then you have your question answered.<br />
                                                        <br />
                                                        So, convey to the audience that your product/service will provide them with a solution and add value to their life.<br />
                                                        <br />
                                                        Share testimonials and case studies to build trust.<br />
                                                        <br />
                                                        Create an email with inspiring content and visually strong images (a picture is worth a thousand words) that emotionally and rationally connect with the customer.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="card-header" id="headingOne3">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne3" aria-expanded="true" aria-controls="collapseOne3">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">Any tips on how to write the content of an email?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne3" class="collapse fade" aria-labelledby="headingOne3" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Content that offers value to the customers, for example, a discount or sale would elicit an instant response. But, emails are not just meant to inform customers about offers and discounts.<br />
                                                    <br />
                                                    There is a journey that each brand has to travel vis-a-vis each customer to drive him/her to reach to the end of the sales funnel and ultimately make a purchase.<br />
                                                    <br />
                                                    Through emails, you connect with the audience, build interest in your brand, build trust and then get down to talking about the sale. When you directly talk about the sale, it might generate a positive response once or twice but, to convert that customer into a loyal one, you need to go through this journey.
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne4">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne4" aria-expanded="true" aria-controls="collapseOne4">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">How do I grow my email subscribers’ list? Should I buy an email list or build it myself?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne4" class="collapse fade" aria-labelledby="headingOne4" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Buying an email list is strictly a no-no! As these email ids are not verified and not all are interested in your brand. The email list is of no use if your subscribers do not open your emails. If subscribers aren’t actively engaging with your emails or aren’t interested, your email campaigning efforts are redundant.<br />
                                                    <br />
                                                    There are various ways in which you can grow your own opt-in email list. You have to ask for email ids from customers when they visit your website and in return provide them with some deliverable like e-book, whitepaper, etc.<br />
                                                    <br />
                                                    A pop-up window asking them to share their email ids should help build a list of subscribers. You can have a sidebar that will ask your blog visitors to sign in and share their email ids. Ask for their permission to send emails and promotional items.
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne5">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne5" aria-expanded="true" aria-controls="collapseOne5">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">What are the best kind of subject lines?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne5" class="collapse fade" aria-labelledby="headingOne5" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Subject lines should be striking so much so to generate a response of opening the email. It’s the first thing that your subscribers notice. It’s your gateway to further communication.
                                                <br />
                                                    <br />
                                                    So, make it personalized, short and have a message that matters to the audience. You have only 3-4 seconds to create an impact and let anyone decide to open an email.
                                                <br />
                                                    <br />
                                                    You can ask questions or create urgency by stating a deadline.
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne6">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne6" aria-expanded="true" aria-controls="collapseOne6">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">What should be the frequency of sending emails?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne6" class="collapse fade" aria-labelledby="headingOne6" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Sending an email once a month helps to create your presence in someone’s mind. Twice or thrice a month develops a connect and doesn’t create a nuisance. But, when you send emails four times a month it creates consistency.
                                                <br />
                                                    <br />
                                                    When you send offer emails you can send two emails and then send the third one as a final reminder. But, sending more than three emails just to mention the offer creates a nuisance ultimately losing a subscriber as he/she might mark you as spam. Here, in desperation to get a sale, you’ve lost an opportunity.
                                                <br />
                                                    <br />
                                                    Email frequency varies from industry to industry and you need to keep testing in order to know what works best for your brand.
                                                </div>
                                            </div>
                                            <div class="card-header" id="headingOne7">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne7" aria-expanded="true" aria-controls="collapseOne7">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">What is a good email open rate?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne7" class="collapse fade" aria-labelledby="headingOne7" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Email open rate is the percentage of people who opened your email. If someone doesn’t open your email, there are zero chances of engaging with your content and brand.
                                                <br />
                                                    <br />
                                                    On an average, 10-15 percent of email open rates work well for the sender. But, it all depends on your industry and your target audience.
                                                <br />
                                                    <br />
                                                    It’s true that open rate alone isn’t indicative of the success of your email marketing campaign. Its what people do after opening your email is what really matters.
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne8">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne8" aria-expanded="true" aria-controls="collapseOne8">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">How do I design an attractive email?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne8" class="collapse fade" aria-labelledby="headingOne8" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Use catchy images, call to actions and animated gifs that attract attention. Don’t use too many font types, font colors, and font sizes. Let the line spacing be enough. This gives good readability. Depending on the context of your emails its great to use bold colors.
                                                <br />
                                                    <br />
                                                    Don’t forget to make your email template responsive, so that it looks good across all devices.
                                                <br />
                                                    <br />
                                                    All in all, designing an attractive email includes minute details and an eye for creativity. It also depends on the type of content and the message you are conveying.
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne9">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne9" aria-expanded="true" aria-controls="collapseOne9">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">How do I analyze the results from my email campaign?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne9" class="collapse fade" aria-labelledby="headingOne9" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    Curious to know how your email campaign performed? Track these few things :
                                                <br />
                                                    <br />
                                                    <b>Click through rate:</b>
                                                    <br />
                                                    <br />
                                                    Click through rate is the percentage of recipients who clicked on the links in your email. The total number of clicks divided by the number of emails sent, multiplied by 100. This gives you an understanding of how your email campaign performed.
                                                <br />
                                                    <br />
                                                    <b>Conversion rate: </b>
                                                    <br />
                                                    <br />
                                                    This reflect that percentage of people who opened your email, read it and responded as per the desired action. You can calculate it as follows:
                                                <br />
                                                    <br />
                                                    The number of recipients who completed the required action/ total number of emails delivered multiplied by 100.
                                                <br />
                                                    <br />
                                                    <b>Bounce rate:</b>
                                                    <br />
                                                    <br />
                                                    When we see “your email has bounced”, it means that your email never actually got to your intended recipient.
                                                <br />
                                                    <br />
                                                    Divide the total number of bounced emails by the number of emails sent, and multiply it with hundred. This is your bounce rate.
                                                <br />
                                                    <br />
                                                    There are various ways in which you can manage bounces so that your email gets the desired response.
                                                <br />
                                                </div>
                                            </div>

                                            <div class="card-header" id="headingOne10">
                                                <p class="mb-0">
                                                    <button class="btn btn-link collapsed btn-block text-left border-0" type="button" data-toggle="collapse" data-target="#collapseOne10" aria-expanded="true" aria-controls="collapseOne10">
                                                        <i class="fa fa-question main"></i><i class="fa fa-angle-double-right mr-3"></i><span class="AccordianHeadline">How do I prevent people from unsubscribing?</span>
                                                    </button>
                                                </p>
                                            </div>
                                            <div id="collapseOne10" class="collapse fade" aria-labelledby="headingOne10" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    If the email subject line is irrelevant to the customers, they will ignore it a couple of times. But, if this keeps repeating they get bugged and unsubscribe from your emails.
                                                <br />
                                                    <br />
                                                    So, send relevant emails that benefit the customer. Don’t send emails that focus only on sales, offers, and discounts frequently. Send information about your company and offerings so as to connect with the customers. You can also inform them about the recent trends in your industry.
                                                <br />
                                                    <br />
                                                    The basic role of an email is to first connect with the customers, leverage this tool to the maximum.
                                                <br />
                                                    <br />
                                                    We know you still have some more questions and are eager to ask them. Connect with our team and have them answered.
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- .// Accordion -->

                <!--==========================
      Contact Section
    ============================-->
                <section id="contact" class="wow fadeInUp">
                    <span id="ContactUs"></span>
                    <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
                        crossorigin="anonymous"></script>
                    <ins class="adsbygoogle"
                        style="display: block; margin: 12px 0px 30px; text-align: center;"
                        data-ad-layout="in-article"
                        data-ad-format="fluid"
                        data-ad-client="ca-pub-5830711168897757"
                        data-ad-slot="6334773287"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>
                    <div class="container">
                        <div class="section-header">
                            <h2>We Are Available To You 24/7</h2>
                            <p>We would love to hear your valuable feedbacks. Share your thoughts, ideas, or if you have any questions too, just drop us an email.</p>
                        </div>
                        <div class="row contact-info">
                            <div class="col-md-4">
                                <div class="contact-address">
                                    <i class="ion-ios-location-outline"></i>
                                    <h3>Address</h3>
                                    <address>Suite # 46, 2nd Floor, Big City Plaza, Lahore, Pakistan</address>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="contact-phone">
                                    <i class="ion-ios-telephone-outline"></i>
                                    <h3>Phone Number</h3>
                                    <p><a href="tel:920000000000" title="Phone No">+92 317 4092224</a></p>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="contact-email">
                                    <i class="ion-ios-email-outline"></i>
                                    <h3>Email</h3>
                                    <p><a title="Email us Link" href="https://mail.google.com/mail/u/0/?fs=1&to=help@eboxmarketing.com&su=A+Chance+To+Make+A+Difference&body=Dear+EBox,+I+have+some+valuable+information+to+share+with+you.+I+have+noticed+that+%3Ctype+your+valuable+suggestions+and+feedbacks+here%3E.Thank+you.&tf=cm" target="_blank">help@eboxmarketing.com</a></p>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="text-center">
                        <a class="btn btn--radius-2 btn--blue w-25 mb-5" title="Email Us" target="_blank" href="https://mail.google.com/mail/u/0/?fs=1&to=admin@eboxmarketing.com&su=A+Chance+To+Make+A+Difference&body=Dear+EBox,+I+have+some+valuable+information+to+share+with+you.+I+have+noticed+that+%3Ctype+your+valuable+suggestions+and+feedbacks+here%3E.Thank+you.&tf=cm">Email Us Now</a>
                    </div>

                </section>
                <!-- #contact -->
                <%--Find us At--%>
             <%--   <section id="FindUs" class="wow fadeInUp d-none">
                    <div class="container">
                        <div class="section-header">
                            <h2>Are you trying to find us?</h2>
                            <p>Just in case if you are trying to find us, grab this map and follow the directions.</p>
                        </div>
                        <div class="container mb-4 px-0">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3401.1473212239953!2d74.26649411515064!3d31.520113481369634!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3919030332efb523%3A0xabb2debe5abc1236!2sZam%20Zam%20Heights%20Sabzazar%20Lahore!5e0!3m2!1sen!2s!4v1619796979386!5m2!1sen!2s" width="100%" height="380" frameborder="0" style="border: 0" allowfullscreen="" loading="lazy"></iframe>
                        </div>
                    </div>
                </section>--%>
                <%--Find us At--%>
                <!-- html fragment -->
                <%--<script async
                    src="https://pay.google.com/gp/p/js/pay.js"
                    onload="onGooglePayLoaded()"></script>--%>
            </main>
        </form>
    </div>
    <script>
        //function closeModal() {
        //    $('#GooglePayModal').modal('toggle');
        //}
       <%-- function openModal() {
            addGooglePayButton();
            $('#GooglePayModal').modal('show');
        }
        //var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_endRequest(function () {
        //    openModal();
        //});
        /**
   * Define the version of the Google Pay API referenced when creating your
   * configuration
   *
   * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#PaymentDataRequest|apiVersion in PaymentDataRequest}
   */
        const baseRequest = {
            apiVersion: 2,
            apiVersionMinor: 0
        };

        /**
         * Card networks supported by your site and your gateway
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#CardParameters|CardParameters}
         * @todo confirm card networks supported by your site and gateway
         */
        const allowedCardNetworks = ["AMEX", "DISCOVER", "JCB", "MASTERCARD", "VISA"];

        /**
         * Card authentication methods supported by your site and your gateway
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#CardParameters|CardParameters}
         * @todo confirm your processor supports Android device tokens for your
         * supported card networks
         */
        const allowedCardAuthMethods = ["PAN_ONLY"];
        //const allowedCardAuthMethods = ["PAN_ONLY", "CRYPTOGRAM_3DS"];

        /**
         * Identify your gateway and your site's gateway merchant identifier
         *
         * The Google Pay API response will return an encrypted payment method capable
         * of being charged by a supported gateway after payer authorization
         *
         * @todo check with your gateway on the parameters to pass
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#gateway|PaymentMethodTokenizationSpecification}
         */
        const tokenizationSpecification = {
            type: 'PAYMENT_GATEWAY',
            parameters: {
                'gateway': 'qualpay',
                'gatewayMerchantId': '12998'
            }
        };

        /**
         * Describe your site's support for the CARD payment method and its required
         * fields
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#CardParameters|CardParameters}
         */
        const baseCardPaymentMethod = {
            type: 'CARD',
            parameters: {
                allowedAuthMethods: allowedCardAuthMethods,
                allowedCardNetworks: allowedCardNetworks
            }
        };

        /**
         * Describe your site's support for the CARD payment method including optional
         * fields
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#CardParameters|CardParameters}
         */
        const cardPaymentMethod = Object.assign(
            {},
            baseCardPaymentMethod,
            {
                tokenizationSpecification: tokenizationSpecification
            }
        );

        /**
         * An initialized google.payments.api.PaymentsClient object or null if not yet set
         *
         * @see {@link getGooglePaymentsClient}
         */
        let paymentsClient = null;

        /**
         * Configure your site's support for payment methods supported by the Google Pay
         * API.
         *
         * Each member of allowedPaymentMethods should contain only the required fields,
         * allowing reuse of this base request when determining a viewer's ability
         * to pay and later requesting a supported payment method
         *
         * @returns {object} Google Pay API version, payment methods supported by the site
         */
        function getGoogleIsReadyToPayRequest() {
            return Object.assign(
                {},
                baseRequest,
                {
                    allowedPaymentMethods: [baseCardPaymentMethod]
                }
            );
        }

        /**
         * Configure support for the Google Pay API
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#PaymentDataRequest|PaymentDataRequest}
         * @returns {object} PaymentDataRequest fields
         */
        function getGooglePaymentDataRequest() {
            const paymentDataRequest = Object.assign({}, baseRequest);
            paymentDataRequest.allowedPaymentMethods = [cardPaymentMethod];
            paymentDataRequest.transactionInfo = getGoogleTransactionInfo();
            paymentDataRequest.merchantInfo = {
                // @todo a merchant ID is available for a production environment after approval by Google
                // See {@link https://developers.google.com/pay/api/web/guides/test-and-deploy/integration-checklist|Integration checklist}
                merchantId: 'BCR2DN6TR6A4XMQP',
                merchantName: 'Ebox Marketing Solutions'
            };

            paymentDataRequest.callbackIntents = ["PAYMENT_AUTHORIZATION"];

            return paymentDataRequest;
        }

        /**
         * Return an active PaymentsClient or initialize
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/client#PaymentsClient|PaymentsClient constructor}
         * @returns {google.payments.api.PaymentsClient} Google Pay API client
         */
        function getGooglePaymentsClient() {
            if (paymentsClient === null) {
                paymentsClient = new google.payments.api.PaymentsClient({
                    environment: 'TEST',
                    paymentDataCallbacks: {
                        onPaymentAuthorized: onPaymentAuthorized
                    }
                });
            }
            return paymentsClient;
        }

        /**
         * Handles authorize payments callback intents.
         *
         * @param {object} paymentData response from Google Pay API after a payer approves payment through user gesture.
         * @see {@link https://developers.google.com/pay/api/web/reference/response-objects#PaymentData object reference}
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/response-objects#PaymentAuthorizationResult}
         * @returns Promise<{object}> Promise of PaymentAuthorizationResult object to acknowledge the payment authorization status.
         */
        function onPaymentAuthorized(paymentData) {
            return new Promise(function (resolve, reject) {
                // handle the response
                processPayment(paymentData)
                    .then(function () {
                        resolve({ transactionState: 'SUCCESS' });
                        showDiv();
                        $('#GooglePayModal').modal('hide');
                        MyTextBox = document.getElementById("<%= PaymentStatus.ClientID %>");
                        MyTextBox.value = "Success";
                        MyTextBox.onchange();
                    })
                    .catch(function () {
                        resolve({
                            transactionState: 'ERROR',
                            error: {
                                intent: 'PAYMENT_AUTHORIZATION',
                                message: 'Insufficient funds, try again. Next attempt should work.',
                                reason: 'PAYMENT_DATA_INVALID'
                            }
                        });
                    });
            });
        }

        /**
         * Initialize Google PaymentsClient after Google-hosted JavaScript has loaded
         *
         * Display a Google Pay payment button after confirmation of the viewer's
         * ability to pay.
         */
        function onGooglePayLoaded() {
            const paymentsClient = getGooglePaymentsClient();
            paymentsClient.isReadyToPay(getGoogleIsReadyToPayRequest())
                .then(function (response) {
                    if (response.result) {
                        addGooglePayButton();
                    }
                })
                .catch(function (err) {
                    // show error in developer console for debugging
                    console.error(err);
                });
        }

        /**
         * Add a Google Pay purchase button alongside an existing checkout button
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#ButtonOptions|Button options}
         * @see {@link https://developers.google.com/pay/api/web/guides/brand-guidelines|Google Pay brand guidelines}
         */
        function addGooglePayButton() {
            const paymentsClient = getGooglePaymentsClient();
            const button =
                paymentsClient.createButton({ onClick: onGooglePaymentButtonClicked });
            document.getElementById('container').appendChild(button);
        }

        /**
         * Provide Google Pay API with a payment amount, currency, and amount status
         *
         * @see {@link https://developers.google.com/pay/api/web/reference/request-objects#TransactionInfo|TransactionInfo}
         * @returns {object} transaction info, suitable for use as transactionInfo property of PaymentDataRequest
         */
        function getGoogleTransactionInfo() {
            priceOfItem = document.getElementById("<%=subscriptionPrice.ClientID %>").innerText;
            subType = document.getElementById("<%=subscriptionType.ClientID %>").innerText;
            return {
                displayItems: [
                    {
                        label: subType + " Subscription",
                        type: "SUBTOTAL",
                        price: priceOfItem,
                    }
                ],
                countryCode: 'US',
                currencyCode: "USD",
                totalPriceStatus: "FINAL",
                totalPrice: priceOfItem,
                totalPriceLabel: "Total"
            };
        }

        /**
         * Show Google Pay payment sheet when Google Pay payment button is clicked
         */
        function onGooglePaymentButtonClicked() {
            const paymentDataRequest = getGooglePaymentDataRequest();
            paymentDataRequest.transactionInfo = getGoogleTransactionInfo();

            const paymentsClient = getGooglePaymentsClient();
            paymentsClient.loadPaymentData(paymentDataRequest);
        }

        let attempts = 0;
        /**
         * Process payment data returned by the Google Pay API
         *
         * @param {object} paymentData response from Google Pay API after user approves payment
         * @see {@link https://developers.google.com/pay/api/web/reference/response-objects#PaymentData|PaymentData object reference}
         */
        function processPayment(paymentData) {
            return new Promise(function (resolve, reject) {
                setTimeout(function () {
                    // @todo pass payment token to your gateway to process payment
                    paymentToken = paymentData.paymentMethodData.tokenizationData.token;
                    //if (attempts++ % 2 == 0) {
                    //    reject(new Error('Every other attempt fails, next one should succeed'));
                    //} else {
                    //    resolve({});
                    //}

                    resolve({});
                }, 500);
            });
        }--%>

     <%--   function showDiv() {
            document.getElementById('<%=loading.ClientID%>').className = "loader";
            document.getElementById('<%=loading.ClientID%>').focus();
            //run();
        }--%>

    </script>

    <%--    <button type="submit" name="pay" class="btn btn-primary" id="submitPaymentMethod"
onClick="loadIframe();">Continue to Easypay Portal</button>

<iframe id="easypay-iframe" name="easypay-iframe" src="about:blank" width="100%"
height="500px"></iframe>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js" integrity="sha512-c3Nl8+7g4LMSTdrm621y7kf9v3SDPnhxLNhcjFJbKECVnmZHTdo+IRO05sNLTH/D3vA6u1X32ehoLC7WFVdheg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/ricmoo/aes-js/e27b99df/index.js"></script>

<script>
            function getValues() {

        }
 function loadIframe(iframeName, url) {

     var storeID = "12414"; //document.getElementById("storeId").value;
     var amount = "100"; //document.getElementById("amount").value;
     var orderID = "10"; //document.getElementById("orderId").value;
     var email = "name@example.com"; //document.getElementById("email").value;
     var cellNo = "03000000000"; //document.getElementById("cellNo").value;
     var token = "YOUR_MERCHANT_TOKEN"; //document.getElementById("token").value;
     var bankId = ""; //document.getElementById("bankId").value;
     var postBackURL = ""; //document.getElementById("postBackURL").value;
     var merchantPaymentMethod = "CC_PAYMENT_METHOD"; //document.getElementById("merchantPaymentMethod").value;
     
     var aesjs = require(["aes-js"])

     var keyString = 'CRW4SGV95G6PPW8P';//Your hash key

     var input = 'amount=100&emailAddress=name@example.com&expiryDate=20210730024336&merchantPaymentMethod=CC_PAYMENT_METHOD&mobileNum=03000000000&orderRefNum=97303878&paymentMethod=InitialRequest&postBackURL=https://staging.winkells.com/payment-response&storeId=12375&timeStamp=2021-06-30T09:49:00';

     const keyBuffer = aesjs.utils.utf8.toBytes(keyString);

     const inputBuffer = aesjs.padding.pkcs7.pad(aesjs.utils.utf8.toBytes(input));

     const escEcb = new aesjs.ModeOfOperation.ecb(keyBuffer);

     const encryptedBytes = escEcb.encrypt(inputBuffer);

     const encryptedData = Buffer.from(encryptedBytes).toString('base64');

     console.log(encryptedData);
     var encryptedHashRequest = encryptedData2;

     var signature = ""; //document.getElementById("signature").value;
            var params = {
                storeId: storeID, orderId: orderID, transactionAmount: amount,
                mobileAccountNo: cellNo, emailAddress: email, transactionType: "InitialRequest", tokenExpiry: token,
                bankIdentificationNumber: bankId, encryptedHashRequest:encryptedHashRequest, merchantPaymentMethod: merchantPaymentMethod,
                postBackURL: postBackURL, signature: signature
            };
            var $iframe = $('#' + iframeName);

            if ($iframe.length) {
                if (params.storeId != "" && params.orderId != "") {
                    var str = jQuery.param(params);
                    $iframe.attr('src', url + '?' + str); // here you can change src
                    /*console.log(url + str);*/
                }
                return false;
            }

            return true;
        }

     ////Sample UAT
     //https://easypaystg.easypaisa.com.pk/tpg/?storeId=1&orderId=6&transactionAmount=500.0&mobileAccountNo=03000000000&emailAddress=name@example.com&transactionType=InitialRequest&tokenExpiry=20201231%20111111&bankIdentificationNumber=&encryptedHashRequest=f4jnS1GpY97qR0KjjNutzdIbMhrtmgHObhMGWi9Sp7DS%2Bk2FVM7usiV3K%2Fssyo8ULftZBUXkv%2FzduHaFcxq7dMRK62BgBppP61ZUQ%2BaOZzcXmKw6CgGCh71Vz3UuDulpDN

        $("#submitPaymentMethod").click(function () {
            $("#iframe-class").addClass("show-iframe");
            return loadIframe('easypay-iframe', 'https://easypaystg.easypaisa.com.pk/tpg/?');
        });
</script>--%>
    <%-- <script>
     (function (document, src, libName, config) {
         var script = document.createElement('script');
         script.src = src;
         script.async = true;
         var firstScriptElement = document.getElementsByTagName('script')[0];
         script.onload = function () {
             for (var namespace in config) {
                 if (config.hasOwnProperty(namespace)) {
                     window[libName].setup.setConfig(namespace, config[namespace]);
                 }
             }
             window[libName].register();
         };

         firstScriptElement.parentNode.insertBefore(script, firstScriptElement);
     })(document, 'https://secure.2checkout.com/checkout/client/twoCoInlineCart.js', 'TwoCoInlineCart', { "app": { "merchant": "251215024005", "iframeLoad": "checkout" }, "cart": { "host": "https:\/\/secure.2checkout.com", "customization": "inline" } });
 </script>--%>
</asp:Content>
