using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array CARD_TYPE (CARD TYPE)
	/// </summary>
	public class ArrayCard_type : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayCard_type _instance = new ArrayCard_type();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayCard_type Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// YELLOW CARD
		/// </summary>
		public const string E_YC_1 = "YC";
		/// <summary>
		/// RED CARD
		/// </summary>
		public const string E_RC_2 = "RC";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayCard_type"/> class from being created.
		/// </summary>
		private ArrayCard_type() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_YC_1, new ArrayElement() { ResourceId = "YELLOW_CARD04777", HelpId = "", Group = "" } },
				{ E_RC_2, new ArrayElement() { ResourceId = "RED_CARD10428", HelpId = "", Group = "" } },
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
