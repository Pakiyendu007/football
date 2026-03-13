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
using GenioMVC.ViewModels.Awayteam;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PNL INCLUDE_CONTROLLER AWAYTEAM]/

namespace GenioMVC.Controllers
{
	public partial class AwayteamController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_TEAM_CANCEL = new("TEAM57329", "F_team_Cancel", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_TEAM_SHOW = new("TEAM57329", "F_team_Show", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_TEAM_NEW = new("TEAM57329", "F_team_New", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_TEAM_EDIT = new("TEAM57329", "F_team_Edit", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_TEAM_DUPLICATE = new("TEAM57329", "F_team_Duplicate", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_TEAM_DELETE = new("TEAM57329", "F_team_Delete", "Awayteam") { vueRouteName = "form-F_TEAM", mode = "DELETE" };

		#endregion

		#region F_team private

		private void FormHistoryLimits_F_team()
		{

		}

		#endregion

		#region F_team_Show

// USE /[MANUAL PNL CONTROLLER_SHOW F_TEAM]/

		[HttpPost]
		public ActionResult F_team_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_team_Show_GET",
				AreaName = "awayteam",
				Location = ACTION_F_TEAM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_team();
// USE /[MANUAL PNL BEFORE_LOAD_SHOW F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_SHOW F_TEAM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_team_New

// USE /[MANUAL PNL CONTROLLER_NEW_GET F_TEAM]/
		[HttpPost]
		public ActionResult F_team_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_team_New_GET",
				AreaName = "awayteam",
				FormName = "F_TEAM",
				Location = ACTION_F_TEAM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_team();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW F_TEAM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Awayteam/F_team_New
// USE /[MANUAL PNL CONTROLLER_NEW_POST F_TEAM]/
		[HttpPost]
		public ActionResult F_team_New([FromBody]F_team_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_team_New",
				ViewName = "F_team",
				AreaName = "awayteam",
				Location = ACTION_F_TEAM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_NEW F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_NEW F_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW_EX F_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW_EX F_TEAM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_team_Edit

// USE /[MANUAL PNL CONTROLLER_EDIT_GET F_TEAM]/
		[HttpPost]
		public ActionResult F_team_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_team_Edit_GET",
				AreaName = "awayteam",
				FormName = "F_TEAM",
				Location = ACTION_F_TEAM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_team();
// USE /[MANUAL PNL BEFORE_LOAD_EDIT F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT F_TEAM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Awayteam/F_team_Edit
// USE /[MANUAL PNL CONTROLLER_EDIT_POST F_TEAM]/
		[HttpPost]
		public ActionResult F_team_Edit([FromBody]F_team_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_team_Edit",
				ViewName = "F_team",
				AreaName = "awayteam",
				Location = ACTION_F_TEAM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_EDIT F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_EDIT F_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_EDIT_EX F_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT_EX F_TEAM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_team_Delete

// USE /[MANUAL PNL CONTROLLER_DELETE_GET F_TEAM]/
		[HttpPost]
		public ActionResult F_team_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_team_Delete_GET",
				AreaName = "awayteam",
				FormName = "F_TEAM",
				Location = ACTION_F_TEAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_team();
// USE /[MANUAL PNL BEFORE_LOAD_DELETE F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DELETE F_TEAM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Awayteam/F_team_Delete
// USE /[MANUAL PNL CONTROLLER_DELETE_POST F_TEAM]/
		[HttpPost]
		public ActionResult F_team_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_team_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_team_Delete",
				ViewName = "F_team",
				AreaName = "awayteam",
				Location = ACTION_F_TEAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_DESTROY_DELETE F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_DESTROY_DELETE F_TEAM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_team_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_TEAM");
		}

		#endregion

		#region F_team_Duplicate

// USE /[MANUAL PNL CONTROLLER_DUPLICATE_GET F_TEAM]/

		[HttpPost]
		public ActionResult F_team_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_team_Duplicate_GET",
				AreaName = "awayteam",
				FormName = "F_TEAM",
				Location = ACTION_F_TEAM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE F_TEAM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Awayteam/F_team_Duplicate
// USE /[MANUAL PNL CONTROLLER_DUPLICATE_POST F_TEAM]/
		[HttpPost]
		public ActionResult F_team_Duplicate([FromBody]F_team_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_team_Duplicate",
				ViewName = "F_team",
				AreaName = "awayteam",
				Location = ACTION_F_TEAM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_DUPLICATE F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_DUPLICATE F_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE_EX F_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE_EX F_TEAM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_team_Cancel

		//
		// GET: /Awayteam/F_team_Cancel
// USE /[MANUAL PNL CONTROLLER_CANCEL_GET F_TEAM]/
		public ActionResult F_team_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Awayteam model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("awayteam");

// USE /[MANUAL PNL BEFORE_CANCEL F_TEAM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PNL AFTER_CANCEL F_TEAM]/

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

				Navigation.SetValue("ForcePrimaryRead_awayteam", "true", true);
			}

			Navigation.ClearValue("awayteam");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Awayteam/F_team_SaveEdit
		[HttpPost]
		public ActionResult F_team_SaveEdit([FromBody] F_team_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_team_SaveEdit",
				ViewName = "F_team",
				AreaName = "awayteam",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_APPLY_EDIT F_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_APPLY_EDIT F_TEAM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_teamDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_team_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_team([FromBody] F_teamDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
