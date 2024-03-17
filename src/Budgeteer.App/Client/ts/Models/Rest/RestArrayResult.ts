import { QueryRange } from './QueryRange';

// TODO: Doku

export class RestArrayResult<T = object> {
  constructor(copy?: Partial<RestArrayResult<T>>) {
    this.pagination = copy?.pagination ? new QueryRange(copy.pagination) : undefined;
    this.values = copy?.values ?? [];
  }

  public pagination: QueryRange | undefined;

  public values: T[];

  public revive(elementCtor: new (copy?: Partial<T>) => T): void {
    for (let i = 0; i < this.values.length; i++) {
      this.values[i] = new elementCtor(this.values[i]);
    }
  }
}
