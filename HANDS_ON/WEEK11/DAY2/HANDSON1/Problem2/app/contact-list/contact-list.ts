import { Component } from '@angular/core';
import { Contact } from '../models/contact';
import { ContactService } from '../services/contact';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  imports: [CommonModule,RouterLink],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {

  contacts: Contact[] = [];

  constructor(private contactService: ContactService) {

    this.contacts = this.contactService.getContacts();
  }

  


 
}
