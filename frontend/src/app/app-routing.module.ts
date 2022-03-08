import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginPageComponent } from './_pages/login-page/login-page.component';
import { OnlyAuthorizedComponent } from './_pages/only-authorized/only-authorized.component';
import { RegisterPageComponent } from './_pages/register-page/register-page.component';
import { AuthGuardService } from './_services/auth-guard.service';
import { DatasetLoadComponent } from './_elements/dataset-load/dataset-load.component';

const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  { path: 'register', component: RegisterPageComponent },
  { path: 'only-authorized', component: OnlyAuthorizedComponent, canActivate: [AuthGuardService] },
  { path: 'proba', component: DatasetLoadComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
