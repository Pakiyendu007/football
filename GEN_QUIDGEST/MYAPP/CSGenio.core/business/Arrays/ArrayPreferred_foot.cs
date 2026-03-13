using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array PREFERRED_FOOT (PREFERRED FOOT)
	/// </summary>
	public class ArrayPreferred_foot : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPreferred_foot _instance = new ArrayPreferred_foot();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPreferred_foot Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// LEFT
		/// </summary>
		public const string E_L_1 = "L";
		/// <summary>
		/// RIGHT
		/// </summary>
		public const string E_R_2 = "R";
		/// <summary>
		/// BOTH
		/// </summary>
		public const string E_BTH_3 = "BTH";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPreferred_foot"/> class from being created.
		/// </summary>
		private ArrayPreferred_foot() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_L_1, new ArrayElement() { ResourceId = "LEFT12364", HelpId = "", Group = "" } },
				{ E_R_2, new ArrayElement() { ResourceId = "RIGHT52242", HelpId = "", Group = "" } },
				{ E_BTH_3, new ArrayElement() { ResourceId = "BOTH48095", HelpId = "", Group = "" } },
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
