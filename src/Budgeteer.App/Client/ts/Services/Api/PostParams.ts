import { ModelCtor } from './ModelCtor';
import { QueryParams } from './QueryParams';
import { UrlParams } from './UrlParams';

export type PostParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string;
  urlParams?: UrlParams;
  query?: QueryParams;
} & ({ body: object; form?: never; } | { body?: never; form: FormData; });
