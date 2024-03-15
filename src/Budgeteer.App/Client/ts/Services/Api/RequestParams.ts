import { ModelCtor } from './ModelCtor';

export type RequestParams<TModel extends object> = {
  method: 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE';
  ctor: ModelCtor<TModel>;
  url: string;
  body?: object | FormData;
};
