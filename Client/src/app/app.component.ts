import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from './interfaces/product';
import { Pagination } from './interfaces/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
	title = 'Nike';
	public products: Product[];

	constructor(private http: HttpClient) {}

	ngOnInit(): void {
		this.http.get('https://localhost:5001/api/products?pageSize=50')
		.subscribe((response: Pagination) => {
			this.products = response.data;
			console.log(response);
		}, error => {
			console.log(error);
		});
	}
}
