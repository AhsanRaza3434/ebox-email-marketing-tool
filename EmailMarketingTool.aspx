<%@ Page Title="" Language="VB" enableSessionState="true" MaintainScrollPositionOnPostback="true" Async="true" MasterPageFile="~/BulkEmails.master" ValidateRequest="false" EnableEventValidation="false" CodeFile="EmailMarketingTool.aspx.vb" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Mass Emails Sender Tool | EBox Marketing</title>
    <meta name="description" content="Bulk emails tool, start sending mass emails to your clients today and promote your brand among potential customers.">
    <link rel="canonical" href="https://www.eboxmarketing.com/EmailMarketingTool">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="RadScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<script id="PDS644430" type="text/javascript">(function (d) { var wrapper = d.createElement("script"); wrapper.id = "WDS644430"; wrapper.type = "text/javascript"; wrapper.src = "https://s.adlane.info/?floor=0&content_page_url=" + encodeURIComponent(window.location.href) + "&width=970&height=90&cb=" + (new Date()).getTime().toString() + "&aid=644430"; var s = d.getElementById("PDS644430"); s.parentNode.insertBefore(wrapper, s); }(document));</script>--%>
        <div class="page-wrapper pt-100 bg-gra-02 p-b-100 font-poppins">
            <div class="wrapper w-82">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb pl-0">
                        <li class="breadcrumb-item"><a title="Bulk Email Marketing Tool Page" href="/Bulk-Email-Services-Page.aspx">Bulk Emails Service Page</a></li>
                        <li class="breadcrumb-item">Email Marketing Tool</li>
                    </ol>
                </nav>
                <div class="card card-4">
                    <div class="card-body mx-auto py-5 w-100">
                        <h1 class="H1title">Send Free Bulk Emails</h1>
                        <div class="mb-1 row">
                            <div class="col-sm-12 col-lg-12">
                                <asp:Label ID="SignInNotification" CssClass="NotificationText text-secondary" runat="server"> </asp:Label>
                                <asp:Label ID="NotificationText" CssClass="NotificationText" runat="server"> </asp:Label>
                            </div>
                        </div>
                        <div id="bodyDisabled" runat="server">
                          <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="ImportEmailsBtn" />
                                </Triggers>
                                <ContentTemplate>
                                    
                                    <div class="border-bottom-emailbox d-none">
                                        <div class="mb-1 row">
                                            <div class="col-sm-12 mb-2">
                                                <div class="row">
                                                    <div class="col-sm-12 col-lg-6">
                                                        <asp:Label Text="1. Link Your Desired Gmail Account To Send Emails." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                                        <span class="text-left fs-14 mb-2 mb-lg-0 d-block text-muted">Feel free to use the demo credentials to send emails.</span>
                                                    </div>
                                                    <div class="col-sm-12 col-lg-6">
                                                        <asp:LinkButton ID="GmailLoginBtn" runat="server" CssClass="float-lg-right float-left"><img class="GoogleBtnimg" title="Google Sign up Image" src="img/name@example.com" alt="Google Sign In Button"/></asp:LinkButton>
                                                        <asp:LinkButton ID="UseDemoCredentialsBtn" runat="server" CssClass="btn btn-primary float-lg-right float-left text-white btn-DemoCre mr-2"> Use Demo Credentials</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="col-sm-12 col-lg-6">
                                               <asp:Label Text="Sender Gmail Address*" runat="server" CssClass="FormTitle"></asp:Label>
                                               <asp:TextBox ID="SenderEmailAddress" Enabled="false" AutoCompleteType="None" Placeholder="It will be fetched automatically" runat="server" TextMode="Email" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-lg-6">
                                                <asp:Label Text="Sender Gmail Password*" runat="server" CssClass="FormTitle"></asp:Label>
                                                <asp:TextBox ID="SenderPassword" type="password" Placeholder="Enter sender's gmail password" runat="server" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="border-bottom-emailbox  d-none" id="InstructionsBody" runat="server">
                                        <div class="mb-1 row">
                                            <div class="col-sm-12">
                                                <asp:Label Text="2. Allow device and timezone to send emails." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                                <span class="text-left fs-14 d-block text-muted mb-2">Make sure that you allow this application for the same Email Address that you have provided above.</span>
                                                <asp:Label ID="InstructionOneText" CssClass="InstructionsToLogin" runat="server"><span class="text-success">✔️ Step-1:</span> Login to Gmail, then allow <a href="https://www.google.com/settings/security/lesssecureapps" target="_blank" class="text-primary">Access & Authenticate</a>, and make sure it is allowed by visiting the link again.</asp:Label>
                                                <asp:Label ID="InstructionThreeText" CssClass="InstructionsToLogin pt-1" runat="server"><span class="text-success">✔️ Step-2:</span> Click on <a href="https://g.co/allowaccess" target="_blank" class="text-primary">Continue</a> to Enable Access and allow the server's timezone in your Google Account to send emails.</asp:Label>
                                                <asp:Label ID="breaker" CssClass="border-bottom mb-1 pb-2 d-block" runat="server"></asp:Label>
                                                <asp:Label ID="InstructionTwoText" CssClass="InstructionsToLogin pt-1" runat="server"><span class="text-danger">🎌 Case-2:</span> If you have enabled <b>2-Step Verification</b>, click here to <a href="https://myaccount.google.com/u/0/apppasswords" target="_blank" class="text-primary"> Generate Password</a>. It will be used as your gmail login password below.</asp:Label>
                                                <asp:Label ID="InstructionForthText" CssClass="InstructionsToLogin pt-1" runat="server"><span class="text-danger">🎌 Case-3:</span> If you still face any problem, view <a href="image/Instructions.pdf" target="_blank" class="text-primary">Instructions</a> in details with pictures.</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="border-bottom-emailbox">
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                            <!-- modal for saved templates-->
                            <div class="ModalSlider modal fade" id="SavedTempModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <!-- carousel -->
                                            <div id='carouselExampleIndicators2' class='carousel slide' data-interval="false">
                                                <div class='carousel-inner'>
                                                    <asp:Repeater ID="ModalSlider_TemplateRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <div class="carousel-item <%#If(Container.ItemIndex = 0, "active", "") %>" id='<%#Container.DataItem("ID")%>'>
                                                                <div class="ModalSlider_TemplateBody">
                                                                    <div class="ModalSlider_Header">
                                                                        <div class="row">
                                                                            <div class="col-sm-8">
                                                                                <h2>Your Saved Template #<asp:Label ID="tempIDText" runat="server" Text='<%#Container.DataItem("ID")%>'></asp:Label>:</h2>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <asp:LinkButton ID="TemplateDeleteBtn" OnClick="GetValue" runat="server" OnClientClick="showUploader()" CssClass="btn btn-danger text-white btn-Modal" Text="Delete Template" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ModalSlider_SubjectHeader">
                                                                        <h4>Subject:
                                                                        </h4>
                                                                        <asp:Label ID="TemplateSubject" CssClass="ModalSlider_Subject" runat="server" Text='<%#Container.DataItem("Subject")%>'></asp:Label>
                                                                        <h4>Body:
                                                                        </h4>
                                                                    </div>
                                                                    <asp:Label ID="SavedTemplateID" Visible="false" Text='<%#Container.DataItem("ID")%>' runat="server">
                                                                    </asp:Label>
                                                                    <asp:Label ID="SavedTemplateText" Text='<%#Container.DataItem("Text")%>' runat="server">
                                                                    </asp:Label>
                                                                    <div class="modal-footer2">
                                                                        <asp:LinkButton ID="GetSavedTemplateBtn" OnClick="GetSavedTemplateText" runat="server" OnClientClick="showUploader()" CssClass="btn btn-success text-white btn-Modal" Text="Use It" />
                                                                        <button type="button" class="btn btn-danger text-white btn-Modal" data-dismiss="modal">Close</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <a class='carousel-control-prev' href='#carouselExampleIndicators2' role='button' data-slide='prev'>
                                                    <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                                                    <span class='sr-only'>Previous</span>
                                                </a>
                                                <a class='carousel-control-next' href='#carouselExampleIndicators2' role='button' data-slide='next'>
                                                    <span
                                                        class='carousel-control-next-icon'
                                                        aria-hidden='true'></span>
                                                    <span class='sr-only'>Next</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- modal for default templates-->
                            <div class="ModalSlider modal fade" id="largeModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <!-- carousel -->
                                            <div id='carouselExampleIndicators' class='carousel slide' data-interval="false">
                                                <div class='carousel-inner'>
                                                    <asp:Repeater ID="ModalSlider_DefaultTemplateRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <div class="carousel-item <%#If(Container.ItemIndex = 0, "active", "") %>" id='<%#Container.DataItem("ID")%>'>
                                                                <div class="ModalSlider_TemplateBody">
                                                                    <div class="ModalSlider_Header">
                                                                        <h2>
                                                                            <asp:Label ID="TemplateHeading" CssClass="DefaultTemplate_Header" Text='<%#Container.DataItem("Header")%>' runat="server">
                                                                            </asp:Label></h2>
                                                                    </div>
                                                                    <div class="ModalSlider_SubjectHeader">
                                                                        <h4>Subject:
                                                                        </h4>
                                                                        <asp:Label ID="TemplateSubject" CssClass="ModalSlider_Subject" runat="server" Text='<%#Container.DataItem("Subject")%>'></asp:Label>
                                                                        <h4>Body:
                                                                        </h4>
                                                                    </div>
                                                                    <p>
                                                                        <asp:Label ID="TemplateText" CssClass="DefaultTemplate_Text" Text='<%#Container.DataItem("Text")%>' runat="server">
                                                                        </asp:Label>
                                                                    </p>
                                                                    <div class="modal-footer2">
                                                                        <asp:LinkButton ID="templateSelectBtn" OnClick="UseDefaultTemplate" runat="server" OnClientClick="showUploader()" CssClass="btn btn-success text-white btn-Modal" Text="Use It" />
                                                                        <button type="button" class="btn btn-danger text-white btn-Modal" data-dismiss="modal">Close</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <a
                                                    class='carousel-control-prev'
                                                    href='#carouselExampleIndicators'
                                                    role='button'
                                                    data-slide='prev'>
                                                    <span class='carousel-control-prev-icon'
                                                        aria-hidden='true'></span>
                                                    <span class='sr-only'>Previous</span>
                                                </a>
                                                <a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'>
                                                    <span
                                                        class='carousel-control-next-icon'
                                                        aria-hidden='true'></span>
                                                    <span class='sr-only'>Next</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="border-bottom-emailbox">
                                <div class="row">
                                    <div class="col-sm-12 mb-2">
                                        <asp:Label Text="1. Enter Sender Details, Write a catchy Subject with a concise Email Body Text." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                        <span class="text-left fs-14 d-block text-muted">Note: If you don't want to use a company email, then leave the company email box empty, it'll pick your Gmail address automatically.</span>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div id="loading" runat="server" class="loader imHidden">
                                        <img src="image/Loading.gif" title="Loading Gif" alt="Loading gif" />
                                        <asp:Label ID="Label1" Text="Please be patient... It may take a while." CssClass="Loader_Text" runat="server"> </asp:Label>
                                    </div>
                                    <div id="uploading" runat="server" class="loader imHidden">
                                        <img src="image/Uploading.gif" title="Uploading Gif" alt="uploading gif" />
                                        <asp:Label ID="Label2" Text="Please be patient... It may take a while." CssClass="Loader_Text" runat="server"> </asp:Label>
                                    </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-lg-12">
                                                <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" CssClass="RadioButtonsCss" RepeatDirection="Vertical" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                                                    <asp:ListItem Value="0">Add CC</asp:ListItem>
                                                    <asp:ListItem Value="1">Add BCC</asp:ListItem>
                                                    <asp:ListItem Value="3">Add Both</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">None</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-sm-12 col-lg-6 mt-1" id="CCBCCTextDiv" runat="server">
                                                <asp:Label Text="CCBCCText" ID="CCBCCText" runat="server" CssClass="FormTitle"></asp:Label>
                                                <asp:TextBox ID="CCBCCTextbox" runat="server" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-lg-6 mt-1" id="CCBCCTextDivBoth" runat="server">
                                                <asp:Label Text="CCBCCBothText" ID="CCBCCBothText" runat="server" CssClass="FormTitle"></asp:Label>
                                                <asp:TextBox ID="CCBCCTextboxBoth" runat="server" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-lg-6">
                                                <%--<asp:Label Text="Demo Name: EBox Demo User" runat="server" CssClass="text-left fs-14 text-muted d-inline-block w-100"></asp:Label>--%>
                                                <asp:Label Text="Sender Customize Name*" runat="server" CssClass="FormTitle"></asp:Label>
                                                <asp:TextBox ID="SenderName" Placeholder="Enter sender's name" runat="server" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-lg-6">
                                                <%--<asp:Label Text="Demo Company Name: demo@eboxmarketing.com" runat="server" CssClass="text-left fs-14 text-muted d-inline-block w-100"></asp:Label>--%>
                                                <asp:Label Text="Sender Company Email Address (Optional)" runat="server" CssClass="FormTitle"></asp:Label>
                                                <asp:TextBox ID="SenderCompanyEmailAddress" Placeholder="Enter sender's company email address" runat="server" TextMode="Email" CssClass="form-control LetterBody mb-2"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 mb-2">
                                                <span class="text-left fs-14 d-block text-muted">Note: Your company email must be linked to your google email account that you have provided above as a sender's email<%--<span id="googleEmailRef" class="ml-1 text-info" runat="server"></span>--%>, if you use one.</span>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-sm-12 col-lg-12">
                                        <asp:Label Text="Email Subject*" runat="server" CssClass="FormTitle"></asp:Label>
                                        <asp:TextBox ID="LetterSubject" runat="server" Placeholder="Enter a catchy and concise subject for the email" AutoCompleteType="None" CssClass="form-control LetterBody mb-2" Rows="1"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-12 col-lg-12">
                                        <asp:Label Text="Email Body*" runat="server" CssClass="FormTitle"></asp:Label>
                                        <asp:TextBox ID="LetterBody" runat="server" placeholder="If you do not know what to write, then choose one of the provided email templates according to your need and modify them." CssClass="form-control LetterBody" TextMode="MultiLine" Rows="12"></asp:TextBox>
                                        <asp:Label runat="server" CssClass="text-left fs-12">Hint: Use <span class="text-primary">@ClientName</span> & <span class="text-primary">@ClientCompany</span> to change them into client's name & company. For example, @ClientName = Alex & @ClientCompany = Ebox.</asp:Label>
                                    </div>
                                    <div class="col-sm-12 col-lg-12 mt-2">
                                        <a href="#" title="Default Templates Modal Btn" class="btn btn-primary text-white btn-DeleteAll float-left" data-toggle="modal" data-target="#largeModal">Show Default Templates</a>
                                        <asp:LinkButton ID="SaveTemplateBtn" runat="server" OnClientClick="showUploader()" CssClass="btn btn-success text-white btn-DeleteAll ml-2 float-left" Text="Save Template" />
                                        <a href="#" title="Saved Templates Modal Btn" id="SavedTemplatesBtn" runat="server" class="btn btn-warning text-white btn-DeleteAll float-left ml-2" data-toggle="modal" data-target="#SavedTempModal">Show Saved Templates</a>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="Button1" />
                                    <asp:PostBackTrigger ControlID="AttachEmailSignatureBtn" />
                                    <asp:PostBackTrigger ControlID="Sava_button" />
                                    <asp:PostBackTrigger ControlID="FollowUp_button" />
                                    <asp:PostBackTrigger ControlID="ExportUnsentEmailsBtn" />
                                    <asp:PostBackTrigger ControlID="ExportSentEmailsBtn" />
                                    <asp:PostBackTrigger ControlID="ExportFollowedEmailsBtn" />
                                    <asp:PostBackTrigger ControlID="ImportEmailsBtn" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="d-block border-bottom-emailbox pb-0 mb-3">
                                        <div class="form-group row">
                                            <div class="col-sm-12 mb-2">
                                                <asp:Label Text="2. You can insert your signature or attach files if you want. (Optional)" runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                                <span class="text-left fs-14 d-block text-muted">Attach your important documents or add your professional signature which are totally optional.</span>
                                            </div>
                                            <div class="col-sm-12 col-lg-6">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <label class="FormTitle">Add Email Signature: </label>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="row">
                                                            <div class="col-sm-12 col-lg-9">
                                                                <asp:FileUpload ID="AttachEmailSignature" CssClass="UploaderCss" AllowMultiple="false" runat="server" OnDataBinding="AttachEmailSignature_DataBinding" />
                                                                <asp:Label Text="Only .png, .jpg or .jpeg image files are allowed." ID="InnerAttachmentText" runat="server" CssClass="pt-1 text-muted"></asp:Label>
                                                                <asp:Button ID="AttachEmailSignatureBtn" runat="server" Style="display: none" OnClientClick="showUploader()" Text="Button" />
                                                            </div>
                                                            <div class="col-sm-12 pt-2 pl-lg-2 pt-lg-0 col-lg-3 mb-3 mb-lg-2">
                                                                <asp:LinkButton ID="RemoveInnerAttachments" runat="server" OnClientClick="showUploader()" CssClass="btnUpload2 btn--radius-2 btn-info text-white w-50" Text="Remove" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-lg-6">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <label class="FormTitle">Upload Attachements: </label>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="row">
                                                            <div class="col-sm-12 col-lg-9">
                                                                <asp:FileUpload ID="image_FileUpload" CssClass="UploaderCss" AllowMultiple="true" runat="server" OnDataBinding="image_FileUpload_DataBinding" />
                                                                <asp:Label Text="It must not be a .rar file & exceed 20mb size." ID="FileUploadText" runat="server" CssClass="pt-1 text-muted"></asp:Label>
                                                                <asp:Button ID="Button1" runat="server" Style="display: none" OnClientClick="showUploader()" Text="Button" />
                                                            </div>
                                                            <div class="col-sm-12 pt-2 pl-lg-2 pt-lg-0 col-lg-3">
                                                                <asp:LinkButton ID="RemoveAttachments" runat="server" OnClientClick="showUploader()" CssClass="btnUpload2 btn--radius-2 btn-info text-white w-50" Text="Remove" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <label class="fs-12 m-0 p-0">You can also create your signature from <a target="_blank" title="Signature Link" class="text-primary" href="https://www.mail-signatures.com/signature-generator/">Signature Generator.</a> When ready, just copy/paste them into the body of the email.</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="d-block border-bottom-emailbox">
                                        <div class="mb-2">
                                            <asp:Label Text="3. Select & Mark the emails to whom you want to send emails." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                            <span class="text-left fs-14 d-block text-muted">Note: You can either import emails in bulk by editing and importing this <a href="TemplateEmails.csv" title="Downloadable CSV file" target="_blank" class="text-primary fs-14">.csv file sample</a> or by adding emails manually one by one.</span>
                                            <%--<span class=" d-block">
                                                    <asp:Label Text="Remaining Importable Emails For Today: " runat="server" ID="AvailableEmailsStart" CssClass="text-left fs-14 text-muted"></asp:Label>
                                                    <asp:Label Text="" runat="server" ID="AvailableEmailsText" CssClass="text-left fs-14 text-success"></asp:Label></span>
                                                <asp:Label Text="Sorry, you have reached your uploading limit for today." runat="server" ID="LimitReachedText" CssClass="text-left d-block fs-14 text-danger"></asp:Label>--%>
                                            <asp:FileUpload ID="ImportEmailsUploader" AllowMultiple="true" runat="server" CssClass="UploaderCss rounded-0 rounded-right p-0 my-1" />
                                            <asp:Button ID="ImportEmailsBtn" OnClientClick="showUploader()" CssClass="btnUpload btn--radius-2 d-none btn-info text-white w-50" runat="server" Text="Import Emails" />
                                        </div>
                                        <asp:Label Text="Unsent Emails:" runat="server" CssClass="FormTitle"></asp:Label>
                                        <span class="FormTitle pl-0">
                                            <asp:Label ID="UnsentMailsQty" runat="server"></asp:Label></span>
                                        <asp:Label Text=" | " runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                        <asp:Label Text="Selected Emails:" runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                        <span class="fs-12 m-0 p-0">
                                            <asp:Label ID="SelectedUnsentEmails" runat="server"></asp:Label></span>
                                        <asp:LinkButton ID="AddEmailButton" OnClientClick="showUploader()" runat="server" CssClass="btn btn-primary text-white btn-DeleteAll ml-2 mb-1" ToolTip="Add a single email data manually.">Add An Email</asp:LinkButton>
                                        <asp:LinkButton ID="UpdateRecordUnsent" OnClientClick="showUploader()" runat="server" CssClass="btn btn-success text-white btn-DeleteAll mx-2 mb-1">Update Record</asp:LinkButton>
                                        <asp:LinkButton ID="AddEmailRowBtn" OnClientClick="showUploader()" runat="server" CssClass="btn btn-success text-white btn-DeleteAll mx-2 mb-1">Add Record</asp:LinkButton>
                                        <asp:LinkButton ID="CancelAddBtn" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Cancel</asp:LinkButton>
                                        <asp:LinkButton ID="DeleteAllUnsentMailsBtn" OnClientClick="showUploader()" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Delete Selected</asp:LinkButton>
                                        <asp:LinkButton ID="ExportUnsentEmailsBtn" runat="server" CssClass="btn btn-warning text-white btn-DeleteAll mx-2 mb-1">Export Selected</asp:LinkButton>
                                        <asp:LinkButton ID="SelectAllBtn" runat="server" CssClass="btn btn-info text-white btn-DeleteAll mx-2 mb-1" ToolTip="Select all emails to send emails.">Select All Email</asp:LinkButton>
                                        <asp:LinkButton ID="UnSelectAllBtn" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1" ToolTip="Unselect all emails to send emails.">Unselect All Emails</asp:LinkButton>
                                        <asp:GridView ShowFooter="true" OnRowEditing="radGrid3_RowEditing" OnRowDeleting="radGrid3_RowDeleting" OnRowCommand="radGrid3_RowCommand"
                                            EmptyDataText="No Record Found" ID="radGrid3" runat="server" CssClass="scrollbar style-1 Form-Grid table table-striped table-light rounded p-1" EnableEmbeddedSkins="false"
                                            AutoGenerateColumns="False" GridLines="None"
                                            AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                            AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Name" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 200px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Sr" runat="server" Text='<%#Eval("Sr")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="EmailAddress" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 250px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="CompanyName" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 225px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Uploaded Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="DateSent" CssClass="GridCommonCSS text-left form-label mb-2 d-block" Style="width: 140px!important" runat="server" Text='<%#Eval("DateSent")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" Visible="false" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Emails") %>' CommandName="Delete" runat="server" CssClass="btn btn-danger text-white btn-Delete">Delete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditRecord" CommandArgument='<%# Eval("Emails") %>' CommandName="Edit" runat="server" CssClass="btn btn-success text-white btn-Delete">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="SelectRecord" Checked="true" CommandName="Select" runat="server" CssClass="gridCheckbox" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ShowFooter="true" EmptyDataText="No Record Found" ID="SelectedRows" runat="server" Visible="false" EnableEmbeddedSkins="false"
                                            AutoGenerateColumns="False" GridLines="None"
                                            AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                            AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Name" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 192px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Emails" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 225px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Company" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 150px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Sr" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="d-block border-bottom-emailbox">
                                        <div class="mb-2">
                                            <asp:Label Text="3.1. Select & Mark the sent emails whom you want to follow-up with an email." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                            <span class="text-left fs-14 d-block text-muted">Check if your client has opened your emails or not. The follow-up button will send emails to the following people, spontaneously.</span>
                                        </div>
                                        <asp:Label Text="Sent Emails:" runat="server" CssClass="FormTitle"></asp:Label>
                                        <span class="FormTitle">
                                            <asp:Label ID="SentMailsQty" runat="server"></asp:Label></span>
                                        <asp:Label Text=" | " runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                        <asp:Label Text="Selected Emails:" runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                        <span class="fs-12 m-0 p-0">
                                            <asp:Label ID="SelectedSentEmailsText" runat="server"></asp:Label></span>
                                        <asp:LinkButton ID="UpdateRecordSent" OnClientClick="showUploader()" runat="server" CssClass="btn btn-success text-white btn-DeleteAll mx-2 mb-1">Update Record</asp:LinkButton>
                                        <asp:LinkButton ID="CancelButtonSent" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Cancel</asp:LinkButton>
                                        <asp:LinkButton ID="DeleteAllSentMailsBtn" OnClientClick="showUploader()" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Delete Selected</asp:LinkButton>
                                        <asp:LinkButton ID="ExportSentEmailsBtn" runat="server" CssClass="btn btn-warning text-white btn-DeleteAll mx-2 mb-1">Export Selected</asp:LinkButton>
                                        <asp:LinkButton ID="SelectAllSentBtn" runat="server" CssClass="btn btn-info text-white btn-DeleteAll mx-2 mb-1" ToolTip="Select all emails to send emails.">Select All Email</asp:LinkButton>
                                        <asp:LinkButton ID="UnSelectAllSentBtn" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1" ToolTip="Unselect all emails to send emails.">Unselect All Emails</asp:LinkButton>
                                        <asp:GridView ShowFooter="true" EmptyDataText="No Record Found" ID="radGrid2" runat="server" CssClass="scrollbar style-1 Form-Grid table table-striped table-light rounded p-1" EnableEmbeddedSkins="false"
                                            AutoGenerateColumns="False" OnRowEditing="radGrid2_RowEditing" OnRowDeleting="radGrid2_RowDeleting" OnRowCommand="radGrid2_RowCommand" GridLines="None"
                                            AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                            AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Name2" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 150px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Sr" runat="server" Text='<%#Eval("Sr")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="EmailAddress2" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 230px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="CompanyName" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 200px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Sent Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="DateSent2" CssClass="GridCommonCSS text-left form-label mb-2 d-block" Style="width: 115px!important" runat="server" Text='<%#Eval("DateSent")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Status" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Status" CssClass="GridCommonLabelCSS form-label mb-2 d-block" Style="width: 87px!important" runat="server" Text='<%#Eval("ReadStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" Visible="false" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Emails") %>' CommandName="Delete" runat="server" CssClass="btn btn-danger text-white btn-Delete">Delete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditRecord" CommandArgument='<%# Eval("Emails") %>' CommandName="Edit" runat="server" CssClass="btn btn-success text-white btn-Delete">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="SelectRecord" Checked="true" CommandName="Select" runat="server" CssClass="gridCheckbox" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ShowFooter="true" Visible="false" EmptyDataText="No Record Found" ID="SelectedSentEmailRows" runat="server" EnableEmbeddedSkins="false"
                                            AutoGenerateColumns="False" GridLines="None"
                                            AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                            AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Name" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 192px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Emails" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 225px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Company" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 150px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Sr" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="border-bottom-emailbox">
                                        <div class="row">
                                            <div class="col-sm-12 mb-2">
                                                <asp:Label Text="4. Finally, start sending emails to your clients." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                                <span class="text-left fs-14 d-block text-muted">Note: The emails will only be sent to those whom you have selected from the bottom tables. They are all selected by default.</span>
                                            </div>
                                            <div class="col-sm-6 mb-4 mb-lg-1">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <span class="LastEmailsText">Last Sent: </span>
                                                        <asp:Label ID="LastMailSentDate" CssClass="LastEmailsText" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <asp:Button class="btn btn--radius-2 btn--blue" ID="Sava_button" runat="server" OnClientClick="showDiv()" Text="Send Emails" />
                                                        <%--<asp:Label Text="" runat="server" ID="RemainingEmailsPreText" CssClass="text-left fs-14 text-muted"></asp:Label>
                                                        <asp:Label Text="" runat="server" ID="RemainingEmailsText" CssClass="text-left fs-14 text-success"></asp:Label>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <span class="LastEmailsText">Last Followed-up: </span>
                                                        <asp:Label ID="LastFollowupMailSentDate" CssClass="LastEmailsText" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <asp:Button class="btn btn--radius-2 btn--blue" ID="FollowUp_button" OnClientClick="showDiv()" runat="server" Text="Send Follow-Ups" />
                                                        <%--<asp:Label ID="SendFollowUpstext" CssClass="DisabledButton" Text="Send Follow-Ups" runat="server"></asp:Label>--%>
                                                        <%--<asp:Label Text="Remaining Follow Up Emails For A Month: " runat="server" ID="RemainingFollowUpEmailsPreText" CssClass="text-left fs-14 text-muted"></asp:Label>
                                                        <asp:Label Text="" runat="server" ID="RemainingFollowUpEmailsText" CssClass="text-left fs-14 text-success"></asp:Label>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--        <div class="col-sm-4">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Button class="btn btn--radius-2 btn--blue" ID="PrintPage_Btn" runat="server" Text="Print Page" />
                                                        <%--<asp:Label ID="SendFollowUpstext" CssClass="DisabledButton" Text="Send Follow-Ups" runat="server"></asp:Label>--%>
                                            <%--<asp:Label Text="Remaining Follow Up Emails For A Month: " runat="server" ID="RemainingFollowUpEmailsPreText" CssClass="text-left fs-14 text-muted"></asp:Label>
                                                        <asp:Label Text="" runat="server" ID="RemainingFollowUpEmailsText" CssClass="text-left fs-14 text-success"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>

                                    <div class="border-bottom-emailbox">
                                        <div class="d-block">
                                            <div class="mb-2">
                                                <asp:Label Text="5. View the follow-up emails status and export them whenever you want." runat="server" CssClass="EmailInstructionsText"></asp:Label>
                                                <span class="text-left fs-14 d-block text-muted">You can simply export them into .csv file<span id="NotForTrialText" runat="server"> or visit the <a title="Dashboard" href="UserDashboard.aspx">Dashboard</a> for a 360-degree insight</span>.</span>
                                            </div>
                                            <asp:Label Text="Followed-Up Emails:" runat="server" CssClass="FormTitle"></asp:Label>
                                            <span class="FormTitle">
                                                <asp:Label ID="FollowedUpMailsQty" runat="server"></asp:Label></span>
                                            <asp:Label Text=" | " runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                            <asp:Label Text="Selected Emails:" runat="server" CssClass="fs-12 m-0 p-0"></asp:Label>
                                            <span class="fs-12 m-0 p-0">
                                                <asp:Label ID="SelectedFollowedEmailsText" runat="server"></asp:Label></span>
                                            <asp:LinkButton ID="UpdateRecordFollowed" OnClientClick="showUploader()" runat="server" CssClass="btn btn-success text-white btn-DeleteAll mx-2 mb-1">Update Record</asp:LinkButton>
                                            <asp:LinkButton ID="CancelButtonFollowed" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Cancel</asp:LinkButton>
                                            <asp:LinkButton ID="DeleteAllFollowedupMailsBtn" OnClientClick="showUploader()" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1">Delete Selected</asp:LinkButton>
                                            <asp:LinkButton ID="ExportFollowedEmailsBtn" runat="server" CssClass="btn btn-warning text-white btn-DeleteAll mx-2 mb-1">Export Selected</asp:LinkButton>
                                            <asp:LinkButton ID="SelectFollowedEmailsBtn" runat="server" CssClass="btn btn-info text-white btn-DeleteAll mx-2 mb-1" ToolTip="Select all emails to send emails.">Select All Email</asp:LinkButton>
                                            <asp:LinkButton ID="UnselectFollowedEmailsBtn" runat="server" CssClass="btn btn-danger text-white btn-DeleteAll mx-2 mb-1" ToolTip="Unselect all emails to send emails.">Unselect All Emails</asp:LinkButton>
                                            <asp:GridView ShowFooter="true" EmptyDataText="No Record Found" ID="radGrid1" runat="server" CssClass="scrollbar style-1 Form-Grid table table-striped table-light rounded p-1" EnableEmbeddedSkins="false"
                                                AutoGenerateColumns="False" GridLines="None" OnRowEditing="radGrid1_RowEditing" OnRowDeleting="radGrid1_RowDeleting" OnRowCommand="radGrid1_RowCommand"
                                                AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                                AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Name3" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 150px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Sr" runat="server" Text='<%#Eval("Sr")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="EmailAddress3" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 215px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="CompanyName" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 205px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Followed-Up Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="DateSent3" CssClass="GridCommonCSS text-left form-label mb-2 d-block" Style="width: 115px!important" runat="server" Text='<%#Eval("DateSent")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Status" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Status" CssClass="GridCommonLabelCSS form-label mb-2 d-block" Style="width: 87px!important" runat="server" Text='<%#Eval("ReadStatus")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" Visible="false" HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Emails") %>' CommandName="Delete" runat="server" CssClass="btn btn-danger text-white btn-Delete">Delete</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="EditRecord" CommandArgument='<%# Eval("Emails") %>' CommandName="Edit" runat="server" CssClass="btn btn-success text-white btn-Delete">Edit</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="SelectRecord" Checked="true" CommandName="Select" runat="server" CssClass="gridCheckbox" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ShowFooter="true" Visible="false" EmptyDataText="No Record Found" ID="SelectedFollowedEmailRows" runat="server" EnableEmbeddedSkins="false"
                                                AutoGenerateColumns="False" GridLines="None"
                                                AllowMultiRowEdit="True" AllowAutomaticInserts="true"
                                                AllowAutomaticUpdates="true" AllowAutomaticDeletes="false" FooterStyle-CssClass="d-none">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Name" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Name" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 192px!important" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Email Address">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Emails" ReadOnly="true" TextMode="Email" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 225px!important" runat="server" Text='<%#Eval("Emails")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold" HeaderText="Company Name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Company" ReadOnly="true" CssClass="GridCommonCSS text-left form-label mb-2 d-block GridTextboxes" Style="width: 150px!important" runat="server" Text='<%#Eval("Company")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="font-weight-bold d-none" HeaderText="Sr" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Sr" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>

            <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
                crossorigin="anonymous"></script>
            <!-- Square_Ads -->
            <ins class="adsbygoogle"
                style="display: block; margin: 12px 0; text-align: center;"
                data-ad-client="ca-pub-5830711168897757"
                data-ad-slot="2436547414"
                data-ad-format="auto"
                data-full-width-responsive="true"></ins>
            <script>
                (adsbygoogle = window.adsbygoogle || []).push({});
            </script>
            <%--<script async="async" data-cfasync="false" src="//pl16379349.effectiveperformancenetwork.com/3f18ab9b21120c10a2fb1b31bd8847a4/invoke.js"></script>
<div id="container-3f18ab9b21120c10a2fb1b31bd8847a4" class="pt-4 pb-2 text-white"></div>--%>
        </div>
    </form>
    <script>
        function ImportEmails(ImportEmailsUploader) {
            if (ImportEmailsUploader.value != '') {
                document.getElementById("<%=ImportEmailsBtn.ClientID %>").click();
            }
        }
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Button1.ClientID %>").click();
            }
        }
        function UploadFile2(AttachEmailSignature) {
            if (AttachEmailSignature.value != '') {
                document.getElementById("<%=AttachEmailSignatureBtn.ClientID %>").click();
            }
        }
        function showDiv() {
            document.getElementById('<%=loading.ClientID%>').className = "loader"; document.getElementById('<%=loading.ClientID%>').focus();
            //run();
        }


        function showUploader() {
            document.getElementById('<%=uploading.ClientID%>').className = "loader";
            document.getElementById('<%=uploading.ClientID%>').focus();
        }
        function FocusAttachmentBtn() {
            document.getElementById('<%=RemoveInnerAttachments.ClientID%>').focus();
        }
    </script>

</asp:Content>
