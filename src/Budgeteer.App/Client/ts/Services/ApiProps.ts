/**
 * Stellt statische Werte der API bereit, die über die Seite bereitgestellt werden.
 */
export class ApiProps {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor() {
    const src = document.getElementById('ApiEnvironment') as HTMLDivElement | undefined;

    if (src) {
      this.apiUrl = String(src?.dataset.apiUrl);

      console.log('Api-Environment geladen: ', this);
    } else {
      this.apiUrl = ';';

      console.warn('Api-Environment konnte nicht geladen werden!');
    }

    if (!this.apiUrl.endsWith('/')) {
      this.apiUrl += '/';
    }
  }

  /**
   * Die Basis-URL der API.
   * Endet immer uaf `/`.
   */
  public readonly apiUrl: string;
}
