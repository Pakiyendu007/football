using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array MATCH_STATUS (MATCH STATUS)
	/// </summary>
	public class ArrayMatch_status : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayMatch_status _instance = new ArrayMatch_status();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayMatch_status Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// SCHEDULED
		/// </summary>
		public const string E_SCH_1 = "SCH";
		/// <summary>
		/// LIVE
		/// </summary>
		public const string E_LIV_2 = "LIV";
		/// <summary>
		/// FINISHED
		/// </summary>
		public const string E_FIN_3 = "FIN";
		/// <summary>
		/// CANCELLED
		/// </summary>
		public const string E_CAN_4 = "CAN";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayMatch_status"/> class from being created.
		/// </summary>
		private ArrayMatch_status() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_SCH_1, new ArrayElement() { ResourceId = "SCHEDULED64233", HelpId = "", Group = "" } },
				{ E_LIV_2, new ArrayElement() { ResourceId = "LIVE02541", HelpId = "", Group = "" } },
				{ E_FIN_3, new ArrayElement() { ResourceId = "FINISHED25623", HelpId = "", Group = "" } },
				{ E_CAN_4, new ArrayElement() { ResourceId = "CANCELLED08999", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
