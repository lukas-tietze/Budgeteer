import { InternationalizationHelper } from '../../i18n/InternationalizationHelper';
import { inject } from '../../Services/Di';

export function Replace(
  oldValue: string,
  replaceValue: string,
  replaceStart: number,
  replaceEnd: number,
  format: (val: number) => string
): {
  newValue: string;
  newCursorPos: number;
} {
  let newValue = oldValue;
  let newCursorPos = replaceStart;

  return { newValue, newCursorPos };
}
