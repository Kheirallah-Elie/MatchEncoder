import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { MatchComponent } from './match.component';


const routes: Routes = [
  { path: '', component: AppComponent, pathMatch: 'full' },
  { path: 'create-match', component: MatchComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
