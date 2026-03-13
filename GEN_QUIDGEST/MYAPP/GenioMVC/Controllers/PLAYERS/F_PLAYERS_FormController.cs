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
using GenioMVC.ViewModels.Players;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PNL INCLUDE_CONTROLLER PLAYERS]/

namespace GenioMVC.Controllers
{
	public partial class PlayersController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PLAYERS_CANCEL = new("PLAYERS01799", "F_players_Cancel", "Players") { vueRouteName = "form-F_PLAYERS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PLAYERS_SHOW = new("PLAYERS01799", "F_players_Show", "Players") { vueRouteName = "form-F_PLAYERS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PLAYERS_NEW = new("PLAYERS01799", "F_players_New", "Players") { vueRouteName = "form-F_PLAYERS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PLAYERS_EDIT = new("PLAYERS01799", "F_players_Edit", "Players") { vueRouteName = "form-F_PLAYERS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PLAYERS_DUPLICATE = new("PLAYERS01799", "F_players_Duplicate", "Players") { vueRouteName = "form-F_PLAYERS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PLAYERS_DELETE = new("PLAYERS01799", "F_players_Delete", "Players") { vueRouteName = "form-F_PLAYERS", mode = "DELETE" };

		#endregion

		#region F_players private

		private void FormHistoryLimits_F_players()
		{

		}

		#endregion

		#region F_players_Show

// USE /[MANUAL PNL CONTROLLER_SHOW F_PLAYERS]/

		[HttpPost]
		public ActionResult F_players_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_players_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_players_Show_GET",
				AreaName = "players",
				Location = ACTION_F_PLAYERS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_players();
// USE /[MANUAL PNL BEFORE_LOAD_SHOW F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_SHOW F_PLAYERS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_players_New

// USE /[MANUAL PNL CONTROLLER_NEW_GET F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_players_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_players_New_GET",
				AreaName = "players",
				FormName = "F_PLAYERS",
				Location = ACTION_F_PLAYERS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_players();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW F_PLAYERS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Players/F_players_New
// USE /[MANUAL PNL CONTROLLER_NEW_POST F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_New([FromBody]F_players_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_players_New",
				ViewName = "F_players",
				AreaName = "players",
				Location = ACTION_F_PLAYERS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_NEW F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_NEW F_PLAYERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW_EX F_PLAYERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW_EX F_PLAYERS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_players_Edit

// USE /[MANUAL PNL CONTROLLER_EDIT_GET F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_players_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_players_Edit_GET",
				AreaName = "players",
				FormName = "F_PLAYERS",
				Location = ACTION_F_PLAYERS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_players();
// USE /[MANUAL PNL BEFORE_LOAD_EDIT F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT F_PLAYERS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Players/F_players_Edit
// USE /[MANUAL PNL CONTROLLER_EDIT_POST F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_Edit([FromBody]F_players_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_players_Edit",
				ViewName = "F_players",
				AreaName = "players",
				Location = ACTION_F_PLAYERS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_EDIT F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_EDIT F_PLAYERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_EDIT_EX F_PLAYERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT_EX F_PLAYERS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_players_Delete

// USE /[MANUAL PNL CONTROLLER_DELETE_GET F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_players_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_players_Delete_GET",
				AreaName = "players",
				FormName = "F_PLAYERS",
				Location = ACTION_F_PLAYERS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_players();
// USE /[MANUAL PNL BEFORE_LOAD_DELETE F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DELETE F_PLAYERS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Players/F_players_Delete
// USE /[MANUAL PNL CONTROLLER_DELETE_POST F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_players_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_players_Delete",
				ViewName = "F_players",
				AreaName = "players",
				Location = ACTION_F_PLAYERS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_DESTROY_DELETE F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_DESTROY_DELETE F_PLAYERS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_players_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PLAYERS");
		}

		#endregion

		#region F_players_Duplicate

// USE /[MANUAL PNL CONTROLLER_DUPLICATE_GET F_PLAYERS]/

		[HttpPost]
		public ActionResult F_players_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_players_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_players_Duplicate_GET",
				AreaName = "players",
				FormName = "F_PLAYERS",
				Location = ACTION_F_PLAYERS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE F_PLAYERS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Players/F_players_Duplicate
// USE /[MANUAL PNL CONTROLLER_DUPLICATE_POST F_PLAYERS]/
		[HttpPost]
		public ActionResult F_players_Duplicate([FromBody]F_players_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_players_Duplicate",
				ViewName = "F_players",
				AreaName = "players",
				Location = ACTION_F_PLAYERS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_DUPLICATE F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_DUPLICATE F_PLAYERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE_EX F_PLAYERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE_EX F_PLAYERS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_players_Cancel

		//
		// GET: /Players/F_players_Cancel
// USE /[MANUAL PNL CONTROLLER_CANCEL_GET F_PLAYERS]/
		public ActionResult F_players_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Players model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("players");

// USE /[MANUAL PNL BEFORE_CANCEL F_PLAYERS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PNL AFTER_CANCEL F_PLAYERS]/

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

				Navigation.SetValue("ForcePrimaryRead_players", "true", true);
			}

			Navigation.ClearValue("players");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_players_MatchesValMatchidModel : RequestLookupModel
		{
			public F_players_ViewModel Model { get; set; }
		}

		//
		// GET: /Players/F_players_MatchesValMatchid
		// POST: /Players/F_players_MatchesValMatchid
		[ActionName("F_players_MatchesValMatchid")]
		public ActionResult F_players_MatchesValMatchid([FromBody] F_players_MatchesValMatchidModel requestModel)
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

			Models.Players parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_players_MatchesValMatchid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Players/F_players_SaveEdit
		[HttpPost]
		public ActionResult F_players_SaveEdit([FromBody] F_players_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_players_SaveEdit",
				ViewName = "F_players",
				AreaName = "players",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_APPLY_EDIT F_PLAYERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_APPLY_EDIT F_PLAYERS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_playersDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_players_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_players([FromBody] F_playersDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
