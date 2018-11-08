import { Item } from './item';

export class Employee {
    id: number;
    name: string;
    surname: string;
    patronymic: string;
    items: Item[];

    constructor() {
        this.id = 0;
        this.name = '';
        this.surname = '';
        this.patronymic = '';
        this.items = [];
    }
}