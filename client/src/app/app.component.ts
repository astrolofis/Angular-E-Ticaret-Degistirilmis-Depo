import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-first',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'E-Ticaret';
  //products! :IProduct[];//!!!!!!!!!  normalde ! olmaması lazım 
  

constructor (){}

ngOnInit():void{//!!!!!!!!! <IPagination> yok normalde
//   this.http.get<IPagination>('https://localhost:44373/api/products').subscribe((response:IPagination)=>{
  
//   this.products=response.data;

// },error=>{
//   console.log(error);
// });
}

}
