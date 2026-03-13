using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_playersForm : Form
{
	/// <summary>
	/// position
	/// </summary>
	public BaseInputControl PlayersPosition => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERS__PLAYERS__POSITION", "#F_PLAYERS__PLAYERS__POSITION");

	/// <summary>
	/// player id
	/// </summary>
	public BaseInputControl PlayersPlayerid => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERS__PLAYERS__PLAYERID", "#F_PLAYERS__PLAYERS__PLAYERID");

	/// <summary>
	/// playername
	/// </summary>
	public BaseInputControl PlayersPlayername => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERS__PLAYERS__PLAYERNAME", "#F_PLAYERS__PLAYERS__PLAYERNAME");

	/// <summary>
	/// age
	/// </summary>
	public BaseInputControl PlayersAge => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERS__PLAYERS__AGE", "#F_PLAYERS__PLAYERS__AGE");

	/// <summary>
	/// match id
	/// </summary>
	public LookupControl MatchesMatchid => new LookupControl(driver, ContainerLocator, "container-F_PLAYERS__MATCHES__MATCHID");
	public SeeMorePage MatchesMatchidSeeMorePage => new SeeMorePage(driver, "F_PLAYERS", "F_PLAYERS__MATCHES__MATCHID");

	public F_playersForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PLAYERS", containerLocator: containerLocator) { }
}
