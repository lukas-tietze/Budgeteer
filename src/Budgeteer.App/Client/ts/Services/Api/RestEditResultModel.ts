
////TODO: Doku
export class RestEditResultModel {
  constructor(copy?: Partial<RestEditResultModel>) {
    this.success = copy?.success ?? false;
    this.entityId = copy?.entityId ?? undefined;
    this.errorCode = copy?.errorCode ?? undefined;
  }

  public success: boolean;

  public entityId: number | undefined;

  public errorCode: number | undefined;
}
