/**
 * Stellt einen nicht erfolgreichen Request an die API dar.
 */
export class ApiError {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   *
   * @param request Der Request, der zum Fehler führte.
   */
  constructor(request: XMLHttpRequest) {
    this.returnCode = request.status;
    this.message = String(request.response);
  }

  /**
   * Der Statuscode der Anfrage.
   */
  public readonly returnCode: number;

  /**
   * Die vom Server empfangene Fehlermeldung.
   */
  public readonly message: string;
}
