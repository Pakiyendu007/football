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
			name: 'F_GOALS',
			area: 'GOALS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_goals',
				updateFilesTickets: 'UpdateFilesTicketsF_goals',
				setFile: 'SetFileF_goals'
			}
		})

		/** The primary key. */
		this.ValCodgoals = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgoals',
			originId: 'ValCodgoals',
			area: 'GOALS',
			field: 'CODGOALS',
			description: '',
		}).cloneFrom(values?.ValCodgoals))
		this.stopWatchers.push(watch(() => this.ValCodgoals.value, (newValue, oldValue) => this.onUpdate('goals.codgoals', this.ValCodgoals, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValMatchid = reactive(new modelFieldType.ForeignKey({
			id: 'ValMatchid',
			originId: 'ValMatchid',
			area: 'GOALS',
			field: 'MATCHID',
			relatedArea: 'MATCHES',
			description: computed(() => this.Resources.MATCHID28731),
		}).cloneFrom(values?.ValMatchid))
		this.stopWatchers.push(watch(() => this.ValMatchid.value, (newValue, oldValue) => this.onUpdate('goals.matchid', this.ValMatchid, newValue, oldValue)))

		this.ValPlayerid = reactive(new modelFieldType.ForeignKey({
			id: 'ValPlayerid',
			originId: 'ValPlayerid',
			area: 'GOALS',
			field: 'PLAYERID',
			relatedArea: 'PLAYERS',
			description: computed(() => this.Resources.PLAYER_ID62777),
		}).cloneFrom(values?.ValPlayerid))
		this.stopWatchers.push(watch(() => this.ValPlayerid.value, (newValue, oldValue) => this.onUpdate('goals.playerid', this.ValPlayerid, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValGoalsid = reactive(new modelFieldType.Number({
			id: 'ValGoalsid',
			originId: 'ValGoalsid',
			area: 'GOALS',
			field: 'GOALSID',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.GOALS_ID25685),
		}).cloneFrom(values?.ValGoalsid))
		this.stopWatchers.push(watch(() => this.ValGoalsid.value, (newValue, oldValue) => this.onUpdate('goals.goalsid', this.ValGoalsid, newValue, oldValue)))

		this.TableMatchesMatchid = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableMatchesMatchid',
			originId: 'ValMatchid',
			area: 'MATCHES',
			field: 'MATCHID',
			maxDigits: 8,
			decimalDigits: 0,
			description: computed(() => this.Resources.MATCH_ID16862),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableMatchesMatchid))
		this.stopWatchers.push(watch(() => this.TableMatchesMatchid.value, (newValue, oldValue) => this.onUpdate('matches.matchid', this.TableMatchesMatchid, newValue, oldValue)))

		this.TablePlayersPlayerid = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TablePlayersPlayerid',
			originId: 'ValPlayerid',
			area: 'PLAYERS',
			field: 'PLAYERID',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.PLAYER_ID62777),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePlayersPlayerid))
		this.stopWatchers.push(watch(() => this.TablePlayersPlayerid.value, (newValue, oldValue) => this.onUpdate('players.playerid', this.TablePlayersPlayerid, newValue, oldValue)))

		this.ValMinute = reactive(new modelFieldType.Number({
			id: 'ValMinute',
			originId: 'ValMinute',
			area: 'GOALS',
			field: 'MINUTE',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.MINUTE14222),
		}).cloneFrom(values?.ValMinute))
		this.stopWatchers.push(watch(() => this.ValMinute.value, (newValue, oldValue) => this.onUpdate('goals.minute', this.ValMinute, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFGoalsViewModel instance.
	 * @returns {QFormFGoalsViewModel} A new instance of QFormFGoalsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgoals'

	get QPrimaryKey() { return this.ValCodgoals.value }
	set QPrimaryKey(value) { this.ValCodgoals.updateValue(value) }
}
