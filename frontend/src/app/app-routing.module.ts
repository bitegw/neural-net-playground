import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuardService } from './_services/auth-guard.service';
import { AddModelComponent } from './_pages/add-model/add-model.component';
import { HomeComponent } from './_pages/home/home.component';
import { MyDatasetsComponent } from './_pages/my-datasets/my-datasets.component';
import { MyModelsComponent } from './_pages/my-models/my-models.component';
import { MyPredictorsComponent } from './_pages/my-predictors/my-predictors.component';
import { BrowsePredictorsComponent } from './_pages/browse-predictors/browse-predictors.component';
import { BrowseDatasetsComponent } from './_pages/browse-datasets/browse-datasets.component';
import { SettingsComponent } from './_pages/settings/settings.component';
import { ProfileComponent } from './_pages/profile/profile.component';
import { PredictComponent } from './_pages/predict/predict.component';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { title: 'Početna strana' } },
  { path: 'add-model', component: AddModelComponent, data: { title: 'Dodaj model' } },
  { path: 'my-datasets', component: MyDatasetsComponent, canActivate: [AuthGuardService], data: { title: 'Moji izvori podataka' } },
  { path: 'my-models', component: MyModelsComponent, canActivate: [AuthGuardService], data: { title: 'Moji modeli' } },
  { path: 'my-predictors', component: MyPredictorsComponent, canActivate: [AuthGuardService], data: { title: 'Moji trenirani modeli' } },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuardService], data: { title: 'Podešavanja' } },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService], data: { title: 'Profil' } },
  { path: 'browse-datasets', component: BrowseDatasetsComponent, data: { title: 'Javni izvori podataka' } },
  { path: 'browse-predictors', component: BrowsePredictorsComponent, data: { title: 'Javni trenirani modeli' } },
  { path: 'predict', component: PredictComponent, data: { title: 'Predvidi vrednosti' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
