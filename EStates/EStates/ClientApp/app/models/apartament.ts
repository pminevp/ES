import { User } from "./user.model";

export class Apartament {
    id: number;
    name: string;
    description: string;
    owners: any;
    status: string;
    owner?: Array<User>
}