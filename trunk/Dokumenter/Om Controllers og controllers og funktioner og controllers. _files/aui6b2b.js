/* Begin AUI JS framework ==================================================================================== */

// MyReadyFunction is called by the AJAX framework when the AJAX request is complete
function MyReadyFunction(html, elementId)  //alert('in MyReadyFunction(), html = '+html);
{
  // the result of the AJAX call is passed in the first parameter
  // the second parameter is the ID of the element whose content is to be updated with the html provided
  var theTarget = document.getElementById(elementId);
  if (theTarget != null)
    theTarget.innerHTML = html;
}

// CallGenericChunk
function CallGenericChunk(url, elementId) {  //alert('in GenericChunk(), elementId = '+elementId+' and the url = '+url);
  if(!window.pageLoadingFinished)
    // make sure the page has finished loading before doing an AJAX call
    window.setTimeout("CallGenericChunk('" + url + "','" + elementId + "')", 100);
  else
    // perform the AJAX call itself
    // function AjaxCall(url, readyFunction, readyFunctionParameter, postData, id)
    // url: the URL to call
    // readyFunction: the function that will be called when the AJAX request is complete
    // readyFunctionParameter: a parameter that will be passed to the readyFunction when it is called
    // postData: if non null, the call will be performed using a POST rather than a GET and the given data sent along with the call. usually not necessary unless you have a good reason to do so
    // id: an ID that uniquely indentifies the call (this is used to manage simultaneous calls)
   // alert ("In CallGenericChunk with url " + url + " and elementId " + elementId);
    AjaxCall('GenericChunk' + url, MyReadyFunction, elementId, null, elementId);  
    //alert('after call to AjaxCall()');
}



var anonUI = {
  
  onecycle: 0,

  bustcachevar:1, // bust potential caching of external pages after initial request? (1=yes, 0=no)

  chgLink:function(elem) {

     var listContainer = document.getElementById('categorieswrap');
     var theList = listContainer.getElementsByTagName('li');

     for(var i = 0; i<theList.length; i++) {
       if(theList[i].firstChild.className == 'indicate') {
         theList[i].firstChild.className = '';
       }
     }
    
     elem.className = 'indicate';

  },

  chgLinkTwo:function(elem) {
    
     var listContainer = document.getElementById('categorieswrap');
     var theList = listContainer.getElementsByTagName('li');

     for(var i = 0; i<theList.length; i++) {
       if(theList[i].firstChild.className == 'indicate') {
         theList[i].firstChild.className = '';
       }
       // alert('elem = '+elem+' and the list item = '+theList[i].firstChild.innerHTML);
       if(theList[i].firstChild.innerHTML == elem) {
         theList[i].firstChild.className = 'indicate';
       }
     }

  },
/*
  getDomain:function() {
    
    var thestring = ""+window.location.href;
    var urlpattern = new RegExp("(http|ftp|https)://(.*?)/.*$");
    var parsedurl = thestring.match(urlpattern);
    var thedomain =  parsedurl[2].split(".");
    return thedomain[0];

  },
*/

  ajaxpage:function(url, containerid, tab, litem){

    if(tab) {
      var thisTab = document.getElementById(tab);
      var tabCollParent = document.getElementById('auiTabList');
      var tabCollection = tabCollParent.getElementsByTagName('li'); //alert(tabCollection.length);
      for(var i=0; i<tabCollection.length; i++) {
        
         var thisID = "auiB2BTab"+(i+1);  //alert(thisID);
         document.getElementById(thisID).className = '';

      }
      thisTab.className = 'active';
    }

    var page_request = false;
    if (window.XMLHttpRequest) { // if Mozilla, Safari etc
      page_request = new XMLHttpRequest();
    }
    else if (window.ActiveXObject){ // if IE
      try {
        page_request = new ActiveXObject("Msxml2.XMLHTTP");
      }
      catch (e){
        try{
          page_request = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e){}
      }
    }
    else {
      return false;
    }
    page_request.onreadystatechange=function(){
      anonUI.loadpage(page_request, containerid, tab, url, litem);
    }
    if (anonUI.bustcachevar) { //if bust caching of external page
      var bustcacheparameter=(url.indexOf("?")!=-1)? "&"+new Date().getTime() : "?"+new Date().getTime();
    }
    page_request.open('GET', url+bustcacheparameter, true);
    page_request.send(null);

  },
  /* cmh - used for novartis to allow user to select library prior to 
   * self registering 
   */
  callSelfReg:function(buttonGroup) {  
     var buttonGroup = document.chooseLibForm.uicode;
     var oneLibSpan = document.getElementById('oneLibSpan');  //error message      
     if (!buttonGroup[0].checked  &&  !buttonGroup[1].checked){
        //alert("You must select a library to register.");

        oneLibSpan.innerHTML = "You must select a library to register.";
        return;
     }
     if (buttonGroup[0].checked) {
        //alert("You have selected the business library");
        document.location  = "/register?uicode=novartisbiz";
         return;
     }
     if (buttonGroup[1].checked) {
        //alert("You have selected the premium library");
        document.location  = "/register?uicode=novartis";
        return;
     } 
     
     return;
    },
   toggleLib1:function() {
   	  var oneLibSpan = document.getElementById('oneLibSpan'); 
   	  oneLibSpan.innerHTML = ""; // turn off error
      document.chooseLibForm.uicode[1].checked =false;
   },
   toggleLib2:function() {
   	  var oneLibSpan = document.getElementById('oneLibSpan'); 
   	  oneLibSpan.innerHTML = ""; // turn off error
   	
      document.chooseLibForm.uicode[0].checked =false;
   },
   /* end cmh add  */
    
  loadpage:function(page_request, containerid, tab, url, litem){

    var ext = '.html';
    var sl = '/';
    var newurl = url.replace(ext,'');
    var newurl = newurl.replace(sl,'');

    if (page_request.readyState == 4 && (page_request.status==200 || window.location.href.indexOf("http")==-1)) {
      document.getElementById(containerid).innerHTML=page_request.responseText;
if (tab=='auiB2BTab1') {
        aui.dynInitCalls("welcome");
      }
     if (tab=='auiB2BTab4') {
        aui.dynInitCalls(productCat);
      }
    }
  }

 /* setupDelayed:function() {
    setTimeout( 'anonUI.fiveSlotSetup()', 100 );
  }


  openLogin:function(obj) {
    var loginBox = document.getElementById(obj);
    loginBox.style.display = 'block';
    document.forms.login.login.focus();
    document.getElementById('login').focus();
  },

  closeLogin:function(obj) {
    var loginBox = document.getElementById(obj);
    loginBox.style.display = 'none';
  }
*/

}

/* End AUI JS framework ==================================================================================== */
