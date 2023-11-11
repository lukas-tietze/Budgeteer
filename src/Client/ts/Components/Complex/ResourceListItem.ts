/**
 * Stellt ein Element für eine Liste von Ressourcen dar.
 */
export interface ResourceListItem {
  /**
   * Der darzustellende Text.
   */
  readonly text: string;

  /**
   * Der Url-Teil, der die Ressource identifiziert.
   */
  readonly slug: string;
}
