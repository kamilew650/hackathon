import { Component, OnInit } from '@angular/core';

import { Session } from '../../models/Session';
import { Task } from '../../models/Task';

import { ApiService } from '../../services/api.services';

@Component({
    selector: 'session',
    templateUrl: './session.component.html'
})
export class SessionComponent implements OnInit {
    private serrion: Session;
    private tasks: Task[];

    constructor(
        private apiService: ApiService
    ) { }

    ngOnInit(){
        
    }

}
