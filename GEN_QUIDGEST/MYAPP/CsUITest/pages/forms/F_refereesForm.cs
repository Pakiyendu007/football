using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_refereesForm : Form
{
	/// <summary>
	/// referee id
	/// </summary>
	public BaseInputControl RefereesRefereeid => new BaseInputControl(driver, ContainerLocator, "container-F_REFEREES__REFEREES__REFEREEID", "#F_REFEREES__REFEREES__REFEREEID");

	/// <summary>
	/// referee name
	/// </summary>
	public BaseInputControl RefereesRefereename => new BaseInputControl(driver, ContainerLocator, "container-F_REFEREES__REFEREES__REFEREENAME", "#F_REFEREES__REFEREES__REFEREENAME");

	/// <summary>
	/// age
	/// </summary>
	public BaseInputControl RefereesAge => new BaseInputControl(driver, ContainerLocator, "container-F_REFEREES__REFEREES__AGE", "#F_REFEREES__REFEREES__AGE");

	/// <summary>
	/// nationality
	/// </summary>
	public BaseInputControl RefereesNationality => new BaseInputControl(driver, ContainerLocator, "container-F_REFEREES__REFEREES__NATIONALITY", "#F_REFEREES__REFEREES__NATIONALITY");

	/// <summary>
	/// experience years
	/// </summary>
	public BaseInputControl RefereesExperienceyears => new BaseInputControl(driver, ContainerLocator, "container-F_REFEREES__REFEREES__EXPERIENCEYEARS", "#F_REFEREES__REFEREES__EXPERIENCEYEARS");

	public F_refereesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_REFEREES", containerLocator: containerLocator) { }
}
