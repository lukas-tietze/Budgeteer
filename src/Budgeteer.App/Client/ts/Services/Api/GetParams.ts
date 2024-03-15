import { ModelCtor } from './ModelCtor';
import { QueryParams } from './QueryParams';
import { UrlParams } from './UrlParams';

export type GetParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string;
  urlParams?: UrlParams;
  query?: QueryParams;
};
