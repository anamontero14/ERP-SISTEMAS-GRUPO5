import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { clsUsuario } from '../../domain/entities/clsUsuario';
import { getAuth, signInWithEmailAndPassword, signOut, onAuthStateChanged } from 'firebase/auth';
import { firebaseApp } from '../../data/datasource/firebase/FirebaseConfig';
import { Router } from '@angular/router';

const auth = getAuth(firebaseApp);

@Injectable({ providedIn: 'root' })
export class AuthService {
  private usuario$ = new BehaviorSubject<clsUsuario | null>(null);

  constructor(private router: Router) {
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

  async logout(): Promise<void> {
    await signOut(auth);
    this.router.navigate(['/login']);
  }

  getUsuario() {
    return this.usuario$.asObservable();
  }

  isAuthenticated(): boolean {
    return this.usuario$.value !== null;
  }
}
