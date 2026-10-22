<%@ Page Title="" Language="VB" MasterPageFile="~/BulkEmails.master" ValidateRequest="false" EnableEventValidation="false" CodeFile="UserDashboard.aspx.vb" Inherits="UserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>User Dashboard | Email Marketing Tool | EBox Marketing</title>
    <meta name="description" content="User Dashboard, view your analtyics today. Start sending mass emails to your clients today and promote your brand among potential customers.">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script id="PDS644430" type="text/javascript">(function (d) { var wrapper = d.createElement("script"); wrapper.id = "WDS644430"; wrapper.type = "text/javascript"; wrapper.src = "https://s.adlane.info/?floor=0&content_page_url=" + encodeURIComponent(window.location.href) + "&width=970&height=90&cb=" + (new Date()).getTime().toString() + "&aid=644430"; var s = d.getElementById("PDS644430"); s.parentNode.insertBefore(wrapper, s); }(document));</script>--%>
<form id="form" runat="server">
            <asp:ScriptManager ID="RadScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="DateSubmitBtn" />
                    <asp:PostBackTrigger ControlID="DateSubmitBtn2" />
                </Triggers>
                <ContentTemplate>
        <!-- Begin Page Content -->
        <div class="container-fluid UserDashboard_Body">
            <!-- Content Row -->
                    <div class="DatePicker-Body">
                        <div class="row">
                            <div class="col-sm-12 col-lg-12">
                                <asp:RadioButtonList ID="FilterList" AutoPostBack="true" CssClass="FilterListCss" RepeatDirection="Vertical" OnSelectedIndexChanged="FilterList_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="0" Selected="True">Today Stats</asp:ListItem>
                                    <asp:ListItem Value="1">Yesterday Stats</asp:ListItem>
                                    <asp:ListItem Value="2">Last Week Stats</asp:ListItem>
                                    <asp:ListItem Value="3">Last Month Stats</asp:ListItem>
                                    <asp:ListItem Value="4">Last 6 Months Stats</asp:ListItem>
                                    <asp:ListItem Value="6">All Time Stats</asp:ListItem>
                                    <asp:ListItem Value="5">Custom Dates</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-sm-12" id="DatePickerBody" runat="server">
                                <div class="DatePicker-BodyInner">
                                    <asp:Label ID="FromDateLabel" CssClass="text-left form-label mb-2 d-block" runat="server" Text="From"></asp:Label>
                                    <input type="date" id="FromDateDatePicker" runat="server">
                                    <asp:Label ID="ToDateLabel" CssClass="text-left form-label mb-2 d-block" runat="server" Text="To"></asp:Label>
                                    <input type="date" id="ToDateDatePicker" runat="server">
                                    <asp:Button ID="DateSubmitBtn" runat="server" Style="display: none" OnClick="DateSubmitBtn_Click" Text="Button" />
                                    <asp:Button ID="DateSubmitBtn2" runat="server" Style="display: none" OnClick="DateSubmitBtn2_Click" Text="Button" />
                                </div>
                            </div>
                        </div>
                    </div>
            <!-- Content Row -->
            <div class="row my-3">
                <div class="px-3">
                    <div class="Section_Title">
                        <h2 class="mb-2">Displaying <span id="CurrentFilter" runat="server"></span></h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-sm-12 col-md-3 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                        Total Emails
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalEmails" runat="server"></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fa fa-paper-plane-o text-primary"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-sm-12 col-md-3 mb-4">
                    <div class="card border-left-danger shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">
                                        Unsent Emails
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalUnsentEmails" runat="server"></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fa fa-envelope-square text-danger"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-sm-12 col-md-3 mb-4">
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                        Sent Emails
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalSentEmails" runat="server"></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fa fa-check-square-o text-success"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Pending Requests Card Example -->
                <div class="col-sm-12 col-md-3 mb-4">
                    <div class="card border-left-warning shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                        Followed-Up Emails
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalFollowedUpEmails" runat="server"></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fa fa-comments text-warning"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                    
            <!-- Content Row -->
            <div class="row">
                <!-- Area Chart -->
                <div class="col-sm-12 col-lg-8">
                    <div class="card dashboard-cards-graphs shadow mb-4">
                        <!-- Card Header - Dropdown -->
                        <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                            <h6 class="m-0 font-weight-bold">Total Emails Overview</h6>
                        </div>
                        <!-- Card Body -->
                        <div class="card-body">
                            <div class="chart-area">
                                <canvas id="myAreaChart" class="long-charts"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Pie Chart -->
                <div class="col-sm-12 col-lg-4">
                    <div class="card dashboard-cards-graphs shadow mb-4">
                        <!-- Card Header - Dropdown -->
                        <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                            <h6 class="m-0 font-weight-bold">360 Degree Overview</h6>
                        </div>
                        <!-- Card Body -->
                        <div class="card-body">
                                <canvas id="myPieChart" class="shortpie-charts"></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Content Row -->
            <div class="row">
                <div class="col-sm-12 col-md-3">
                    <div class="row">
                        <!-- Earnings (Monthly) Card Example -->
                        <div class="col-sm-12 col-lg-12 mb-4">
                            <div class="card border-left-success shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                                Top Active Client 
                                            </div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="TopClient" runat="server">0</div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fa fa-users text-success"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 mb-4">
                            <div class="card border-left-info shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                                 Total Opened Emails
                                            </div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalOpenedEmails" runat="server">0</div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fa fa-envelope-open text-primary"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Earnings (Monthly) Card Example -->
                        <div class="col-xl-12 col-md-12 mb-4">
                            <div class="card border-left-danger shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">
                                                 Total Unopened Emails
                                            </div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="TotalUnopenedEmails" runat="server">0</div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fa fa-envelope text-danger"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 col-lg-5">
                    <!-- Bar Chart -->
                    <div class="card dashboard-cards-graphs shadow mb-4">
                        <div class="card-header">
                            <h6 class="m-0 font-weight-bold ">Total Opened Emails Stats</h6>
                        </div>
                        <div class="card-body">
                            <div class="chart-bar">
                                <canvas id="myBarChart" class="long-charts"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Area Chart -->
                <div class="col-sm-12 col-lg-4">
                    <div class="card dashboard-cards-graphs shadow mb-4">
                        <!-- Card Header - Dropdown -->
                        <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                            <h6 class="m-0 font-weight-bold">Total Unopened Emails Stats (Sent & Followed-Up)</h6>
                        </div>
                        <!-- Card Body -->
                        <div class="card-body">
                            <div class="chart-area">
                                <canvas id="myAreaChart2" class="long-charts"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5830711168897757"
     crossorigin="anonymous"></script>
