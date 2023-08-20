let counter = 0;

/**
 * Stellt Hilfsmethoden zur Erzeugung von IDs bereit.
 */
export const IdService = {
  /**
   * Liefert die nächste sequenzielle ID aus.
   *
   * @returns Die erzeugte ID.
   */
  next(): number {
    return counter++;
  },

  /**
   * Liefert eine neue zufällige ID aus, die
   * ein zufälliger hexadezimaler String ist.
   *
   * Es gibt keine Garantie, dass diese ID einzigartig ist.
   *
   * @returns Die erzeugte ID.
   */
  nextRandom(): string {
    return Math.random().toString(16).substring(2);
  },
} as const;
