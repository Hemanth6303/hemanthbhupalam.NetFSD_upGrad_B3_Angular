import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
  standalone: true,
  pure: false
})
export class SearchFilterPipe implements PipeTransform {

  transform(contacts: any[], searchText: string): any[] {

    if (!searchText) return contacts;

    searchText = searchText.toLowerCase();

    return contacts.filter(c =>
      c.name.toLowerCase().includes(searchText) ||
      c.email.toLowerCase().includes(searchText)
    );
  }
}
