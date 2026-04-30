import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { AddContact} from './add-contact/add-contact';
import { ContactList } from './contact-list/contact-list';
import { ContactDetail } from './contact-detail/contact-detail'; 
@Component({
  selector: 'app-root',
  imports: [FormsModule,AddContact,ContactList,ContactDetail],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ContactManagementservicesDI');
}
