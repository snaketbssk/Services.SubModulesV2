using Services.SubModules.LogicLayers.Models.Requests;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public abstract class BaseIdResponse<T> : IBaseIdRequest<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseIdResponse()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public BaseIdResponse(T id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public abstract string ToIdString();
    }
}
