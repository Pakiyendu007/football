import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/F_GOALS/:mode/:id?',
			name: 'form-F_GOALS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFGoals/QFormFGoals.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GOALS',
				humanKeyFields: ['ValGoalsid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_MATCHES/:mode/:id?',
			name: 'form-F_MATCHES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFMatches/QFormFMatches.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MATCHES',
				humanKeyFields: ['ValMatchid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PLAYERS/:mode/:id?',
			name: 'form-F_PLAYERS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPlayers/QFormFPlayers.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLAYERS',
				humanKeyFields: ['ValPlayerid'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_REFEREES/:mode/:id?',
			name: 'form-F_REFEREES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFReferees/QFormFReferees.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REFEREES',
				humanKeyFields: ['ValAge'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_TEAM/:mode/:id?',
			name: 'form-F_TEAM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFTeam/QFormFTeam.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AWAYTEAM',
				humanKeyFields: ['ValTeamid'],
				isPopup: false
			}
		},
	]
}
