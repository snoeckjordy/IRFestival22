import { Injectable } from '@angular/core';
import { Schedule } from '../api/models/schedule.model';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppSettings } from '../api/models/appsettings.model';

@Injectable({
  providedIn: 'root',
})
export class AppSettingsApiService {
  private baseUrl = environment.apiBaseUrl + 'settings';

  constructor(private httpClient: HttpClient) {}

  getSettings(): Observable<AppSettings> {
    const headers = new HttpHeaders().set(
      'Ocp-Apim-Subscription-Key',
      '1bd54acd932e490fbdc1c2f7ab0e7814'
    );
    return this.httpClient.get<AppSettings>(this.baseUrl, { headers: headers });
  }
}
