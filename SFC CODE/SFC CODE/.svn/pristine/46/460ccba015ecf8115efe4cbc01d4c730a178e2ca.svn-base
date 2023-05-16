<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DisplayPic.aspx.vb" Inherits="WebPLM.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  
 
  <head>
    <title>DEMO: faq - online document viewer</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>     
    <link href="css/AeroWindow.css?r=123" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Scripts/jquery-1.4.2.min.js"></script>        
    <script type="text/javascript" src="Scripts/jquery-OnlineViewer.js"></script>
 
<script type="text/javascript"> 
    /*---------------完整参数Demo-------------------*/
 
    $(document).ready(function () {
 
        $("html").find("a[open='1']").each(function (i) {
            $("html").find("a[open='1']").each(function (i) {
                if (!$(this).attr("id")) {
                    $(this).attr("id", "openlink" + i)
                }
                if (!$(this).attr("FileName")) {
                    $(this).attr("FileName", $(this).text());
                }
                if (!$(this).attr("FileAttribute")) {
                    if ($(this).attr("title")) {
                        $(this).attr("FileAttribute", $(this).attr("title"));
                    }
                    else {
                        $(this).attr("FileAttribute", $(this).text());
                    }
                }
                $(this).attr("FileUrl", $(this).attr("href"));
                $(this).attr("href", "javascript:void(0);");
                $(this).click(function () {
                    cls = '0';
                    RequestViews(this);
                });
            });
        });
    });
 
    function RequestViews(obj) {
        //var userid=$("#userid").val();
        RequestView({
            FileName: $(obj).attr("FileName"),
            FileAttribute: $(obj).attr("FileAttribute"),
            FileUrl: $(obj).attr("FileUrl"),
            FileSourceUrl: (typeof ($(obj).attr("FileSourceUrl")) == "undefined") ? "" : $(obj).attr("FileSourceUrl"),
            Title: (typeof ($(obj).attr("Title") == "undefined")) ? "" : $(obj).attr("Title"),
            Width: window.screen.width - 60,
            Height: window.screen.height - 180,
            InsideWidth: window.screen.width - 260,
            InsideHeight: window.screen.height - 250,
            Server: (typeof ($(obj).attr("Server")) == "undefined") ? "192.168.20.179:8089/odv" : $(obj).attr("Server"),
            //Server: (typeof($(obj).attr("Server")) == "undefined") ? "faq.luxshare-ict.com" : $(obj).attr("Server"),
          //  WindowAppID: (typeof ($(obj).attr("WindowAppID")) == "undefined") ? "WindowApp" : $(obj).attr("WindowAppID"),
            WindowAppID: (typeof ($(obj).attr("WindowAppID")) == "undefined") ? "WindowApp" : $(obj).attr("WindowAppID"),
            WindowHiddenID: (typeof ($(obj).attr("WindowHiddenID")) == "undefined") ? "WindowHidden" : $(obj).attr("WindowHiddenID"),
            IsCover: false,
            DocumentID: $(obj).attr("title").split("_")[0],
           // PlatformID: (typeof ($(obj).attr("PlatformID")) == "undefined") ? "ict" : $(obj).attr("PlatformID"),

            PlatformID: (typeof ($(obj).attr("PlatformID")) == "undefined") ? "plm" : $(obj).attr("PlatformID"),
            Password: (typeof ($(obj).attr("Password")) == "undefined") ? "123456" : $(obj).attr("Password"),
          //  Password: (typeof ($(obj).attr("Password")) == "undefined") ? "1236" : $(obj).attr("Password"),

            //minue:ireadtime,
            Module: (typeof ($(obj).attr("Module")) == "undefined") ? "" : $(obj).attr("Module"),
            Iframe: (typeof ($(obj).attr("Iframe")) == "undefined") ? true : $(obj).attr("Iframe"),
            IsDownFile: (typeof ($(obj).attr("IsDownFile")) == "undefined") ? true : $(obj).attr("IsDownFile"),
            IsDownSource: (typeof ($(obj).attr("IsDownSource")) == "undefined") ? false : $(obj).attr("IsDownSource"),
            showheader: (typeof ($(obj).attr("showheader")) == "undefined") ? false : $(obj).attr("showheader"),
            //Operator:userid,//操作用户
            fileid: (typeof ($(obj).attr("fileid")) == "undefined") ? false : $(obj).attr("fileid")//文档id
        }, obj);
    }
  

</script>
   
  </head>
  <body>   
      <form id="form1" runat="server">
  <div id="maindiv">
  <!--以下a标签属性必须，href可传加密或非加密链接-->
<%--      <a open='1'  href='http://192.168.20.70/plmquery/plm_file/C/A5/0c3/WxkBMzsnksoJXxvISlvQz1jtN/lx9noe2PM+8bHL7B/b1JKKpJ8fiAxteGh2MUSCSB2gX3VZ/6/vA+1n++Cfm4asWsPlFRKaWR00D+JgIhNSg+yxF1pacOf0zKne.pdf' fileid="ADC05CA1F3444B479824A7923BEE42CA" title='CAD14-0000002874' target='_blank'>文档名称</a>
--%>
    <a open='1'  href='0c3/WxkBMzsnksoJXxvISlvQz1jtN/lx9noe2PM+8bHL7B/b1JKKpJ8fiAxteGh2MUSCSB2gX3VZ/6/vA+1n++Cfm4asWsPlFRKaWR00D+JgIhNSg+yxF1pacOf0zKne' fileid="ADC05CA1F3444B479824A7923BEE42CA" title='CAD14-0000002874' target='_blank'>文档名称</a>
	   <!
	   <!--下面两个div必须要-->
	   <div id="WindowApp" style="display: none;"></div>	
	   <div id="WindowHidden" ></div>
	   
    </div>
    <p>
        <input id="Button1" type="button" value="button" onclick="return Button1_onclick()" /></p>
    <asp:Button ID="Button2" runat="server" Text="Button" />
</form>
  </body>  
</html>

