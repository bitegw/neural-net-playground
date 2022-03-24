import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { MatSliderModule } from '@angular/material/slider';
import { MatIconModule } from '@angular/material/icon';

import {NgChartsModule} from 'ng2-charts';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DatasetLoadComponent } from './_elements/dataset-load/dataset-load.component';
import { AddModelComponent } from './_pages/add-model/add-model.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginModalComponent } from './_modals/login-modal/login-modal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterModalComponent } from './_modals/register-modal/register-modal.component';

import { MaterialModule } from './material.module';
import { HomeComponent } from './_pages/home/home.component';
import { NavbarComponent } from './_elements/navbar/navbar.component';
import { ItemPredictorComponent } from './_elements/item-predictor/item-predictor.component';
import { ItemDatasetComponent } from './_elements/item-dataset/item-dataset.component';
import { CarouselComponent } from './_elements/carousel/carousel.component';
import { SettingsComponent } from './_pages/settings/settings.component';
import { ProfileComponent } from './_pages/profile/profile.component';
import { MyPredictorsComponent } from './_pages/my-predictors/my-predictors.component';
import { MyDatasetsComponent } from './_pages/my-datasets/my-datasets.component';
import { MyModelsComponent } from './_pages/my-models/my-models.component';
import { BrowseDatasetsComponent } from './_pages/browse-datasets/browse-datasets.component';
import { BrowsePredictorsComponent } from './_pages/browse-predictors/browse-predictors.component';
import { PredictComponent } from './_pages/predict/predict.component';
import { ScatterchartComponent } from './scatterchart/scatterchart.component';
import { BarchartComponent } from './barchart/barchart.component';
import { NotificationsComponent } from './_elements/notifications/notifications.component';
import { DatatableComponent } from './_elements/datatable/datatable.component';

@NgModule({
  declarations: [
    AppComponent,
    DatasetLoadComponent,
    AddModelComponent,
    LoginModalComponent,
    RegisterModalComponent,
    HomeComponent,
    NavbarComponent,
    ItemPredictorComponent,
    ItemDatasetComponent,
    CarouselComponent,
    SettingsComponent,
    ProfileComponent,
    MyPredictorsComponent,
    MyDatasetsComponent,
    MyModelsComponent,
    BrowseDatasetsComponent,
    BrowsePredictorsComponent,
    PredictComponent,
    ScatterchartComponent,
    BarchartComponent,
    NotificationsComponent,
    DatatableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    MatSliderModule,
    MatIconModule,
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
