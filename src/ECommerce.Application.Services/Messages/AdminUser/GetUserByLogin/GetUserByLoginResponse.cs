﻿using ECommerce.Domain.Dtos;
using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetUserByLoginResponse 
	{
        [DataMember]
        public UsuarioDto Usuario { get; set; }
    } 
}
