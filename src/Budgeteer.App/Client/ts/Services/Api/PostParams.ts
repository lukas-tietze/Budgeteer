import { ModelCtor } from './ModelCtor';
import { QueryParams } from './QueryParams';

export type PostParams<TModel extends object> = {
  ctor: ModelCtor<TModel>;
  url: string | unknown[];
  query?: QueryParams;
} & ({ body: object; form?: never } | { body?: never; form: FormData });
