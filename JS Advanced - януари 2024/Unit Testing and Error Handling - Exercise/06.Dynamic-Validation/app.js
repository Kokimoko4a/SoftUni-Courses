function validate() {
   
    let regex= /^[a-z0-9]+\@[a-z0-9]+\.[a-z0-9]+$/gm;

    let input = document.getElementById("email");

    input.addEventListener('change',() => {

        if (!regex.test(input.value)) {
            input.classList.add('error');
        }
    
        else
        {
    
            input.classList.remove('error');
        } 

    });

   

}