﻿using MediatR;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class UpdateAccount : IRequest<Account>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public UpdateAccount(int id, string name, string token)
        {
            this.Id = id;
            this.Name = name;
            this.Token = token;
        }
    }
}
