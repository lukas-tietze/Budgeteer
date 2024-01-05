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
    this.code = copy?.code ?? LoginResultCode.SUCCESS;
  }

  /**
   * Der Ergebniscode des Logins.
   */
  public code: LoginResultCode;
}
