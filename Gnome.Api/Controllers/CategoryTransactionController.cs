﻿using Gnome.Api.Services.CategoryTransactions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class CategoryTransactionController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;
        public Guid UserId { get; set; }

        public CategoryTransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("categories/{categoryId}/transaction{transactionId}")]
        public async Task<IActionResult> AssignCategoryTransaction(Guid categoryId, Guid transactionId)
        {
            await mediator.Publish(new CreateCategoryTransaction(categoryId, transactionId));
            return new NoContentResult();
        }

        [HttpDelete("categories/{categoryId}/transaction{transactionId}")]
        public async Task<IActionResult> RemoveCategoryTransaction(Guid categoryId, Guid transactionId)
        {
            await mediator.Publish(new RemoveCategoryTransaction(categoryId, transactionId));
            return new NoContentResult();
        }
    }
}