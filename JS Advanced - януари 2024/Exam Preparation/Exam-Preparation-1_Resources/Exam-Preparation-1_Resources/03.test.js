import { expect } from "chai";
import { motorcycleRider } from "./Motorcycle Rider";


describe('Test suite', function() {

    describe('licenseRestriction functionality', function() {

        it('Case AM', () => {
    
    
            expect(motorcycleRider.licenseRestriction('AM')).to.equal("Mopeds with a maximum design speed of 45 km. per hour, engine volume is no more than 50 cubic centimeters, and the minimum age is 16.");
    
        });
    
        it('Case A1', () => {
    
            expect(motorcycleRider.licenseRestriction('A1')).to.equal('Motorcycles with engine volume is no more than 125 cubic centimeters, maximum power of 11KW. and the minimum age is 16.');
        });
    
        it('Case A2', () => {
    
            expect(motorcycleRider.licenseRestriction('A2')).to.equal("Motorcycles with maximum power of 35KW. and the minimum age is 18.");
        });
    
        it('Case A', () => {
    
            expect(motorcycleRider.licenseRestriction('A')).to.equal('No motorcycle restrictions, and the minimum age is 24.');
        });
    
        it('Invalid cases', () => {
    
            expect(() => motorcycleRider.licenseRestriction(5)).to.throw();
    
            expect(() => motorcycleRider.licenseRestriction('aaaa')).to.throw();
    
            expect(() => motorcycleRider.licenseRestriction({key:12, d:12})).to.throw();

            expect(() => motorcycleRider.licenseRestriction(['d', 'dd', 'd'])).to.throw();

            expect(() => motorcycleRider.licenseRestriction(function(){console.log('ddd')})).to.throw();
        })
    });

    describe('motorcycleShowroom functionality', function() {


        it('Adds bikes', () => {

            expect(motorcycleRider.motorcycleShowroom([50],50)).to.equal(`There are ${1} available motorcycles matching your criteria!`);

            expect(motorcycleRider.motorcycleShowroom([50, 1],50)).to.equal(`There are ${1} available motorcycles matching your criteria!`);

            expect(motorcycleRider.motorcycleShowroom([50, 50],50)).to.equal(`There are ${2} available motorcycles matching your criteria!`);
        });

        it('Not array case', () => {

            expect(() => motorcycleRider.motorcycleShowroom('sss',50)).to.throw();

            expect(() => motorcycleRider.motorcycleShowroom('sss','dd')).to.throw();

            expect(() => motorcycleRider.motorcycleShowroom('sss',{s: 1, s:4})).to.throw();
        });

        it('Not number maximumEngineVolume', () => {

            expect(() => motorcycleRider.motorcycleShowroom(['1'], 'ddd')).to.throw();
        });

        it('engine volume array empty', () => {

            expect(() => motorcycleRider.motorcycleShowroom([], 50)).to.throw();

            expect(() => motorcycleRider.motorcycleShowroom([], [])).to.throw();

            expect(() => motorcycleRider.motorcycleShowroom([], 'ddd')).to.throw();

            expect(() => motorcycleRider.motorcycleShowroom('dd', 'ddd')).to.throw();
        });

        it('maximum engine volume is below 50', () => {

            expect(() => motorcycleRider.motorcycleShowroom(['50'], 1)).to.throw();
        });
    });

    describe('otherSpendings functionality', function() {

        it('invalid equipment', () => {

            expect(() => motorcycleRider.otherSpendings(['dddd'],['oil filter'],false)).to.throw();

            expect(() => motorcycleRider.otherSpendings('ddd',['oil filter'],false)).to.throw();

            expect(() => motorcycleRider.otherSpendings(1,['oil filter'],false)).to.throw();
        });

        it('invalid consumables', () => {

            expect(() => motorcycleRider.otherSpendings(['helmet'], ['dd'],false)).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], 'ddd',false)).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], 1,false)).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], 1,true)).to.throw();

            expect(() => motorcycleRider.otherSpendings('helmet', 1,false)).to.throw();

            expect(() => motorcycleRider.otherSpendings(1,1,1)).to.throw();
        });

        it('invalid state of discount', () =>{

            expect(() => motorcycleRider.otherSpendings(['helmet'], ['oil filter'], 'chushki')).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], ['oil filter'], 1)).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], ['oil filter'], {c:1, d:4})).to.throw();

            expect(() => motorcycleRider.otherSpendings(['helmet'], ['oil filter'], ['dd', 'dd'])).to.throw();

            expect(() => motorcycleRider.otherSpendings('helmet', 'oil filter', ['dd', 'dd'])).to.throw();

            expect(() => motorcycleRider.otherSpendings(false,false,1)).to.throw();

            expect(() => motorcycleRider.otherSpendings(1,1,1)).to.throw();
        });

        it('works properly without discount', () => {

            let expected = 230;
            let expectedTwo = 370;
            let expectedThree = 600;
            let expectedFour = 270;

            expect(motorcycleRider.otherSpendings(['helmet'], ['oil filter'],false)).to.equal(`You spend $${expected.toFixed(2)} for equipment and consumables!`);

            expect(motorcycleRider.otherSpendings(['jacked'], ['engine oil'],false)).to.equal(`You spend $${expectedTwo.toFixed(2)} for equipment and consumables!`);

            expect(motorcycleRider.otherSpendings(['jacked', 'helmet'], ['engine oil','oil filter'],false)).to.equal(`You spend $${expectedThree.toFixed(2)} for equipment and consumables!`);
     
            expect(motorcycleRider.otherSpendings(['helmet'], ['engine oil'],false)).to.equal(`You spend $${expectedFour.toFixed(2)} for equipment and consumables!`);
        });


        it('Totally invalid cases', () => {

            expect(motorcycleRider.otherSpendings(1,1,1)).to.throw();


            expect(motorcycleRider.otherSpendings('d','g', 'd')).to.throw();

            expect(motorcycleRider.otherSpendings('d', [12], 12)).to.throw();
        });
        
        it('woks properly with discount', () => {

            let expected = 230 - (0.1 * 230);
            let expectedTwo = 370 - 37;
            let expectedThree = 600 - 60;
            let expectedFour = 270 - 27;

            expect(motorcycleRider.otherSpendings(['helmet'], ['oil filter'],true)).to.equal(`You spend $${expected.toFixed(2)} for equipment and consumables with 10% discount!`);

            expect(motorcycleRider.otherSpendings(['helmet'], ['engine oil'],true)).to.equal(`You spend $${expectedFour.toFixed(2)} for equipment and consumables with 10% discount!`);

         

            expect(motorcycleRider.otherSpendings(['jacked'], ['engine oil'],true)).to.equal(`You spend $${expectedTwo.toFixed(2)} for equipment and consumables with 10% discount!`);

            expect(motorcycleRider.otherSpendings(['jacked', 'helmet'], ['engine oil', 'oil filter'],true)).to.equal(`You spend $${expectedThree.toFixed(2)} for equipment and consumables with 10% discount!`);
        });
    });

});
