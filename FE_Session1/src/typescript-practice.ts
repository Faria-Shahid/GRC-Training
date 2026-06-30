interface Animal{
    name: string;
    age: number;
    species: string;
}

function printAnimalDetails(animal: Animal): void {
    console.log(`Name: ${animal.name}`);
    console.log(`Age: ${animal.age}`);
    console.log(`Species: ${animal.species}`);
}

enum WeekDays {
    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
}

enum FeeTypes {
    Daily, Hourly, Flat
}

interface vehicle{
    numberPlate : string;
    ownerName : string;
    feeType : FeeTypes;
}

interface Floor{
    floorNumber: number;
    capacity: number;
    vehicles: vehicle[];
}

interface ParkingLot{
    name: string;
    location: string;
    capacity: number;
    floors: Floor[];
}

interface Person{
    name : string;
    age : number;
    gender : string;
    height : number;
}

// Animal
const myAnimal: Animal = {
    name: 'Leo',
    age: 5,
    species: 'Lion'
};
printAnimalDetails(myAnimal);

// Vehicle
const myVehicle: vehicle = {
    numberPlate: 'ABC-1234',
    ownerName: 'Faria',
    feeType: FeeTypes.Hourly
};
console.log(`Number Plate: ${myVehicle.numberPlate}`);
console.log(`Owner: ${myVehicle.ownerName}`);
console.log(`Fee Type: ${FeeTypes[myVehicle.feeType]}`);

// Floor
const myFloor: Floor = {
    floorNumber: 1,
    capacity: 20,
    vehicles: [myVehicle]
};
console.log(`Floor: ${myFloor.floorNumber}`);
console.log(`Capacity: ${myFloor.capacity}`);
console.log(`Vehicles on floor: ${myFloor.vehicles.length}`);

// ParkingLot
const myParkingLot: ParkingLot = {
    name: 'City Parking',
    location: 'Downtown',
    capacity: 100,
    floors: [myFloor]
};
console.log(`Parking Lot: ${myParkingLot.name}`);
console.log(`Location: ${myParkingLot.location}`);
console.log(`Total Capacity: ${myParkingLot.capacity}`);
console.log(`Number of Floors: ${myParkingLot.floors.length}`);

// Person
const myPerson: Person = {
    name: 'Faria',
    age: 22,
    gender: 'Female',
    height: 5.4
};
console.log(`Name: ${myPerson.name}`);
console.log(`Age: ${myPerson.age}`);
console.log(`Gender: ${myPerson.gender}`);
console.log(`Height: ${myPerson.height}`);
