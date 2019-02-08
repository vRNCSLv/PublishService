using System;

namespace PublishingService.Logic
{
    internal class ErrorModel //: IReceivable
    {
        private string message;

        public ErrorModel(string message)
        {
            this.message = message;
        }

        public Object GetTempValue(ErrorModel em)
        {
            return em.message;
        }

        //public object GetTempValue(IReceivable rec)
        //{
        //    return rec.ToString();
        //}
    }
}