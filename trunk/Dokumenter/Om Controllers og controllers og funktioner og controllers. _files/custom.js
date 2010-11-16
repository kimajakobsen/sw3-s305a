
/*
var filerefB = document.createElement('script');
filerefB.setAttribute("type","text/javascript");
filerefB.setAttribute("src", "/6.0/dyncats.js");  

if (typeof filerefB!="undefined") {
  document.getElementsByTagName("head")[0].appendChild(filerefB);
}


var filerefA = document.createElement('script');
filerefA.setAttribute("type","text/javascript");
filerefA.setAttribute("src", "/6.0/aui6b2b.js");  

if (typeof filerefA!="undefined") {
  document.getElementsByTagName("head")[0].appendChild(filerefA);
}

*/


  document.write('<script type="text/javascript" src="/files/6.0/jquery-1.3.2.min.js"></script>');
  document.write('<script type="text/javascript" src="/files/6.0/ferot.js"></script>');
    document.write('<script type="text/javascript" src="/files/6.0/ferot_moblie.js"></script>');

  document.write('<script type="text/javascript" src="/files/6.0/dyncats.js"></script>');
  document.write('<script type="text/javascript" src="/files/6.0/aui6b2b.js"></script>');



var sbolib={


  /* Simple Show/Hide (tans, sans, hans)
  ---------------------------------------------------------------------------------------------------------- */
  tans:function(elemID) {
    if (!document.getElementById) return false;
    var myDiv=document.getElementById(elemID);
    if (myDiv){
      if (myDiv.style.display == 'none'){
        sbolib.sans(elemID);
      } else{
        sbolib.hans(elemID);
      }
    }
  },

  sans:function(elemID) {
    var myDiv=document.getElementById(elemID);
    if (myDiv){
      myDiv.style.display="block";
    } else {
      return false;
    }
  },

  hans:function(elemID) {
    var myDiv=document.getElementById(elemID);
    if (myDiv){
      myDiv.style.display="none";
    } else {
      return false;
    }
  },
  
  /* Simple Pop-ups
  ---------------------------------------------------------------------------------------------------------- */
  popup:function(thepage) {
    var winl=(screen.width - 640) / 2;
    var wint=(screen.height - 450) / 4;
    winprops='height=450,width=640,top='+wint+',left='+winl+',toolbar=no,scrollbars='+'yes'+',resizable';

    win=window.open(thepage, 'sbopopup', winprops);

    if (parseInt(navigator.appVersion) >= 4) { win.window.focus(); }
  }
  
 }



// Tip of the Week

var currentTip = 2; // Edit this to match the intial TOW set up in v6_custompopup.html
var numberOfTips = 27; // Edit this to match the number of tips available;


