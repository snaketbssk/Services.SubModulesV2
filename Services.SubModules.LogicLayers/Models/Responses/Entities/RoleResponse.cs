using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response model for roles.
    /// </summary>
    public class RoleResponse : BaseTable<Guid>, IRoleResponse
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleResponse"/> class.
        /// </summary>
        public RoleResponse()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleResponse"/> class with the specified id and name.
        /// </summary>
        /// <param name="id">The unique identifier for the role.</param>
        /// <param name="name">The name of the role.</param>
        public RoleResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
