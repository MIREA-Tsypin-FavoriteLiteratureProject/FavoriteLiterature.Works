using App.Metrics.Counter;
using Unit = App.Metrics.Unit;

namespace FavoriteLiterature.Works.Metrics;

public static partial class MetricsRegistry
{
    public static CounterOptions CreatedAuthorsCounter => new CounterOptions
    {
        Name = "Created author",
        Context = "Works.Api",
        MeasurementUnit = Unit.Calls
    };
}