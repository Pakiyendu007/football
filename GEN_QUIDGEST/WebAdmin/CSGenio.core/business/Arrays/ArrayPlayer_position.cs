using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array PLAYER_POSITION (PLAYER POSITION)
	/// </summary>
	public class ArrayPlayer_position : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPlayer_position _instance = new ArrayPlayer_position();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPlayer_position Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// GOALKEEPER
		/// </summary>
		public const string E_GK_1 = "GK";
		/// <summary>
		/// DEFENDER
		/// </summary>
		public const string E_DEF_2 = "DEF";
		/// <summary>
		/// MIDFEILDER
		/// </summary>
		public const string E_MID_3 = "MID";
		/// <summary>
		/// FORWARD
		/// </summary>
		public const string E_FWD_4 = "FWD";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPlayer_position"/> class from being created.
		/// </summary>
		private ArrayPlayer_position() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_GK_1, new ArrayElement() { ResourceId = "GOALKEEPER42691", HelpId = "", Group = "" } },
				{ E_DEF_2, new ArrayElement() { ResourceId = "DEFENDER58833", HelpId = "", Group = "" } },
				{ E_MID_3, new ArrayElement() { ResourceId = "MIDFEILDER15633", HelpId = "", Group = "" } },
				{ E_FWD_4, new ArrayElement() { ResourceId = "FORWARD37428", HelpId = "", Group = "" } },
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
