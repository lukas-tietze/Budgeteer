import { ModelBase } from './ModelBase';

/**
 * Stellt ein eingestelltes Budgets dar.
 */
export class BudgetModel extends ModelBase {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor(copy?: Partial<BudgetModel>) {
    super(copy);

    this.parentId = copy?.parentId ?? 0;
    this.slug = copy?.slug ?? '';
  }

  /**
   * Die ID der übergeordneten Kategorie.
   */
  public parentId: number;

  /**
   * Der Url-Teil, der die Kategorie eindeutig identifiziert.
   */
  public slug: string;
}
