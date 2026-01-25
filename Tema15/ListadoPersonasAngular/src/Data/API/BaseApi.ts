import { injectable } from 'inversify';

@injectable()
export class BaseApi {
  private baseUrl = 'https://ui20251201134838-gqgjeaf9bycuf0gn.spaincentral-01.azurewebsites.net/'; 

  public getUrl(endpoint: string): string {
    return `${this.baseUrl}/${endpoint}`;
  }
}