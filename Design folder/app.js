let likeBtn = document.getElementById('like');
alert(likeBtn);
let likes = document.getElementById('likes');
let s = false;

likeBtn.addEventListener('click', (e) => {

    e.preventDefault();

    if (!s) {
        likeBtn.textContent = "Unlike";
        let currentLikes = Number(likes.textContent);
        likes.textContent = currentLikes + 1;
        s = true;
    }

    else{

        likeBtn.textContent = "Like";

        let currentLikes = Number(likes.textContent);
        likes.textContent = currentLikes - 1;
        s = false;
    }

  
    
});