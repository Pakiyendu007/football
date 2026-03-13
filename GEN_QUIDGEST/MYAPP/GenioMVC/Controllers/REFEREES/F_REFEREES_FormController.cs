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
using GenioMVC.ViewModels.Referees;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PNL INCLUDE_CONTROLLER REFEREES]/

namespace GenioMVC.Controllers
{
	public partial class RefereesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_REFEREES_CANCEL = new("REFEREES03665", "F_referees_Cancel", "Referees") { vueRouteName = "form-F_REFEREES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_REFEREES_SHOW = new("REFEREES03665", "F_referees_Show", "Referees") { vueRouteName = "form-F_REFEREES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_REFEREES_NEW = new("REFEREES03665", "F_referees_New", "Referees") { vueRouteName = "form-F_REFEREES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_REFEREES_EDIT = new("REFEREES03665", "F_referees_Edit", "Referees") { vueRouteName = "form-F_REFEREES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_REFEREES_DUPLICATE = new("REFEREES03665", "F_referees_Duplicate", "Referees") { vueRouteName = "form-F_REFEREES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_REFEREES_DELETE = new("REFEREES03665", "F_referees_Delete", "Referees") { vueRouteName = "form-F_REFEREES", mode = "DELETE" };

		#endregion

		#region F_referees private

		private void FormHistoryLimits_F_referees()
		{

		}

		#endregion

		#region F_referees_Show

// USE /[MANUAL PNL CONTROLLER_SHOW F_REFEREES]/

		[HttpPost]
		public ActionResult F_referees_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_referees_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Show_GET",
				AreaName = "referees",
				Location = ACTION_F_REFEREES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_referees();
// USE /[MANUAL PNL BEFORE_LOAD_SHOW F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_SHOW F_REFEREES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_referees_New

// USE /[MANUAL PNL CONTROLLER_NEW_GET F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_referees_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_referees_New_GET",
				AreaName = "referees",
				FormName = "F_REFEREES",
				Location = ACTION_F_REFEREES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_referees();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW F_REFEREES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Referees/F_referees_New
// USE /[MANUAL PNL CONTROLLER_NEW_POST F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_New([FromBody]F_referees_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_referees_New",
				ViewName = "F_referees",
				AreaName = "referees",
				Location = ACTION_F_REFEREES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_NEW F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_NEW F_REFEREES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_NEW_EX F_REFEREES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_NEW_EX F_REFEREES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_referees_Edit

// USE /[MANUAL PNL CONTROLLER_EDIT_GET F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_referees_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Edit_GET",
				AreaName = "referees",
				FormName = "F_REFEREES",
				Location = ACTION_F_REFEREES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_referees();
// USE /[MANUAL PNL BEFORE_LOAD_EDIT F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT F_REFEREES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Referees/F_referees_Edit
// USE /[MANUAL PNL CONTROLLER_EDIT_POST F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_Edit([FromBody]F_referees_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Edit",
				ViewName = "F_referees",
				AreaName = "referees",
				Location = ACTION_F_REFEREES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_EDIT F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_EDIT F_REFEREES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_EDIT_EX F_REFEREES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_EDIT_EX F_REFEREES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_referees_Delete

// USE /[MANUAL PNL CONTROLLER_DELETE_GET F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_referees_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Delete_GET",
				AreaName = "referees",
				FormName = "F_REFEREES",
				Location = ACTION_F_REFEREES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_referees();
// USE /[MANUAL PNL BEFORE_LOAD_DELETE F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DELETE F_REFEREES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Referees/F_referees_Delete
// USE /[MANUAL PNL CONTROLLER_DELETE_POST F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_referees_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_referees_Delete",
				ViewName = "F_referees",
				AreaName = "referees",
				Location = ACTION_F_REFEREES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_DESTROY_DELETE F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_DESTROY_DELETE F_REFEREES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_referees_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_REFEREES");
		}

		#endregion

		#region F_referees_Duplicate

// USE /[MANUAL PNL CONTROLLER_DUPLICATE_GET F_REFEREES]/

		[HttpPost]
		public ActionResult F_referees_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_referees_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Duplicate_GET",
				AreaName = "referees",
				FormName = "F_REFEREES",
				Location = ACTION_F_REFEREES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE F_REFEREES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Referees/F_referees_Duplicate
// USE /[MANUAL PNL CONTROLLER_DUPLICATE_POST F_REFEREES]/
		[HttpPost]
		public ActionResult F_referees_Duplicate([FromBody]F_referees_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_referees_Duplicate",
				ViewName = "F_referees",
				AreaName = "referees",
				Location = ACTION_F_REFEREES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_SAVE_DUPLICATE F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_SAVE_DUPLICATE F_REFEREES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_LOAD_DUPLICATE_EX F_REFEREES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_LOAD_DUPLICATE_EX F_REFEREES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_referees_Cancel

		//
		// GET: /Referees/F_referees_Cancel
// USE /[MANUAL PNL CONTROLLER_CANCEL_GET F_REFEREES]/
		public ActionResult F_referees_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Referees model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("referees");

// USE /[MANUAL PNL BEFORE_CANCEL F_REFEREES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PNL AFTER_CANCEL F_REFEREES]/

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

				Navigation.SetValue("ForcePrimaryRead_referees", "true", true);
			}

			Navigation.ClearValue("referees");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Referees/F_referees_SaveEdit
		[HttpPost]
		public ActionResult F_referees_SaveEdit([FromBody] F_referees_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_referees_SaveEdit",
				ViewName = "F_referees",
				AreaName = "referees",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PNL BEFORE_APPLY_EDIT F_REFEREES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PNL AFTER_APPLY_EDIT F_REFEREES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_refereesDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_referees_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_referees([FromBody] F_refereesDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
