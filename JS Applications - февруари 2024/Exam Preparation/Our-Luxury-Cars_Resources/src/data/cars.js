import { del, get, post,put } from "./request.js";

const endpoints = {

    allCars: '/data/characters?sortBy=_createdOn%20desc',
    details: '/data/characters/',
    add: '/data/characters',
    edit: '/data/characters/',
    deleteCar: '/data/characters/'
};

export async function getAllCars() {

    return  get(endpoints.allCars);
}

export async function getCarById(id) {

    return get(endpoints.details + id);
}

export async function createCar(category, imageUrl, description, moreInfo) {

    return post(endpoints.add, { category, imageUrl, description, moreInfo });
}

export async function updateCar(id, category, imageUrl, description, moreInfo) {

    return put(endpoints.edit + id, { category, imageUrl, description, moreInfo });
}

export async function deleteEvent(id) {

    return del(endpoints.deleteCar + id)
}

