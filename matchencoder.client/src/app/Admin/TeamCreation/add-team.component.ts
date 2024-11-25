import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { ApiService } from '../../../services/api.service';

@Component({
  selector: 'add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css'],
})


export class TeamComponent implements OnInit {


  constructor(private apiService: ApiService) { }

  ngOnInit() {

  }


}
