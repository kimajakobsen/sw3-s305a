// B2B VERSION
var aui = {

  dynInitCalls:function(page) {   
 
    if (status == "NotLogged") {
       if (portal == 'proquestselect') {
       CallGenericChunk('?query=CATEGORY%20itbooks.opsys&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=HomeAnonListPQS',"titleListpqs1");
            CallGenericChunk('?query=CATEGORY%20itbooks.graphics.digphoto&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=HomeAnonListPQS',"titleListpqs2");
            CallGenericChunk('?query=CATEGORY%20helpdesk&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=HomeAnonListPQS',"titleListpqs3");
           
       
       }else {
           CallGenericChunk('?query=CATEGORY%20itbooks&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=HomeAnonList',"titleList1");
            CallGenericChunk('?query=CATEGORY%20bizbooks&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=HomeAnonList',"titleList2");
            }
     }else {
        CallGenericChunk('?query=BOOK&sort=hits&order=desc&searchview=summary&searchmode=simple&xmlid=&view=book&page=&imagepage=&itemsPerPage=20&Template=FeaturedList',"titleList1");
        
     }
  }
  
};