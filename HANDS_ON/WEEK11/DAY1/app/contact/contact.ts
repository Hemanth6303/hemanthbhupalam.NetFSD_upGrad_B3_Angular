import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PhoneFormatterPipe } from '../pipes/phone-formatter-pipe';
import { StatusPipe } from '../pipes/status-pipe';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    PhoneFormatterPipe,
    StatusPipe
  ],
  templateUrl: './contact.html',
  styleUrls: ['./contact.css']
})
export class Contact {

  searchText: string = '';
  showAll: boolean = false;

  contacts = [
    { name: 'hemanth', email: 'HEMANTH@gmail.com', phone: 9876543210, status: true },
    { name: 'rahul', email: 'RAHUL@gmail.com', phone: 9123456780, status: false },
    { name: 'sai', email: 'SAI@gmail.com', phone: 9012345678, status: true },
    { name: 'kiran', email: 'KIRAN@gmail.com', phone: 9988776655, status: false },
    { name: 'ravi', email: 'RAVI@gmail.com', phone: 9871234560, status: true },
    { name: 'john', email: 'JOHN@gmail.com', phone: 8765432109, status: true },
    { name: 'david', email: 'DAVID@gmail.com', phone: 7654321098, status: false },
    { name: 'arun', email: 'ARUN@gmail.com', phone: 6543210987, status: true },
    { name: 'teja', email: 'TEJA@gmail.com', phone: 5432109876, status: false },
    { name: 'ram', email: 'RAM@gmail.com', phone: 4321098765, status: true }
  ];

  // ✅ FINAL WORKING METHOD
  getFilteredContacts() {
    let filtered = this.contacts;

    if (this.searchText) {
      const search = this.searchText.toLowerCase();
      //console.log('Filtering contacts with search text:', search);
      filtered = filtered.filter(c =>
        c.name.toLowerCase().includes(search) ||
        c.email.toLowerCase().includes(search)
      );
    }

    return this.showAll ? filtered : filtered.slice(0, 5);
  }

  toggleStatus(contact: any) {
    console.log('Toggling status for:', contact);
    contact.status = !contact.status;
  }

  toggleShow() {
    this.showAll = !this.showAll;
  }
}