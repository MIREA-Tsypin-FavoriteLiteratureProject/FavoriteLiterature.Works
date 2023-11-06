using App.Metrics;
using App.Metrics.Counter;

namespace FavoriteLiterature.Works.Metrics;

public static partial class MetricsRegistry
{
    public static CounterOptions CreatedGenresCounter => new CounterOptions
    {
        Name = "Created genre",
        Context = "Works.Api",
        MeasurementUnit = Unit.Calls
    };
}