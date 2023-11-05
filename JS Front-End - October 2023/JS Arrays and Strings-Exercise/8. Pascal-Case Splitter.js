function splitter(word)
{

    let regex = /[A-Z][a-z]*/g;
    let matches = word.match(regex);

    console.log(matches.join(", "));
}