import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  returnUrl!: string;

  constructor(
      private accountService: AccountService,
      private router: Router,
      private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')
      ]),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    this.accountService.login(this.form.value)
      .subscribe(
        () => this.router.navigateByUrl(this.returnUrl),
        error => console.error(error)
      );
  }

  isError(fieldName: string, errorType: string): boolean {
    const formField = this.form.get(fieldName);
    if (!formField) return false;
    const formFieldErrors = formField.errors;
    if (!formFieldErrors) return false;
    const formFieldError = formFieldErrors[errorType];
    return formFieldError;
  }
}
