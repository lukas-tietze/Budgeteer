import { ModelBase } from '../ModelBase';
import { SelectableParentBudgetModel } from './SelectableParentBudgetModel';

// TODO: Doku

export class BudgetEditModel extends ModelBase {
  constructor(copy?: Partial<BudgetEditModel>) {
    super(copy);

    this.selectableParents = copy?.selectableParents?.map((s) => new SelectableParentBudgetModel(s)) ?? [];
  }

  public selectableParents: SelectableParentBudgetModel[];
}
