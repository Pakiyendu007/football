using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Goals
{
	public class F_goals_ViewModel : FormViewModel<Models.Goals>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "match id" | Type: "CE"
		/// </summary>
		public string ValMatchid { get; set; }
		/// <summary>
		/// Title: "player id" | Type: "CE"
		/// </summary>
		public string ValPlayerid { get; set; }

		#endregion
		/// <summary>
		/// Title: "goals id" | Type: "N"
		/// </summary>
		public decimal? ValGoalsid { get; set; }
		/// <summary>
		/// Title: "match id" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Matches> TableMatchesMatchid { get; set; }
		/// <summary>
		/// Title: "player id" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Players> TablePlayersPlayerid { get; set; }
		/// <summary>
		/// Title: "minute" | Type: "N"
		/// </summary>
		public decimal? ValMinute { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodgoals { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_goals_ViewModel() : base(null!) { }

		public F_goals_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_GOALS", nestedForm) { }

		public F_goals_ViewModel(UserContext userContext, Models.Goals row, bool nestedForm = false) : base(userContext, "FF_GOALS", row, nestedForm) { }

		public F_goals_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("goals", id);
			Model = Models.Goals.Find(id, userContext, "FF_GOALS", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Goals model = new Models.Goals(userContext) { Identifier = "FF_GOALS" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_GOALS");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Goals m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Goals) to ViewModel (F_goals) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValMatchid = ViewModelConversion.ToString(m.ValMatchid);
				ValPlayerid = ViewModelConversion.ToString(m.ValPlayerid);
				ValGoalsid = ViewModelConversion.ToNumeric(m.ValGoalsid);
				ValMinute = ViewModelConversion.ToNumeric(m.ValMinute);
				ValCodgoals = ViewModelConversion.ToString(m.ValCodgoals);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Goals) to ViewModel (F_goals) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Goals m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_goals) to Model (Goals) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValMatchid = ViewModelConversion.ToString(ValMatchid);
				m.ValPlayerid = ViewModelConversion.ToString(ValPlayerid);
				m.ValGoalsid = ViewModelConversion.ToNumeric(ValGoalsid);
				m.ValMinute = ViewModelConversion.ToNumeric(ValMinute);
				m.ValCodgoals = ViewModelConversion.ToString(ValCodgoals);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_goals) to Model (Goals) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "goals.matchid":
						this.ValMatchid = ViewModelConversion.ToString(_value);
						break;
					case "goals.playerid":
						this.ValPlayerid = ViewModelConversion.ToString(_value);
						break;
					case "goals.goalsid":
						this.ValGoalsid = ViewModelConversion.ToNumeric(_value);
						break;
					case "goals.minute":
						this.ValMinute = ViewModelConversion.ToNumeric(_value);
						break;
					case "goals.codgoals":
						this.ValCodgoals = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_goals) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_goals)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Goals.Find(id ?? Navigation.GetStrValue("goals"), m_userContext, "FF_GOALS"); }
			finally { Model ??= new Models.Goals(m_userContext) { Identifier = "FF_GOALS" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Goals.Find(Navigation.GetStrValue("goals"), m_userContext, "FF_GOALS");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FF_GOALS";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Goals row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Goals.Find(Navigation.GetStrValue("goals"), m_userContext, "FF_GOALS");
				if (Model == null)
				{
					Model = new Models.Goals(m_userContext) { Identifier = "FF_GOALS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("goals");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_goals__matches__matchid(qs, lazyLoad);
			Load_F_goals__players__playerid(qs, lazyLoad);

// USE /[MANUAL PNL VIEWMODEL_LOADPARTIAL F_GOALS]/
		}

// USE /[MANUAL PNL VIEWMODEL_NEW F_GOALS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL PNL VIEWMODEL_SAVE F_GOALS]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PNL VIEWMODEL_APPLY F_GOALS]/

// USE /[MANUAL PNL VIEWMODEL_DUPLICATE F_GOALS]/

// USE /[MANUAL PNL VIEWMODEL_DESTROY F_GOALS]/
		public override void Destroy(string id)
		{
			Model = Models.Goals.Find(id, m_userContext, "FF_GOALS");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableMatchesMatchid -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_goals__matches__matchid(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_goals__matches__matchidDoLoad = true;
			CriteriaSet f_goals__matches__matchidConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("matches", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_goals__matches__matchidConds.Equal(CSGenioAmatches.FldCodmatches, hValue);
					this.ValMatchid = DBConversion.ToString(hValue);
				}
			}

			TableMatchesMatchid = new TableDBEdit<Models.Matches>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_matches") != null)
				{
					this.ValMatchid = Navigation.GetStrValue("RETURN_matches");
					Navigation.CurrentLevel.SetEntry("RETURN_matches", null);
				}
				FillDependant_F_goalsTableMatchesMatchid(lazyLoad);
				return;
			}

			if (f_goals__matches__matchidDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableMatchesMatchid, "sTableMatchesMatchid", "dTableMatchesMatchid", qs, "matches");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableMatchesMatchid_tableFilters"]))
					TableMatchesMatchid.TableFilters = bool.Parse(qs["TableMatchesMatchid_tableFilters"]);
				else
					TableMatchesMatchid.TableFilters = false;

				query = qs["qTableMatchesMatchid"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAmatches.FldMatchid, query + "%");
				}
				f_goals__matches__matchidConds.SubSet(search_filters);

				string tryParsePage = qs["pTableMatchesMatchid"] != null ? qs["pTableMatchesMatchid"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAmatches.FldCodmatches, CSGenioAmatches.FldMatchid, CSGenioAmatches.FldZzstate];

// USE /[MANUAL PNL OVERRQ F_GOALS_MATCHESMATCHID]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("matches", FormMode.New) || Navigation.checkFormMode("matches", FormMode.Duplicate))
					f_goals__matches__matchidConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmatches.FldZzstate, 0)
						.Equal(CSGenioAmatches.FldCodmatches, Navigation.GetStrValue("matches")));
				else
					f_goals__matches__matchidConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmatches.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("matches", "matchid");
				ListingMVC<CSGenioAmatches> listing = Models.ModelBase.Where<CSGenioAmatches>(m_userContext, false, f_goals__matches__matchidConds, fields, offset, numberItems, sorts, "LED_F_GOALS__MATCHES__MATCHID", true, false, firstVisibleColumn: firstVisibleColumn);

				TableMatchesMatchid.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableMatchesMatchid.Query = query;
				TableMatchesMatchid.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Matches(m_userContext, r, true, _fieldsToSerialize_F_GOALS__MATCHES__MATCHID));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_matches") != null)
				{
					this.ValMatchid = Navigation.GetStrValue("RETURN_matches");
					Navigation.CurrentLevel.SetEntry("RETURN_matches", null);
				}

				TableMatchesMatchid.List = new SelectList(TableMatchesMatchid.Elements.ToSelectList(x => x.ValMatchid, x => x.ValCodmatches,  x => x.ValCodmatches == this.ValMatchid), "Value", "Text", this.ValMatchid);
				FillDependant_F_goalsTableMatchesMatchid();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableMatchesMatchid (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Matches</param>
		public ConcurrentDictionary<string, object> GetDependant_F_goalsTableMatchesMatchid(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAmatches.FldCodmatches, CSGenioAmatches.FldMatchid];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAmatches tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAmatches.FldCodmatches, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableMatchesMatchid (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_goalsTableMatchesMatchid(bool lazyLoad = false)
		{
			var row = GetDependant_F_goalsTableMatchesMatchid(this.ValMatchid);
			try
			{

				// Fill List fields
				this.ValMatchid = ViewModelConversion.ToString(row["matches.codmatches"]);
				TableMatchesMatchid.Value = (decimal?)row["matches.matchid"];
				if (GenFunctions.emptyG(this.ValMatchid) == 1)
				{
					this.ValMatchid = "";
					TableMatchesMatchid.Value = 0m;
					Navigation.ClearValue("matches");
				}
				else if (lazyLoad)
				{
					TableMatchesMatchid.SetPagination(1, 0, false, false, 1);
					TableMatchesMatchid.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValMatchid),
							Text = Convert.ToString(TableMatchesMatchid.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValMatchid);
				}

				TableMatchesMatchid.Selected = this.ValMatchid;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableMatchesMatchid): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_GOALS__MATCHES__MATCHID = ["Matches", "Matches.ValCodmatches", "Matches.ValZzstate", "Matches.ValMatchid"];

		/// <summary>
		/// TablePlayersPlayerid -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_goals__players__playerid(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_goals__players__playeridDoLoad = true;
			CriteriaSet f_goals__players__playeridConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("players", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_goals__players__playeridConds.Equal(CSGenioAplayers.FldCodplayers, hValue);
					this.ValPlayerid = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			f_goals__players__playeridDoLoad &= AddCriteriaAreaLimit(f_goals__players__playeridConds, CSGenio.business.CSGenioAmatches.FldCodmatches, "matches", this.ValMatchid, true);

			TablePlayersPlayerid = new TableDBEdit<Models.Players>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_players") != null)
				{
					this.ValPlayerid = Navigation.GetStrValue("RETURN_players");
					Navigation.CurrentLevel.SetEntry("RETURN_players", null);
				}
				FillDependant_F_goalsTablePlayersPlayerid(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValMatchid))
				f_goals__players__playeridDoLoad = false;

			if (f_goals__players__playeridDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePlayersPlayerid, "sTablePlayersPlayerid", "dTablePlayersPlayerid", qs, "players");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePlayersPlayerid_tableFilters"]))
					TablePlayersPlayerid.TableFilters = bool.Parse(qs["TablePlayersPlayerid_tableFilters"]);
				else
					TablePlayersPlayerid.TableFilters = false;

				query = qs["qTablePlayersPlayerid"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAplayers.FldPlayerid, query + "%");
				}
				f_goals__players__playeridConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePlayersPlayerid"] != null ? qs["pTablePlayersPlayerid"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAplayers.FldCodplayers, CSGenioAplayers.FldPlayerid, CSGenioAplayers.FldZzstate];

// USE /[MANUAL PNL OVERRQ F_GOALS_PLAYERSPLAYERID]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("players", FormMode.New) || Navigation.checkFormMode("players", FormMode.Duplicate))
					f_goals__players__playeridConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAplayers.FldZzstate, 0)
						.Equal(CSGenioAplayers.FldCodplayers, Navigation.GetStrValue("players")));
				else
					f_goals__players__playeridConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAplayers.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("players", "playerid");
				ListingMVC<CSGenioAplayers> listing = Models.ModelBase.Where<CSGenioAplayers>(m_userContext, false, f_goals__players__playeridConds, fields, offset, numberItems, sorts, "LED_F_GOALS__PLAYERS__PLAYERID", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePlayersPlayerid.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePlayersPlayerid.Query = query;
				TablePlayersPlayerid.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Players(m_userContext, r, true, _fieldsToSerialize_F_GOALS__PLAYERS__PLAYERID));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_players") != null)
				{
					this.ValPlayerid = Navigation.GetStrValue("RETURN_players");
					Navigation.CurrentLevel.SetEntry("RETURN_players", null);
				}

				TablePlayersPlayerid.List = new SelectList(TablePlayersPlayerid.Elements.ToSelectList(x => x.ValPlayerid, x => x.ValCodplayers,  x => x.ValCodplayers == this.ValPlayerid), "Value", "Text", this.ValPlayerid);
				FillDependant_F_goalsTablePlayersPlayerid();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePlayersPlayerid (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Players</param>
		public ConcurrentDictionary<string, object> GetDependant_F_goalsTablePlayersPlayerid(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAplayers.FldCodplayers, CSGenioAplayers.FldPlayerid];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("matches");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAplayers.FldTeamid, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAplayers tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAplayers.FldCodplayers, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePlayersPlayerid (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_goalsTablePlayersPlayerid(bool lazyLoad = false)
		{
			var row = GetDependant_F_goalsTablePlayersPlayerid(this.ValPlayerid);
			try
			{

				// Fill List fields
				this.ValPlayerid = ViewModelConversion.ToString(row["players.codplayers"]);
				TablePlayersPlayerid.Value = (decimal?)row["players.playerid"];
				if (GenFunctions.emptyG(this.ValPlayerid) == 1)
				{
					this.ValPlayerid = "";
					TablePlayersPlayerid.Value = 0m;
					Navigation.ClearValue("players");
				}
				else if (lazyLoad)
				{
					TablePlayersPlayerid.SetPagination(1, 0, false, false, 1);
					TablePlayersPlayerid.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValPlayerid),
							Text = Convert.ToString(TablePlayersPlayerid.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValPlayerid);
				}

				TablePlayersPlayerid.Selected = this.ValPlayerid;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePlayersPlayerid): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_GOALS__PLAYERS__PLAYERID = ["Players", "Players.ValCodplayers", "Players.ValZzstate", "Players.ValPlayerid"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"goals.matchid" => ViewModelConversion.ToString(modelValue),
				"goals.playerid" => ViewModelConversion.ToString(modelValue),
				"goals.goalsid" => ViewModelConversion.ToNumeric(modelValue),
				"goals.minute" => ViewModelConversion.ToNumeric(modelValue),
				"goals.codgoals" => ViewModelConversion.ToString(modelValue),
				"matches.codmatches" => ViewModelConversion.ToString(modelValue),
				"matches.matchid" => ViewModelConversion.ToNumeric(modelValue),
				"players.codplayers" => ViewModelConversion.ToString(modelValue),
				"players.playerid" => ViewModelConversion.ToNumeric(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PNL VIEWMODEL_CUSTOM F_GOALS]/

		#endregion
	}
}
