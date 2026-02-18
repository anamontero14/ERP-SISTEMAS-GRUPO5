// auth.service.ts — ÚNICO archivo de autenticación
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { clsUsuario } from '../../domain/entities/clsUsuario';
import { getAuth, signInWithEmailAndPassword, signOut, onAuthStateChanged } from 'firebase/auth';
import { firebaseApp } from '../../data/datasource/firebase/FirebaseConfig';

const auth = getAuth(firebaseApp);

@Injectable({ providedIn: 'root' })
export class AuthService {
  private usuario$ = new BehaviorSubject<clsUsuario | null>(null);

  constructor() {
    onAuthStateChanged(auth, user => {
      if (user) {
        this.usuario$.next(new clsUsuario(0, user.displayName ?? '', user.email ?? ''));
      } else {
        this.usuario$.next(null);
      }
    });
  }

  login(email: string, password: string): Promise<void> {
    return signInWithEmailAndPassword(auth, email, password).then(() => {});
  }

  logout(): Promise<void> {
    return signOut(auth);
  }

  getUsuario() {
    return this.usuario$.asObservable();
  }

  // ← Agrega este método para el guard
  isAuthenticated(): boolean {
    return this.usuario$.value !== null;
  }
}