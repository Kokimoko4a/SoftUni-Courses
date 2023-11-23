function dictionary(input) {
    let list = [];

    for (let element of input) {
        let row = JSON.parse(element);
        let key = Object.keys(row)[0];
        let value = row[key];

        let existingObject = list.find(item => item.name === key);

        if (existingObject) {
   
            existingObject.description = value;
        } else {
   
            list.push({ name: key, description: value });
        }
    }

    list.sort((a, b) => a.name.localeCompare(b.name));

    list.forEach(element => {
        console.log(`Term: ${element.name} => Definition: ${element.description}`);
    });
}

dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    );