import { ModelBase } from '../ModelBase';

/**
 * Stellt ein eingestelltes Budgets dar.
 */
export class ListModel extends ModelBase {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor(copy?: Partial<ListModel>) {
    super(copy);

    this.parentId = copy?.parentId ?? 0;
    this.children = copy?.children?.map((c) => new ListModel(c)) ?? [];
  }

  /**
   * Die ID der übergeordneten Kategorie.
   */
  public parentId: number;

  /**
   * Holt oder setzt die untergeordneten Budgets.
   */
  public children: ListModel[];
}
