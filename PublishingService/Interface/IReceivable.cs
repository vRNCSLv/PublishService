using System;
namespace PublishingService
{
    public interface IReceivable
    {
        Object GetTempValue(IReceivable rec);
    }
}
