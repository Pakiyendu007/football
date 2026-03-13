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
			name: 'F_REFEREES',
			area: 'REFEREES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_referees',
				updateFilesTickets: 'UpdateFilesTicketsF_referees',
				setFile: 'SetFileF_referees'
			}
		})

		/** The primary key. */
		this.ValCodreferees = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodreferees',
			originId: 'ValCodreferees',
			area: 'REFEREES',
			field: 'CODREFEREES',
			description: '',
		}).cloneFrom(values?.ValCodreferees))
		this.stopWatchers.push(watch(() => this.ValCodreferees.value, (newValue, oldValue) => this.onUpdate('referees.codreferees', this.ValCodreferees, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValRefereeid = reactive(new modelFieldType.Number({
			id: 'ValRefereeid',
			originId: 'ValRefereeid',
			area: 'REFEREES',
			field: 'REFEREEID',
			maxDigits: 8,
			decimalDigits: 0,
			description: computed(() => this.Resources.REFEREE_ID28621),
		}).cloneFrom(values?.ValRefereeid))
		this.stopWatchers.push(watch(() => this.ValRefereeid.value, (newValue, oldValue) => this.onUpdate('referees.refereeid', this.ValRefereeid, newValue, oldValue)))

		this.ValRefereename = reactive(new modelFieldType.String({
			id: 'ValRefereename',
			originId: 'ValRefereename',
			area: 'REFEREES',
			field: 'REFEREENAME',
			maxLength: 50,
			description: computed(() => this.Resources.REFEREE_NAME11471),
		}).cloneFrom(values?.ValRefereename))
		this.stopWatchers.push(watch(() => this.ValRefereename.value, (newValue, oldValue) => this.onUpdate('referees.refereename', this.ValRefereename, newValue, oldValue)))

		this.ValAge = reactive(new modelFieldType.Number({
			id: 'ValAge',
			originId: 'ValAge',
			area: 'REFEREES',
			field: 'AGE',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.AGE26077),
		}).cloneFrom(values?.ValAge))
		this.stopWatchers.push(watch(() => this.ValAge.value, (newValue, oldValue) => this.onUpdate('referees.age', this.ValAge, newValue, oldValue)))

		this.ValNationality = reactive(new modelFieldType.String({
			id: 'ValNationality',
			originId: 'ValNationality',
			area: 'REFEREES',
			field: 'NATIONALITY',
			maxLength: 50,
			description: computed(() => this.Resources.NATIONALITY53539),
		}).cloneFrom(values?.ValNationality))
		this.stopWatchers.push(watch(() => this.ValNationality.value, (newValue, oldValue) => this.onUpdate('referees.nationality', this.ValNationality, newValue, oldValue)))

		this.ValExperienceyears = reactive(new modelFieldType.Number({
			id: 'ValExperienceyears',
			originId: 'ValExperienceyears',
			area: 'REFEREES',
			field: 'EXPERIENCEYEARS',
			maxDigits: 8,
			decimalDigits: 0,
			description: computed(() => this.Resources.EXPERIENCE_YEARS16336),
		}).cloneFrom(values?.ValExperienceyears))
		this.stopWatchers.push(watch(() => this.ValExperienceyears.value, (newValue, oldValue) => this.onUpdate('referees.experienceyears', this.ValExperienceyears, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFRefereesViewModel instance.
	 * @returns {QFormFRefereesViewModel} A new instance of QFormFRefereesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodreferees'

	get QPrimaryKey() { return this.ValCodreferees.value }
	set QPrimaryKey(value) { this.ValCodreferees.updateValue(value) }
}
