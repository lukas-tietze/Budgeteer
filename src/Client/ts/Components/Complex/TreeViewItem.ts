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
   * Der darzustellende Text.
   */
  public text: string;

  /**
   * Der Url-Teil, der die Ressource identifiziert.
   */
  public slug: string;

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
      slug: string;
      text: string;
    }
  ): TreeViewItem[] {
    const byId = new Map<number, TreeViewItem>();
    const res = new Set<TreeViewItem>();

    for (const item of items) {
      const { id, slug, text } = mapper(item);
      const treeViewItem = new TreeViewItem({ slug, text });

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
}
