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

namespace GenioMVC.ViewModels.Matches
{
	public class F_matches_ViewModel : FormViewModel<Models.Matches>, IPreparableForSerialization
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
		/// Title: "team id" | Type: "CE"
		/// </summary>
		public string ValAwayteamid { get; set; }
		/// <summary>
		/// Title: "team id" | Type: "CE"
		/// </summary>
		public string ValHometeam { get; set; }

		#endregion
		/// <summary>
		/// Title: "match id" | Type: "N"
		/// </summary>
		public decimal? ValMatchid { get; set; }
		/// <summary>
		/// Title: "team id" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Awayteam> TableAwayteamTeamid { get; set; }
		/// <summary>
		/// Title: "match date" | Type: "D"
		/// </summary>
		public DateTime? ValMatchdate { get; set; }
		/// <summary>
		/// Title: "home goals" | Type: "N"
		/// </summary>
		public decimal? ValHomegoals { get; set; }
		/// <summary>
		/// Title: "away goals" | Type: "N"
		/// </summary>
		public decimal? ValAwaygoals { get; set; }
		/// <summary>
		/// Title: "team id" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Team> TableTeamTeamid { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodmatches { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_matches_ViewModel() : base(null!) { }

		public F_matches_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_MATCHES", nestedForm) { }

		public F_matches_ViewModel(UserContext userContext, Models.Matches row, bool nestedForm = false) : base(userContext, "FF_MATCHES", row, nestedForm) { }

