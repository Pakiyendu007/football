using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Awayteam : ModelBase
	{
		[JsonIgnore]
		public CSGenioAawayteam klass { get { return baseklass as CSGenioAawayteam; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Awayteam.ValCodteam")]
		public string ValCodteam { get { return klass.ValCodteam; } set { klass.ValCodteam = value; } }

		[DisplayName("team id")]
		/// <summary>Field : "team id" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Awayteam.ValTeamid")]
		[NumericAttribute(0)]
		public decimal? ValTeamid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTeamid, 0)); } set { klass.ValTeamid = Convert.ToDecimal(value); } }

		[DisplayName("team name")]
		/// <summary>Field : "team name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Awayteam.ValTeamname")]
		public string ValTeamname { get { return klass.ValTeamname; } set { klass.ValTeamname = value; } }

		[DisplayName("city")]
		/// <summary>Field : "city" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Awayteam.ValCity")]
		public string ValCity { get { return klass.ValCity; } set { klass.ValCity = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Awayteam.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Awayteam(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAawayteam(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Awayteam(UserContext userContext, CSGenioAawayteam val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAawayteam csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Awayteam Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAawayteam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Awayteam(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Awayteam> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAawayteam>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Awayteam>((r) => new Awayteam(userCtx, r));
		}

// USE /[MANUAL PNL MODEL AWAYTEAM]/
	}
}
