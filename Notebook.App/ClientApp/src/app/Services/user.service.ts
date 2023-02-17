import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable, Subject, tap} from "rxjs";
import {User} from "../Models/User";

@Injectable({
  providedIn : "root"
})

export class UserService{

  constructor(private http: HttpClient) {
    }

    httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };


  private _refreshrequired = new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }

  GetUsers() : Observable<User[]>{
    return  this.http.get<User[]>( 'api/users' );
  }

  GetUserById(id : string) : Observable<User>{
    return  this.http.get<User>( 'api/users/' + id  );
  }

  DeleteUserById(id : string) : Observable<User>{
    return  this.http.delete<User>( 'api/users/' + id );
  }

  Save(data : any){
    return this.http.post('api/users', data, this.httpOptions).pipe(
      tap(()=>{
        this.RequiredRefresh.next();
      })
    );
  }
}

