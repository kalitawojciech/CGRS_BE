using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Commands.ChangeActivityStatus
{
    public class ChangeCategoryActiveStatusCommandHandler : IRequestHandler<ChangeCategoryActiveStatusCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ChangeCategoryActiveStatusCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(ChangeCategoryActiveStatusCommand request, CancellationToken cancellationToken)
        {
            Category categoryFromDb = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryFromDb == null)
            {
                throw new BadRequestException("Given game does not exist");
            }

            categoryFromDb.IsActive = !categoryFromDb.IsActive;
            await _categoryRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
