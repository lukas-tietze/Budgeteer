import { Buttons } from './Buttons/Buttons';
import { Complex } from './Complex/Complex';
import { Inputs } from './Inputs/Inputs';
import NavItemVue from './NavItem.vue';
import TitleVue from './Title.vue';

export const Components = { ...Inputs, ...Buttons, ...Complex, NavItemVue, TitleVue };
