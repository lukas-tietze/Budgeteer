import { AuthService } from '../Services/AuthService.ts';
import { di } from '../Services/Di.ts';

export const AuthGuard: NavigationGuard = () => (di(AuthService).isLoggedIn ? true : '/auth/login');
