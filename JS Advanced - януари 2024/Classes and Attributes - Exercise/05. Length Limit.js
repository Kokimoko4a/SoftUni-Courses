class Stringer{


    innerString;
    innerLength;

    constructor(string, length){

        this.innerString = string;
        this.innerLength = length;
    }

    increase(length){

        this.innerLength += length;
    }

    decrease(length){

        if (this.innerLength - length < 0) {

            this.innerLength = 0;
        }

        else{

            this.innerLength -= length;
        }
      

    }

    toString(){

        if (this.innerLength === this.innerString.length) {
            
            return this.innerString;
        }

       

        else if (this.innerLength === 0) {
            return "...";
        }

        else{

            let diff = this.innerString.length - this.innerLength;
            let absDiff = Math.abs(diff);

            let f = this.innerString.substr(0,this.innerLength);

            if (diff !== absDiff) {
                return f;
            }

            else{
                return f + '.'.repeat(diff);
            }
           
        } 
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
