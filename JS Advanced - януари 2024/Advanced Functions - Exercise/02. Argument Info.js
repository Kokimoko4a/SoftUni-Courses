function solve(...array){

    const res = {};
    


    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        let type = typeof(element);
        

        if (!res.hasOwnProperty(type)) {
            
           
           res[type] = 0
        }

        res[type]++;


        if (typeof(element) !== 'object') {
            console.log(`${type}: ${element}`);    
        }
        else
        {
            console.log('object:')
        }
        
    }


    let sortedres = Object.entries(res).sort((a,b) => b[1] - a[1]);

for (let [k,v] of sortedres) {
    
    console.log(`${k} = ${v}`)
}

}

solve({ name: 'bob'}, 3.333, 9.999);