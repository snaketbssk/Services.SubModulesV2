using Services.SubModules.LogicLayers.Models.Requests.Entities;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class EmailRequestMapping : Mapping<EmailRequest>
    {
        public string Email { get; set; }
        public EmailRequestMapping(string email)
        {
            Email = email;
        }
        public override EmailRequest Map()
        {
            var result = new EmailRequest
            {
                Email = Email
            };
            return result;
        }

        public override EmailRequest Update(EmailRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
