/**
 * Stellt das Ergebnis eines Logins dar.
 */
export enum LoginResultCode {
  /**
   * Gibt an, dass der Login erfolgreich war.
   */
  success,

  /**
   * Gibt an, das ungültige Logindaten übergeben wurden.
   */
  invalidData,
}
