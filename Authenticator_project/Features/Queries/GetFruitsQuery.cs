using Authenticator_project.Core;
using MediatR;
using System.Net;

namespace Authenticator_project.Features.Queries
{
    public class GetFruitsQuery
    {
        public class Query : IRequest<APIResponse> { }
        public sealed class Handler : IRequestHandler<Query, APIResponse>
        {
            public async Task<APIResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var fruits = new List<object> 
                {
                    new { Id = 1 , Name = "Orange"},
                    new { Id = 2 , Name = "Cherry"},
                    new { Id = 3 , Name = "Kiwi"},
                    new { Id = 4 , Name = "Strawberry"},
                    new { Id = 5 , Name = "Avocado"},
                    new { Id = 6 , Name = "Papaya"},
                    new { Id = 7 , Name = "Watermelon"},
                    new { Id = 8 , Name = "Pear"}
                };

                return APIResponse.GetSuccessMessage(HttpStatusCode.Created, data: fruits, ResponseMessages.FetchData);
            }
        }

    }
}
