/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_TEAM',
			area: 'AWAYTEAM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_team',
				updateFilesTickets: 'UpdateFilesTicketsF_team',
				setFile: 'SetFileF_team'
			}
		})

		/** The primary key. */
		this.ValCodteam = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodteam',
			originId: 'ValCodteam',
			area: 'AWAYTEAM',
			field: 'CODTEAM',
			description: '',
		}).cloneFrom(values?.ValCodteam))
		this.stopWatchers.push(watch(() => this.ValCodteam.value, (newValue, oldValue) => this.onUpdate('awayteam.codteam', this.ValCodteam, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValTeamid = reactive(new modelFieldType.Number({
			id: 'ValTeamid',
			originId: 'ValTeamid',
			area: 'AWAYTEAM',
			field: 'TEAMID',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.TEAM_ID47569),
		}).cloneFrom(values?.ValTeamid))
		this.stopWatchers.push(watch(() => this.ValTeamid.value, (newValue, oldValue) => this.onUpdate('awayteam.teamid', this.ValTeamid, newValue, oldValue)))

		this.ValTeamname = reactive(new modelFieldType.String({
			id: 'ValTeamname',
			originId: 'ValTeamname',
			area: 'AWAYTEAM',
			field: 'TEAMNAME',
			maxLength: 50,
			description: computed(() => this.Resources.TEAM_NAME40736),
		}).cloneFrom(values?.ValTeamname))
		this.stopWatchers.push(watch(() => this.ValTeamname.value, (newValue, oldValue) => this.onUpdate('awayteam.teamname', this.ValTeamname, newValue, oldValue)))

		this.ValCity = reactive(new modelFieldType.String({
			id: 'ValCity',
			originId: 'ValCity',
			area: 'AWAYTEAM',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY35974),
		}).cloneFrom(values?.ValCity))
		this.stopWatchers.push(watch(() => this.ValCity.value, (newValue, oldValue) => this.onUpdate('awayteam.city', this.ValCity, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFTeamViewModel instance.
	 * @returns {QFormFTeamViewModel} A new instance of QFormFTeamViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodteam'

	get QPrimaryKey() { return this.ValCodteam.value }
	set QPrimaryKey(value) { this.ValCodteam.updateValue(value) }
}
