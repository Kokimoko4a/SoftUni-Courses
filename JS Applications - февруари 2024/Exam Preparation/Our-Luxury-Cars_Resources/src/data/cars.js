import { del, get, post } from "./request.js";

const endpoints = {

    allCars: '/data/cars?sortBy=_createdOn%20desc',
    details: '/data/cars/',
    add: '/data/cars',
    edit: '/data/cars/',
    deleteCar: '/data/cars/'
};

export async function getAllCars() {

    return get(endpoints.allCars);
}

export async function getCarById(id) {

    return get(endpoints.details + id);
}

export async function createCar(model, imageUrl, price, weight, speed, about
) {

    return post(endpoints.add, { model, imageUrl, price, weight, speed, about });
}

export async function updateCar(id, data) {

    return put(endpoints.edit + id, data);
}

export async function deleteEvent(id) {

    return del(endpoints.deleteCar + id)
}