var tow={
  

   getDomain:function() {
    
    var thestring = ""+window.location.href;
    var urlpattern = new RegExp("(http|ftp|https)://(.*?)/.*$");
    var parsedurl = thestring.match(urlpattern);
    var thedomain =  parsedurl[2].split(".");
    return thedomain[0];

  },


   towNav:function(page) {

     if(page == 'previous') {

       if(currentTip == 1) {
         var thePage = "/files/6.0/tip"+numberOfTips+".html";
         currentTip = numberOfTips;
       } else {
         var thePage = "/files/6.0/tip"+(currentTip-1)+".html";
         currentTip = (currentTip-1);
       }
       
// var s=s_gi(s_account);s.linkTrackVars='prop10,eVar10';s.prop10='checkboxON';s.eVar10='checkboxON';s.tl(true,'o','link_name');
       
       //var s=s_gi(s_account);
       //s.linkTrackVars='prop10,eVar10';
       var omnival = "tip"+currentTip;       
       s.prop10=omnival;
       s.eVar10=omnival;
       s.tl(true,'o','link_name');
       
       $("#currentTipDisplay").html(currentTip);

     } else if(page == 'next') {

       if (currentTip == numberOfTips) {
         var thePage = "/files/6.0/tip1.html";
         currentTip = 1;
       } else {
         var thePage = "/files/6.0/tip"+(currentTip+1)+".html";
         currentTip = (currentTip+1);
       }
       
       //var s=s_gi(s_account);
       //s.linkTrackVars='prop10,eVar10';
       var omnival = "tip"+currentTip;
       s.prop10=omnival;
       s.eVar10=omnival;
       s.tl(true,'o','link_name');
       
       $("#currentTipDisplay").html(currentTip);
       
     } else {  // default to the index
     
       //$("#towNavigation").hide();
       
       var thePage = "/files/6.0/tipindex.html";
       
       //var s=s_gi(s_account);
       //s.linkTrackVars='prop10,eVar10';
       var omnival = "tipIndex";
       s.prop10=omnival;
       s.eVar10=omnival;
       s.tl(true,'o','link_name');
       
     }
     
     // var thePage = "/files/6.0/"+page+".html";
     $("#popup1").load(thePage);
     return false;

   },
   
   towNavDirect:function(pageNum) {

     var thePage = "/files/6.0/tip"+pageNum+".html";
     $("#popup1").load(thePage);
     //$("#towNavigation").show();
     currentTip = pageNum;
     
     //var s=s_gi(s_account);
     //s.linkTrackVars='prop10,eVar10';
     var omnival = "tip"+pageNum; //currentTip;
     s.prop10=omnival;
     s.eVar10=omnival;
     s.tl(true,'o','link_name');
     
     $("#totalTips").html(numberOfTips);

     return false;

   },

   towUserPref:function(thebox) {
     if(thebox.checked) {
       tow.createCookie('userTow','true',365);
       s.prop10='checkboxON';s.eVar10='checkboxON';
     } else {
       tow.createCookie('userTow','false',365); // or we could remove the cookie...
       s.prop10='checkboxOFF';s.eVar10='checkboxOFF';
     }

   },

   launchTow:function() {  

     // if the user has set a preference
     if(tow.readCookie('userTow')) {

       // if the preference is to launch the popup on login, then we want to be sure to set the checkbox correctly
       if(tow.readCookie('userTow') == 'true') {
         OpenGenericPopup(this, 600, true, 'myvariable1=tip&myvariable2=true');
       } else { // if the user does not want the popup on login, uncheck the box
         OpenGenericPopup(this, 600, true, 'myvariable1=tip&myvariable2=false');
       }

     } else { // the user has not set a preference, so the default is to open tow on login, so check the box
       OpenGenericPopup(this, 600, true, 'myvariable1=tip&myvariable2=true');

     }
     
     var s=s_gi(s_account);
     s.linkTrackVars='prop10,eVar10';
     var omnival = "tip"+currentTip;
     s.prop10=omnival;
     s.eVar10=omnival;
     s.tl(true,'o','link_name');

   },

   checkCookie:function() {
     
     if(tow.readCookie('userTow')) {
       alert(tow.readCookie('userTow'));
     } else {
       alert('user pref. not set');
     }

   },
   
   setCheckBox:function() {
     if(tow.readCookie('userTow')) {
       if(tow.readCookie('userTow') == 'true') {
         document.popconform.popcon.checked=true;
       } else {
         document.popconform.popcon.checked=false;
       }
     } else {
       document.popconform.popcon.checked=true;
    }
   },
   
   createCookie:function(name,value,days) { 

     // set domain to allow cross subdomain reading of cookies
     if( (tow.getDomain() == 'safarirel6') || (tow.getDomain() == 'securesafarirel6') ) {
       var thedomain = "; domain=.bvdep.com";
     }  else {
        var thedomain = "; domain=.safaribooksonline.com";
     }

     if (days) {
      var date = new Date();
      date.setTime(date.getTime()+(days*24*60*60*1000));
      var expires = "; expires="+date.toGMTString();
     }
     else { var expires = ""; }
     document.cookie = name+"="+value+expires+"; path=/"+thedomain;
   },

   readCookie:function(name) {
     var nameEQ = name + "=";
     var ca = document.cookie.split(';');
     for(var i=0;i < ca.length;i++) {   //>
      var c = ca[i];
      while (c.charAt(0)==' ') c = c.substring(1,c.length);
      if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
     }
     return null;
   },

   eraseCookie:function(name) {
    tow.createCookie(name,"",-1);
    //alert(name+' erased');
   },

   // Allows multiple function calls to be added to the onload event
   // usage: ferot.addEvent(window, 'load', functionName);
   addEvent:function( obj, type, fn ) {
     if (obj.addEventListener)
       obj.addEventListener( type, fn, false );
     else if (obj.attachEvent) {
       obj["e"+type+fn] = fn;
       obj[type+fn] = function() { obj["e"+type+fn]( window.event ); }
       obj.attachEvent( "on"+type, obj[type+fn] );
     }
   } // end jq.addEvent()
  
  
}



