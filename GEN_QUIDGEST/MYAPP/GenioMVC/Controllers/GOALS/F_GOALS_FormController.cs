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
using GenioMVC.ViewModels.Goals;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PNL INCLUDE_CONTROLLER GOALS]/

namespace GenioMVC.Controllers
{
	public partial class GoalsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_GOALS_CANCEL = new("GOALS59839", "F_goals_Cancel", "Goals") { vueRouteName = "form-F_GOALS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_GOALS_SHOW = new("GOALS59839", "F_goals_Show", "Goals") { vueRouteName = "form-F_GOALS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_GOALS_NEW = new("GOALS59839", "F_goals_New", "Goals") { vueRouteName = "form-F_GOALS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_GOALS_EDIT = new("GOALS59839", "F_goals_Edit", "Goals") { vueRouteName = "form-F_GOALS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_GOALS_DUPLICATE = new("GOALS59839", "F_goals_Duplicate", "Goals") { vueRouteName = "form-F_GOALS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_GOALS_DELETE = new("GOALS59839", "F_goals_Delete", "Goals") { vueRouteName = "form-F_GOALS", mode = "DELETE" };

		#endregion

		#region F_goals private

		private void FormHistoryLimits_F_goals()
		{

		}

		#endregion

		#region F_goals_Show

// USE /[MANUAL PNL CONTROLLER_SHOW F_GOALS]/

		[HttpPost]
		public ActionResult F_goals_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_goals_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Show_GET",
				AreaName = "goals",
				Location = ACTION_F_GOALS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_goals();
// USE /[MANUAL PNL BEFORE_LOAD_SHOW F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_SHOW F_GOALS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_goals_New

// USE /[MANUAL PNL CONTROLLER_NEW_GET F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_goals_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_goals_New_GET",
				AreaName = "goals",
				FormName = "F_GOALS",
				Location = ACTION_F_GOALS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_goals();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW F_GOALS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Goals/F_goals_New
// USE /[MANUAL PNL CONTROLLER_NEW_POST F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_New([FromBody]F_goals_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_goals_New",
				ViewName = "F_goals",
				AreaName = "goals",
				Location = ACTION_F_GOALS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_NEW F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_NEW F_GOALS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW_EX F_GOALS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW_EX F_GOALS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_goals_Edit

// USE /[MANUAL PNL CONTROLLER_EDIT_GET F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_goals_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Edit_GET",
				AreaName = "goals",
				FormName = "F_GOALS",
				Location = ACTION_F_GOALS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_goals();
// USE /[MANUAL PNL BEFORE_LOAD_EDIT F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT F_GOALS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Goals/F_goals_Edit
// USE /[MANUAL PNL CONTROLLER_EDIT_POST F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_Edit([FromBody]F_goals_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Edit",
				ViewName = "F_goals",
				AreaName = "goals",
				Location = ACTION_F_GOALS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_EDIT F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_EDIT F_GOALS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_EDIT_EX F_GOALS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT_EX F_GOALS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_goals_Delete

// USE /[MANUAL PNL CONTROLLER_DELETE_GET F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_goals_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Delete_GET",
				AreaName = "goals",
				FormName = "F_GOALS",
				Location = ACTION_F_GOALS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_goals();
// USE /[MANUAL PNL BEFORE_LOAD_DELETE F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DELETE F_GOALS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Goals/F_goals_Delete
// USE /[MANUAL PNL CONTROLLER_DELETE_POST F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_goals_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_goals_Delete",
				ViewName = "F_goals",
				AreaName = "goals",
				Location = ACTION_F_GOALS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_DESTROY_DELETE F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_DESTROY_DELETE F_GOALS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_goals_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_GOALS");
		}

		#endregion

		#region F_goals_Duplicate

// USE /[MANUAL PNL CONTROLLER_DUPLICATE_GET F_GOALS]/

		[HttpPost]
		public ActionResult F_goals_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_goals_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Duplicate_GET",
				AreaName = "goals",
				FormName = "F_GOALS",
				Location = ACTION_F_GOALS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE F_GOALS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Goals/F_goals_Duplicate
// USE /[MANUAL PNL CONTROLLER_DUPLICATE_POST F_GOALS]/
		[HttpPost]
		public ActionResult F_goals_Duplicate([FromBody]F_goals_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_goals_Duplicate",
				ViewName = "F_goals",
				AreaName = "goals",
				Location = ACTION_F_GOALS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_DUPLICATE F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_DUPLICATE F_GOALS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE_EX F_GOALS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE_EX F_GOALS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_goals_Cancel

		//
		// GET: /Goals/F_goals_Cancel
// USE /[MANUAL PNL CONTROLLER_CANCEL_GET F_GOALS]/
		public ActionResult F_goals_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Goals model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("goals");

// USE /[MANUAL PNL BEFORE_CANCEL F_GOALS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PNL AFTER_CANCEL F_GOALS]/

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

				Navigation.SetValue("ForcePrimaryRead_goals", "true", true);
			}

			Navigation.ClearValue("goals");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_goals_MatchesValMatchidModel : RequestLookupModel
		{
			public F_goals_ViewModel Model { get; set; }
		}

		//
		// GET: /Goals/F_goals_MatchesValMatchid
		// POST: /Goals/F_goals_MatchesValMatchid
		[ActionName("F_goals_MatchesValMatchid")]
		public ActionResult F_goals_MatchesValMatchid([FromBody] F_goals_MatchesValMatchidModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_matches")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_matches");
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

			Models.Goals parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_goals_MatchesValMatchid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class F_goals_PlayersValPlayeridModel : RequestLookupModel
		{
			public F_goals_ViewModel Model { get; set; }
		}

		//
		// GET: /Goals/F_goals_PlayersValPlayerid
		// POST: /Goals/F_goals_PlayersValPlayerid
		[ActionName("F_goals_PlayersValPlayerid")]
		public ActionResult F_goals_PlayersValPlayerid([FromBody] F_goals_PlayersValPlayeridModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_players")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_players");
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

			Models.Goals parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_goals_PlayersValPlayerid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Goals/F_goals_SaveEdit
		[HttpPost]
		public ActionResult F_goals_SaveEdit([FromBody] F_goals_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_goals_SaveEdit",
				ViewName = "F_goals",
				AreaName = "goals",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_APPLY_EDIT F_GOALS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_APPLY_EDIT F_GOALS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_goalsDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_goals_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_goals([FromBody] F_goalsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
