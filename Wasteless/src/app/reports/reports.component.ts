import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ReportsService } from '../services/reports.service';
import { ReportItem } from '../models/reportItem';

@Component({
    selector: 'reports',
    templateUrl: './reports.component.html',
    providers: [AuthService, ReportsService]
})

export class ReportsComponent {
    reportItems: ReportItem[];
    colors: ['red', 'green'];

    constructor(private authService: AuthService,
                private reportsService: ReportsService) { }

    weekly(){
        this.reportsService.getWeekly(this.authService.getUserId())
            .subscribe(res =>
                {
                    this.setReport(res);
                })
    }

    monthly(){
        this.reportsService.getMonthly(this.authService.getUserId())
            .subscribe(res =>
                {
                    this.setReport(res);
                })
    }

    setReport(res){
        console.log(res);
        this.reportItems = res;
    }
}