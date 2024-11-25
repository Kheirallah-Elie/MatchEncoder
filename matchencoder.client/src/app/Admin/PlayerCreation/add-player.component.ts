import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { ApiService } from '../../../services/api.service';


@Component({
  selector: 'add-player',
  templateUrl: './add-player.component.html',
  styleUrls: ['./add-player.component.css'],
})




export class PlayerComponent implements OnInit {

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }


}
