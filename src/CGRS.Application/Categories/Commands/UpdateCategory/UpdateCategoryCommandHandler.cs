using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
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

            if (categoryFromDb == null)
            {
                throw new BadRequestException("Given category do not exist!");
            }

            await Validate(request);

            categoryFromDb.Name = request.Name;
            categoryFromDb.Description = request.Description;

            await _categoryRepository.SaveChangesAsync();

            return Unit.Value;
        }

        public async Task Validate(UpdateCategoryCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Category name cannot be empty!");
            }

            if (string.IsNullOrEmpty(request.Description))
            {
                throw new BadRequestException("Category description cannot be empty!");
            }

            Category categoryWithGivenName = await _categoryRepository.GetByNameAsync(request.Name);

            if (categoryWithGivenName != null)
            {
                if (categoryWithGivenName.Id != request.Id)
                {
                    throw new BadRequestException("Category with given name already exist!");
                }
            }
        }
    }
}
