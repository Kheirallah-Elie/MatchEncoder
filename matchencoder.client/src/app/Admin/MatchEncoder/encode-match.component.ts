import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { ApiService } from '../../../services/api.service';


@Component({
  selector: 'add-encoder',
  templateUrl: './encode-match.component.html',
  styleUrls: ['./encode-match.component.css'],
})



export class MatchEncoderComponent implements OnInit {


  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }




}
