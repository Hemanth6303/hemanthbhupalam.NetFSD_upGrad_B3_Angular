import { Component, Input } from '@angular/core';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './contact-detail.html',
  styleUrls: ['./contact-detail.css']   
})
export class ContactDetail {

  @Input() contactId: number = 1;

  contact: Contact | undefined;
  searchName: string = '';
  hasSearched: boolean = false;   // added flag

  
  constructor(private contactService: ContactService) {
 
    this.contact = this.contactService.getContactById(this.contactId);
  }

  // Search method
  searchByName() {
    this.hasSearched = true;

    if (!this.searchName.trim()) {
      this.contact = undefined;
      return;
    }

    const contacts = this.contactService.getContacts();
   
    this.contact = contacts.find(c =>
      c.name.toLowerCase().includes(this.searchName.toLowerCase())
    );
  }
}