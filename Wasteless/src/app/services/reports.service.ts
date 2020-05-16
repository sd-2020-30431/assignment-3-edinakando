import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

import { ReportItem } from 'src/app/models/reportItem';

@Injectable()

export class ReportsService {
    constructor(private http: HttpClient) { }

    getWeekly(userId): Observable<ReportItem[]>{
        return this.http.get<ReportItem[]>(`${environment.apiUrl}/reports`, {params: {type: '0', userId: userId}} );
    }   
    
    getMonthly(userId): Observable<ReportItem[]>{
        return this.http.get<ReportItem[]>(`${environment.apiUrl}/reports`, {params: {type: '1', userId: userId}} );
    }
}