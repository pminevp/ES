import { User } from "./user.model";

export class Apartament {
    id: number;
    buildingEntranceId: number;
    buildingId: number;
    name: string;
    description: string;
    parentFloorId: number;
    status: string;
    owners: Array<User>;
}