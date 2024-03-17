import { build } from 'vite';

import { ApiError } from '../ApiError';
import { ApiProps } from '../ApiProps';
import { inject } from '../Di';
import { GetParams } from './GetParams';
import { ModelCtor } from './ModelCtor';
import { PostParams } from './PostParams';
import { QueryParams } from './QueryParams';
import { RequestParams } from './RequestParams';
import { RestEditResultModel } from './RestEditResultModel';

const apiRoot = document.baseURI + 'api';

/**
 * Ermöglicht Zugriffe auf die API.
 */
export class Api {
  /**
   * Enthält die vom Server gelieferten Einstellungen der API.
   */
  private props: ApiProps;

  /**
   * Initialisiert ein neue Instanz der Klasse.k
   */
  constructor() {
    this.props = inject(ApiProps);
  }

  public post(url: string | unknown[], body: object | FormData): Promise<RestEditResultModel>;
  public post<TModel extends object>(url: string | unknown[], body: object | FormData, ctor: ModelCtor<TModel>): Promise<TModel>;
  public post<TModel extends object>(params: PostParams<TModel>): Promise<TModel>;
  public async post<TModel extends object>(
    arg1: PostParams<TModel> | string | unknown[],
    arg2?: object | FormData,
    arg3?: ModelCtor<TModel>
  ): Promise<TModel | RestEditResultModel> {
    if (typeof arg1 === 'object' && !Array.isArray(arg1)) {
      return await this.request({
        method: 'POST',
        ctor: arg1.ctor,
        url: this.buildUrl(arg1.url, arg1.query),
        body: arg1.body ?? arg1.form,
      });
    }

    if (arg3) {
      return await this.request({
        method: 'POST',
        ctor: arg3,
        url: this.buildUrl(arg1),
        body: arg2,
      });
    }

    return await this.request({
      method: 'POST',
      ctor: RestEditResultModel,
      url: this.buildUrl(arg1),
      body: arg2,
    });
  }

  public get<TModel extends object>(ctor: ModelCtor<TModel>, url: string | unknown[]): Promise<TModel>;
  public get<TModel extends object>(params: GetParams<TModel>): Promise<TModel>;

  public async get<TModel extends object>(arg1: GetParams<TModel> | ModelCtor<TModel>, arg2?: string | unknown[]): Promise<TModel> {
    if (typeof arg1 !== 'object') {
      return await this.request({
        method: 'GET',
        ctor: arg1,
        url: this.buildUrl(arg2!, undefined),
      });
    }

    return await this.request({
      method: 'GET',
      ctor: arg1.ctor,
      url: this.buildUrl(arg1.url, arg1.query),
    });
  }

  /**
   * Sendet einen Request an die API.
   *
   * @param params Die Aufrufparameter.
   */
  public request<TModel extends object>(params: RequestParams<TModel>): Promise<TModel> {
    return new Promise((resolve, reject) => {
      const request = new XMLHttpRequest();

      request.open(params.method, this.trimSlashes(this.props.apiUrl) + '/' + this.trimSlashes(params.url));
      request.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');

      request.onload = () => {
        if (request.readyState == XMLHttpRequest.DONE) {
          if (request.status === 200) {
            resolve(JSON.parse(request.response));
          } else {
            reject(new ApiError(request));
          }
        }
      };

      request.onerror = request.onabort = () => {
        reject(new ApiError(request));
      };

      if (params.body) {
        request.send(JSON.stringify(params.body));
      } else {
        request.send();
      }
    });
  }

  /**
   * Baut eine URl zusammen.
   *
   * @param path Der Pfad der angefragten Ressource, relativ zur API-URL.
   * @param query Die Query-Parameter.
   * @returns Die erzeugte URL.
   */
  private buildUrl(path: string | unknown[], query?: QueryParams): string {
    let url = '';

    if (typeof path === 'string') {
      url = path;
    } else {
      url += '/' + path.map((p) => this.trimSlashes(String(p))).join('/');
    }

    if (query) {
      let p = new URLSearchParams();

      for (const [key, values] of Object.entries(query)) {
        if (Array.isArray(values)) {
          for (const value of values) {
            p.append(key, String(value));
          }
        } else {
          p.append(key, String(values));
        }
      }

      url += '?' + p.toString();
    }

    return url;
  }

  /**
   * Entfernt führend und schließende `/`-Zeichen.
   *
   * @param arg Der zu bereinigende String.
   * @returns den bereinigten String.
   */
  private trimSlashes(arg: string): string {
    while (arg.startsWith('/')) {
      arg = arg.substring(1);
    }

    while (arg.endsWith('/')) {
      arg = arg.substring(0, arg.length - 1);
    }

    return arg;
  }
}
