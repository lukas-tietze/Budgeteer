import { ModelCtor } from './ModelCtor';
import { QueryParams } from './QueryParams';

export type GetParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string | unknown[];
  query?: QueryParams;
};
