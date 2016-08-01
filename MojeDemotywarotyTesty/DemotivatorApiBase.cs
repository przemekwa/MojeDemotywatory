using MojeDemotywatoryApi;

namespace MojeDemotywarotyTesty
{
    public abstract class DemotivatorApiBase
    {
        public virtual DemotivatorApi DemotivatorApi { get; set; } = new DemotivatorApi("http://demotywatory.pl/");
    }
}