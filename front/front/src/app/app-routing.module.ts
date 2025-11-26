import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { TermsComponent } from './terms/terms.component';
import { ArchiveComponent } from './archive/archive.component';
import { DraftsComponent } from './drafts/drafts.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'terms', component: TermsComponent},
  { path: 'archived', component: ArchiveComponent},
  { path: 'drafts', component: DraftsComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
 }
