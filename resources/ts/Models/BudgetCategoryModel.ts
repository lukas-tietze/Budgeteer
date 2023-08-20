import { ModelBase } from './ModelBase';

/**
 * Stellt eine Kategorie für Budgets dar.
 */
export class BudgetCategoryModel extends ModelBase {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   */
  constructor(copy?: Partial<BudgetCategoryModel>) {
    super(copy);

    this.parentId = copy?.parentId ?? 0;
  }

  /**
   * Die ID der übergeordneten Kategorie.
   */
  public parentId: number;
}
