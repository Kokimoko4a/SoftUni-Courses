function encodeAndDecodeMessages() {
    
    let buttonForEncoding = document.getElementsByTagName("button")[0];
    let buttonForDecoding = document.getElementsByTagName('button')[1];
    let textForEncoding = document.getElementsByTagName('textarea')[0];
    let textForCoding = document.getElementsByTagName('textarea')[1];

    buttonForEncoding.addEventListener('click', encodeMessageAndSendIt);
    buttonForDecoding.addEventListener('click', decodeMessage);


    function encodeMessageAndSendIt(){

        let newCodedMessage = '';

        let srrays = Array.from('aaaaa');

        let words = Array.from(textForEncoding.value);

        for (let i = 0; i < words.length; i++) {
            let element = Array.from( words[i]);

            for (let k = 0; k < element.length; k++) {
                
                newCodedMessage += String.fromCharCode(element[k].charCodeAt(0) +1 );
                
            }
            
        }

        textForEncoding.value = "";
       textForCoding.value =  newCodedMessage;

    }

    function decodeMessage(){
        let newDecodedMessage = '';

       

        let words = Array.from(textForCoding.value);

        for (let i = 0; i < words.length; i++) {
            let element = Array.from( words[i]);

            for (let k = 0; k < element.length; k++) {
                
                newDecodedMessage += String.fromCharCode(element[k].charCodeAt(0) -1 );
                
            }
            
        }

       
       textForCoding.value =  newDecodedMessage;

    }
}