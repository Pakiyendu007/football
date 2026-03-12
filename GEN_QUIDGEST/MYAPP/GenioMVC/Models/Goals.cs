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
	public class Goals : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgoals klass { get { return baseklass as CSGenioAgoals; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Goals.ValCodgoals")]
		public string ValCodgoals { get { return klass.ValCodgoals; } set { klass.ValCodgoals = value; } }

		[DisplayName("goals id")]
		/// <summary>Field : "goals id" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Goals.ValGoalsid")]
		[NumericAttribute(0)]
		public decimal? ValGoalsid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValGoalsid, 0)); } set { klass.ValGoalsid = Convert.ToDecimal(value); } }

		[DisplayName("matchid")]
		/// <summary>Field : "matchid" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Goals.ValMatchid")]
		public string ValMatchid { get { return klass.ValMatchid; } set { klass.ValMatchid = value; } }

		private Matches _matches;
		[DisplayName("Matches")]
		[ShouldSerialize("Matches")]
		public virtual Matches Matches
		{
			get
			{
				if (!isEmptyModel && (_matches == null || (!string.IsNullOrEmpty(ValMatchid) && (_matches.isEmptyModel || _matches.klass.QPrimaryKey != ValMatchid))))
					_matches = Models.Matches.Find(ValMatchid, m_userContext, Identifier, _fieldsToSerialize);
				_matches ??= new Models.Matches(m_userContext, true, _fieldsToSerialize);
				return _matches;
			}
			set { _matches = value; }
		}

		[DisplayName("player id")]
		/// <summary>Field : "player id" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Goals.ValPlayerid")]
		public string ValPlayerid { get { return klass.ValPlayerid; } set { klass.ValPlayerid = value; } }

		private Players _players;
		[DisplayName("Players")]
		[ShouldSerialize("Players")]
		public virtual Players Players
		{
			get
			{
				if (!isEmptyModel && (_players == null || (!string.IsNullOrEmpty(ValPlayerid) && (_players.isEmptyModel || _players.klass.QPrimaryKey != ValPlayerid))))
					_players = Models.Players.Find(ValPlayerid, m_userContext, Identifier, _fieldsToSerialize);
				_players ??= new Models.Players(m_userContext, true, _fieldsToSerialize);
				return _players;
			}
			set { _players = value; }
		}

		[DisplayName("minute")]
		/// <summary>Field : "minute" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Goals.ValMinute")]
		[NumericAttribute(0)]
		public decimal? ValMinute { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMinute, 0)); } set { klass.ValMinute = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Goals.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Goals(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgoals(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Goals(UserContext userContext, CSGenioAgoals val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAgoals csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "matches":
						_matches ??= new Matches(m_userContext, true, _fieldsToSerialize);
						_matches.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "players":
						_players ??= new Players(m_userContext, true, _fieldsToSerialize);
						_players.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Goals Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgoals>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Goals(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Goals> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgoals>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Goals>((r) => new Goals(userCtx, r));
		}

// USE /[MANUAL PNL MODEL GOALS]/
	}
}
