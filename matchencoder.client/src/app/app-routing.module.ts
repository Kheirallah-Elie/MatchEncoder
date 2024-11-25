import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

import { LoginComponent } from './Login/login.component';
import { RegisterComponent } from './Register/register.component';
import { AdminComponent } from './Admin/admin.component';

import { MatchComponent } from './Admin/MatchCreation/add-match.component';
import { MatchEncoderComponent } from './Admin/MatchEncoder/encode-match.component';
import { PlayerComponent } from './Admin/PlayerCreation/add-player.component';
import { TeamComponent } from './Admin/TeamCreation/add-team.component';

const routes: Routes = [
  { path: '', component: AppComponent, pathMatch: 'full' },
  { path: 'add-match', component: MatchComponent },
  { path: 'add-encoder', component: MatchEncoderComponent },
  { path: 'add-player', component: PlayerComponent },
  { path: 'add-team', component: TeamComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
