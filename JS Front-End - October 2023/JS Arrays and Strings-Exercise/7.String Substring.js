function solve(wordToSearch, sentence){
    
    let words = sentence.toLowerCase().split(" ");

    for (let index = 0; index < words.length; index++) {
        const element = words[index];

        if(element == wordToSearch ){
            console.log(wordToSearch);
            return;
        }
        
    }

    console.log(`${wordToSearch} not found!`)
}
solve('java',
'JavaScript java is the best programming language');