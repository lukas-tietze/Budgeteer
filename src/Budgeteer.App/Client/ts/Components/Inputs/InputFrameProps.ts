import { Prop } from 'vue';

export const InputFrameProps = {
  label: {
    type: String,
    default: '',
    required: false,
  } satisfies Prop<string>,
  description: {
    type: String,
    default: '',
    required: false,
  } satisfies Prop<string>,
  required: {
    type: Boolean,
    default: false,
    required: false,
  } satisfies Prop<boolean>,
  id: {
    type: String,
    default: undefined,
    required: false,
  } satisfies Prop<String>,
} as const satisfies Record<string, Prop<unknown>>;
