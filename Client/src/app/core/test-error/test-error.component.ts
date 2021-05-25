import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void { }

  get404Error() {
    this.http.get<IProduct>(this.baseUrl + 'product/83ACE365-48CF-47D5-A920-DC237E5454E4').subscribe(console.log, console.error);
  }

  get500Error() {
    this.http.get(this.baseUrl + 'weatherforecast/servererror').subscribe(console.log, console.error);
  }

  get400Error() {
    this.http.get<IProduct>(this.baseUrl + 'weatherforecast/badrequest').subscribe(console.log, console.error);
  }

  get400ValidationError() {
    this.http.get<IProduct>(this.baseUrl + 'product/notGuidId').subscribe(
      console.log,
      error => {
        console.error;
        this.validationErrors = error.errors;
      }
    );
  }
}
