namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class TokenRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string SecurityToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IssuerToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AudienceToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DaysExpiresToken { get; set; }
    }
}
