using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            await _categoryRepository.AddAsync(new Category()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
            });

            return Unit.Value;
        }

        public async Task Validate(CreateCategoryCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Category name cannot be empty!");
            }

            if (string.IsNullOrEmpty(request.Description))
            {
                throw new BadRequestException("Category description cannot be empty!");
            }

            if ((await _categoryRepository.GetByNameAsync(request.Name)) != null)
            {
                throw new BadRequestException("Category with this name already exist!");
            }
        }
    }
}
