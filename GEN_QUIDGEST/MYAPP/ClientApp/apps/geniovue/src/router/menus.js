// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/PNL/menu/PNL_131',
			name: 'menu-PNL_131',
			component: () => import('@/views/menus/ModulePNL/MenuPNL_131/QMenuPnl131.vue'),
			meta: {
				routeType: 'menu',
				module: 'PNL',
				order: '131',
				baseArea: 'PLAYERS',
				hasInitialPHE: false,
				humanKeyFields: ['ValPlayerid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PNL/menu/PNL_151',
			name: 'menu-PNL_151',
			component: () => import('@/views/menus/ModulePNL/MenuPNL_151/QMenuPnl151.vue'),
			meta: {
				routeType: 'menu',
				module: 'PNL',
				order: '151',
				baseArea: 'GOALS',
				hasInitialPHE: false,
				humanKeyFields: ['ValGoalsid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PNL/menu/PNL_111',
			name: 'menu-PNL_111',
			component: () => import('@/views/menus/ModulePNL/MenuPNL_111/QMenuPnl111.vue'),
			meta: {
				routeType: 'menu',
				module: 'PNL',
				order: '111',
				baseArea: 'AWAYTEAM',
				hasInitialPHE: false,
				humanKeyFields: ['ValTeamid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PNL/menu/PNL_141',
			name: 'menu-PNL_141',
			component: () => import('@/views/menus/ModulePNL/MenuPNL_141/QMenuPnl141.vue'),
			meta: {
				routeType: 'menu',
				module: 'PNL',
				order: '141',
				baseArea: 'REFEREES',
				hasInitialPHE: false,
				humanKeyFields: ['ValAge'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PNL/menu/PNL_121',
			name: 'menu-PNL_121',
			component: () => import('@/views/menus/ModulePNL/MenuPNL_121/QMenuPnl121.vue'),
			meta: {
				routeType: 'menu',
				module: 'PNL',
				order: '121',
				baseArea: 'MATCHES',
				hasInitialPHE: false,
				humanKeyFields: ['ValMatchid'],
				isPopup: false
			}
		},
	]
}
