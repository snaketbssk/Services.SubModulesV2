namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public abstract class BaseIdRequest<T> : IBaseIdRequest<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseIdRequest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public BaseIdRequest(T id)
        {
            Id = id;
        }

        public abstract string ToIdString();
    }
}
