import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        const errorList = err.error?.errors;
        const error: string = err.error;
        const status: string = err.status.toString();
        if(err) {
          switch (err.status) {
            case 400:
              if(errorList) {
                const modelStateErrors = [];
                for(const key in errorList) {
                  if(errorList[key]) {
                    modelStateErrors.push(errorList[key])
                  }
                }
                throw modelStateErrors.flat();
              }
              else {
                this.toastr.error(error, status)
              }
              break;
            case 401:
              this.toastr.error('Unauthorized', status);
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              //get the error and store it in the router state
              const navExtras: NavigationExtras = {state: {error: error}};
              //when we navigate to the server error we'll get access to the error inside the navExtras
              this.router.navigateByUrl('/server-error', navExtras);
              break;
            default:
              this.toastr.error('Unknown error');
              console.log(err);
              break;
          }
        }
        throw err;
      })
    );
  }
}
