import { Link as LinkVue } from '@inertiajs/vue3';

import AddButtonVue from './AddButton.vue';
import ButtonVue from './Button.vue';
import DeleteButtonVue from './DeleteButton.vue';
import { Inputs } from './Inputs/Inputs';
import NavItemVue from './NavItem.vue';
import TitleVue from './Title.vue';

export const Components = { ...Inputs, LinkVue, AddButtonVue, DeleteButtonVue, ButtonVue, NavItemVue, TitleVue };
