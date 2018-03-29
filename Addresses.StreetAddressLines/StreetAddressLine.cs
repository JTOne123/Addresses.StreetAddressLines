// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.StreetAddressLines
{
    /// <summary>Contains street address line information</summary>
    [ProtoBufSerializable]
    [Table("StreetAddressLines", Schema = "Addresses")]
    public class StreetAddressLine : IStaticEntity<StreetAddressLine, int>
    {
        public StreetAddressLine()
        {
        }

        public StreetAddressLine(string addressLine)
        {
            AddressLine = addressLine;
        }

        /// <summary>Contains AddressLine value</summary>
        [Position(2)]
        public string AddressLine { get; set; }

        /// <summary>StreetAddressLine unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int StreetAddressLineId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 3;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => StreetAddressLineId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<StreetAddressLine, object>> GetUniqueIndex() => entity => new { entity.AddressLine };
    }
}
