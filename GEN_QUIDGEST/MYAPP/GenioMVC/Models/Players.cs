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
	public class Players : ModelBase
	{
		[JsonIgnore]
		public CSGenioAplayers klass { get { return baseklass as CSGenioAplayers; } set { baseklass = value; } }

		[DisplayName("position")]
		/// <summary>Field : "position" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Players.ValPosition")]
		[NumericAttribute(0)]
		public decimal? ValPosition { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPosition, 0)); } set { klass.ValPosition = Convert.ToDecimal(value); } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Players.ValCodplayers")]
		public string ValCodplayers { get { return klass.ValCodplayers; } set { klass.ValCodplayers = value; } }

		[DisplayName("player id")]
		/// <summary>Field : "player id" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Players.ValPlayerid")]
		[NumericAttribute(0)]
		public decimal? ValPlayerid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlayerid, 0)); } set { klass.ValPlayerid = Convert.ToDecimal(value); } }

		[DisplayName("playername")]
		/// <summary>Field : "playername" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Players.ValPlayername")]
		public string ValPlayername { get { return klass.ValPlayername; } set { klass.ValPlayername = value; } }

		[DisplayName("age")]
		/// <summary>Field : "age" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Players.ValAge")]
		[NumericAttribute(0)]
		public decimal? ValAge { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAge, 0)); } set { klass.ValAge = Convert.ToDecimal(value); } }

		[DisplayName("team id")]
		/// <summary>Field : "team id" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Players.ValTeamid")]
		public string ValTeamid { get { return klass.ValTeamid; } set { klass.ValTeamid = value; } }

		private Matches _matches;
		[DisplayName("Matches")]
		[ShouldSerialize("Matches")]
		public virtual Matches Matches
		{
			get
			{
				if (!isEmptyModel && (_matches == null || (!string.IsNullOrEmpty(ValTeamid) && (_matches.isEmptyModel || _matches.klass.QPrimaryKey != ValTeamid))))
					_matches = Models.Matches.Find(ValTeamid, m_userContext, Identifier, _fieldsToSerialize);
				_matches ??= new Models.Matches(m_userContext, true, _fieldsToSerialize);
				return _matches;
			}
			set { _matches = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Players.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Players(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAplayers(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Players(UserContext userContext, CSGenioAplayers val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAplayers csgenioa)
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
		public static Players Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAplayers>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Players(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Players> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAplayers>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Players>((r) => new Players(userCtx, r));
		}

// USE /[MANUAL PNL MODEL PLAYERS]/
	}
}
