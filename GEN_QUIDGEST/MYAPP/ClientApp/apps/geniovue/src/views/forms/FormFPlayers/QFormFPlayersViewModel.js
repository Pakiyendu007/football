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
			name: 'F_PLAYERS',
			area: 'PLAYERS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_players',
				updateFilesTickets: 'UpdateFilesTicketsF_players',
				setFile: 'SetFileF_players'
			}
		})

		/** The primary key. */
		this.ValCodplayers = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodplayers',
			originId: 'ValCodplayers',
			area: 'PLAYERS',
			field: 'CODPLAYERS',
			description: '',
		}).cloneFrom(values?.ValCodplayers))
		this.stopWatchers.push(watch(() => this.ValCodplayers.value, (newValue, oldValue) => this.onUpdate('players.codplayers', this.ValCodplayers, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValTeamid = reactive(new modelFieldType.ForeignKey({
			id: 'ValTeamid',
			originId: 'ValTeamid',
			area: 'PLAYERS',
			field: 'TEAMID',
			relatedArea: 'MATCHES',
			description: computed(() => this.Resources.TEAM_ID47569),
		}).cloneFrom(values?.ValTeamid))
		this.stopWatchers.push(watch(() => this.ValTeamid.value, (newValue, oldValue) => this.onUpdate('players.teamid', this.ValTeamid, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPosition = reactive(new modelFieldType.String({
			id: 'ValPosition',
			originId: 'ValPosition',
			area: 'PLAYERS',
			field: 'POSITION',
			maxLength: 50,
			description: computed(() => this.Resources.POSITION56645),
		}).cloneFrom(values?.ValPosition))
		this.stopWatchers.push(watch(() => this.ValPosition.value, (newValue, oldValue) => this.onUpdate('players.position', this.ValPosition, newValue, oldValue)))

		this.ValPlayerid = reactive(new modelFieldType.Number({
			id: 'ValPlayerid',
			originId: 'ValPlayerid',
			area: 'PLAYERS',
			field: 'PLAYERID',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.PLAYER_ID62777),
		}).cloneFrom(values?.ValPlayerid))
		this.stopWatchers.push(watch(() => this.ValPlayerid.value, (newValue, oldValue) => this.onUpdate('players.playerid', this.ValPlayerid, newValue, oldValue)))

		this.ValPlayername = reactive(new modelFieldType.String({
			id: 'ValPlayername',
			originId: 'ValPlayername',
			area: 'PLAYERS',
			field: 'PLAYERNAME',
			maxLength: 50,
			description: computed(() => this.Resources.PLAYERNAME24447),
		}).cloneFrom(values?.ValPlayername))
		this.stopWatchers.push(watch(() => this.ValPlayername.value, (newValue, oldValue) => this.onUpdate('players.playername', this.ValPlayername, newValue, oldValue)))

		this.ValAge = reactive(new modelFieldType.Number({
			id: 'ValAge',
			originId: 'ValAge',
			area: 'PLAYERS',
			field: 'AGE',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.AGE26077),
		}).cloneFrom(values?.ValAge))
		this.stopWatchers.push(watch(() => this.ValAge.value, (newValue, oldValue) => this.onUpdate('players.age', this.ValAge, newValue, oldValue)))

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
	}

	/**
	 * Creates a clone of the current QFormFPlayersViewModel instance.
	 * @returns {QFormFPlayersViewModel} A new instance of QFormFPlayersViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplayers'

	get QPrimaryKey() { return this.ValCodplayers.value }
	set QPrimaryKey(value) { this.ValCodplayers.updateValue(value) }
}
