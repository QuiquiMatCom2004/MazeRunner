using Spectre.Console;

class Menu{
    public static string DisplayMenu(){
        AnsiConsole.Write(new FigletText("Happy Hunger Games").Color(Color.Aqua).LeftJustified());
        Thread.Sleep(1000);
        AnsiConsole.Clear();
        var select =  new SelectionPrompt<string> ().Title("Game Menu").PageSize(3);
        select.AddChoiceGroup("Opcions", new string[] { "[Aqua]Jugar[/]","[Aqua]Salir[/]"});
        var Opcion = AnsiConsole.Prompt(
           select
        );
        return Opcion;
    }
}