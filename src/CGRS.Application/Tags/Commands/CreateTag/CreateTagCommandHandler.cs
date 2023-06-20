using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Unit> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            await _tagRepository.AddAsync(new Tag()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsActive = true,
            });

            return Unit.Value;
        }

        private async Task Validate(CreateTagCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Tag name cannot be empty!");
            }

            if ((await _tagRepository.GetByNameAsync(request.Name)) != null)
            {
                throw new BadRequestException("Tag with this name already used!");
            }
        }
    }
}
