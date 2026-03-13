using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_matchesForm : Form
{
	/// <summary>
	/// match id
	/// </summary>
	public BaseInputControl MatchesMatchid => new BaseInputControl(driver, ContainerLocator, "container-F_MATCHES__MATCHES__MATCHID", "#F_MATCHES__MATCHES__MATCHID");

	/// <summary>
	/// team id
	/// </summary>
	public LookupControl AwayteamTeamid => new LookupControl(driver, ContainerLocator, "container-F_MATCHES__AWAYTEAM__TEAMID");
	public SeeMorePage AwayteamTeamidSeeMorePage => new SeeMorePage(driver, "F_MATCHES", "F_MATCHES__AWAYTEAM__TEAMID");

	/// <summary>
	/// match date
	/// </summary>
	public DateInputControl MatchesMatchdate => new DateInputControl(driver, ContainerLocator, "#F_MATCHES__MATCHES__MATCHDATE");

	/// <summary>
	/// home goals
	/// </summary>
	public BaseInputControl MatchesHomegoals => new BaseInputControl(driver, ContainerLocator, "container-F_MATCHES__MATCHES__HOMEGOALS", "#F_MATCHES__MATCHES__HOMEGOALS");

	/// <summary>
	/// away goals
	/// </summary>
	public BaseInputControl MatchesAwaygoals => new BaseInputControl(driver, ContainerLocator, "container-F_MATCHES__MATCHES__AWAYGOALS", "#F_MATCHES__MATCHES__AWAYGOALS");

	/// <summary>
	/// team id
	/// </summary>
	public LookupControl TeamTeamid => new LookupControl(driver, ContainerLocator, "container-F_MATCHES__TEAM__TEAMID");
	public SeeMorePage TeamTeamidSeeMorePage => new SeeMorePage(driver, "F_MATCHES", "F_MATCHES__TEAM__TEAMID");

	public F_matchesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_MATCHES", containerLocator: containerLocator) { }
}
