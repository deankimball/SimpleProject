import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

interface Profile {
  name: string;
  address: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  public profile: Profile = { name: "", address: "" };
  profileForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    address: new FormControl(''),
  });
  submitted = false;

  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    //this.getProfile();
    this.profileForm = this.formBuilder.group({
      name: ['', Validators.required],
      address: [''],
    });
  }

  
  getProfile() {
    this.http.get<Profile>('/api/profile').subscribe(
      (result) => {
        this.profile = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  get requiredCheck(): { [key: string]: AbstractControl } {
    let nameControl = this.profileForm.controls["name"];
    return nameControl.errors ? nameControl.errors['required'] : false;
  }

  onSubmit(): void {
    this.http.post<Profile>('api/profile', { "name": this.profileForm.value.name, "address": this.profileForm.value.address }).subscribe(
      (result) => {
        this.profile.name = result.name || "";
        this.profile.address = result.address || "";
        console.error("Profile updated");
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
