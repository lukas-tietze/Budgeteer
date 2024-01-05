import { RegisterResultCode } from './RegisterResultCode';

/**
 * Modelliert das Ergebnis einer Registrierung.
 */
export class RegisterResultModel {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   *
   * @param copy Die ggf. zu kopierenden Daten.
   */
  constructor(copy?: Partial<RegisterResultModel>) {
    this.code = copy?.code ?? RegisterResultCode.SUCCESS;
  }

  /**
   * Der Ergebniscode des Logins.
   */
  public code: RegisterResultCode;
}
