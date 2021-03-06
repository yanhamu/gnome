﻿using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class CreateExpression : IRequest<Model.Expression>
    {
        public Guid UserId { get; set; }
        public string Expression { get; set; }
        public string Name { get; set; }
    }
}
