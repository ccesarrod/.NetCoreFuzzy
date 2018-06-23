import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Category } from './category.component';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CategoryService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'api/category/GetCategories');
  }
 

}
