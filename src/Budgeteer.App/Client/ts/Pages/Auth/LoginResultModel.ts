import { LoginResultCode } from './LoginResultCode';

/**
 * Modelliert das Ergebnis eines Login-Prozesses.
 */
export class LoginResultModel {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   *
   * @param copy Die ggf. zu kopierenden Daten.
   */
  constructor(copy?: Partial<LoginResultModel>) {
    this.code = copy?.code ?? LoginResultCode.invalidData;
  }

  /**
   * Statische Instanz, die einen Fehlercode für einen unbekannten Fehler enthält.
   */
  public static readonly Failure = new LoginResultModel({ code: LoginResultCode.invalidData });

  /**
   * Der Ergebniscode des Logins.
   */
  public readonly code: LoginResultCode;
}
