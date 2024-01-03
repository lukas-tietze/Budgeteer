import { build } from 'vite';

import { ApiError } from './ApiError';
import { ApiProps } from './ApiProps';
import { inject } from './Di';

type ModelCtor<T> = new (copy?: Partial<T>) => T;

const apiRoot = document.baseURI + 'api';

export type UrlParams = unknown[];
export type QueryParams = Record<string, unknown[] | unknown[]>;

export type RequestParams<TModel extends object> = {
  method: 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE';
  ctor: ModelCtor<TModel>;
  url: string;
  body?: object | FormData;
};

export type GetParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string;
  urlParams?: UrlParams;
  query?: QueryParams;
};

export type PostParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string;
  urlParams?: UrlParams;
  query?: QueryParams;
} & ({ body: object; form?: never } | { body?: never; form: FormData });

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

  public post<TModel extends object>(ctor: ModelCtor<TModel>, url: string, body: object | FormData): Promise<TModel>;
  public post<TModel extends object>(params: PostParams<TModel>): Promise<TModel>;
  public async post<TModel extends object>(
    arg1: PostParams<TModel> | ModelCtor<TModel>,
    arg2?: string,
    arg3?: object | FormData
  ): Promise<TModel> {
    if (typeof arg1 !== 'object') {
      return await this.request({
        method: 'POST',
        ctor: arg1,
        url: this.buildUrl(arg2!),
        body: arg3,
      });
    }

    return await this.request({
      method: 'POST',
      ctor: arg1.ctor,
      url: this.buildUrl(arg1.url, arg1.urlParams, arg1.query),
      body: arg1.body ?? arg1.form,
    });
  }

  public get<TModel extends object>(ctor: ModelCtor<TModel>, url: string, ...urlParams: UrlParams): Promise<TModel>;
  public get<TModel extends object>(params: GetParams<TModel>): Promise<TModel>;

  public async get<TModel extends object>(arg1: GetParams<TModel> | ModelCtor<TModel>, arg2?: string, ...arg3: UrlParams): Promise<TModel> {
    if (typeof arg1 !== 'object') {
      return await this.request({
        method: 'GET',
        ctor: arg1,
        url: this.buildUrl(arg2!, arg3, undefined),
      });
    }

    return await this.request({
      method: 'GET',
      ctor: arg1.ctor,
      url: this.buildUrl(arg1.url, arg1.urlParams, arg1.query),
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

      request.open(params.method, this.props.apiUrl + '/' + params.url);

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
   * @param params Die URL-Parameter.
   * @param query Die Query-Parameter.
   * @returns Die erzeugte URL.
   */
  private buildUrl(path: string, params?: UrlParams, query?: QueryParams): string {
    let url = path;

    if (params) {
      path += '/' + params.map((p) => String(p)).join('/');
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
}
