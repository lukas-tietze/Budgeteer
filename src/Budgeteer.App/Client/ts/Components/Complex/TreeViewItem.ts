/**
 * Stellt ein Element das Treeviews dar.
 */
export class TreeViewItem {
  /**
   * Initialisiert eine neue Instanz der Klasse.
   *
   * @param copy Die ggf. zu kopierenden Daten.
   */
  constructor(copy?: Partial<TreeViewItem>) {
    this.text = copy?.text ?? '';
    this.slug = copy?.slug ?? '';
    this.children = copy?.children?.map((c) => new TreeViewItem(c)) ?? [];
  }

  /**
   * Der URL-Teil zum Identifizierende des Eintrags.
   */
  public slug: string;

  /**
   * Der darzustellende Text.
   */
  public text: string;

  /**
   * Die Sammlung der Kind-Elemente.
   */
  public children: TreeViewItem[];

  /**
   * Erzeugt eine Baumstruktur aus einer flachen Liste.
   *
   * @param items Die flache Liste.
   * @param mapper Eine Funktion, die für jeden Eintrag der flachen Liste benötigte Werte abruft.
   * @returns Die Wurzelelemente der erzeugten Baumstruktur.
   */
  public static FromList<T>(
    items: T[],
    mapper: (arg: T) => {
      id: number;
      parentId: number;
      text: string;
    }
  ): TreeViewItem[] {
    const byId = new Map<number, TreeViewItem>();
    const res = new Set<TreeViewItem>();

    for (const item of items) {
      const { id, text } = mapper(item);
      const treeViewItem = new TreeViewItem({ text });

      byId.set(id, treeViewItem);
      res.add(treeViewItem);
    }

    for (const item of items) {
      const { id, parentId } = mapper(item);

      const parent = byId.get(parentId);
      const child = byId.get(id);

      if (parent && child) {
        res.delete(child);
        parent.children.push(child);
      }
    }

    return Array.from(res);
  }

  // TODO: Doku
  static FromTree<T>(values: T[], childGetter: (arg: T) => T[], mapper: (arg: T) => Omit<TreeViewItem, 'children'>): TreeViewItem[] {
    return values.map(
      (v) =>
        new TreeViewItem({
          ...mapper(v),
          children: TreeViewItem.FromTree(childGetter(v), childGetter, mapper),
        })
    );
  }
}
