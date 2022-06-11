using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserResponseMapping : Mapping<IUserResponse>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? ConfirmedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? ConfirmedphoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public List<string> Roles { get; set; }
        public UserResponseMapping(
            string? name, 
            string? email, 
            bool? confirmedEmail, 
            string? phoneNumber, 
            bool? confirmedphoneNumber, 
            bool? twoFactorEnabled, 
            List<string> roles)
        {
            Name = name;
            Email = email;
            ConfirmedEmail = confirmedEmail;
            PhoneNumber = phoneNumber;
            ConfirmedphoneNumber = confirmedphoneNumber;
            TwoFactorEnabled = twoFactorEnabled;
            Roles = roles;
        }
        public override IUserResponse Map()
        {
            var result = new UserResponse
            {
                Name = Name,
                Email = Email,
                ConfirmedEmail = ConfirmedEmail,
                PhoneNumber = PhoneNumber,
                ConfirmedphoneNumber = ConfirmedphoneNumber,
                TwoFactorEnabled = TwoFactorEnabled,
                Roles = Roles
            };
            return result;
        }

        public override IUserResponse Update(IUserResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
