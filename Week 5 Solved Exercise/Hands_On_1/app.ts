import { Component } from '@angular/core';
import { HeaderComponent } from './components/header/header';
import { HomeComponent } from './pages/home/home';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  imports: [HeaderComponent, HomeComponent, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}
