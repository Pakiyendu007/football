using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_teamForm : Form
{
	/// <summary>
	/// team id
	/// </summary>
	public BaseInputControl AwayteamTeamid => new BaseInputControl(driver, ContainerLocator, "container-F_TEAM__AWAYTEAM__TEAMID", "#F_TEAM__AWAYTEAM__TEAMID");

	/// <summary>
	/// team name
	/// </summary>
	public BaseInputControl AwayteamTeamname => new BaseInputControl(driver, ContainerLocator, "container-F_TEAM__AWAYTEAM__TEAMNAME", "#F_TEAM__AWAYTEAM__TEAMNAME");

	/// <summary>
	/// city
	/// </summary>
	public BaseInputControl AwayteamCity => new BaseInputControl(driver, ContainerLocator, "container-F_TEAM__AWAYTEAM__CITY", "#F_TEAM__AWAYTEAM__CITY");

	public F_teamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_TEAM", containerLocator: containerLocator) { }
}
