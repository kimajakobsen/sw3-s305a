// Feature Rotator
var ferot={

   // caching mechanism
   img2cache: new Array(),
   
   numimages: 4, 

   preCache:function() {
   
     for (x=0; x>ferot.numimages; x++){
       ferot.img2cache[x] = new Image();
       ferot.img2cache[x].src = ferot.img2cache.arguments[x];
     }

   },

   // initialize and set globals
   initStart: true,   // true = Auto forward will start on pageload
   useFade: false,     // true = turns on fade transition effect, false = no fade
   currFeature: 1,    // seed for controls
   currslide: 0,      // seed for slide show state
   numslides: 0,      // number of slides
   slidespeed: 10000,  // auto slide speed in miliseconds (2000=2 seconds)
   timing: '',            // the setTimeout variable to enable it to be turned off - set in autoforward()
   collslides: new Array(), // the slide collection
   classname: 'featureBucketSlide', // class name of parent feature bucket wrapper
   
   rotrue: true,

   // Highlight the current slide's corresponding numbered button
   hiliteControl:function(fin) {

     // clicked on a numbered button
     if(fin) {

       var thisID = fin;
       var currFeatureID = "#rboxnum"+ferot.currFeature;
       var thisJQid = "#"+thisID;
       var thisFeature = (thisID.replace("rboxnum", ""))*1;
     
       ferot.cycleforward(thisFeature);

       $(currFeatureID).removeClass("thisisit");
       $(thisJQid).addClass("thisisit");

       ferot.currFeature = thisFeature;

      
     } else {
  
       var currFeatureID = "#rboxnum"+ferot.currFeature;

       if(ferot.currFeature == 4) {
         var nextFeatureID = "#rboxnum1";
         var nextFeature = 1;
       } else {
         var nextFeatureID = "#rboxnum"+(ferot.currFeature+1);
         var nextFeature = (ferot.currFeature+1);
       }

       $(currFeatureID).removeClass("thisisit");
       $(nextFeatureID).addClass("thisisit");

       ferot.currFeature = nextFeature;

     }

   }, // end ferot.hiliteControl()

   // initialize feature bucket collection
   initFeatureBucket:function(){

     var inc=0;
     var alltags=document.all? document.all : document.getElementsByTagName("*");
     for (var i=0; i<alltags.length; i++){
       if (alltags[i].className==ferot.classname) {
         ferot.collslides[inc++]=alltags[i];
         ferot.numslides++;
       }
     }
     
     if(ferot.initStart) {
       ferot.timing = setTimeout("ferot.autoforward()",ferot.slidespeed);
     }
     
     
     ferot.preCache(

           "/images/6.0/home/rotfb01_shortcuts.png",
           "/images/6.0/home/rotfb02_mobile.png",
           "/images/6.0/home/rotfb03_wiley.png",
           "/images/6.0/home/rotfb04_projmgmt.png"

      );




   }, // end ferot.initFeatureBucket()

   // moves slide forward one
   cycleforward:function(slidein) {
     
     if(ferot.useFade) {
       var currJqID = "#"+ferot.collslides[ferot.currslide].id;
     } else {
       ferot.collslides[ferot.currslide].style.display="none";
     }

     if(slidein) {

       ferot.stopauto();
       ferot.currslide = slidein-1;

     } else {
  
       ferot.stopauto();
       ferot.currslide=(ferot.currslide<ferot.collslides.length-1)? ferot.currslide+1 : 0;
       ferot.hiliteControl();
     }
     
     if(ferot.useFade) {
       var nextJqID = "#"+ferot.collslides[ferot.currslide].id;
       $(currJqID).fadeOut(1000, function () {
         $(nextJqID).fadeIn(1000);
       });
     } else {
       ferot.collslides[ferot.currslide].style.display="block";
     }

   }, // end ferot.cycleforward()

   // moves slide back one - !buggy: deprecated for initial release
   cycleback:function() {

     ferot.stopauto();

     ferot.collslides[ferot.currslide].style.display="none";
     ferot.currslide=(ferot.currslide>0)? ferot.currslide-1 : ferot.collslides.length-1;
     ferot.collslides[ferot.currslide].style.display="block";

     ferot.hiliteControl(ferot.currslide+1);

   }, // end ferot.cycleback()
   
   // automatic forward
   autoforward:function() {

       if(ferot.useFade) {
         var currJqID = "#"+ferot.collslides[ferot.currslide].id;
       } else {
         ferot.collslides[ferot.currslide].style.display="none";
       }

       ferot.currslide=(ferot.currslide<ferot.collslides.length-1)? ferot.currslide+1 : 0;

       if(ferot.useFade) {
         var nextJqID = "#"+ferot.collslides[ferot.currslide].id;
         $(currJqID).fadeOut(1000, function () {
           $(nextJqID).fadeIn(1000);
           ferot.hiliteControl();
           ferot.timing = setTimeout("ferot.autoforward()",ferot.slidespeed);
         });
       } else {
          ferot.collslides[ferot.currslide].style.display="block";
          ferot.hiliteControl();
          ferot.timing = setTimeout("ferot.autoforward()",ferot.slidespeed);
       }
     
       $("#stopBtn").removeClass("thisisit");
       $("#startBtn").addClass("thisisit");


   }, // end ferot.autoforward()
   
   // pause automatic forwarding
   stopauto:function() {

     clearTimeout(ferot.timing);
     
     $("#startBtn").removeClass("thisisit");
     $("#stopBtn").addClass("thisisit");
     
     ferot.rotrue = false;

   }, // end ferot.stopauto()
   
   // pause automatic forwarding
   startauto:function() {

     if(!ferot.rotrue) {
        ferot.autoforward();
        ferot.rotrue = true;
     }

   }, // end ferot.startauto()
   
   // resets back to first feature slide
   startover:function() {

     ferot.stopauto();
  
     var clearCurrent = "#rboxnum"+(ferot.currslide+1);

     ferot.collslides[ferot.currslide].style.display="none";
     ferot.currslide = 0;
     ferot.collslides[ferot.currslide].style.display="block";

     ferot.currFeature = 1;
     var currFeatureID = "#rboxnum"+ferot.currFeature;
     $(clearCurrent).removeClass("thisisit");
     $(currFeatureID).addClass("thisisit");

   }, // end ferot.startover()

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
   }, // end ferot.addEvent()

   test:function() {
     
      alert('a simple test in ferot.js 2');

   }



} // end ferot{}


// initialize home page feature bucket rotator
//ferot.addEvent(window, 'load', ferot.initFeatureBucket);   MOVED TO ONLOAD.JS TO FILTER ON PAGE=HOME, STATUS=LOGGED



// Cache any desired images

/*  Example usage:
ferot.preCache(

           "http://my.safaribooksonline.com/images/0130353310/0130353310_xs.jpg",
           "http://my.safaribooksonline.com/images/0139696946/0139696946_xs.jpg",
           "http://my.safaribooksonline.com/images/0130461393/0130461393_xs.jpg",
           "http://my.safaribooksonline.com/images/0130428299/0130428299_xs.jpg",
           "http://my.safaribooksonline.com/images/0130923559/0130923559_xs.jpg",
           "http://my.safaribooksonline.com/images/0131463152/0131463152_xs.jpg",
           "http://my.safaribooksonline.com/images/9781590478493/9781590478493_xs.jpg"

);
*/



