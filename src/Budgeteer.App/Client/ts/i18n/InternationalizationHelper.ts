/**
 * Stellt Daten zur Internationalisierung dar.
 */
export class InternationalizationHelper {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor() {
    const remDigitsRegEx = /[\d]/gi;

    this.thousandsSeparator = (1_000)
      .toLocaleString(undefined, { minimumFractionDigits: 0, maximumFractionDigits: 0 })
      .replaceAll(remDigitsRegEx, '');

    this.decimalSeparator = (1)
      .toLocaleString(undefined, { minimumFractionDigits: 1, maximumFractionDigits: 1 })
      .replaceAll(remDigitsRegEx, '');
  }

  public readonly thousandsSeparator: string;

  public readonly decimalSeparator: string;
}
