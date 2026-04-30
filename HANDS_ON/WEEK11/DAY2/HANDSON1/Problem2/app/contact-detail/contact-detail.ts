import { Component, Input } from '@angular/core';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './contact-detail.html',
  styleUrls: ['./contact-detail.css']   
})
export class ContactDetail {

  contact?: Contact;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact = this.contactService.getContactById(id);
  }
}