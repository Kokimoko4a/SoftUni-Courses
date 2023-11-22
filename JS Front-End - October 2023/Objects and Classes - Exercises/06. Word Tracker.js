function countWords(array) {

  let list = [];
  let searched = array[0].split(" ");

  for (let index = 0; index < searched.length; index++) {
    const curr = searched[index].toLowerCase();

    list.push({ word: curr, occurences: 0 });

    array.forEach(element => {

      if (element === curr) {

        list[index].occurences++;
      }
    });

  }

  list = list.sort((a, b) => b.occurences - a.occurences);

  list.forEach(element => {

    console.log(`${element.word} - ${element.occurences}`)
  });



}


countWords([
  'this sentence',
  'In', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'is', 'your', 'task'
]
);

