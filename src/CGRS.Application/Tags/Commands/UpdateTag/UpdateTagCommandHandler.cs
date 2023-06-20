using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Application.Tags.Commands.EditTag;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tagFromDb = await _tagRepository.GetByIdAsync(request.Id);

            if (tagFromDb == null)
            {
                throw new BadRequestException("Tag does not exist.");
            }

            await Validate(request);

            tagFromDb.Name = request.Name;

            await _tagRepository.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task Validate(UpdateTagCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Tag name cannot be empty!");
            }

            Tag tagWithGivenName = await _tagRepository.GetByNameAsync(request.Name);

            if (tagWithGivenName != null)
            {
                if (tagWithGivenName.Id != request.Id)
                {
                    throw new BadRequestException("Tag with given name already exist!");
                }
            }
        }
    }
}
