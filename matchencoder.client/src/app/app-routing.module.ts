import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MatchComponent } from './match.component';


const routes: Routes = [
  { path: 'create-match', component: MatchComponent },
  //{ path: '', redirectTo: '/create-match', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
