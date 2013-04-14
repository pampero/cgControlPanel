<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="" CodeBehind="ChangePassword.aspx.cs" Inherits="dateRange.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="accountHeader">
    <h2>
        Change Password</h2>
    <p>Use the form below to change your password.</p>
    <p>New passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.</p>
</div>

<br />
<dx:ASPxLabel ID="lblCurrentPassword" runat="server" Text="Old Password:" />
<div class="form-field">
	<dx:ASPxTextBox ID="tbCurrentPassword" runat="server" Password="true" Width="200px">
	    <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
	        <RequiredField ErrorText="Old Password is required." IsRequired="true" />
	    </ValidationSettings>
	</dx:ASPxTextBox>
</div>
<dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="tbPassword" Text="Password:" />
<div class="form-field">
	<dx:ASPxTextBox ID="tbPassword" ClientInstanceName="Password" Password="true" runat="server"
	    Width="200px">
	    <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
	        <RequiredField ErrorText="Password is required." IsRequired="true" />
	    </ValidationSettings>
	</dx:ASPxTextBox>
</div>
<dx:ASPxLabel ID="lblConfirmPassword" runat="server" AssociatedControlID="tbConfirmPassword"
    Text="Password:" />
<div class="form-field">
	<dx:ASPxTextBox ID="tbConfirmPassword" Password="true" runat="server" Width="200px">
	    <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
	        <RequiredField ErrorText="Confirm Password is required." IsRequired="true" />
	    </ValidationSettings>
	    <ClientSideEvents Validation="function(s, e) {
			var originalPasswd = Password.GetText();
			var currentPasswd = s.GetText();
			e.isValid = (originalPasswd  == currentPasswd );
			e.errorText = 'The Password and Confirmation Password must match.';
		}" />
	</dx:ASPxTextBox>
</div>
<dx:ASPxButton ID="btnChangePassword" runat="server" Text="Change Password" ValidationGroup="ChangeUserPasswordValidationGroup"
    OnClick="btnChangePassword_Click">
</dx:ASPxButton>
    </div>
    </form>
</body>
</html>