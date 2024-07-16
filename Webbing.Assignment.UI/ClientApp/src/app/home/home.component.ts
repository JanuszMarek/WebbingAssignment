import { HttpClient, HttpParams } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { CustomerUsageModel } from '../models/customerUsageModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private readonly http: HttpClient) {
    
  }

  simsCount = 0;
  totalUsage = 0;
  topCustomers: CustomerUsageModel[] = [];

  ngOnInit() : void {
    this.http.get('https://localhost:7187/api/health/check')
      .subscribe();

    this.loadReportData();

  }

  loadReportData(): void {
    let params = new HttpParams();
    params = params.append('FromDate', new Date().getUTCDate());

    //move to separate service
    this.http.get<CustomerUsageModel[]>('https://localhost:7187/api/usages-group-by-customer', {params: params}).subscribe(items => {
      items.forEach(item => {
        this.simsCount += item.simCount;
        this.totalUsage += item.quotaSum;
      });
      this.topCustomers = this.getTopCustomers(items, 2);
    });
  }

  getTopCustomers(objects: CustomerUsageModel[], count: number): CustomerUsageModel[] {
    return objects
      .sort((a, b) => b.quotaSum - a.quotaSum) // Sort by 'quotaSum' in descending order
      .slice(0, count); // Take the first two elements
  }
}
