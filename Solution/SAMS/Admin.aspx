<%@ Page  Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SAMS.Admin1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

		<div class="col-md-2 sidebar">
			<ul class="nav nav-pills nav-stacked">
				<li class="active"><a href="#">Home</a></li>
				<li><a href="#">My Profile</a></li>
				<li><a href="#">Grading</a></li>
				<li><a href="#">Attendance</a></li>
			</ul>
		</div>
		<div class="col-md-10 content">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Dashboard
                </div>
                <div class="panel-body">
    <div class="row">
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <span class="glyphicon glyphicon-bookmark"></span>Quick Shortcuts</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-md-6">
                          <a href="#" class="btn btn-danger btn-lg" role="button"><span class="glyphicon glyphicon-list-alt"></span> <br/>My Classes</a>
                          <a href="#" class="btn btn-warning btn-lg" role="button"><span class="glyphicon glyphicon-bookmark"></span> <br/>Grading</a>
                          <a href="#" class="btn btn-primary btn-lg" role="button"><span class="glyphicon glyphicon-signal"></span> <br/>Attendance</a>
                          <a href="#" class="btn btn-success btn-lg" role="button"><span class="glyphicon glyphicon-comment"></span> <br/>Departments</a>
                        </div>
                        <div class="col-xs-4 col-md-6">
                          <a href="#" class="btn btn-info btn-lg" role="button"><span class="glyphicon glyphicon-user"></span> <br/>Users</a>
                          <a href="#" class="btn btn-success btn-lg" role="button"><span class="glyphicon glyphicon-user"></span> <br/>New Users</a>
                          <a href="#" class="btn btn-warning btn-lg" role="button"><span class="glyphicon glyphicon-file"></span> <br/>Classes</a>
                          <a href="#" class="btn btn-primary btn-lg" role="button"><span class="glyphicon glyphicon-file"></span> <br/>New Class</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


                </div>
            </div>
	

</asp:Content>
