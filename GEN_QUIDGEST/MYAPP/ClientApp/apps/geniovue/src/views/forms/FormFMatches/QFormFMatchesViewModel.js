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
			name: 'F_MATCHES',
			area: 'MATCHES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_matches',
				updateFilesTickets: 'UpdateFilesTicketsF_matches',
				setFile: 'SetFileF_matches'
			}
		})

		/** The primary key. */
		this.ValCodmatches = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmatches',
			originId: 'ValCodmatches',
			area: 'MATCHES',
			field: 'CODMATCHES',
			description: '',
		}).cloneFrom(values?.ValCodmatches))
		this.stopWatchers.push(watch(() => this.ValCodmatches.value, (newValue, oldValue) => this.onUpdate('matches.codmatches', this.ValCodmatches, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValAwayteamid = reactive(new modelFieldType.ForeignKey({
			id: 'ValAwayteamid',
			originId: 'ValAwayteamid',
			area: 'MATCHES',
			field: 'AWAYTEAMID',
			relatedArea: 'AWAYTEAM',
			description: computed(() => this.Resources.AWAYTEAM_ID17063),
		}).cloneFrom(values?.ValAwayteamid))
		this.stopWatchers.push(watch(() => this.ValAwayteamid.value, (newValue, oldValue) => this.onUpdate('matches.awayteamid', this.ValAwayteamid, newValue, oldValue)))

		this.ValHometeam = reactive(new modelFieldType.ForeignKey({
			id: 'ValHometeam',
			originId: 'ValHometeam',
			area: 'MATCHES',
			field: 'HOMETEAM',
			relatedArea: 'TEAM',
			description: computed(() => this.Resources.HOME_TEAM21446),
		}).cloneFrom(values?.ValHometeam))
		this.stopWatchers.push(watch(() => this.ValHometeam.value, (newValue, oldValue) => this.onUpdate('matches.hometeam', this.ValHometeam, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValMatchid = reactive(new modelFieldType.Number({
			id: 'ValMatchid',
			originId: 'ValMatchid',
			area: 'MATCHES',
			field: 'MATCHID',
			maxDigits: 8,
			decimalDigits: 0,
			description: computed(() => this.Resources.MATCH_ID16862),
		}).cloneFrom(values?.ValMatchid))
		this.stopWatchers.push(watch(() => this.ValMatchid.value, (newValue, oldValue) => this.onUpdate('matches.matchid', this.ValMatchid, newValue, oldValue)))

		this.TableAwayteamTeamid = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableAwayteamTeamid',
			originId: 'ValTeamid',
			area: 'AWAYTEAM',
			field: 'TEAMID',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.TEAM_ID47569),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableAwayteamTeamid))
		this.stopWatchers.push(watch(() => this.TableAwayteamTeamid.value, (newValue, oldValue) => this.onUpdate('awayteam.teamid', this.TableAwayteamTeamid, newValue, oldValue)))

		this.ValMatchdate = reactive(new modelFieldType.Date({
			id: 'ValMatchdate',
			originId: 'ValMatchdate',
			area: 'MATCHES',
			field: 'MATCHDATE',
			description: computed(() => this.Resources.MATCH_DATE48973),
		}).cloneFrom(values?.ValMatchdate))
		this.stopWatchers.push(watch(() => this.ValMatchdate.value, (newValue, oldValue) => this.onUpdate('matches.matchdate', this.ValMatchdate, newValue, oldValue)))

		this.ValHomegoals = reactive(new modelFieldType.Number({
			id: 'ValHomegoals',
			originId: 'ValHomegoals',
			area: 'MATCHES',
			field: 'HOMEGOALS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.HOME_GOALS11591),
		}).cloneFrom(values?.ValHomegoals))
		this.stopWatchers.push(watch(() => this.ValHomegoals.value, (newValue, oldValue) => this.onUpdate('matches.homegoals', this.ValHomegoals, newValue, oldValue)))

		this.ValAwaygoals = reactive(new modelFieldType.Number({
			id: 'ValAwaygoals',
			originId: 'ValAwaygoals',
			area: 'MATCHES',
			field: 'AWAYGOALS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.AWAY_GOALS14181),
		}).cloneFrom(values?.ValAwaygoals))
		this.stopWatchers.push(watch(() => this.ValAwaygoals.value, (newValue, oldValue) => this.onUpdate('matches.awaygoals', this.ValAwaygoals, newValue, oldValue)))

		this.TableTeamTeamid = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableTeamTeamid',
			originId: 'ValTeamid',
			area: 'TEAM',
			field: 'TEAMID',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.TEAM_ID47569),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableTeamTeamid))
		this.stopWatchers.push(watch(() => this.TableTeamTeamid.value, (newValue, oldValue) => this.onUpdate('team.teamid', this.TableTeamTeamid, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFMatchesViewModel instance.
	 * @returns {QFormFMatchesViewModel} A new instance of QFormFMatchesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmatches'

	get QPrimaryKey() { return this.ValCodmatches.value }
	set QPrimaryKey(value) { this.ValCodmatches.updateValue(value) }
}
