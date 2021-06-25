using System.Threading;
using System.Threading.Tasks;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryFromDb = await _categoryRepository.GetByIdAsync(request.Id);

            categoryFromDb.Name = request.Name;
            categoryFromDb.Description = request.Description;
            categoryFromDb.IsActive = request.IsActive;

            await _categoryRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
