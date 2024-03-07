// winners.component.ts
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-winners',
  templateUrl: './winners.component.html',
  styleUrls: ['./winners.component.scss'],
})
export class WinnersComponent implements OnInit {
  prizes: string[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}

  loadWinners(): void {
    this.apiService.getWinners().subscribe((data) => {
      this.prizes = [data.firstPrize, data.secondPrize];
    });
  }
}
