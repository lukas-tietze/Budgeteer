type Ctor<T = unknown> = new () => T;
type DiContainer = Map<Ctor, unknown>;
type WindowWithDi = Window & { _di?: DiContainer };

const container = ((window as WindowWithDi)._di ??= new Map());

export function inject<T>(ctor: Ctor<T>): T {
  let service = container.get(ctor);

  if (!service) {
    service = new ctor();

    container.set(ctor, service);
  }

  return service;
}
