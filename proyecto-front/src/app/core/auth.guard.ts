/* import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  tokenExists = null;
	constructor(
		//private ls: StorageService,
		private authService: AuthService,
		private router: Router
	) {}

	canActivate(
		route: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	):
		| Observable<boolean | UrlTree>
		| Promise<boolean | UrlTree>
		| boolean
		| UrlTree {
		this.tokenExists = this.ls.getItem('token');
		return this.authService.isLoggedIn.pipe(
      take(1),
			map((loggedIn) => {
				if (!(loggedIn && !!this.tokenExists)) {
					this.router.navigate(['/authentication']);
				}
				return loggedIn && !!this.tokenExists;
			})
		);
	}
  
} */
