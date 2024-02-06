function validateUrl(obj){

    let isValid = true;
    let validUrls = ['GET', 'POST','DELETE', 'CONNECT'];
    let regex = /^[A-Za-z0-9\.]+$/gm;
    let validHTTPVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1' ,'HTTP/2.0' ];
    let regexForMessage = /[<>\&'"]+/gm;
    

    
        if (!validUrls.includes(obj.method) || obj.method === null) {
        
            throw new Error("Invalid request header: Invalid Method");
        }
    
        if ( obj.uri === undefined) {
            
            throw new Error("Invalid request header: Invalid URI");
        }

        if (!(obj.uri === '*' || obj.uri.match(regex))) {
            
            throw new Error("Invalid request header: Invalid URI");
        }
    
        if (!validHTTPVersions.includes(obj.version)) {
            
            throw new Error("Invalid request header: Invalid Version");
        }
    
        if (obj.message === undefined) {
            throw new Error("Invalid request header: Invalid Message");
        }

        if (obj.message.match(regexForMessage)) {
            
            throw new Error("Invalid request header: Invalid Message");
        }  

        return obj;
    


   


}

validateUrl({
    method: 'GET',
   uri:"dewf",
    version: 'HTTP/1.1'
    
  }
  
  
  )