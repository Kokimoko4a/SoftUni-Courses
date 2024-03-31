import { del, get, post, put } from "./request.js";

const endpoints = {

    allCars: '/data/cyberpunk?sortBy=_createdOn%20desc',
    details: '/data/cyberpunk/',
    add: '/data/cyberpunk',
    edit: '/data/cyberpunk/',
    deleteCar: '/data/cyberpunk/'
};

export async function getAllCars() {

    return get(endpoints.allCars);
}

export async function getCarById(id) {

    return get(endpoints.details + id);
}

export async function createCar(item, imageUrl, price, availability, type, description) {

    return post(endpoints.add, { item, imageUrl, price, availability, type, description });
}

export async function updateCar(id, item, imageUrl, price, availability, type, description) {

    return put(endpoints.edit + id, { item, imageUrl, price, availability, type, description });
}

export async function deleteEvent(id) {

    return del(endpoints.deleteCar + id)
}

