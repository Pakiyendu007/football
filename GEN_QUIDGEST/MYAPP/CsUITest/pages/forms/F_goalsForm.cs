using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_goalsForm : Form
{
	/// <summary>
	/// goals id
	/// </summary>
	public BaseInputControl GoalsGoalsid => new BaseInputControl(driver, ContainerLocator, "container-F_GOALS_GOALSGOALSID_", "#F_GOALS_GOALSGOALSID_");

	/// <summary>
	/// match id
	/// </summary>
	public LookupControl MatchesMatchid => new LookupControl(driver, ContainerLocator, "container-F_GOALS__MATCHES__MATCHID");
	public SeeMorePage MatchesMatchidSeeMorePage => new SeeMorePage(driver, "F_GOALS", "F_GOALS__MATCHES__MATCHID");

	/// <summary>
	/// player id
	/// </summary>
	public LookupControl PlayersPlayerid => new LookupControl(driver, ContainerLocator, "container-F_GOALS__PLAYERS__PLAYERID");
	public SeeMorePage PlayersPlayeridSeeMorePage => new SeeMorePage(driver, "F_GOALS", "F_GOALS__PLAYERS__PLAYERID");

	/// <summary>
	/// minute
	/// </summary>
	public BaseInputControl GoalsMinute => new BaseInputControl(driver, ContainerLocator, "container-F_GOALS_GOALSMINUTE__", "#F_GOALS_GOALSMINUTE__");

	public F_goalsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_GOALS", containerLocator: containerLocator) { }
}
