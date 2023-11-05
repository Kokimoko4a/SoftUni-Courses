function solve(word, sentence) {


    let arrayWithWordsToInsert = word.split(", ");
    let arraySentence = sentence.split(" ");

    for (let index = 0; index < arrayWithWordsToInsert.length; index++) {
        let element = arrayWithWordsToInsert[index];


        for (let k = 0; k < arraySentence.length; k++) {

            

            if (arraySentence[k].includes('*')  && arraySentence[k].length === element.length) {
                arraySentence[k] = element;
                break;
            }



        }



    }

    console.log(arraySentence.join(' '));




}

solve('great, learning',
'softuni is ***** place for ******** new programming languages'
)