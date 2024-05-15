using Kuzya.CLI;
using Kuzya;

public static class Program
{
    static Tree command;

    static void Main(string[] argvs)
    { Args args = Args.New(argvs);
        #region Init
        // intern name, seen only in code (better set a name that app will be published as a.k.a: cliapp -> cliapp.exe)
        command = new Tree("cliapp");
        // *cliapp* node
        command.AddSub(new Node("node")
            .SetAct((_) => { Console.WriteLine("node!"); })
            .AddSub(new Node("world")
                .SetAct((_) => { Console.WriteLine("Hello, World!"); }))
            );
        command.SetAct((args) => 
            { // better wrap in functions, not lambas
                if (args.HasFlag("help", "h"))
                { 
                    Console.WriteLine("help article"); 
                    return; 
                }
                Console.WriteLine("from test"); });
        #endregion
        #region Call
        command.Call(args);
        #endregion
    }
}