import { StringData } from "./StringData";

export class Task{
        id: number;
        sessionId: number;
        ready: boolean;
        assignedTo: StringData[]=[];
}