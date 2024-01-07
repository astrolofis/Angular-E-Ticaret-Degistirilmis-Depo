import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-first',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'E-Ticaret';
  //products! :IProduct[];//!!!!!!!!!  normalde ! olmaması lazım 
  

constructor (private basketService: BasketService, private accountService : AccountService ){}

ngOnInit():void{
  this.loadBasket();
  this.loadCurrentUser();
}

loadCurrentUser(){
  
  const token= localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(()=>{
      console.log('Loaded User');
    },error=>{
      console.log(error);
    })
  
}

loadBasket(){
  const basketId = localStorage.getItem('basket_id');
  if(basketId){
    this.basketService.getBasket(basketId).subscribe(()=>{
      console.log("initiliaze basket");
    },error=>{
      console.log(error);
    })
  }
}

}
