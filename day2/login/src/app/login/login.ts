import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  title = 'login'
  email='';
  password='';

  submit(){
    console.log(this.email);
    console.log(this.password);
  }
}
