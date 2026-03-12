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
	public class Matches : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmatches klass { get { return baseklass as CSGenioAmatches; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValCodmatches")]
		public string ValCodmatches { get { return klass.ValCodmatches; } set { klass.ValCodmatches = value; } }

		[DisplayName("match id")]
		/// <summary>Field : "match id" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValMatchid")]
		[NumericAttribute(0)]
		public decimal? ValMatchid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMatchid, 0)); } set { klass.ValMatchid = Convert.ToDecimal(value); } }

		[DisplayName("awayteam id")]
		/// <summary>Field : "awayteam id" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValAwayteamid")]
		public string ValAwayteamid { get { return klass.ValAwayteamid; } set { klass.ValAwayteamid = value; } }

		private Awayteam _awayteam;
		[DisplayName("Awayteam")]
		[ShouldSerialize("Awayteam")]
		public virtual Awayteam Awayteam
		{
			get
			{
				if (!isEmptyModel && (_awayteam == null || (!string.IsNullOrEmpty(ValAwayteamid) && (_awayteam.isEmptyModel || _awayteam.klass.QPrimaryKey != ValAwayteamid))))
					_awayteam = Models.Awayteam.Find(ValAwayteamid, m_userContext, Identifier, _fieldsToSerialize);
				_awayteam ??= new Models.Awayteam(m_userContext, true, _fieldsToSerialize);
				return _awayteam;
			}
			set { _awayteam = value; }
		}

		[DisplayName("match date")]
		/// <summary>Field : "match date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValMatchdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValMatchdate { get { return klass.ValMatchdate; } set { klass.ValMatchdate = value ?? DateTime.MinValue; } }

		[DisplayName("home goals")]
		/// <summary>Field : "home goals" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValHomegoals")]
		[NumericAttribute(0)]
		public decimal? ValHomegoals { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValHomegoals, 0)); } set { klass.ValHomegoals = Convert.ToDecimal(value); } }

		[DisplayName("away goals")]
		/// <summary>Field : "away goals" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValAwaygoals")]
		[NumericAttribute(0)]
		public decimal? ValAwaygoals { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAwaygoals, 0)); } set { klass.ValAwaygoals = Convert.ToDecimal(value); } }

		[DisplayName("home team")]
		/// <summary>Field : "home team" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Matches.ValHometeam")]
		public string ValHometeam { get { return klass.ValHometeam; } set { klass.ValHometeam = value; } }

		private Team _team;
		[DisplayName("Team")]
		[ShouldSerialize("Team")]
		public virtual Team Team
		{
			get
			{
				if (!isEmptyModel && (_team == null || (!string.IsNullOrEmpty(ValHometeam) && (_team.isEmptyModel || _team.klass.QPrimaryKey != ValHometeam))))
					_team = Models.Team.Find(ValHometeam, m_userContext, Identifier, _fieldsToSerialize);
				_team ??= new Models.Team(m_userContext, true, _fieldsToSerialize);
				return _team;
			}
			set { _team = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Matches.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Matches(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmatches(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Matches(UserContext userContext, CSGenioAmatches val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmatches csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "awayteam":
						_awayteam ??= new Awayteam(m_userContext, true, _fieldsToSerialize);
						_awayteam.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "team":
						_team ??= new Team(m_userContext, true, _fieldsToSerialize);
						_team.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Matches Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmatches>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Matches(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Matches> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmatches>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Matches>((r) => new Matches(userCtx, r));
		}

// USE /[MANUAL PNL MODEL MATCHES]/
	}
}
