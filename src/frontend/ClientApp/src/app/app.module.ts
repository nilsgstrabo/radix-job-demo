import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SelectAndClickDirective } from './directives/select-and-click.directive';
import { NotificationHubService } from './services/notification-hub.service';

@NgModule({ declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        SelectAndClickDirective,
    ],
    bootstrap: [AppComponent], imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
        ])], providers: [
        NotificationHubService,
        provideHttpClient(withInterceptorsFromDi()),
    ] })
export class AppModule { }
