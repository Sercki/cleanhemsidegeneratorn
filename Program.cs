//Det är en liten projekt så alla klasser och interface finns i en fil - program.cs. Om koden blir storre, jag skapar nya .cs filer (där en fil innehåller endast en klass eller en interface)

WebsiteGenerator HemsideGeneratorn = new WebsiteGenerator();
HemsideGeneratorn.ShowPageToUser();
interface IPage
{
	void PrintHTMLBeginning();
	void PrintWelcomeClassMessage(string className);
	void ShowCourses();
	void PrintHTMLEnding();
	void ShowPageToUser();
}
class WebsiteGenerator : IPage
{
	ReceiveTextfromApi SchoolApi = new();
	APIToCourseGenerator CoursesinClassDotNet = new();
	public void PrintHTMLBeginning()
	{
		string start = "<!DOCTYPE html>\n<html>\n<body>\n<main>\n";
		Console.WriteLine(start);
	}
	public void PrintWelcomeClassMessage(string className)
	{
		string welcome = $"<h1> Välkomna {className}! </h1>";

		string welcomeMessage = "";

		foreach (string msg in SchoolApi.ReceiveMessagesToClassFromApi())
		{
			welcomeMessage += $"\n<p><b> Meddelande: </b> {msg} </p>";
		}

		Console.WriteLine(welcome + welcomeMessage);
	}
	public void ShowCourses()
	{
		string courses = CoursesinClassDotNet.CourseGenerator(SchoolApi.ReceiveTechniquesfromAPI());
		Console.WriteLine(courses);
	}
	public void PrintHTMLEnding()
	{
		string end = "</main>\n</body>\n</html>";
		Console.WriteLine(end);
	}
	public void ShowPageToUser()
	{
		PrintHTMLBeginning();
		PrintWelcomeClassMessage("Klass A");
		ShowCourses();
		PrintHTMLEnding();
	}
}
class ReceiveTextfromApi
{
	internal string[] ReceiveTechniquesfromAPI()
	{
		string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };
		return techniques;

	}
	internal string[] ReceiveMessagesToClassFromApi()
	{
		string[] messagesToClass = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };
		return messagesToClass;
	}
}
class APIToCourseGenerator
{
    internal string CourseGenerator(string[] techniques)
	{
		string kurser = "";

		foreach (string technique in techniques)
		{
			string tmp = technique.Trim();
			kurser += "<p>" + tmp[0].ToString().ToUpper() + tmp.Substring(1).ToLower() + "</p>\n";
		}
		return kurser;
	}
}