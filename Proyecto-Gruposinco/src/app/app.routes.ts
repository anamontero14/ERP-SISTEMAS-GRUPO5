import { Routes } from '@angular/router';
import { authGuard } from './auth/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () =>
      import('./views/login/login').then(m => m.LoginScreen),
  },
  {
    path: 'welcome',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./views/welcome/welcome').then(m => m.WelcomeComponent),
  },
  {
  path: 'pedidos',
  canActivate: [authGuard],
  children: [
      {
        path: '',
        loadComponent: () =>
          import('./views/list-pedidos-proveedores/list-pedidos-proveedores')
            .then(m => m.ListPedidosProveedores),
      },
      {
        path: 'create',
        loadComponent: () =>
          import('./views/create-pedidos-proveedores/create-pedidos-proveedores')
            .then(m => m.CreatePedidosProveedoresScreen),
      },
      {
        path: ':id',
        loadComponent: () =>
          import('./views/details-pedidos-proveedores/details-pedidos-proveedores')
            .then(m => m.DetailsPedidosProveedoresScreen),
      },
      {
        path: ':id/edit',
        loadComponent: () =>
          import('./views/update-pedidos-proveedores/update-pedidos-proveedores')
            .then(m => m.UpdatePedidosProveedoresScreen),
},

  ],
},

  {
    path: 'archivados',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./views/archivados/archivados').then(
        m => m.ArchivadosScreen
      ),
  },
  { path: '', pathMatch: 'full', redirectTo: 'welcome' },
  { path: '**', redirectTo: 'welcome' },
];
