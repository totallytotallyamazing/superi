<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationForm.aspx.cs" Inherits="ApplicationForm" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function checkInt(num)
        {
            return /^\d+$/.test(num);
        }
        
        function checkEmail(str) 
        {
		    var at="@"
		    var dot="."
		    var lat=str.indexOf(at)
		    var lstr=str.length
		    var ldot=str.indexOf(dot)
		    if (str.indexOf(at)==-1){
		       return false
		    }
		    if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
		       return false
		    }
		    if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
		        return false
		    }
    	    if (str.indexOf(at,(lat+1))!=-1){
		        return false
		    }
		    if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
		        return false
		    }
		    if (str.indexOf(dot,(lat+2))==-1){
		        return false
		    }
		    if (str.indexOf(" ")!=-1){
		        return false
		    }
 		    return true					
	    }
	    
	    function validateForm()
	    {
	        var controls = new Array();
	        var iFio = document.getElementsByName('iFio')[0];
	        controls[0] = iFio;
	        var iCity = document.getElementsByName('iCity')[0];
	        controls[1] = iCity;
	        var iStreet = document.getElementById('iStreet')[0];
	        controls[2] = iStreet;
	        var iHouse = document.getElementsByName('iHouse')[0];
	        controls[3] = iHouse;
	        var iOffice = document.getElementsByName('iOffice')[0];
	        controls[4] = iOffice;
	        var iPhonePrefix = document.getElementsByName('iPhonePrefix')[0];
	        controls[5] = iPhonePrefix;
	        var iPhone = document.getElementsByName('iPhone')[0];
	        controls[6] = iPhone;
	        var iEmail = document.getElementById('iEmail')[0];
	        controls[7] = iEmail;
	        var iCityRestaurant = document.getElementsByName('iCityRestaurant')[0];
	        controls[8] = iCityRestaurant;
	        var iPopulation = document.getElementById('iPopulation')[0];
	        controls[9] = iPopulation;
//	        var irRoom = document.getElementsByName('irRoom');
//	        var iSquare = document.getElementsByName('iSquare')[0];
//	        controls[10] = iSquare;
//	        var irComExp = document.getElementsByName('irComExp');
//	        var iComExp = document.getElementsByName('iComExp')[0];
//	        controls[11] = iComExp;
//	        var irFoodExp = document.getElementsByName('irFoodExp');
//	        var iFoodExp = document.getElementsByName('iFoodExp')[0];
//	        controls[12] = iFoodExp;
	        var iSphere = document.getElementsByName('iSphere')[0];
	        controls[10] = iSphere;
	        var iEducation = document.getElementsByName('iEducation')[0];
	        controls[11] = iEducation;
	        var i;
	        for(i in controls)
	        {
	            if(controls[i].value==='')
	            {
	                return false;
	            }
	        }
	        return true;

	    }
    </script>
    <Controls:TextWriter runat="server" TextName="anketa"></Controls:TextWriter>
    <br />
    <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Ok" />
</asp:Content>

