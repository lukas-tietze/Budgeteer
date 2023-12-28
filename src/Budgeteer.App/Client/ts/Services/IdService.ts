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
  }
} as const;
