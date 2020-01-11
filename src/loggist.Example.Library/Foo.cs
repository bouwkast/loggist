using Microsoft.Extensions.Logging;

namespace loggist.Example.Library
{
    public class Foo
    {
        private ILogger<Foo> _logger = Logging.LogProvider<Foo>.GetCurrentClassLogger();


        public void FooBar(string input)
        {
            using (_logger.BeginScope("Function Name {FunctionName} was called from class {ClassName}", nameof(FooBar), nameof(Foo)))
            {
                _logger.LogInformation("Input was {input}", input);
            }
        }
    }
}
