import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {ListingService } from '../listing.service'
import { Router } from '@angular/router';
import { ToastrService } from '../../../../node_modules/ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent {

  constructor(private tservice: ToastrService,private listingService: ListingService,private router: Router) { }

  @ViewChild('addListingForm', { static: true }) from: NgForm

  createListingHandler(data){
    console.log(data);
    
    this.listingService.create(data).subscribe(res => {
      console.log(res)
      this.from.reset();
      this.router.navigate([`/listing/details/${res.id}`])
    });
  }
}
