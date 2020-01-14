
using Serilog;
using Serilog.Formatting.Compact;

namespace loggist.Example.Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console(new CompactJsonFormatter())
                        .CreateLogger();

            // there are other ways of doing this by creating a LoggerFactory and then calling AddProvider to it
            loggist.Example.Library.Logging.LoggingConfiguration.LoggerFactory = new Microsoft.Extensions.Logging.LoggerFactory().AddSerilog();


            Log.Information("From Program.cs");

            loggist.Example.Library.Foo foo = new loggist.Example.Library.Foo();
            foo.FooBar("From Foo.cs");

            /*
             * OUTPUTS:
             * 
             * {"@t":"2020-01-14T00:47:44.9865711Z","@mt":"From Program.cs"}
             * {"@t":"2020-01-14T00:47:45.0203000Z","@mt":"Input was {input}","input":"From Foo.cs","SourceContext":"loggist.Example.Library.Foo","FunctionName":"FooBar","ClassName":"Foo","Scope":["Function Name FooBar was called from class Foo"]}
             * 
             */
        }
    }
}
