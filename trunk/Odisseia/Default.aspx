<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript">


    curDay = "<%=DateTime.Now.Day%>";
    curMonth = "<%=DateTime.Now.Month%>";
    curYear = "<%=DateTime.Now.Year%>";
    curHour = "<%=DateTime.Now.Hour%>";
    curMinute = "<%=DateTime.Now.Minute%>";
    curSecond = "<%=DateTime.Now.Second%>";

    curDate = curMonth + "/" + curDay + "/" + curYear + " " + curHour + ":" + curMinute + ":" + curSecond;
    date1temp = new Date(curDate);   



onload = function()
{
    
   //setTimeOut('CalcDate()', 250);
    
    CalcDate();
}


function CalcDate() {
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();
    
    
    destDate = "12/16/2008 14:00:00";


    date1temp.setSeconds(date1temp.getSeconds() + 1);

    date1.setTime(date1temp.getTime());
    
    date2temp = new Date(destDate);
    date2.setTime(date2temp.getTime());
    
    diff.setTime(Math.abs(date1.getTime() - date2.getTime()));
    timediff = diff.getTime();
    weeks = Math.floor(timediff / (1000 * 60 * 60 * 24 * 7));
    timediff -= weeks * (1000 * 60 * 60 * 24 * 7);

    days = Math.floor(timediff / (1000 * 60 * 60 * 24)); 
    timediff -= days * (1000 * 60 * 60 * 24);

    hours = Math.floor(timediff / (1000 * 60 * 60)); 
    timediff -= hours * (1000 * 60 * 60);

    mins = Math.floor(timediff / (1000 * 60)); 
    timediff -= mins * (1000 * 60);

    secs = Math.floor(timediff / 1000); 
    timediff -= secs * 1000;

    
    document.getElementById("div1").innerHTML = weeks + " weeks, " + days + " days, " + hours + " hours, " + mins + " minutes, and " + secs + " seconds";
    
    setTimeout('CalcDate()', 1000);
    
}

   

</script>    
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1">
    
    </div>
    </form>
</body>
</html>
