import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'phoneFormatter',
  standalone: true
})
export class PhoneFormatterPipe implements PipeTransform {
  transform(value: number): string {
    if (!value) return '';
    return value.toString().replace(/(\d{3})(\d{3})(\d{4})/, '$1-$2-$3');
  }
}
