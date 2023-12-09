function attachEvents() {
    
    let baseURL = 'http://localhost:3030/jsonstore/messenger';

    let [nameInput, contentInput,sendButton, refreshButton] = document.getElementsByTagName('input');

    let textAreaMessages = document.getElementById('messages');

    sendButton.addEventListener('click', async ()=> {

        let messageFormat = {

            author: nameInput.value,
            content: contentInput.value

        };


        let validMessage = nameInput.value !== '' && contentInput.value !== "";

        if (validMessage) {
                       
        await fetch(baseURL, {

            method: "POST",
            body: JSON.stringify(messageFormat)

        });

    
        
        }


        nameInput.value = '';
        contentInput.value = '';

    });

    refreshButton.addEventListener('click', async () => {
        try {
            let response = await fetch(baseURL);
    
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
    
            let messages = await response.json();
    
            let messageArray = [];
    
            for (const message of Object.values(messages)) {
                messageArray.push(`${message.author}: ${message.content}`);
            }
    
            textAreaMessages.textContent = messageArray.join('\n');
        } catch (error) {
            console.error('Error fetching messages:', error);
        }
    });

}

attachEvents();