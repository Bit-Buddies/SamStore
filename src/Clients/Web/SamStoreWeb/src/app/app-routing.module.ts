import { NotfoundComponent } from './pages/notfound/notfound.component';
import { HomeComponent } from './pages/main/home/home.component';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {
    path: 'account',
    loadChildren: () =>
      import('./pages/main/account/account.module').then(
        (m) => m.AccountModule
      ),
  },
  { path: 'not-found', component: NotfoundComponent },
  { path: '**', component: NotfoundComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, {
      useHash: false,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