		public F_matches_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("matches", id);
			Model = Models.Matches.Find(id, userContext, "FF_MATCHES", fieldsToQuery: fieldsToLoad);
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
			Models.Matches model = new Models.Matches(userContext) { Identifier = "FF_MATCHES" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_MATCHES");
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
		public override void MapFromModel(Models.Matches m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Matches) to ViewModel (F_matches) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAwayteamid = ViewModelConversion.ToString(m.ValAwayteamid);
				ValHometeam = ViewModelConversion.ToString(m.ValHometeam);
				ValMatchid = ViewModelConversion.ToNumeric(m.ValMatchid);
				ValMatchdate = ViewModelConversion.ToDateTime(m.ValMatchdate);
				ValHomegoals = ViewModelConversion.ToNumeric(m.ValHomegoals);
				ValAwaygoals = ViewModelConversion.ToNumeric(m.ValAwaygoals);
				ValCodmatches = ViewModelConversion.ToString(m.ValCodmatches);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Matches) to ViewModel (F_matches) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Matches m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_matches) to Model (Matches) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAwayteamid = ViewModelConversion.ToString(ValAwayteamid);
				m.ValHometeam = ViewModelConversion.ToString(ValHometeam);
				m.ValMatchid = ViewModelConversion.ToNumeric(ValMatchid);
				m.ValMatchdate = ViewModelConversion.ToDateTime(ValMatchdate);
				m.ValHomegoals = ViewModelConversion.ToNumeric(ValHomegoals);
				m.ValAwaygoals = ViewModelConversion.ToNumeric(ValAwaygoals);
				m.ValCodmatches = ViewModelConversion.ToString(ValCodmatches);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_matches) to Model (Matches) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "matches.awayteamid":
						this.ValAwayteamid = ViewModelConversion.ToString(_value);
						break;
					case "matches.hometeam":
						this.ValHometeam = ViewModelConversion.ToString(_value);
						break;
					case "matches.matchid":
						this.ValMatchid = ViewModelConversion.ToNumeric(_value);
						break;
					case "matches.matchdate":
						this.ValMatchdate = ViewModelConversion.ToDateTime(_value);
						break;
					case "matches.homegoals":
						this.ValHomegoals = ViewModelConversion.ToNumeric(_value);
						break;
					case "matches.awaygoals":
						this.ValAwaygoals = ViewModelConversion.ToNumeric(_value);
						break;
					case "matches.codmatches":
						this.ValCodmatches = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_matches) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_matches)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Matches.Find(id ?? Navigation.GetStrValue("matches"), m_userContext, "FF_MATCHES"); }
			finally { Model ??= new Models.Matches(m_userContext) { Identifier = "FF_MATCHES" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Matches.Find(Navigation.GetStrValue("matches"), m_userContext, "FF_MATCHES");
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

			Model.Identifier = "FF_MATCHES";
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
		
		protected override void LoadDocumentsProperties(Models.Matches row)
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
				Model = Models.Matches.Find(Navigation.GetStrValue("matches"), m_userContext, "FF_MATCHES");
				if (Model == null)
				{
					Model = new Models.Matches(m_userContext) { Identifier = "FF_MATCHES" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("matches");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_matches__awayteam__teamid(qs, lazyLoad);
			Load_F_matches__team__teamid(qs, lazyLoad);

// USE /[MANUAL PNL VIEWMODEL_LOADPARTIAL F_MATCHES]/
		}

// USE /[MANUAL PNL VIEWMODEL_NEW F_MATCHES]/

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
// USE /[MANUAL PNL VIEWMODEL_SAVE F_MATCHES]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PNL VIEWMODEL_APPLY F_MATCHES]/

// USE /[MANUAL PNL VIEWMODEL_DUPLICATE F_MATCHES]/

// USE /[MANUAL PNL VIEWMODEL_DESTROY F_MATCHES]/
		public override void Destroy(string id)
		{
			Model = Models.Matches.Find(id, m_userContext, "FF_MATCHES");
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
		/// TableAwayteamTeamid -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_matches__awayteam__teamid(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_matches__awayteam__teamidDoLoad = true;
			CriteriaSet f_matches__awayteam__teamidConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("awayteam", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_matches__awayteam__teamidConds.Equal(CSGenioAawayteam.FldCodteam, hValue);
					this.ValAwayteamid = DBConversion.ToString(hValue);
				}
			}

			TableAwayteamTeamid = new TableDBEdit<Models.Awayteam>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_awayteam") != null)
				{
					this.ValAwayteamid = Navigation.GetStrValue("RETURN_awayteam");
					Navigation.CurrentLevel.SetEntry("RETURN_awayteam", null);
				}
				FillDependant_F_matchesTableAwayteamTeamid(lazyLoad);
				return;
			}

			if (f_matches__awayteam__teamidDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableAwayteamTeamid, "sTableAwayteamTeamid", "dTableAwayteamTeamid", qs, "awayteam");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAwayteamTeamid_tableFilters"]))
					TableAwayteamTeamid.TableFilters = bool.Parse(qs["TableAwayteamTeamid_tableFilters"]);
				else
					TableAwayteamTeamid.TableFilters = false;

				query = qs["qTableAwayteamTeamid"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAawayteam.FldTeamid, query + "%");
				}
				f_matches__awayteam__teamidConds.SubSet(search_filters);

				string tryParsePage = qs["pTableAwayteamTeamid"] != null ? qs["pTableAwayteamTeamid"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAawayteam.FldCodteam, CSGenioAawayteam.FldTeamid, CSGenioAawayteam.FldZzstate];

// USE /[MANUAL PNL OVERRQ F_MATCHES_AWAYTEAMTEAMID]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("awayteam", FormMode.New) || Navigation.checkFormMode("awayteam", FormMode.Duplicate))
					f_matches__awayteam__teamidConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAawayteam.FldZzstate, 0)
						.Equal(CSGenioAawayteam.FldCodteam, Navigation.GetStrValue("awayteam")));
				else
					f_matches__awayteam__teamidConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAawayteam.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("awayteam", "teamid");
				ListingMVC<CSGenioAawayteam> listing = Models.ModelBase.Where<CSGenioAawayteam>(m_userContext, false, f_matches__awayteam__teamidConds, fields, offset, numberItems, sorts, "LED_F_MATCHES__AWAYTEAM__TEAMID", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAwayteamTeamid.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAwayteamTeamid.Query = query;
				TableAwayteamTeamid.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Awayteam(m_userContext, r, true, _fieldsToSerialize_F_MATCHES__AWAYTEAM__TEAMID));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_awayteam") != null)
				{
					this.ValAwayteamid = Navigation.GetStrValue("RETURN_awayteam");
					Navigation.CurrentLevel.SetEntry("RETURN_awayteam", null);
				}

				TableAwayteamTeamid.List = new SelectList(TableAwayteamTeamid.Elements.ToSelectList(x => x.ValTeamid, x => x.ValCodteam,  x => x.ValCodteam == this.ValAwayteamid), "Value", "Text", this.ValAwayteamid);
				FillDependant_F_matchesTableAwayteamTeamid();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAwayteamTeamid (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Awayteam</param>
		public ConcurrentDictionary<string, object> GetDependant_F_matchesTableAwayteamTeamid(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAawayteam.FldCodteam, CSGenioAawayteam.FldTeamid];

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

			CSGenioAawayteam tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAawayteam.FldCodteam, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAwayteamTeamid (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_matchesTableAwayteamTeamid(bool lazyLoad = false)
		{
			var row = GetDependant_F_matchesTableAwayteamTeamid(this.ValAwayteamid);
			try
			{

				// Fill List fields
				this.ValAwayteamid = ViewModelConversion.ToString(row["awayteam.codteam"]);
				TableAwayteamTeamid.Value = (decimal?)row["awayteam.teamid"];
				if (GenFunctions.emptyG(this.ValAwayteamid) == 1)
				{
					this.ValAwayteamid = "";
					TableAwayteamTeamid.Value = 0m;
					Navigation.ClearValue("awayteam");
				}
				else if (lazyLoad)
				{
					TableAwayteamTeamid.SetPagination(1, 0, false, false, 1);
					TableAwayteamTeamid.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValAwayteamid),
							Text = Convert.ToString(TableAwayteamTeamid.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValAwayteamid);
				}

				TableAwayteamTeamid.Selected = this.ValAwayteamid;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAwayteamTeamid): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_MATCHES__AWAYTEAM__TEAMID = ["Awayteam", "Awayteam.ValCodteam", "Awayteam.ValZzstate", "Awayteam.ValTeamid"];

		/// <summary>
		/// TableTeamTeamid -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_matches__team__teamid(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_matches__team__teamidDoLoad = true;
			CriteriaSet f_matches__team__teamidConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("team", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_matches__team__teamidConds.Equal(CSGenioAteam.FldCodteam, hValue);
					this.ValHometeam = DBConversion.ToString(hValue);
				}
			}

			TableTeamTeamid = new TableDBEdit<Models.Team>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_team") != null)
				{
					this.ValHometeam = Navigation.GetStrValue("RETURN_team");
					Navigation.CurrentLevel.SetEntry("RETURN_team", null);
				}
				FillDependant_F_matchesTableTeamTeamid(lazyLoad);
				return;
			}

			if (f_matches__team__teamidDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableTeamTeamid, "sTableTeamTeamid", "dTableTeamTeamid", qs, "team");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTeamTeamid_tableFilters"]))
					TableTeamTeamid.TableFilters = bool.Parse(qs["TableTeamTeamid_tableFilters"]);
				else
					TableTeamTeamid.TableFilters = false;

				query = qs["qTableTeamTeamid"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAteam.FldTeamid, query + "%");
				}
				f_matches__team__teamidConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTeamTeamid"] != null ? qs["pTableTeamTeamid"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAteam.FldCodteam, CSGenioAteam.FldTeamid, CSGenioAteam.FldZzstate];

