import { Component } from '@angular/core';
import { ContactService } from '../services/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-contact',
  imports: [CommonModule,FormsModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {

      contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(private contactService: ContactService) {}

  addContact() {
    this.contactService.addContact(this.contact);
    alert('Contact Added Successfully!');
  }
    

}
