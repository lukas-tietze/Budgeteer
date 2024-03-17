// TODO: Doku

export class QueryRange {
  constructor(copy?: Partial<QueryRange>) {
    this.start = copy?.start ?? 0;
    this.count = copy?.count ?? 0;
  }

  public readonly start: number;

  public readonly count: number;
}