// USE /[MANUAL PNL OVERRQ F_MATCHES_TEAMTEAMID]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("team", FormMode.New) || Navigation.checkFormMode("team", FormMode.Duplicate))
					f_matches__team__teamidConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAteam.FldZzstate, 0)
						.Equal(CSGenioAteam.FldCodteam, Navigation.GetStrValue("team")));
				else
					f_matches__team__teamidConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAteam.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("team", "teamid");
				ListingMVC<CSGenioAteam> listing = Models.ModelBase.Where<CSGenioAteam>(m_userContext, false, f_matches__team__teamidConds, fields, offset, numberItems, sorts, "LED_F_MATCHES__TEAM__TEAMID", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTeamTeamid.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTeamTeamid.Query = query;
				TableTeamTeamid.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Team(m_userContext, r, true, _fieldsToSerialize_F_MATCHES__TEAM__TEAMID));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_team") != null)
				{
					this.ValHometeam = Navigation.GetStrValue("RETURN_team");
					Navigation.CurrentLevel.SetEntry("RETURN_team", null);
				}

				TableTeamTeamid.List = new SelectList(TableTeamTeamid.Elements.ToSelectList(x => x.ValTeamid, x => x.ValCodteam,  x => x.ValCodteam == this.ValHometeam), "Value", "Text", this.ValHometeam);
				FillDependant_F_matchesTableTeamTeamid();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTeamTeamid (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Team</param>
		public ConcurrentDictionary<string, object> GetDependant_F_matchesTableTeamTeamid(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAteam.FldCodteam, CSGenioAteam.FldTeamid];

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

			CSGenioAteam tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAteam.FldCodteam, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTeamTeamid (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_matchesTableTeamTeamid(bool lazyLoad = false)
		{
			var row = GetDependant_F_matchesTableTeamTeamid(this.ValHometeam);
			try
			{

				// Fill List fields
				this.ValHometeam = ViewModelConversion.ToString(row["team.codteam"]);
				TableTeamTeamid.Value = (decimal?)row["team.teamid"];
				if (GenFunctions.emptyG(this.ValHometeam) == 1)
				{
					this.ValHometeam = "";
					TableTeamTeamid.Value = 0m;
					Navigation.ClearValue("team");
				}
				else if (lazyLoad)
				{
					TableTeamTeamid.SetPagination(1, 0, false, false, 1);
					TableTeamTeamid.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValHometeam),
							Text = Convert.ToString(TableTeamTeamid.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValHometeam);
				}

				TableTeamTeamid.Selected = this.ValHometeam;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTeamTeamid): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_MATCHES__TEAM__TEAMID = ["Team", "Team.ValCodteam", "Team.ValZzstate", "Team.ValTeamid"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"matches.awayteamid" => ViewModelConversion.ToString(modelValue),
				"matches.hometeam" => ViewModelConversion.ToString(modelValue),
				"matches.matchid" => ViewModelConversion.ToNumeric(modelValue),
				"matches.matchdate" => ViewModelConversion.ToDateTime(modelValue),
				"matches.homegoals" => ViewModelConversion.ToNumeric(modelValue),
				"matches.awaygoals" => ViewModelConversion.ToNumeric(modelValue),
				"matches.codmatches" => ViewModelConversion.ToString(modelValue),
				"awayteam.codteam" => ViewModelConversion.ToString(modelValue),
				"awayteam.teamid" => ViewModelConversion.ToNumeric(modelValue),
				"team.codteam" => ViewModelConversion.ToString(modelValue),
				"team.teamid" => ViewModelConversion.ToNumeric(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PNL VIEWMODEL_CUSTOM F_MATCHES]/

		#endregion
	}
}
