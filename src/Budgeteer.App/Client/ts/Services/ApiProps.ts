/**
 * Stellt statische Werte der API bereit, die über die Seite bereitgestellt werden.
 */
export class ApiProps {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor() {
    const src = document.getElementById('ApiProps') as HTMLDivElement;

    this.apiUrl = String(src.dataset.apiUrl);
  }

  /**
   * Die Basis-URL der API.
   */
  public readonly apiUrl: string;
}
