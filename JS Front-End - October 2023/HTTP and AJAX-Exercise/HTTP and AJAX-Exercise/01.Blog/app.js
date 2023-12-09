function attachEvents() {

    const baseURL = "http://localhost:3030/jsonstore/blog/";

    let buttonLoadPosts = document.getElementById('btnLoadPosts');
    let buttonView = document.getElementById('btnViewPost');
    let selectPosts = document.getElementById('posts');
    let postBody = document.getElementById('post-body');
    let postTitle = document.getElementById('post-title');
    let commentsList = document.getElementById('post-comments');

    let allPosts = {};

    buttonLoadPosts.addEventListener('click', async ()=> {

        selectPosts.innerHTML = '';

        let response = await fetch(baseURL + "posts");

        allPosts = await response.json();

       for (const [postKey, postObj] of Object.entries(allPosts)) {
        
        let option = document.createElement('option');

        option.value = postKey;
        option.textContent = postObj.title;

        selectPosts.appendChild(option);


       }

    });

    buttonView.addEventListener('click', async ()=> {

        postBody.innerHTML = '';
        commentsList.innerHTML = '';

        let postId = selectPosts.value;

        postBody.textContent = allPosts[postId].body;
        postTitle.textContent = allPosts[postId].title;

        

        let response = await fetch(baseURL + "comments");

        let comments = await response.json();

        let filteredCommments = Object.values(comments).filter(x => x.postId === postId)

        filteredCommments.forEach(comment => {

            let li = document.createElement('li');

            li.id = comment.id;
            li.textContent = comment.text;
            commentsList.appendChild(li);

        })

    })
}

attachEvents();