type ModelCtor<T> = new (copy?: Partial<T>) => T;

export type RequestParams<TModel extends object>
{
  ctor: ModelCtor<TModel>,
  url: string,
  body: object,
};

export const Api = {
  request<TModel extends object>(params: RequestParams<TModel>): Promise<TModel> {
    const request = new XmlHttpRequest();
  },
} as const;
