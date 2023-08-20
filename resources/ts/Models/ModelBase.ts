/**
 * Stellt die Basisklasse für viele Modell dar.
 */
export class ModelBase {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   *
   * @param copy Die ggf. zu kopierenden Daten.
   */
  constructor(copy?: Partial<ModelBase>) {
    this.name = copy?.name ?? '';
    this.description = copy?.description ?? '';
    this.id = copy?.id ?? 0;
  }

  /**
   * Die ID der Entität.
   */
  public id: number;

  /**
   * Der Name der Kategorie.
   */
  public name: string;

  /**
   * Die Beschreibung der Kategorie.
   */
  public description: string;
}
