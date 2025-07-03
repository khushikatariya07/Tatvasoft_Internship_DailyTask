import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './header/header';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Home } from './home/home';

@Component({
  selector: 'app-root',
  imports: [Header,CommonModule,FormsModule,Home,RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'gec';
  name = "khushi"
  visiblity = true;

  list = [ 'vansh','rahul','yash','dev'];

  listner(){
    console.log("primary button clicked");
    this.visiblity =!this.visiblity ;
  }
}
