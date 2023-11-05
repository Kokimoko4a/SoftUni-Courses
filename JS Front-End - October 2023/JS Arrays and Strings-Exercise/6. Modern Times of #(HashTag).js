function solve(sentence) {
    let regex = /#[A-Za-z]+/gm;

    let mathces = sentence.match(regex);

    for (let element of mathces) {
        element = element.replace("#", "");
        console.log(element);
    }

}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');