<ins class="adsbygoogle"
     style="display:block; margin:12px 0; text-align:center;"
     data-ad-format="fluid"
     data-ad-layout-key="-fb+5w+4e-db+86"
     data-ad-client="ca-pub-5830711168897757"
     data-ad-slot="6731015648"></ins>
<script>
    (adsbygoogle = window.adsbygoogle || []).push({});
</script>

            <!-- /.container-fluid -->
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
    <!-- Page level plugins -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js" integrity="sha512-d9xgZrVZpmmQlfonhQUvTR7lMPtO7NkZMkA0ABN3PHCbKA5nqylQ/yWlFAyY6hYgdF1Qh6nYiuADWwKB4C2WSw==" crossorigin="anonymous"></script>
    <script src="/js/chart.js/Chart.js"></script>

    <script type="text/javascript">
        function SubmitDates(ToDateDatePicker) {
            if (ToDateDatePicker.value != '') {
                document.getElementById("<%=DateSubmitBtn.ClientID %>").click();
            }
        }
        function SubmitDates2(ToDateDatePicker2) {
            if (FromDateDatePicker.value != '') {
                document.getElementById("<%=DateSubmitBtn2.ClientID %>").click();
            }
        }
    </script>
<%--    
    <script async="async" data-cfasync="false" src="//pl16379349.effectiveperformancenetwork.com/3f18ab9b21120c10a2fb1b31bd8847a4/invoke.js"></script>
<div id="container-3f18ab9b21120c10a2fb1b31bd8847a4" class="pb-2"></div>--%>
</asp:Content>

