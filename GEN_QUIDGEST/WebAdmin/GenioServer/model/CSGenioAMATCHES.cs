
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// matches
	/// </summary>
	public class CSGenioAmatches : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAmatches(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL PNL CONSTRUTOR MATCHES]/
		}

		public CSGenioAmatches(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codmatches", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "matchid", FieldType.NUMERIC);
			Qfield.FieldDescription = "match id";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 8;
			Qfield.CavDesignation = "MATCH_ID16862";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "awayteamid", FieldType.KEY_INT);
			Qfield.FieldDescription = "awayteam id";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AWAYTEAM_ID17063";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "matchdate", FieldType.DATE);
			Qfield.FieldDescription = "match date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MATCH_DATE48973";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "homegoals", FieldType.NUMERIC);
			Qfield.FieldDescription = "home goals";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "HOME_GOALS11591";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "awaygoals", FieldType.NUMERIC);
			Qfield.FieldDescription = "away goals";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "AWAY_GOALS14181";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "hometeam", FieldType.KEY_INT);
			Qfield.FieldDescription = "home team";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "HOME_TEAM21446";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("players", new String[] {"teamid"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("goals", new String[] {"matchid"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("awayteam", new Relation("PNL", "pnlmatches", "matches", "codmatches", "awayteamid", "PNL", "pnlawayteam", "awayteam", "codteam", "codteam"));
			info.ParentTables.Add("team", new Relation("PNL", "pnlmatches", "matches", "codmatches", "hometeam", "PNL", "pnlteam", "team", "codteam", "codteam"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("awayteam","awayteam");
			info.Pathways.Add("team","team");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAmatches()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="PNL";
			info.TableName="pnlmatches";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codmatches";
			info.HumanKeyName="matchid,".TrimEnd(',');
			info.Alias="matches";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="matches";
			info.AreaPluralDesignation="matches";
			info.DescriptionCav="MATCHES56954";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodmatches { get { return m_fldCodmatches; } }
		private static FieldRef m_fldCodmatches = new FieldRef("matches", "codmatches");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmatches
		{
			get { return (string)returnValueField(FldCodmatches); }
			set { insertNameValueField(FldCodmatches, value); }
		}

		/// <summary>Field : "match id" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldMatchid { get { return m_fldMatchid; } }
		private static FieldRef m_fldMatchid = new FieldRef("matches", "matchid");

		/// <summary>Field : "match id" Tipo: "N" Formula:  ""</summary>
		public decimal ValMatchid
		{
			get { return (decimal)returnValueField(FldMatchid); }
			set { insertNameValueField(FldMatchid, value); }
		}

		/// <summary>Field : "awayteam id" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldAwayteamid { get { return m_fldAwayteamid; } }
		private static FieldRef m_fldAwayteamid = new FieldRef("matches", "awayteamid");

		/// <summary>Field : "awayteam id" Tipo: "CE" Formula:  ""</summary>
		public string ValAwayteamid
		{
			get { return (string)returnValueField(FldAwayteamid); }
			set { insertNameValueField(FldAwayteamid, value); }
		}

		/// <summary>Field : "match date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldMatchdate { get { return m_fldMatchdate; } }
		private static FieldRef m_fldMatchdate = new FieldRef("matches", "matchdate");

		/// <summary>Field : "match date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValMatchdate
		{
			get { return (DateTime)returnValueField(FldMatchdate); }
			set { insertNameValueField(FldMatchdate, value); }
		}

		/// <summary>Field : "home goals" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldHomegoals { get { return m_fldHomegoals; } }
		private static FieldRef m_fldHomegoals = new FieldRef("matches", "homegoals");

		/// <summary>Field : "home goals" Tipo: "N" Formula:  ""</summary>
		public decimal ValHomegoals
		{
			get { return (decimal)returnValueField(FldHomegoals); }
			set { insertNameValueField(FldHomegoals, value); }
		}

		/// <summary>Field : "away goals" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldAwaygoals { get { return m_fldAwaygoals; } }
		private static FieldRef m_fldAwaygoals = new FieldRef("matches", "awaygoals");

		/// <summary>Field : "away goals" Tipo: "N" Formula:  ""</summary>
		public decimal ValAwaygoals
		{
			get { return (decimal)returnValueField(FldAwaygoals); }
			set { insertNameValueField(FldAwaygoals, value); }
		}

		/// <summary>Field : "home team" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldHometeam { get { return m_fldHometeam; } }
		private static FieldRef m_fldHometeam = new FieldRef("matches", "hometeam");

		/// <summary>Field : "home team" Tipo: "CE" Formula:  ""</summary>
		public string ValHometeam
		{
			get { return (string)returnValueField(FldHometeam); }
			set { insertNameValueField(FldHometeam, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("matches", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAmatches search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAmatches area = new CSGenioAmatches(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAmatches> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAmatches>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAmatches> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAmatches>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL PNL TABAUX MATCHES]/

 
        

	}
}
