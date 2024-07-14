import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgxSpinnerComponent } from 'ngx-spinner';
import { HomeComponent } from './home/home.component';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet,NavComponent,HomeComponent,NgxSpinnerComponent]
})

export class AppComponent implements OnInit
{
   private accountService=inject(AccountService);
   
   ngOnInit(): void 
   {
      this.setCurrentUser();
   }
   
   setCurrentUser(): void
   {
      const userString=localStorage.getItem('user');
      if(!userString) return;
      const user=JSON.parse(userString);
      this.accountService.currentUser.set(user);
   }
}
