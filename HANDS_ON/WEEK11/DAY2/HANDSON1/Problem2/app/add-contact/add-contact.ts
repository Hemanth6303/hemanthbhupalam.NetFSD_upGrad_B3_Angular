import { Component } from '@angular/core';
import { ContactService } from '../services/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

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

  constructor(
    private contactService: ContactService,
    private router: Router
  ) {}

  addContact() {
    this.contactService.addContact(this.contact);
    this.router.navigate(['/contacts']);
  }
}
