import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form!: FormGroup;
  errors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      displayName: [ null, Validators.required ],
      email: [
        null,
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')
        ],
        [
          // this.validateEmailNotTaken()
        ]
      ],
      password: [ null, Validators.required ]
    });
   }

  onSubmit() {
     this.accountService.register(this.form.value)
     .subscribe(
       () => this.router.navigateByUrl('/shop'),
       error => {
         console.error(error);
         this.errors = error.errors;
       }
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

  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(
          () => {
            if (!control.value) {
              return of(null);
            }
            return this.accountService.checkEmailExists(control.value).pipe(
              map(res => {
                return res ? { emailExists: true } : null;
              })
            );
          })
      );
    }
  };
}
