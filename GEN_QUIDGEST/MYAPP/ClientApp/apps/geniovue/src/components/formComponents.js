import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFGoals', defineAsyncComponent(() => import('@/views/forms/FormFGoals/QFormFGoals.vue')))
		app.component('QFormFMatches', defineAsyncComponent(() => import('@/views/forms/FormFMatches/QFormFMatches.vue')))
		app.component('QFormFPlayers', defineAsyncComponent(() => import('@/views/forms/FormFPlayers/QFormFPlayers.vue')))
		app.component('QFormFReferees', defineAsyncComponent(() => import('@/views/forms/FormFReferees/QFormFReferees.vue')))
		app.component('QFormFTeam', defineAsyncComponent(() => import('@/views/forms/FormFTeam/QFormFTeam.vue')))
	}
}
