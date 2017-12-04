export class Session{
    id: number;
    sessionName: string;
    administrator: string;
    token: string;
    ready: boolean;
    deadline: Date;
}