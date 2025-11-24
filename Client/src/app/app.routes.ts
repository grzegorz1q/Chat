import { Routes } from '@angular/router';
import { ChatPageComponent } from './features/chat/pages/chat.page.component/chat.page.component';
import { RegisterComponent } from './features/auth/pages/register.component/register.component';
import { LoginComponent } from './features/auth/pages/login.component/login.component';

export const routes: Routes = [
    {
        path: '',
        component: ChatPageComponent
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    {
        path: 'login',
        component: LoginComponent
    }
];
