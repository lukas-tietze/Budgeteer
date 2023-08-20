/**
 * Stellt ein Element eines Dropdowns dar.
 *
 * @template T Der Typ der dargestellten Werte.
 */
export interface SelectItem<T = unknown> {
  /**
   * Der darzustellende Text.
   */
  text: string;

  /**
   * Der Wert des Elements.
   */
  value: T;
}
