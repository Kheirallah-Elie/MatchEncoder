import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { HttpClientModule } from '@angular/common/http';

//import { AppComponent } from './app.component';
import { MatchComponent } from './match.component';

@NgModule({
  declarations: [
    //AppComponent,
    MatchComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule, // Add this to enable ngModel
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [MatchComponent],
})
export class AppModule { }
