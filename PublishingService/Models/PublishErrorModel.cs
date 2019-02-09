using System;

namespace PublishingService.Logic
{
    internal class PublishErrorModel : IReceivable
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => _message = value;
        }

        public PublishErrorModel(string message)
        {
            this.Message = message;
        }

        //public Object GetTempValue(PublishErrorModel em)
        //{
        //    return em.message;
        //}

        //public object GetTempValue(IReceivable rec)
        //{
        //    return rec.ToString();
        //}
    }
}