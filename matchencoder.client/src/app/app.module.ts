import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login.component';
import { RegisterComponent } from './Register/register.component';

import { AdminComponent } from './Admin/admin.component';

import { MatchComponent } from './Admin/MatchCreation/add-match.component';
import { MatchEncoderComponent } from './Admin/MatchEncoder/encode-match.component';
import { PlayerComponent } from './Admin/PlayerCreation/add-player.component';
import { TeamComponent } from './Admin/TeamCreation/add-team.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AdminComponent,
    MatchComponent,
    MatchEncoderComponent,
    PlayerComponent,
    TeamComponent
  ],

  exports: [
    AdminComponent // Export to make it reusable across modules
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, // Add this to enable ngModel
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
