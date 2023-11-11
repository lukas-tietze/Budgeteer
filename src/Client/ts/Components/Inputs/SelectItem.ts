/**
 * Stellt ein Element eines Dropdowns dar.
 */
export interface SelectItem {
  /**
   * Der darzustellende Text.
   */
  text: string;

  /**
   * Der Wert des Elements.
   */
  value: string | number | boolean;
}
