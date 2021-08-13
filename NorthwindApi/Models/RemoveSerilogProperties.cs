using Serilog.Core;
using Serilog.Events;

namespace NorthwindApi.Models
{
    class RemoveSerilogProperties : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory logEventFactory)
        {
            // https://csharp.hotexamples.com/examples/Serilog.Events/LogEvent/AddPropertyIfAbsent/php-logevent-addpropertyifabsent-method-examples.html
            // https://stackoverflow.com/questions/47176191/how-to-remove-properties-from-log-entries-in-asp-net-core
        }
    }
}
