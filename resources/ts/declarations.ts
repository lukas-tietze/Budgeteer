/*
 * Mit diesen globalen Deklaration können Typen erweitert werden, z.B. um TypeScript
 * mitzuteilen, dass die Funktion `glob` in `ImportMeta` vorhanden ist. Diese Funktion wird vermutlich von irgendeinem Plugin definiert.
 */

import '@types/ziggy-js/index';

declare global {
    interface ImportMeta {
        glob(g: string): Record<string, Promise<any> | (() => Promise<any>)>;
    }
}

export {};
