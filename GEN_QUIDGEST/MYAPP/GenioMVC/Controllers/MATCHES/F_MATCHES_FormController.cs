using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Matches;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PNL INCLUDE_CONTROLLER MATCHES]/

namespace GenioMVC.Controllers
{
	public partial class MatchesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_MATCHES_CANCEL = new("MATCHES56954", "F_matches_Cancel", "Matches") { vueRouteName = "form-F_MATCHES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_MATCHES_SHOW = new("MATCHES56954", "F_matches_Show", "Matches") { vueRouteName = "form-F_MATCHES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_MATCHES_NEW = new("MATCHES56954", "F_matches_New", "Matches") { vueRouteName = "form-F_MATCHES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_MATCHES_EDIT = new("MATCHES56954", "F_matches_Edit", "Matches") { vueRouteName = "form-F_MATCHES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_MATCHES_DUPLICATE = new("MATCHES56954", "F_matches_Duplicate", "Matches") { vueRouteName = "form-F_MATCHES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_MATCHES_DELETE = new("MATCHES56954", "F_matches_Delete", "Matches") { vueRouteName = "form-F_MATCHES", mode = "DELETE" };

		#endregion

		#region F_matches private

		private void FormHistoryLimits_F_matches()
		{

		}

		#endregion

		#region F_matches_Show

// USE /[MANUAL PNL CONTROLLER_SHOW F_MATCHES]/

		[HttpPost]
		public ActionResult F_matches_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_matches_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Show_GET",
				AreaName = "matches",
				Location = ACTION_F_MATCHES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_matches();
// USE /[MANUAL PNL BEFORE_LOAD_SHOW F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_SHOW F_MATCHES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_matches_New

// USE /[MANUAL PNL CONTROLLER_NEW_GET F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_matches_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_matches_New_GET",
				AreaName = "matches",
				FormName = "F_MATCHES",
				Location = ACTION_F_MATCHES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_matches();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW F_MATCHES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Matches/F_matches_New
// USE /[MANUAL PNL CONTROLLER_NEW_POST F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_New([FromBody]F_matches_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_matches_New",
				ViewName = "F_matches",
				AreaName = "matches",
				Location = ACTION_F_MATCHES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_NEW F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_NEW F_MATCHES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW_EX F_MATCHES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW_EX F_MATCHES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_matches_Edit

// USE /[MANUAL PNL CONTROLLER_EDIT_GET F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_matches_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Edit_GET",
				AreaName = "matches",
				FormName = "F_MATCHES",
				Location = ACTION_F_MATCHES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_matches();
// USE /[MANUAL PNL BEFORE_LOAD_EDIT F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT F_MATCHES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Matches/F_matches_Edit
// USE /[MANUAL PNL CONTROLLER_EDIT_POST F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_Edit([FromBody]F_matches_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Edit",
				ViewName = "F_matches",
				AreaName = "matches",
				Location = ACTION_F_MATCHES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_EDIT F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_EDIT F_MATCHES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_EDIT_EX F_MATCHES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT_EX F_MATCHES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_matches_Delete

// USE /[MANUAL PNL CONTROLLER_DELETE_GET F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_matches_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Delete_GET",
				AreaName = "matches",
				FormName = "F_MATCHES",
				Location = ACTION_F_MATCHES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_matches();
// USE /[MANUAL PNL BEFORE_LOAD_DELETE F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DELETE F_MATCHES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Matches/F_matches_Delete
// USE /[MANUAL PNL CONTROLLER_DELETE_POST F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_matches_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_matches_Delete",
				ViewName = "F_matches",
				AreaName = "matches",
				Location = ACTION_F_MATCHES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_DESTROY_DELETE F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_DESTROY_DELETE F_MATCHES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_matches_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_MATCHES");
		}

		#endregion

		#region F_matches_Duplicate

// USE /[MANUAL PNL CONTROLLER_DUPLICATE_GET F_MATCHES]/

		[HttpPost]
		public ActionResult F_matches_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_matches_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Duplicate_GET",
				AreaName = "matches",
				FormName = "F_MATCHES",
				Location = ACTION_F_MATCHES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE F_MATCHES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Matches/F_matches_Duplicate
// USE /[MANUAL PNL CONTROLLER_DUPLICATE_POST F_MATCHES]/
		[HttpPost]
		public ActionResult F_matches_Duplicate([FromBody]F_matches_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_matches_Duplicate",
				ViewName = "F_matches",
				AreaName = "matches",
				Location = ACTION_F_MATCHES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_DUPLICATE F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_DUPLICATE F_MATCHES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE_EX F_MATCHES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE_EX F_MATCHES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_matches_Cancel

		//
		// GET: /Matches/F_matches_Cancel
// USE /[MANUAL PNL CONTROLLER_CANCEL_GET F_MATCHES]/
		public ActionResult F_matches_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Matches model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("matches");

// USE /[MANUAL PNL BEFORE_CANCEL F_MATCHES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PNL AFTER_CANCEL F_MATCHES]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_matches", "true", true);
			}

			Navigation.ClearValue("matches");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_matches_AwayteamValTeamidModel : RequestLookupModel
		{
			public F_matches_ViewModel Model { get; set; }
		}

		//
		// GET: /Matches/F_matches_AwayteamValTeamid
		// POST: /Matches/F_matches_AwayteamValTeamid
		[ActionName("F_matches_AwayteamValTeamid")]
		public ActionResult F_matches_AwayteamValTeamid([FromBody] F_matches_AwayteamValTeamidModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_awayteam")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_awayteam");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Matches parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_matches_AwayteamValTeamid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class F_matches_TeamValTeamidModel : RequestLookupModel
		{
			public F_matches_ViewModel Model { get; set; }
		}

		//
		// GET: /Matches/F_matches_TeamValTeamid
		// POST: /Matches/F_matches_TeamValTeamid
		[ActionName("F_matches_TeamValTeamid")]
		public ActionResult F_matches_TeamValTeamid([FromBody] F_matches_TeamValTeamidModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_team")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_team");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Matches parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_matches_TeamValTeamid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Matches/F_matches_SaveEdit
		[HttpPost]
		public ActionResult F_matches_SaveEdit([FromBody] F_matches_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_matches_SaveEdit",
				ViewName = "F_matches",
				AreaName = "matches",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_APPLY_EDIT F_MATCHES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_APPLY_EDIT F_MATCHES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_matchesDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_matches_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_matches([FromBody] F_matchesDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
