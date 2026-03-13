<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="F_MATCHES"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.F_MATCHES__MATCHES__MATCHID.isVisible || controls.F_MATCHES__AWAYTEAM__TEAMID.isVisible || controls.F_MATCHES__MATCHES__MATCHDATE.isVisible || controls.F_MATCHES__MATCHES__HOMEGOALS.isVisible || controls.F_MATCHES__MATCHES__AWAYGOALS.isVisible || controls.F_MATCHES__TEAM__TEAMID.isVisible">
					<q-col
						v-if="controls.F_MATCHES__MATCHES__MATCHID.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__MATCHES__MATCHID.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__MATCHES__MATCHID"
							v-on="controls.F_MATCHES__MATCHES__MATCHID.handlers"
							:loading="controls.F_MATCHES__MATCHES__MATCHID.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.F_MATCHES__MATCHES__MATCHID.isVisible"
								v-bind="controls.F_MATCHES__MATCHES__MATCHID.props"
								@update:model-value="model.ValMatchid.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_MATCHES__AWAYTEAM__TEAMID.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__AWAYTEAM__TEAMID.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__AWAYTEAM__TEAMID"
							v-on="controls.F_MATCHES__AWAYTEAM__TEAMID.handlers"
							:loading="controls.F_MATCHES__AWAYTEAM__TEAMID.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.F_MATCHES__AWAYTEAM__TEAMID.isVisible"
								v-bind="controls.F_MATCHES__AWAYTEAM__TEAMID.props"
								v-on="controls.F_MATCHES__AWAYTEAM__TEAMID.handlers" />
							<q-see-more-f-matches-awayteam-teamid
								v-if="controls.F_MATCHES__AWAYTEAM__TEAMID.seeMoreIsVisible"
								v-bind="controls.F_MATCHES__AWAYTEAM__TEAMID.seeMoreParams"
								v-on="controls.F_MATCHES__AWAYTEAM__TEAMID.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_MATCHES__MATCHES__MATCHDATE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__MATCHES__MATCHDATE.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__MATCHES__MATCHDATE"
							v-on="controls.F_MATCHES__MATCHES__MATCHDATE.handlers"
							:loading="controls.F_MATCHES__MATCHES__MATCHDATE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.F_MATCHES__MATCHES__MATCHDATE.isVisible"
								v-bind="controls.F_MATCHES__MATCHES__MATCHDATE.props"
								:model-value="model.ValMatchdate.value"
								@reset-icon-click="model.ValMatchdate.fnUpdateValue(model.ValMatchdate.originalValue ?? new Date())"
								@update:model-value="model.ValMatchdate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_MATCHES__MATCHES__HOMEGOALS.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__MATCHES__HOMEGOALS.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__MATCHES__HOMEGOALS"
							v-on="controls.F_MATCHES__MATCHES__HOMEGOALS.handlers"
							:loading="controls.F_MATCHES__MATCHES__HOMEGOALS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.F_MATCHES__MATCHES__HOMEGOALS.isVisible"
								v-bind="controls.F_MATCHES__MATCHES__HOMEGOALS.props"
								@update:model-value="model.ValHomegoals.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_MATCHES__MATCHES__AWAYGOALS.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__MATCHES__AWAYGOALS.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__MATCHES__AWAYGOALS"
							v-on="controls.F_MATCHES__MATCHES__AWAYGOALS.handlers"
							:loading="controls.F_MATCHES__MATCHES__AWAYGOALS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.F_MATCHES__MATCHES__AWAYGOALS.isVisible"
								v-bind="controls.F_MATCHES__MATCHES__AWAYGOALS.props"
								@update:model-value="model.ValAwaygoals.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_MATCHES__TEAM__TEAMID.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_MATCHES__TEAM__TEAMID.isVisible"
							class="i-text"
							v-bind="controls.F_MATCHES__TEAM__TEAMID"
							v-on="controls.F_MATCHES__TEAM__TEAMID.handlers"
							:loading="controls.F_MATCHES__TEAM__TEAMID.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.F_MATCHES__TEAM__TEAMID.isVisible"
								v-bind="controls.F_MATCHES__TEAM__TEAMID.props"
								v-on="controls.F_MATCHES__TEAM__TEAMID.handlers" />
							<q-see-more-f-matches-team-teamid
								v-if="controls.F_MATCHES__TEAM__TEAMID.seeMoreIsVisible"
								v-bind="controls.F_MATCHES__TEAM__TEAMID.seeMoreParams"
								v-on="controls.F_MATCHES__TEAM__TEAMID.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormFMatchesViewModel.js'

	const requiredTextResources = ['QFormFMatches', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL FORM_INCLUDEJS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFMatches',

		components: {
			QSeeMoreFMatchesAwayteamTeamid: defineAsyncComponent(() => import('@/views/forms/FormFMatches/dbedits/FMatchesAwayteamTeamidSeeMore.vue')),
			QSeeMoreFMatchesTeamTeamid: defineAsyncComponent(() => import('@/views/forms/FormFMatches/dbedits/FMatchesTeamTeamidSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'F_MATCHES',
					location: 'form-F_MATCHES',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFMatches', false),

				interfaceMetadata: {
					id: 'QFormFMatches', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_MATCHES',
					route: 'form-F_MATCHES',
					area: 'MATCHES',
					primaryKey: 'ValCodmatches',
					designation: computed(() => this.Resources.MATCHES56954),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					F_MATCHES__MATCHES__MATCHID: new fieldControlClass.NumberControl({
						modelField: 'ValMatchid',
						valueChangeEvent: 'fieldChange:matches.matchid',
						id: 'F_MATCHES__MATCHES__MATCHID',
						name: 'MATCHID',
						size: 'small',
						label: computed(() => this.Resources.MATCH_ID16862),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 8,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_MATCHES__AWAYTEAM__TEAMID: new fieldControlClass.LookupControl({
						modelField: 'TableAwayteamTeamid',
						valueChangeEvent: 'fieldChange:awayteam.teamid',
						id: 'F_MATCHES__AWAYTEAM__TEAMID',
						name: 'TEAMID',
						size: 'small',
						label: computed(() => this.Resources.TEAM_ID47569),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValAwayteamid',
							dependencyEvent: 'fieldChange:matches.awayteamid'
						},
						dependentFields: () => ({
							set 'awayteam.codteam'(value) { vm.model.ValAwayteamid.updateValue(value) },
							set 'awayteam.teamid'(value) { vm.model.TableAwayteamTeamid.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_MATCHES__MATCHES__MATCHDATE: new fieldControlClass.DateControl({
						modelField: 'ValMatchdate',
						valueChangeEvent: 'fieldChange:matches.matchdate',
						id: 'F_MATCHES__MATCHES__MATCHDATE',
						name: 'MATCHDATE',
						size: 'small',
						label: computed(() => this.Resources.MATCH_DATE48973),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					F_MATCHES__MATCHES__HOMEGOALS: new fieldControlClass.NumberControl({
						modelField: 'ValHomegoals',
						valueChangeEvent: 'fieldChange:matches.homegoals',
						id: 'F_MATCHES__MATCHES__HOMEGOALS',
						name: 'HOMEGOALS',
						size: 'small',
						label: computed(() => this.Resources.HOME_GOALS11591),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_MATCHES__MATCHES__AWAYGOALS: new fieldControlClass.NumberControl({
						modelField: 'ValAwaygoals',
						valueChangeEvent: 'fieldChange:matches.awaygoals',
						id: 'F_MATCHES__MATCHES__AWAYGOALS',
						name: 'AWAYGOALS',
						size: 'small',
						label: computed(() => this.Resources.AWAY_GOALS14181),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_MATCHES__TEAM__TEAMID: new fieldControlClass.LookupControl({
						modelField: 'TableTeamTeamid',
						valueChangeEvent: 'fieldChange:team.teamid',
						id: 'F_MATCHES__TEAM__TEAMID',
						name: 'TEAMID',
						size: 'small',
						label: computed(() => this.Resources.TEAM_ID47569),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValHometeam',
							dependencyEvent: 'fieldChange:matches.hometeam'
						},
						dependentFields: () => ({
							set 'team.codteam'(value) { vm.model.ValHometeam.updateValue(value) },
							set 'team.teamid'(value) { vm.model.TableTeamTeamid.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Awayteam: {
						get ValTeamid() { return vm.model.TableAwayteamTeamid.value },
						set ValTeamid(value) { vm.model.TableAwayteamTeamid.updateValue(value) },
					},
					Matches: {
						get ValAwaygoals() { return vm.model.ValAwaygoals.value },
						set ValAwaygoals(value) { vm.model.ValAwaygoals.updateValue(value) },
						get ValAwayteamid() { return vm.model.ValAwayteamid.value },
						set ValAwayteamid(value) { vm.model.ValAwayteamid.updateValue(value) },
						get ValHomegoals() { return vm.model.ValHomegoals.value },
						set ValHomegoals(value) { vm.model.ValHomegoals.updateValue(value) },
						get ValHometeam() { return vm.model.ValHometeam.value },
						set ValHometeam(value) { vm.model.ValHometeam.updateValue(value) },
						get ValMatchdate() { return vm.model.ValMatchdate.value },
						set ValMatchdate(value) { vm.model.ValMatchdate.updateValue(value) },
						get ValMatchid() { return vm.model.ValMatchid.value },
						set ValMatchid(value) { vm.model.ValMatchid.updateValue(value) },
					},
					Team: {
						get ValTeamid() { return vm.model.TableTeamTeamid.value },
						set ValTeamid(value) { vm.model.TableTeamTeamid.updateValue(value) },
					},
					keys: {
						/** The primary key of the MATCHES table */
						get matches() { return vm.model.ValCodmatches },
						/** The foreign key to the AWAYTEAM table */
						get awayteam() { return vm.model.ValAwayteamid },
						/** The foreign key to the TEAM table */
						get team() { return vm.model.ValHometeam },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL FORM_CODEJS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL COMPONENT_BEFORE_UNMOUNT F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL BEFORE_LOAD_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL FORM_LOADED_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL BEFORE_APPLY_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL AFTER_APPLY_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL BEFORE_SAVE_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL AFTER_SAVE_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL BEFORE_DEL_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL AFTER_DEL_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL BEFORE_EXIT_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL AFTER_EXIT_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL DLGUPDT F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL CTRLBLR F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL CTRLUPD F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL PNL FUNCTIONS_JS F_MATCHES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
